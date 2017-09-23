using NeuralLibrary.Layers;

namespace NeuralLibrary.Datas.Network
{
    public class NetworkState
    {
        public InputLayer[] Inputs;
        public HiddenLayer[] Hiddens;
        public OutputLayer[] Outputs;

        public int NumberOfInputs;
        public int NumberOfOutputs;
        public int NumberOfHiddens;

        public double LearningRate;
        public double Beta;

        public NetworkState(InputLayer[] inputs, HiddenLayer[] hiddens, OutputLayer[] outputs, int numberOfInputs, int numberOfOutputs, int numberOfHiddens, double learningRate, double beta)
        {
            Inputs = inputs;
            Hiddens = hiddens;
            Outputs = outputs;
            NumberOfInputs = numberOfInputs;
            NumberOfOutputs = numberOfOutputs;
            NumberOfHiddens = numberOfHiddens;
            LearningRate = learningRate;
            Beta = beta;
        }
    }
}
