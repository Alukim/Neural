using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralLibrary.Datas.Training;
using NeuralLibrary.Events;

namespace DigitRecognize.Files
{
    public class FilesProvider
    {
        public async Task<List<TrainingData>> PrepareDataFromFile(string fileName)
        {
            var trainingDatas = new List<TrainingData>();

            var fileInfo = new FileInfo(fileName);
            var value = fileInfo.Name.Replace(".txt", "");

            using (var streamReader = new StreamReader(fileName))
            {
                //while (streamReader.Peek() >= 0)
                for(int i = 0; i < 100; ++i)
                {
                    var inputsList = new List<double>();
                    var line = await streamReader.ReadLineAsync();
                    var seperatedLine = line.Split(' ');
                    var inputs = seperatedLine.Take(seperatedLine.Count() - 1);

                    foreach (var input in inputs)
                    {
                        var convertedInput = double.Parse(input);
                        inputsList.Add(convertedInput);
                    }

                    trainingDatas.Add(new TrainingData(value, inputsList));
                }
            }

            return trainingDatas;
        }

        public async Task SaveProgressToFile(int iterations, double learnignRate, double beta, ICollection<TrainProgressEventArgs> TrainProgressEvents)
        {
            var fileName = $"{Application.StartupPath}/Progresses/{BuildFileName(iterations, learnignRate, beta)}.csv";
            File.Create(fileName).Close();

            var csvProvider = new CsvProvider<TrainProgressEventArgs>(TrainProgressEvents.ToList());
            csvProvider.ExportToFile(fileName);
        }

        private string BuildFileName(int iterations, double learnignRate, double beta)
            => $"{iterations.ToString()}_{learnignRate.ToString().Replace('.', ',')}_{beta.ToString().Replace('.', ',')}_{DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss")}";
    }
}
