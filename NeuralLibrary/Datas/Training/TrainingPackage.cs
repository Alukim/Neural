using System.Collections.Generic;

namespace NeuralLibrary.Datas.Training
{
    public class TrainingPackage
    {
        public int MaximumIterations { get; private set; }

        public List<TrainingData> Datas { get; private set; }

        public TrainingPackage(int maximumIterations, List<TrainingData> datas)
        {
            MaximumIterations = maximumIterations;
            Datas = datas;
        }
    }
}
