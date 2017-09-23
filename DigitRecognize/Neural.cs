using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitRecognize.Extensions;
using DigitRecognize.Files;
using NeuralLibrary;
using NeuralLibrary.Datas.Training;
using NeuralLibrary.Events;
using NeuralLibrary.Recognize;

namespace RozpoznawaniePisma
{
    public partial class Neural : Form
    {
        #region Network
        #region Properties

        private double Beta { get; } = 1;
        private double LearningRate { get; } = 0.15;
        private int MaximumIterations => iterationTrackBar.Value;

        private const int NUMBER_OF_INPUTS = (IMAGE_SIZE * IMAGE_SIZE) + 1;
        private const int NUMBER_OF_OUTPUTS = 10;
        private const int NUMBER_OF_HIDDENS = (NUMBER_OF_INPUTS / 2) + 1;

        private Network network;

        private ICollection<TrainProgressEventArgs> TrainProgressEvents = new List<TrainProgressEventArgs>();

        private bool IsTrained = false;
        #endregion

        private void InitialNetwork()
        {
            this.network = new Network(NUMBER_OF_INPUTS, NUMBER_OF_HIDDENS, NUMBER_OF_OUTPUTS, MaximumIterations, Beta, LearningRate);
            network.OnUpdateStatus += new Network.TrainProgressUpdateHandler(UpdateTrainView);
            network.OnUpdateStatus += new Network.TrainProgressUpdateHandler(SaveTrainProgressEvent);
            network.OnUpdatePackageStatus += new Network.PackageStatusUpdateHandler(UpdatePackageStatus);
            network.OnTrainingEnded += new Network.TrainingEndedHandler(TrainingEnded);
            network.OnRecognizeEnded += new Network.RecognizeEndedHandler(RecognizeEnded);
            network.OnRecognizeStatusUpdated += new Network.RecognizeStatusUpdatedHanler(RecognizeUpdated);
        }

        private void SaveTrainProgressEvent(object sender, TrainProgressEventArgs e)
            => TrainProgressEvents.Add(e);

        #endregion

        #region TrainView

        private int maximumNumberOfPhotos = 1000;
        public const int IMAGE_SIZE = 28;
        private FilesProvider filesProvider { get; }

        public Neural()
        {
            InitializeComponent();
            InitializeBitmap();
            filesProvider = new FilesProvider();
        }

        private void selectPathButton_Click(object sender, EventArgs e)
        {
            folderBrowser.ShowDialog();
            pathLabel.Text = $"Path: {folderBrowser.SelectedPath}";
            trainButton.Enabled = true;
        }

        private void UpdateTrainView(object sender, TrainProgressEventArgs e)
        {
            if (this.trainingDataView.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    var item = trainingDataView.Items.Add(e.Epoch.ToString());
                    item.SubItems.Add(e.Error.ToString("#0.000000"));
                    item.SubItems.Add($"{e.Effectiveness.ToString("#0.00")} %");
                }));
            }
            else
            {
                var item = trainingDataView.Items.Add(e.Epoch.ToString());
                item.SubItems.Add(e.Error.ToString("#0.000000"));
                item.SubItems.Add($"{e.Effectiveness.ToString("#0.00")} %");
            }
        }

