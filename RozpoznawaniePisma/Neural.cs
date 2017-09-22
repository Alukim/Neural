using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitRecognize.Extensions;
using DigitRecognize.Files;
using NeuralLibrary;
using NeuralLibrary.Datas.Training;
using NeuralLibrary.Events;

namespace RozpoznawaniePisma
{
    public partial class Neural : Form
    {
        #region Network
        #region Properties

        private double Beta { get; }
        private double LearningRate { get; }
        private int MaximumIterations { get; }

        private const int NUMBER_OF_INPUTS = (IMAGE_SIZE * IMAGE_SIZE) + 1;
        private const int NUMBER_OF_OUTPUTS = 10;
        private const int NUMBER_OF_HIDDENS = (NUMBER_OF_INPUTS / 2) + 1;

        private Network network;

        private ICollection<TrainProgressEventArgs> TrainProgressEvents = new List<TrainProgressEventArgs>();

        #endregion

        private void InitialNetwork()
        {
            this.network = new Network(NUMBER_OF_INPUTS, NUMBER_OF_HIDDENS, NUMBER_OF_OUTPUTS, Beta, LearningRate);
            this.network.OnUpdateStatus += new Network.TrainProgressUpdateHandler(UpdateTrainView);
            this.network.OnUpdateStatus += new Network.TrainProgressUpdateHandler(SaveTrainProgressEvent);
            this.network.OnUpdatePackageStatus += new Network.PackageStatusUpdateHandler(UpdatePackageStatus);
        }

        private void SaveTrainProgressEvent(object sender, TrainProgressEventArgs e)
            => TrainProgressEvents.Add(e);

        #endregion

        #region TrainView

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
            var item = trainingDataView.Items.Add(e.TrainProgress.Iteration.ToString());
            item.SubItems.Add(e.TrainProgress.Error.ToString("#0.000000"));
            item.SubItems.Add(e.TrainProgress.Effectiveness.ToString("#0.000000"));
        }

        private void UpdatePackageStatus(object sender, PackageStatusEventArgs e)
        {
            PhotoCount.Text = e.PhotoNumber.ToString();
        }

        private async void trainButton_Click(object sender, EventArgs e)
        {
            try
            {
                var files = Directory.GetFiles(folderBrowser.SelectedPath, "*.txt");
                var trainingData = new List<TrainingData>();

                InitialNetwork();

                foreach(var file in files)
                {
                    trainingData.AddRange(await filesProvider.PrepareDataFromFile(file));
                }

                trainingData.Shuffle();
                network.TrainNetwork(new TrainingPackage(MaximumIterations, trainingData));

                MessageExtensions.ShowInfo("Training of network ended");

                await Task.Run(() => filesProvider.SaveProgressToFile(TrainProgressEvents))
                    .ContinueWith((x) => MessageExtensions.ShowInfo("Progress saved to file"));
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

        private void recognizeButton_Click(object sender, EventArgs e)
        {
            //// Zakładamy, że obrazy są kwadratowe

            //var imageSize = pictureBox.Size.Height;

            //// Pobieramy dane z obrazu i przeszktałcamy

            //var sample = new double[IMAGE_SIZE * IMAGE_SIZE];

            //Bitmap image = (Bitmap)pictureBox.Image;
            //var size = new Size(IMAGE_SIZE, IMAGE_SIZE);
            //var resizedImage = new Bitmap(image, size);

            //for (int x = 0; x < IMAGE_SIZE; ++x)
            //{
            //    for (int y = 0; y < IMAGE_SIZE; ++y)
            //    {
            //        var pixel = resizedImage.GetPixel(x, y);

            //        // Konwertujemy color pixela na odpowiednią wartość input-a. 0.0 - kolor biały; 1.0 - kolor czarny
            //        sample[x * IMAGE_SIZE + y] = (1.0 - (pixel.R / 255.0 + pixel.G / 255.0 + pixel.B / 255.0) / 3.0) < 0.5 ? 0.0 : 1.0;
            //    }
            //}

            //network.Recognize(sample);

            //// Wyświetlamy wartości wyjściowe

            //recogonizeDataView.Items.Clear();

            //foreach(var output in network.OutputLayers)
            //{
            //    var item = recogonizeDataView.Items.Add(output.Value);
            //    item.SubItems.Add(output.Output.ToString("#0.000000"));
            //}

            //var maxValue = network.OutputLayers.Max(x => x.Output);
            //OutputLayer? selectedOutput = null;

            //try
            //{
            //    selectedOutput = network.OutputLayers.Single(x => x.Output == maxValue);
            //}
            //catch (Exception exc) { ShowError(exc.Message); }

            //if (selectedOutput != null)
            //    recognizeTextBox.Text = $"Rozpoznano: {selectedOutput.Value.Value}";
            //else
            //    recognizeTextBox.Text = $"Nie rozpoznano";
        }

        #endregion
    }
}