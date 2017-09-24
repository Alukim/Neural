using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralLibrary.Datas.Network;
using NeuralLibrary.Datas.Training;
using NeuralLibrary.Events;
using Newtonsoft.Json;

namespace DigitRecognize.Files
{
    public class FilesProvider
    {
        public async Task<List<TrainingData>> PrepareDataFromFile(string fileName, int maximumNumberOfPhotos)
        {
            var trainingDatas = new List<TrainingData>();

            var fileInfo = new FileInfo(fileName);
            var value = fileInfo.Name.Replace(".txt", "");

            using (var streamReader = new StreamReader(fileName))
            {
                for(int i = 0; i < maximumNumberOfPhotos; ++i)
                {
                    if (streamReader.Peek() < 0)
                        break;

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

        public int GetNumbeOfPhotosFromFile(string fileName)
            => File.ReadAllLines(fileName).Count();

        public void SaveProgressToFile(int iterations, double learnignRate, double beta, int numberOfPhotos, ICollection<EpochEndedEventArgs> TrainProgressEvents)
        {
            var fileName = $"{Application.StartupPath}/Progresses/{BuildFileName(iterations, learnignRate, beta, numberOfPhotos)}.csv";

            var csvProvider = new CsvProvider<EpochEndedEventArgs>(TrainProgressEvents.ToList());
            csvProvider.ExportToFile(fileName);
        }

        private string BuildFileName(int iterations, double learnignRate, double beta, int numberOfPhotos)
            => $"{numberOfPhotos}_{iterations.ToString()}_{learnignRate.ToString().Replace('.', ',')}_{beta.ToString().Replace('.', ',')}_{DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss")}";

        public void SaveNetwork(NetworkState state)
        {
            var json = JsonConvert.SerializeObject(state);
            File.WriteAllText($"{Application.StartupPath}/SavedNetwork/Network.json", json);
        }

        public NetworkState GetNetwork()
        {
            var json = File.ReadAllText($"{Application.StartupPath}/SavedNetwork/Network.json");
            return JsonConvert.DeserializeObject<NetworkState>(json);
        }
    }
}
