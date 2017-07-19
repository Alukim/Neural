using System;

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

        public int currentIteration;
        public int maximumIteration;

        public Network()
        {
            //Wpisujemy domyślne wartości
            LEARNING_RATE = 0.2;
            currentIteration = 0;
            maximumIteration = 10;
        }

        private double Activation(double total)
         => 1.0 / (1.0 + Math.Exp(-total));

        private void CalculateOutput(double[] pattern, string output)
        {
            // Przpisujemy wejścia do warstwy wejściowej sieci
            for (int i = 0; i < pattern.Length; ++i)
                InputLayers[i].Value = pattern[i];

            // Obliczamy wejście, wyjście, wartość oczekiwaną oraz błąd pierwszej warstwy
            for(int i = 0; i < OutputNumber; ++i)
            {
                double total = 0.0;

                for (int j = 0; j < InputNumber; ++j)
                    total += InputLayers[j].Value * InputLayers[j].Weights[i];

                OutputLayers[i].InputSum = total;
                OutputLayers[i].Output = Activation(total);
                OutputLayers[i].Target = OutputLayers[i].Value.CompareTo(output) == 0 ? 1.0 : 0.0;
                OutputLayers[i].Error = (OutputLayers[i].Target - OutputLayers[i].Output) * OutputLayers[i].Output * (1 - OutputLayers[i].Output);
            }
        }

        private void BackPropagation()
        {
            for(int j = 0; j < OutputNumber; ++j)
            {
                for(int i = 0; i < InputNumber; ++i)
                {
                    InputLayers[i].Weights[j] += LEARNING_RATE * (OutputLayers[j].Error) * InputLayers[i].Value;
                }
            }
        }

        private double GetError()
        {
            double total = 0.0;

            for(int i = 0; i < OutputNumber; ++i)
            {
                total += Math.Pow((OutputLayers[i].Target - OutputLayers[i].Output), 2.0) / 2.0;
            }

            return total;
        }

        public bool TrainNetwork(double[][] inputs, double[][] outputs)
        {
            double currentError = 0.0;
            double maximumError = 0.0;

            currentIteration = 0;
            Errors = new double[maximumIteration];

            do
            {
                currentError = 0;

                for (int i = 0; i < inputs.Length; ++i)
                {
                    CalculateOutput(inputs[i], OutputLayers[i].Value);
                    BackPropagation();

                    currentError += GetError();
                }

                Errors[currentIteration] = currentError;
                ++currentIteration;
            }
            while (currentError > maximumError && currentIteration < maximumIteration);

            // Jeżeli maksymalny błąd został osiągnięty w mniejszej liczbie iteracji, to nauka sieci zakończyła się pomyślnie.
            if (currentIteration <= maximumIteration)
                return true;

            return false;
        }

        public void Recognize(double[] input)
        {
            // Przpisujemy wejścia do warstwy wejściowej sieci
            for (int i = 0; i < InputNumber; ++i)
                InputLayers[i].Value = input[i];

            // Obliczamy wejście, wyjście, wartość oczekiwaną oraz błąd pierwszej warstwy
            for (int i = 0; i < OutputNumber; ++i)
            {
                double total = 0.0;

                for (int j = 0; j < InputNumber; ++j)
                    total += InputLayers[j].Value * InputLayers[j].Weights[i];

                OutputLayers[i].InputSum = total;
                OutputLayers[i].Output = Activation(total);
            }
        }

        public void Initialize(int inputSize, int outputSize)
        {
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
    }
}
