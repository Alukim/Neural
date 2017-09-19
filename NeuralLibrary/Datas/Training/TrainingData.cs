using System.Collections.Generic;

namespace NeuralLibrary.Datas.Training
{
    public class TrainingData
    {
        public TrainingData(string value, List<double> inputs)
        {
            Value = value;
            Inputs = inputs;
        }

        public string Value { get; set; }

        public List<double> Inputs { get; set; }
    }
}
