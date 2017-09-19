using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralLibrary.Layers;

namespace NeuralLibrary
{
    public class NeuralNetwork
    {
        private int numberOfInput; // number input nodes
        private int numberOfHidden; // number of hidden nodes
        private int numberOfOutput; // number of outputs nodes

        private InputLayer[] Inputs;
        private HiddenLayer[] Hiddens;
        private OutputLayer[] Outputs;

        private Random rnd = new Random(0);

        public NeuralNetwork(int numberOfInput, int numberOfHidden, int numberOfOutput)
        {
            this.numberOfInput = numberOfInput;
            this.numberOfHidden = numberOfHidden;
            this.numberOfOutput = numberOfOutput;

            InitializeInputs();
            InitializeHiddens();
            InitializeOutputs();
        }

        private void InitializeInputs()
        {
            this.Inputs = new InputLayer[this.numberOfInput];
            
            for(int i = 0; i < numberOfInput; ++i)
            {
                this.Inputs[i].Weights = new double[numberOfHidden];

                for(int j = 0; j < numberOfHidden; ++j)
                {
                    this.Inputs[i].Weights[j] = rnd.Next(1, 3) / 100.0;
                }
            }
        }

        private void InitializeHiddens()
        {
            this.Hiddens = new HiddenLayer[this.numberOfHidden];

            for (int i = 0; i < numberOfHidden; ++i)
            {
                this.Hiddens[i].Weights = new double[numberOfOutput];

                for (int j = 0; j < numberOfOutput; ++j)
                {
                    this.Hiddens[i].Weights[j] = rnd.Next(1, 3) / 100.0;
                }
            }
        }

        private void InitializeOutputs()
        {
            this.Outputs = new OutputLayer[this.numberOfOutput];
        }

        public void TrainNetwork()
        {

        }

        public void Recognize()
        {

        }
    }
}
