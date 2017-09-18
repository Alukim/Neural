using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RozpoznawaniePisma.Network;

namespace RozpoznawaniePisma
{
    public partial class Neural : Form
    {
        private Network network = new Network();
        private const float penSize = 2;
        private Pen pen = new Pen(Color.White, penSize);
        private Bitmap bmp;
        private bool isDrawing = false;

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
                network.maximumIteration = changedNumber;
            else
                ShowError("Wystąpił problem przy próbie konwertowania wartości na liczbę.");
        }

        private void trainButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Pobieramy z wskazanej lokalizacji, wszystkie obrazy typu "jpg"
                var files = Directory.GetFiles(folderBrowser.SelectedPath, "*.txt");
                int numberOfPixels = 28 * 28;
                int numberOfPerceptons = numberOfPixels + 1;
                int numberOfOutputs = 10;

                network.Initialize(numberOfPerceptons, numberOfOutputs);

                var trainingData = new List<TrainingPackages>();

                var photosInFileCount = 4000;
                var openFiles = new List<StreamReader>();
                numberOfOutputs = 0;

                foreach (var file in files)
                {
                    openFiles.Add(File.OpenText(file));

                    var fileInfo = new FileInfo(files[numberOfOutputs]);
                    network.OutputLayers[numberOfOutputs].Value = fileInfo.Name.Replace(".txt", "");
                    ++numberOfOutputs;
                }

                do
                {
                    // Pobieramy dane z obrazów i konwertujemy do tablic o typie double
                    var inputs = new double[files.Length][];
                    var outputs = new double[files.Length][];

                    for (int i = 0; i < files.Length; ++i)
                    {
                        inputs[i] = new double[numberOfPerceptons];

                        var line = openFiles[i].ReadLine();
                        var seperatedLine = line.Split(' ');

                        for(int j = 0; j < numberOfPixels; ++j)
                        {
                            inputs[i][j] = double.Parse(seperatedLine[j]);
                        }

                        inputs[i][numberOfPixels] = 1;

                        outputs[i] = new double[files.Length];

                        for (int j = 0; j < files.Length; ++j)
                            outputs[i][j] = i == j ? 1.0 : 0.0;
                    }

                    trainingData.Add(new TrainingPackages(inputs, outputs));
                    --photosInFileCount;
                } while (photosInFileCount != 0);

                var task = new Task(() => Train(trainingData)).ContinueWith(x =>
                {
                    var endItem = trainingDataView.Items.Add(network.currentIteration.ToString());
                    endItem.SubItems.Add(network.Errors[network.currentIteration - 1].ToString("#0.000000"));
                    ShowError("DONE");
                });

                task.Wait();
            }
            catch(Exception exc)
            {
                ShowError($"Błąd przy próbie wgrania i nauczenia sieci.\nExc: {exc.Message}");
            }
        }

        private void Train(List<TrainingPackages> trainingData)
        {
            for (int i = 0; i < network.maximumIteration; i++)
            {
                iterationsNumber.Text = i.ToString();

                network.CurrentError = 0;
                network.currentIteration = 0;

                foreach (var data in trainingData)
                {
                    // Trenujemy sieć
                    network.TrainNetwork(data.inputs, data.outputs, trainingDataView);

                    //if (network.currentIteration % 100 == 0 || network.currentIteration == 0)
                    //{
                    //    var item = trainingDataView.Items.Add(network.currentIteration.ToString());
                    //    item.SubItems.Add(network.Errors[network.currentIteration == 0 ? 0 : network.currentIteration - 1].ToString("#0.000000"));
                    //    trainingDataView.Refresh();
                    //}
                }
            }
        }

        private Task<List<TrainingData>> GenerateTrainingData(string filePath)
        {
            var image = new Bitmap(filePath);
            var trainingDataList = new List<TrainingData>();
            var fileInfo = new FileInfo(filePath);
            var value = int.Parse(fileInfo.Name.Replace(".jpg", ""));

            const int imageSideSize = 28;

            var columnsCount = (image.Width / imageSideSize) - 1;
            var rawsCount = image.Height / imageSideSize;

            for(var i = 0; i < rawsCount; ++i)
            {
                for (var j = 0; j < columnsCount; ++j)
                {
                    var trainingData = new TrainingData(value);

                    for (var x = 0; x < imageSideSize; ++x)
                    {
                        for (var y = 0; y < imageSideSize; ++y)
                        {
                            var pixel = image.GetPixel((j * imageSideSize) + x, (i * imageSideSize) + y);

                            // Konwertujemy color pixela na odpowiednią wartość input-a. 0.0 - kolor biały; 1.0 - kolor czarny
                            trainingData.Data.Add((1.0 - (pixel.R / 255.0 + pixel.G / 255.0 + pixel.B / 255.0) / 3.0) < 0.5 ? 0.0 : 1.0);
                        }
                    }

                    trainingDataList.Add(trainingData);
                }
            }

            return Task.FromResult(trainingDataList);
        }

        private void readPicture_Click(object sender, EventArgs e)
            => fileBrowser.ShowDialog();

        private void recognizeButton_Click(object sender, EventArgs e)
        {
            // Zakładamy, że obrazy są kwadratowe

            var imageSize = pictureBox.Size.Height;

            // Pobieramy dane z obrazu i przeszktałcamy

            var sample = new double[imageSize * imageSize];

            Bitmap image = (Bitmap)pictureBox.Image;

            for (int x = 0; x < imageSize; ++x)
            {
                for (int y = 0; y < imageSize; ++y)
                {
                    var pixel = image.GetPixel(x, y);

                    // Konwertujemy color pixela na odpowiednią wartość input-a. 0.0 - kolor biały; 1.0 - kolor czarny
                    sample[x * imageSize + y] = (1.0 - (pixel.R / 255.0 + pixel.G / 255.0 + pixel.B / 255.0) / 3.0) < 0.5 ? 0.0 : 1.0;
                }
            }

            network.Recognize(sample);

            // Wyświetlamy wartości wyjściowe

            recogonizeDataView.Items.Clear();

            foreach(var output in network.OutputLayers)
            {
                var item = recogonizeDataView.Items.Add(output.Value);
                item.SubItems.Add(output.Output.ToString("#0.000000"));
            }

            var maxValue = network.OutputLayers.Max(x => x.Output);
            OutputLayer? selectedOutput = null;

            try
            {
                selectedOutput = network.OutputLayers.Single(x => x.Output == maxValue);
            }
            catch (Exception exc) { ShowError(exc.Message); }

            if (selectedOutput != null)
                recognizeTextBox.Text = $"Rozpoznano: {selectedOutput.Value.Value}";
            else
                recognizeTextBox.Text = $"Nie rozpoznano";
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

    internal class TrainingData
    {
        public int Value { get; }
        public List<double> Data { get; set; }

        public TrainingData(int value)
        {
            Value = value;
            Data = new List<double>();
        }
    }

    internal class TrainingPackages
    {
        public double[][] inputs;
        public double[][] outputs;

        public TrainingPackages(double[][] inputs, double[][] outputs)
        {
            this.inputs = inputs;
            this.outputs = outputs;
        }
    }
}
