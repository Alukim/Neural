using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
                while (streamReader.Peek() >= 0)
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

        public async Task SaveProgressToFile(ICollection<TrainProgressEventArgs> TrainProgressEvents)
        {

        }
    }
}
