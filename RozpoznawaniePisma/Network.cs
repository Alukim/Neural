using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RozpoznawaniePisma
{
    public class Network
    {
        public struct InputLayer
        {
            public double Value;
            public double[] Weights;
        }

        public struct OutputLayer
        {
            public double InputSum;
            public double Output;
            public double Error;
            public double Target;
            public string Value;
        }

        private readonly double LEARNING_RATE;
        public int ImageSize;
        private int InputNumber;
        private int OutputNumber;

        public InputLayer[] InputLayers;
        public OutputLayer[] OutputLayers;

        public double[] Errors;

        private int currentIteration;
        public int maximumIteration;

        public Network(int inputSize, int outputSize)
        {
            LEARNING_RATE = 0.2;
            currentIteration = 0;
            maximumIteration = 10;

            InputNumber = inputSize;
            OutputNumber = outputSize;

            //Tworzymy tablice z neuronami na wejściu oraz na wyjściu
            InputLayers = new InputLayer[InputNumber];
            OutputLayers = new OutputLayer[OutputNumber];

            var random = new Random();
            //Inicjalizujemy wagi losowymi wartościami z zakresu 0.01 - 0.02
            for (int i = 0; i < InputNumber; ++i)
            {
                InputLayers[i].Weights = new double[OutputNumber];

                for (int j = 0; j < OutputNumber; ++j)
                {
                    InputLayers[i].Weights[j] = random.Next(1, 3) / 100.0;
                }
            }
        }


        public void TrainNetwork(double[][] inputs, double[][] outputs)
        {

        }
    }
}
