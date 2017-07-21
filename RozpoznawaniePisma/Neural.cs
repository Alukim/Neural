using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static RozpoznawaniePisma.Network;

namespace RozpoznawaniePisma
{
    public partial class Neural : Form
    {
        private Network network = new Network();
        private const float penSize = 2;
        private Pen pen = new Pen(Color.Black, penSize);
        private Graphics graphic;
        private bool isDrawing = false;

        public Neural()
        {
            InitializeComponent();
            graphic = pictureBox.CreateGraphics();
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
                // Pobieramy z wskazanej lokalizacji, wszystkie obrazy typu "bmp"
                var files = Directory.GetFiles(folderBrowser.SelectedPath, "*.bmp");

                // Założyliśmy, że obrazy do nauczania są kwadratami
                var imageSize = Bitmap.FromFile(files[0]).Width;
                var numberOfPixels = imageSize * imageSize;

                // Inicjalizujemy warstwy naszej sieci
                network.Initialize(numberOfPixels, files.Length);

                // Pobieramy dane z obrazów i konwertujemy do tablic o typie double
                var inputs = new double[files.Length][];
                var outputs = new double[files.Length][];

                for(int i = 0; i < files.Length; ++i)
                {
                    inputs[i] = new double[numberOfPixels];

                    var image = new Bitmap(files[i]);

                    for (int x = 0; x < imageSize; ++x)
                    {
                        for (int y = 0; y < imageSize; ++y)
                        {
                            var pixel = image.GetPixel(x, y);

                            // Konwertujemy color pixela na odpowiednią wartość input-a. 0.0 - kolor biały; 1.0 - kolor czarny
                            inputs[i][x * imageSize + y] = (1.0 - (pixel.R / 255.0 + pixel.G / 255.0 + pixel.B / 255.0) / 3.0) < 0.5 ? 0.0 : 1.0;
                        }
                    }

                    outputs[i] = new double[files.Length];

                    for (int j = 0; j < files.Length; ++j)
                        outputs[i][j] = i == j ? 1.0 : 0.0;

                    var fileInfo = new FileInfo(files[i]);
                    network.OutputLayers[i].Value = fileInfo.Name.Replace(".bmp", "");
                }

                // Trenujemy sieć
                network.TrainNetwork(inputs, outputs);

                // Wyświetlmy wartości błędów w kolejnych iteracjach.
                trainingDataView.Items.Clear();

                for(int i = 0; i < network.currentIteration; ++i)
                {
                    var item = trainingDataView.Items.Add(i.ToString());
                    item.SubItems.Add(network.Errors[i].ToString("#0.000000"));
                }
            }
            catch(Exception exc)
            {
                ShowError($"Błąd przy próbie wgrania i nauczenia sieci.\nExc: {exc.Message}");
            }
        }

        private void readPicture_Click(object sender, EventArgs e)
            => fileBrowser.ShowDialog();

        private void recognizeButton_Click(object sender, EventArgs e)
        {
            // Zakładamy, że obrazy są kwadratowe

            var imageSize = pictureBox.Size.Height;

            // Pobieramy dane z obrazu i przeszktałcamy

            var sample = new double[imageSize * imageSize];

            Bitmap image;
            if (string.IsNullOrEmpty(pictureBox.ImageLocation))
            {
                image = new Bitmap(pictureBox.Width, pictureBox.Height, graphic);
            }
            else
                image = new Bitmap(pictureBox.ImageLocation);

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
            catch (Exception exc) { }

            if (selectedOutput != null)
                recognizeTextBox.Text = $"Rozpoznano: {selectedOutput.Value}";
            else
                recognizeTextBox.Text = $"Nie rozpoznano";
        }

        private void fileSelected(object sender, CancelEventArgs e)
        {
            var image = new Bitmap(fileBrowser.FileName);
            pictureBox.Image = new Bitmap(image, new Size(112, 112));
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
            graphic.DrawEllipse(pen, x, y, pen.Width, pen.Width);
        }        
    }
}
