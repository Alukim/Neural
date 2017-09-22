using System.Collections.Generic;
using NeuralLibrary.Recognize;

namespace NeuralLibrary.Datas.Training
{
    public class TrainingPackage
    {
        public List<TrainingData> RecognizeTrainigData { get; private set; }

        public List<TrainingData> TrainingDatas { get; private set; }

        public TrainingPackage(List<TrainingData> trainingDatas, List<TrainingData> recognizeTrainigData)
        {
            TrainingDatas = trainingDatas;
            RecognizeTrainigData = recognizeTrainigData;
        }
    }
}