        private void UpdatePackageStatus(object sender, PackageStatusEventArgs e)
        {
            if(this.PhotoCount.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate () { PhotoCount.Text = e.PhotoNumber.ToString(); }));
            else
                PhotoCount.Text = e.PhotoNumber.ToString();
        }

        private void TrainingEnded(object sender, TrainingEndedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate () {
                MessageExtensions.ShowInfo("Training of network ended");
                trainButton.Enabled = true;
            }));

            IsTrained = true;

            Task.Run(() => filesProvider.SaveProgressToFile(MaximumIterations, LearningRate, Beta, maximumNumberOfPhotos, TrainProgressEvents));
        }

        private void UpdateProgressBar(object sender, TrainProgressEventArgs e)
        {
            
        }

        private async void trainButton_Click(object sender, EventArgs e)
        {
            trainButton.Enabled = false;
            try
            {
                var files = Directory.GetFiles(folderBrowser.SelectedPath, "*.txt");
                var trainingData = new List<TrainingData>();
                var recognizeData = new List<TrainingData>();

                var numberOfPhotosInFile = filesProvider.GetNumbeOfPhotosFromFile(files[0]);

                if (maximumNumberOfPhotos > numberOfPhotosInFile)
                    maximumNumberOfPhotos = numberOfPhotosInFile;

                InitialNetwork();

                foreach (var file in files)
                    trainingData.AddRange(await filesProvider.PrepareDataFromFile(file, maximumNumberOfPhotos));

                trainingData.Shuffle();

                await Task.Run(() => network.TrainNetwork(new TrainingPackage(trainingData, trainingData)));
            }
            catch(Exception exc)
            {
                MessageExtensions.ShowError($"Error in preparing and training network\nExc: {exc.Message}");
            }
        }

        private void readPicture_Click(object sender, EventArgs e)
            => fileBrowser.ShowDialog();

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
        }

        #endregion

        #region Recognize partial

        #region Variables

        private const float penSize = 5;
        private Pen pen = new Pen(Color.White, penSize);
        private Bitmap bmp;
        private bool isDrawing = false;

        #endregion

        #region Events

        private void DrawPoint(int x, int y)
        {
            using (Graphics graphic = Graphics.FromImage(pictureBox.Image))
            {
                graphic.DrawEllipse(pen, x, y, pen.Width, pen.Width);
            }
            pictureBox.Invalidate();

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            InitializeBitmap();
            pictureBox.Refresh();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            DrawPoint(e.X, e.Y);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
                DrawPoint(e.X, e.Y);
        }

        private void fileSelected(object sender, CancelEventArgs e)
        {
            var image = new Bitmap(fileBrowser.FileName);
            pictureBox.Image = new Bitmap(image, new Size(28, 28));
            pictureBox.ImageLocation = fileBrowser.FileName;
            recognizeButton.Enabled = true;
        }

        #endregion

        private void InitializeBitmap()
        {
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);
            }
            pictureBox.Image = bmp;
        }

        private void RecognizeEnded(object sender, RecognizeEndedEventArgs e)
        {
            foreach(var outputs in e.OutputInfo.Outputs)
            {
                var item = recogonizeDataView.Items.Add(outputs.Value);
                item.SubItems.Add(outputs.Output.ToString("#0.000000"));
            }

            recognizeTextBox.Text = $"Founded: {e.OutputInfo.MaximumOutput.Value}";

            MessageExtensions.ShowInfo($"Recognize ended");
        }

        private void RecognizeUpdated(object sender, RecognizeStatusUpdatedEventArgs e)
        {
            recognizeProgressBar.PerformStep();
        }

        private void recognizeButton_Click(object sender, EventArgs e)
        {
            if(!IsTrained)
            {
                MessageExtensions.ShowError("First, train your network");
                return;
            }

            // Get data from picture and convert to bit array

            var sample = new double[IMAGE_SIZE * IMAGE_SIZE];

            var size = new Size(IMAGE_SIZE, IMAGE_SIZE);
            var resizedImage = new Bitmap(pictureBox.Image, size);

            for (int x = 0; x < IMAGE_SIZE; ++x)
            {
                for (int y = 0; y < IMAGE_SIZE; ++y)
                {
                    var pixel = resizedImage.GetPixel(x, y);

                    // Convert color to pixel
                    sample[x * IMAGE_SIZE + y] = (1.0 - (pixel.R / 255.0 + pixel.G / 255.0 + pixel.B / 255.0) / 3.0) < 0.5 ? 0.0 : 1.0;
                }
            }
            network.Recognize(new RecognizeDigit(sample));
        }

        #endregion

        private void Neural_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory($"{Application.StartupPath}/Progresses");

            if (File.Exists($"{Application.StartupPath}/SavedNetwork/Network.txt"))
                UploadSavedNetwork();
        }

        private void UploadSavedNetwork()
        {

        }
    }
}