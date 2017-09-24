using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitRecognize.Extensions;
using DigitRecognize.Files;
using DigitRecognize.Primitives;
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
        const int betaPrecision = 10;
        const int learningRatePrecision = 100;

        private double Beta => ((double)betaRatioTrackBar.Value / betaPrecision);
        private double LearningRate => ((double)learningRateRatioTrackBar.Value / learningRatePrecision);

        private int MaximumIterations => iterationTrackBar.Value;

        private const int NUMBER_OF_INPUTS = (IMAGE_SIZE * IMAGE_SIZE) + 1;
        private const int NUMBER_OF_OUTPUTS = 10;
        private const int NUMBER_OF_HIDDENS = (NUMBER_OF_INPUTS / 2) + 1;

        private Network network;

        private ICollection<EpochEndedEventArgs> TrainProgressEvents = new List<EpochEndedEventArgs>();

        private List<string> Outputs
        {
            get
            {
                return new List<string>
                {
                    "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                };
            }
        }

        private bool IsTrained = false;
        #endregion

        private void InitialNetwork()
        {
            this.network = new Network(NUMBER_OF_INPUTS, NUMBER_OF_HIDDENS, NUMBER_OF_OUTPUTS, MaximumIterations, Beta, LearningRate, Outputs);
            network.OnEpochEnded += new Network.EpochEndedHandler(UpdateTrainView);
            network.OnEpochEnded += new Network.EpochEndedHandler(SaveTrainProgressEvent);
            network.OnUpdatePackageStatus += new Network.PackageStatusUpdateHandler(UpdatePackageStatus);
            network.OnUpdatePackageStatus += new Network.PackageStatusUpdateHandler(UpdateProgressBar);
            network.OnTrainingEnded += new Network.TrainingEndedHandler(TrainingEnded);
            network.OnRecognizeEnded += new Network.RecognizeEndedHandler(RecognizeEnded);
            network.OnRecognizeStatusUpdated += new Network.RecognizeStatusUpdatedHanler(RecognizeUpdated);
        }

        private void UploadSavedNetwork()
        {
            var savedNetwork = filesProvider.GetNetwork();
            this.network = new Network(savedNetwork);
            IsTrained = true;
            ChangeState(TrainingState.NeuralStateImport);
        }

        private void SaveTrainProgressEvent(object sender, EpochEndedEventArgs e)
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

        private void UpdateTrainView(object sender, EpochEndedEventArgs e)
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
            if (this.PhotoCount.InvokeRequired)
                this.Invoke(new MethodInvoker(delegate () { PhotoCount.Text = e.PhotoNumber.ToString(); }));
            else
                PhotoCount.Text = e.PhotoNumber.ToString();
        }

        private void TrainingEnded(object sender, TrainingEndedEventArgs e)
        {
            var maximumIt = 0;
            var lr = 0.0;
            var beta = 0.0;
            this.Invoke(new MethodInvoker(delegate () {
                ChangeState(TrainingState.EndTraining);
                ChangeEnabledTrainingForm(true);
                maximumIt = MaximumIterations;
                lr = LearningRate;
                beta = Beta;
            }));

            IsTrained = true;

            Task.Run(() => filesProvider.SaveProgressToFile(maximumIt, lr, beta, maximumNumberOfPhotos, TrainProgressEvents));
        }

        private void UpdateProgressBar(object sender, PackageStatusEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate ()
            {
                trainingProgressBar.PerformStep();
                var trainedPhoto = (e.Epoch - 1) * maximumNumberOfPhotos * 20; 
                progressPercantegeLabel.Text = $"{(((trainedPhoto + e.PhotoNumber) * 5) / (maximumNumberOfPhotos * MaximumIterations)).ToString()}%";
            }));
        }

        private async void trainButton_Click(object sender, EventArgs e)
        {
            ChangeState(TrainingState.Waiting);
            ChangeEnabledTrainingForm(false);
            try
            {
                var files = Directory.GetFiles(folderBrowser.SelectedPath, "*.txt");
                var trainingData = new List<TrainingData>();
                var recognizeData = new List<TrainingData>();

                var numberOfPhotosInFile = filesProvider.GetNumbeOfPhotosFromFile(files[0]);

                if (maximumNumberOfPhotos > numberOfPhotosInFile)
                    maximumNumberOfPhotos = numberOfPhotosInFile;

                SetTrainingProgress();

                InitialNetwork();

                ChangeState(TrainingState.FilesImport);
                var tasks = new Task[]
                {
                    Task.Run(async () => trainingData = await GetData(files)),
                    Task.Run(async () => recognizeData = await GetData(files))
                };
                Task.WaitAll(tasks);

                ChangeState(TrainingState.ShuffleDatas);
                trainingData.Shuffle();

                ChangeState(TrainingState.StartTraining);
                await Task.Run(() => network.TrainNetwork(new TrainingPackage(trainingData, recognizeData)));
            }
            catch (Exception exc)
            {
                MessageExtensions.ShowError($"Error in preparing and training network\nExc: {exc.Message}");
            }
        }

        private void ChangeEnabledTrainingForm(bool value)
        {
            trainButton.Enabled = value;
            selectPathButton.Enabled = value;
            iterationTrackBar.Enabled = value;
            betaRatioTrackBar.Enabled = value;
            learningRateRatioTrackBar.Enabled = value;
            maximumPhotosNumeric.Enabled = value;
        }

        private void SetTrainingProgress()
        {
            progressPercantegeLabel.Text = "0%";
            trainingProgressBar.Value = 0;
            trainingProgressBar.Maximum = MaximumIterations * maximumNumberOfPhotos * 20;
            trainingProgressBar.Step = 1;
        }

        private void ClearTrainingView()
            => trainingDataView.Clear();

        private void ChangeState(TrainingState state)
        {
            trainingStateLabel.Text = state.ToString();
        }

        private async Task<List<TrainingData>> GetData(string[] files)
        {
            var trainingData = new List<TrainingData>();
            foreach (var file in files)
                trainingData.AddRange(await filesProvider.PrepareDataFromFile(file, maximumNumberOfPhotos));
            return trainingData;
        }

        private void readPicture_Click(object sender, EventArgs e)
            => fileBrowser.ShowDialog();

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
            foreach (var outputs in e.OutputInfo.Outputs)
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
            if (!IsTrained)
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
            Directory.CreateDirectory($"{Application.StartupPath}/SavedNetwork");

            if (File.Exists($"{Application.StartupPath}/SavedNetwork/Network.json"))
                UploadSavedNetwork();
            else
                ChangeState(TrainingState.Waiting);
        }

        private void iterationTrackBar_Scroll(object sender, EventArgs e)
        {
            setToolTipValue(iterationTrackBar);
        }

        private void setToolTipValue(TrackBar trackBar)
        {
            trackBarToolTip.SetToolTip(trackBar, trackBar.Value.ToString());
        }

        private void setToolTipFloatValue(TrackBar trackBar, int precision)
        {
            var value = (double)trackBar.Value / precision;
            trackBarToolTip.SetToolTip(trackBar, value.ToString());
        }

        private void betaRatioTrackBar_Scroll(object sender, EventArgs e)
        {
            setToolTipFloatValue(betaRatioTrackBar, 10);
        }

        private void learningRateRatioTrackBar_Scroll(object sender, EventArgs e)
        {
            setToolTipFloatValue(learningRateRatioTrackBar, 100);
        }

        private void maximumPhotosNumeric_ValueChanged(object sender, EventArgs e)
            => maximumNumberOfPhotos = int.Parse(maximumPhotosNumeric.Value.ToString());

        private void Neural_Closed(object sender, FormClosedEventArgs e)
        {
            if (this.network != null)
                filesProvider.SaveNetwork(network.GetNetworkState());
        }
    }
}