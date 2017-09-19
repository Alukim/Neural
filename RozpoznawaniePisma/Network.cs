﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RozpoznawaniePisma
{
    public class Network
    {
        public struct InputLayer
        {
            public double Value;
            public double[] Weights;
        }
    
        public struct HiddenLayer
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
        private int InputNumber;
        private int OutputNumber;
        private int HiddenNumber;

        public InputLayer[] InputLayers;
        public HiddenLayer[] HiddenLayers;
        public OutputLayer[] OutputLayers;

        public List<double> Errors;
        public double CurrentError;

        public int CurrentIteration;
        public int MaximumIteration;

        public Network()
        {
            //Let set default values
            LEARNING_RATE = 0.2;
            CurrentIteration = 0;
            MaximumIteration = 100;
            CurrentError = 0.0;
            Errors = new List<double>();
        }

        private double Activation(double total)
         => 1.0 / (1.0 + Math.Exp(-total));

        private void CalculateOutput(double[] pattern, string output)
        {
            // writing inputs from pattern to input layer
            for (int i = 0; i < pattern.Length; ++i)
                InputLayers[i].Value = pattern[i];

            //Processing input, calculating output, expected value and first layer error
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

        public void TrainNetwork(double[][] inputs, double[][] outputs, ListView view)
        {

            double maximumError = 0.0;

            //do
            //{
            CurrentError = 0;
                for (int i = 0; i < inputs.Length; ++i)
                {
                    CalculateOutput(inputs[i], OutputLayers[i].Value);
                    BackPropagation();

                    CurrentError += GetError();
                }

                Errors.Add(CurrentError);
                ++CurrentIteration;
            //}
            //while (currentError > maximumError && CurrentIteration < MaximumIteration);

            //// Jeżeli maksymalny błąd został osiągnięty w mniejszej liczbie iteracji, to nauka sieci zakończyła się pomyślnie.
            //if (CurrentIteration <= MaximumIteration)
            //    return true;

            //return false;

            if (CurrentIteration % 100 == 0 || CurrentIteration == 0)
            {
                var item = view.Items.Add(CurrentIteration.ToString());
                item.SubItems.Add(Errors[CurrentIteration == 0 ? 0 : CurrentIteration - 1].ToString("#0.000000"));
                view.Refresh();
            }
        }

        public void Recognize(double[] input)
        {
            // Write inputs to input layer
            for (int i = 0; i < InputNumber; ++i)
                InputLayers[i].Value = input[i];

            // Calculating inputs sum and output
            for (int i = 0; i < OutputNumber; ++i)
            {
                double total = 0.0;

                for (int j = 0; j < InputNumber; ++j)
                    total += InputLayers[j].Value * InputLayers[j].Weights[i];

                OutputLayers[i].InputSum = total;
                OutputLayers[i].Output = Activation(total);
            }
        }

        //
        public void Initialize(int inputSize, int outputSize)
        {
            InputNumber = inputSize;
            OutputNumber = outputSize;

            //Creating an array with input and output neurones
            InputLayers = new InputLayer[InputNumber];
            OutputLayers = new OutputLayer[OutputNumber];

            var random = new Random();
            //Initializing weights with random values range from 0.01 to 0.02
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
