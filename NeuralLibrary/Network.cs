using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using NeuralLibrary.Datas.OutputLayers;
using NeuralLibrary.Datas.Training;
using NeuralLibrary.Layers;
using NeuralLibrary.Recognize;

namespace NeuralLibrary
{
    public class Network
    {
        private int numberOfInput; // number input nodes
        private int numberOfHidden; // number of hidden nodes
        private int numberOfOutput; // number of outputs nodes

        private double Beta = 1.0;
        private double LearningRate = 0.15;

        private InputLayer[] Inputs;
        private HiddenLayer[] Hiddens;
        private OutputLayer[] Outputs;

        private Random rnd = new Random(0);

        public Network(int numberOfInput, int numberOfHidden, int numberOfOutput, double beta, double learningRate)
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
                    this.Inputs[i].Weights[j] = rnd.Next(-100, 100) / 100.0;
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
                    this.Hiddens[i].Weights[j] = rnd.Next(-100, 100) / 100.0;
                }
            }
        }

        private void InitializeOutputs()
        {
            this.Outputs = new OutputLayer[this.numberOfOutput];

            for(int i = 0; i < numberOfOutput; ++i)
            {
                Outputs[i].Value = i.ToString();
            }
        }

        public void TrainNetwork(TrainingPackage datas)
        {
            var currentError = 0.0;
            var maximumError = 0.0;

            var currentIteration = 0;

            do
            {
                currentError = 0.0;

                foreach (var data in datas.Datas)
                {
                    SetInputs(data.Inputs);

                    CalculateHiddenSum();
                    CalculateOutputSum(data.Value);

                    CalculateHiddensError();
                    CalculateInputsError();

                    OutputBackPropagation();
                    HiddenBackPropagation();

                    currentError += GetErrors();
                }

                var effectiveness = TestAndCheckEffectiveness(datas);

                UpdateErrorList(currentIteration, currentError, effectiveness);
            } while (currentError > maximumError && currentIteration < datas.MaximumIterations);
        }

        public double TestAndCheckEffectiveness(TrainingPackage datas)
        {

        }

        public void Recognize(RecognizeDigit data)
        {
            SetInputs(data.Pixels.ToList());

            CalculateHiddenSum();

            for (int i = 0; i < this.numberOfOutput; ++i)
            {
                double total = 0.0;

                for (int j = 0; j < this.numberOfHidden; ++j)
                    total += Hiddens[j].Output * Hiddens[j].Weights[i];

                this.Outputs[i].InputSum = total;
                this.Outputs[i].Output = ActivateNeuron(total);
            }
        }

        public OutputLayerOutputs GetOutputs()
        {
            var outputs = this.Outputs.Select(x => new OutputLayerOutput(x.Value, x.Output)).ToList();
            var max = outputs.MaxBy(x => x.Output);

            return new OutputLayerOutputs(outputs, max);
        }

        public void ChangeBeta(double beta)
            => this.Beta = beta;

        public void ChangeLearningRate(double learningRate)
            => this.LearningRate = learningRate;

        private double ActivateNeuron(double sum)
            => 1.0 / (1.0 + Math.Exp(-sum));

        private void SetInputs(IList<double> inputs)
        {
            for (var i = 0; i < inputs.Count(); ++i)
            {
                this.Inputs[i].Value = inputs[i];
            }
        }

        private void CalculateHiddenSum()
        {
            for(var i = 0; i < this.numberOfHidden; ++i)
            {
                var total = 0.0;

                for(var j = 0; j < this.numberOfInput; ++j)
                {
                    total += this.Inputs[j].Value * Inputs[j].Weights[i];
                }

                this.Hiddens[i].InputSum = total;
                this.Hiddens[i].Output = ActivateNeuron(total);
            }
        }

        private void CalculateOutputSum(string output)
        {
            for (int i = 0; i < this.numberOfOutput; ++i)
            {
                double total = 0.0;

                for (int j = 0; j < this.numberOfHidden; ++j)
                    total += Hiddens[j].Output * Hiddens[j].Weights[i];

                this.Outputs[i].InputSum = total;
                this.Outputs[i].Output = ActivateNeuron(total);
                this.Outputs[i].Target = Outputs[i].Value.CompareTo(output) == 0 ? 1.0 : 0.0;
                this.Outputs[i].Error = Beta * (Outputs[i].Target - Outputs[i].Output) * Outputs[i].Output * (1 - Outputs[i].Output);
            }
        }

        private void CalculateHiddensError()
        {
            for (int i = 0; i < this.numberOfHidden; ++i)
            {
                double total = 0.0;

                for (int j = 0; j < this.numberOfOutput; ++j)
                    total += Outputs[j].Error * Hiddens[i].Weights[j];

                this.Hiddens[i].Error = Beta * this.Hiddens[i].Output * (1 - this.Hiddens[i].Output);
            }
        }

        private void CalculateInputsError()
        {
            for (int i = 0; i < this.numberOfInput; ++i)
            {
                double total = 0.0;

                for (int j = 0; j < this.numberOfHidden; ++j)
                    total += Hiddens[j].Error * Inputs[i].Weights[j];

                this.Hiddens[i].Error = Beta * this.Inputs[i].Value * (1 - this.Inputs[i].Value);
            }
        }

        private void OutputBackPropagation()
        {
            for (int j = 0; j < this.numberOfHidden; ++j)
            {
                for (int i = 0; i < this.numberOfOutput; ++i)
                {
                    Hiddens[j].Weights[i] += LearningRate * (Hiddens[j].Error) * Outputs[i].Output;
                }
            }
        }

        private void HiddenBackPropagation()
        {
            for (int j = 0; j < this.numberOfInput; ++j)
            {
                for (int i = 0; i < this.numberOfHidden; ++i)
                {
                    Inputs[j].Weights[i] += LearningRate * (Inputs[j].Error) * Hiddens[i].Output;
                }
            }
        }

        private double GetErrors()
        {
            double total = 0.0;

            for (int i = 0; i < this.numberOfOutput; ++i)
            {
                total += Math.Pow((Outputs[i].Target - Outputs[i].Output), 2.0) / 2.0;
            }

            return total;
        }

        private void UpdateErrorList(int iteration, double iterationError, double iterationEffectiveness)
        {

        }
    }
}
