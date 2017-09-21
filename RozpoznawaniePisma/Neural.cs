using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitRecognize.Extensions;
using NeuralLibrary;
using NeuralLibrary.Datas.Training;
using NeuralLibrary.Events;

namespace RozpoznawaniePisma
{
    public partial class Neural : Form
    {
        private Network network;
        private const float penSize = 5;
        private Pen pen = new Pen(Color.White, penSize);
        private Bitmap bmp;
        private bool isDrawing = false;

        private int maximumIteration = 1;

        const int IMAGE_SIZE = 28;

        private double beta = 1.0;
        private double learningRate = 0.1;

        private const int NUMBER_OF_INPUTS = (IMAGE_SIZE * IMAGE_SIZE) + 1;
        private const int NUMBER_OF_OUTPUTS = 10;
        private const int NUMBER_OF_HIDDENS = (NUMBER_OF_INPUTS / 2) + 1;

        public Neural()
        {
            InitializeComponent();
            InitializeBitmap();
        }

        private void InitializeBitmap()
        {
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Black);
            }
            pictureBox.Image = bmp;
        }

        private void ShowError(string message)
            => MessageBox.Show($"{message}\nSpróbuj jeszcze raz.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void selectPathButton_Click(object sender, EventArgs e)
        {
            folderBrowser.ShowDialog();
            pathLabel.Text = $"Ścieżka: {folderBrowser.SelectedPath}";
            trainButton.Enabled = true;
        }

        private void numberOfIteration_Changed(object sender, EventArgs e)
        {
            if (int.TryParse(numberOfIterationTextBox.Text, out int changedNumber))
                this.maximumIteration = changedNumber;
            else
                ShowError("Wystąpił problem przy próbie konwertowania wartości na liczbę.");
        }

        private void UpdateStatus(object sender, TrainProgressEventArgs e)
        {
            var item = trainingDataView.Items.Add(e.TrainProgress.Iteration.ToString());
            item.SubItems.Add(e.TrainProgress.Error.ToString("#0.000000"));
            item.SubItems.Add(e.TrainProgress.Effectiveness.ToString("#0.000000"));
        }

        private void UpdatePackageStatus(object sender, PackageStatusEventArgs e)
        {
            iterationsNumber.Text = e.PhotoNumber.ToString();
        }

        private async void trainButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Pobieramy z wskazanej lokalizacji, wszystkie obrazy typu "jpg"
                var files = Directory.GetFiles(folderBrowser.SelectedPath, "*.txt");

                this.network = new Network(NUMBER_OF_INPUTS, NUMBER_OF_HIDDENS, NUMBER_OF_OUTPUTS, beta, learningRate);
                this.network.OnUpdateStatus += new Network.StatusUpdateHandler(UpdateStatus);
                this.network.OnUpdatePackageStatus += new Network.PackageStatusUpdateHandler(UpdatePackageStatus);

                var trainingDataFromFile = new List<List<TrainingData>>();
                var trainingData = new List<TrainingData>();

                foreach(var file in files)
                {
                    trainingDataFromFile.Add(await PrepareDataFromFile(file));
                }
                
                foreach(var data in trainingDataFromFile)
                {
                    trainingData.AddRange(data);
                }

                trainingData.Shuffle();
                network.TrainNetwork(new TrainingPackage(maximumIteration, trainingData));

                ShowError("DONE. KONIEC NAUCZANIA");
            }
            catch(Exception exc)
            {
                ShowError($"Błąd przy próbie wgrania i nauczenia sieci.\nExc: {exc.Message}");
            }
        }

        private async Task<List<TrainingData>> PrepareDataFromFile(string fileName)
        {
            var trainingDatas = new List<TrainingData>();

            var fileInfo = new FileInfo(fileName);
            var value = fileInfo.Name.Replace(".txt", "");

            using (var streamReader = new StreamReader(fileName))
            {
                //while(streamReader.Peek() >= 0)
                //{
                for(int i = 0; i < 500; ++i)
                { 
                    var inputsList = new List<double>();
                    var line = await streamReader.ReadLineAsync();
                    var seperatedLine = line.Split(' ');
                    var inputs = seperatedLine.Take(seperatedLine.Count() - 1);

                    foreach(var input in inputs)
                    {
                        var convertedInput = double.Parse(input);
                        inputsList.Add(convertedInput);
                    }

                    trainingDatas.Add(new TrainingData(value, inputsList));
                }
            }

            return trainingDatas;
        }

        private void readPicture_Click(object sender, EventArgs e)
            => fileBrowser.ShowDialog();

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

        private void fileSelected(object sender, CancelEventArgs e)
        {
            var image = new Bitmap(fileBrowser.FileName);
            pictureBox.Image = new Bitmap(image, new Size(112, 112));
            pictureBox.ImageLocation = fileBrowser.FileName;
            recognizeButton.Enabled = true;
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
    }
}
