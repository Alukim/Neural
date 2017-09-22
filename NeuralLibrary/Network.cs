using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NeuralLibrary.Datas.OutputLayers;
using NeuralLibrary.Datas.Training;
using NeuralLibrary.Events;
using NeuralLibrary.Layers;
using NeuralLibrary.Recognize;

namespace NeuralLibrary
{
    public class Network
    {
        private int numberOfInput; // number input nodes
        private int numberOfHidden; // number of hidden nodes
        private int numberOfOutput; // number of outputs nodes

        private double MaximumIteration;
        private double Beta;
        private double LearningRate;

        private InputLayer[] Inputs;
        private HiddenLayer[] Hiddens;
        private OutputLayer[] Outputs;

        private Random rnd = new Random();

        public delegate void TrainProgressUpdateHandler(object sender, TrainProgressEventArgs e);
        public event TrainProgressUpdateHandler OnUpdateStatus;

        public delegate void PackageStatusUpdateHandler(object sender, PackageStatusEventArgs e);
        public event PackageStatusUpdateHandler OnUpdatePackageStatus;

        public delegate void TrainingEndedHandler(object sender, TrainingEndedEventArgs e);
        public event TrainingEndedHandler OnTrainingEnded;

        public delegate void RecognizeEndedHandler(object sender, RecognizeEndedEventArgs e);
        public event RecognizeEndedHandler OnRecognizeEnded;

        public delegate void RecognizeStatusUpdatedHanler(object sender, RecognizeStatusUpdatedEventArgs e);
        public event RecognizeStatusUpdatedHanler OnRecognizeStatusUpdated;

        public Network(int numberOfInput, int numberOfHidden, int numberOfOutput, int maximumIteration, double beta, double learningRate)
        {
            this.numberOfInput = numberOfInput;
            this.numberOfHidden = numberOfHidden;
            this.numberOfOutput = numberOfOutput;

            this.MaximumIteration = maximumIteration;
            this.Beta = beta;
            this.LearningRate = learningRate;

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
                    this.Inputs[i].Weights[j] = (rnd.NextDouble() * 2) - 1;
                }
            }

            this.Inputs[numberOfInput - 1].Value = 1;
        }

        private void InitializeHiddens()
        {
            this.Hiddens = new HiddenLayer[this.numberOfHidden];

            for (int i = 0; i < numberOfHidden; ++i)
            {
                this.Hiddens[i].Weights = new double[numberOfOutput];

                for (int j = 0; j < numberOfOutput; ++j)
                {
                    this.Hiddens[i].Weights[j] = (rnd.NextDouble() * 2) - 1;
                }
            }

            this.Hiddens[numberOfHidden - 1].InputSum = 1;
            this.Hiddens[numberOfHidden - 1].Output = 1;
        }

        private void InitializeOutputs()
        {
            this.Outputs = new OutputLayer[this.numberOfOutput];

            for(int i = 0; i < numberOfOutput; ++i)
            {
                Outputs[i].Value = i.ToString();
            }
        }

        public void TrainNetwork(TrainingPackage trainingPackage)
        {
            double currentError = 0.0;
            double maximumError = 0.0;

            int currentIteration = 0;

            do
            {
                currentError = 0.0;
                int photoInEpoch = 1;
                for (int i = 0; i < trainingPackage.TrainingDatas.Count(); ++i)
                {
                    SetInputs(trainingPackage.TrainingDatas[i].Inputs);

                    CalculateHiddenSum();
                    CalculateOutputSum(trainingPackage.TrainingDatas[i].Value);

                    CalculateHiddensError();
                    CalculateInputsError();

                    OutputBackPropagation();
                    HiddenBackPropagation();

                    currentError += GetErrors();
                    UpdatePackageStatus(currentIteration, photoInEpoch++);
                }

                currentError /= trainingPackage.TrainingDatas.Count();
                double effectiveness = TestAndCheckEffectiveness(trainingPackage);

                UpdateProgress(++currentIteration, currentError, effectiveness);
            } while (currentError > maximumError && currentIteration < this.MaximumIteration);

            UpdateTrainStatusEnded(currentIteration <= this.MaximumIteration);
        }

        private double TestAndCheckEffectiveness(TrainingPackage trainingPackage)
        {
            double recognizeDigitsCount = 0.0;
            var datas = trainingPackage.RecognizeTrainigData;

            foreach(var data in datas)
            {
                SetInputs(data.Inputs);

                CalculateHiddenSum();

                for (int i = 0; i < this.numberOfOutput; ++i)
                {
                    double total = 0.0;

                    for (int j = 0; j < this.numberOfHidden; ++j)
                        total += this.Hiddens[j].Output * Hiddens[j].Weights[i];

                    this.Outputs[i].InputSum = total;
                    this.Outputs[i].Output = ActivateNeuron(total);
                }
                var outputsLog = GetOutputs();

                if (outputsLog.MaximumOutput.Value == data.Value)
                    recognizeDigitsCount++;
            }

            return (recognizeDigitsCount / datas.Count()) * 100;
        }

        public void Recognize(RecognizeDigit data)
        {
            int step = 1;
            RecognizeStatusUpdated(step++);
            SetInputs(data.Pixels.ToList());

            RecognizeStatusUpdated(step++);
            CalculateHiddenSum();

            for (int i = 0; i < this.numberOfOutput; ++i)
            {
                double total = 0.0;

                for (int j = 0; j < this.numberOfHidden; ++j)
                    total += this.Hiddens[j].Output * Hiddens[j].Weights[i];

                this.Outputs[i].InputSum = total;
                this.Outputs[i].Output = ActivateNeuron(total);

                RecognizeStatusUpdated(step++);
            }

            RecognizeEnded(GetOutputs());
        }

        private OutputLayerOutputs GetOutputs()
        {
            var outputs = this.Outputs.Select(x => new OutputLayerOutput(x.Value, x.Output)).OrderByDescending(x => x.Output).ToList();
            var max = outputs.First();

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
            for (int i = 0; i < inputs.Count(); ++i)
            {
                this.Inputs[i].Value = inputs[i];
            }
        }

        private void CalculateHiddenSum()
        {
            for(int i = 0; i < this.numberOfHidden - 1; ++i)
            {
                double total = 0.0;

                for(int j = 0; j < this.numberOfInput; ++j)
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
                    total += this.Hiddens[j].Output * Hiddens[j].Weights[i];

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

                this.Hiddens[i].Error = total * Beta * this.Hiddens[i].Output * (1 - this.Hiddens[i].Output);
            }
        }

        private void CalculateInputsError()
        {
            for (int i = 0; i < this.numberOfInput; ++i)
            {
                double total = 0.0;

                for (int j = 0; j < this.numberOfHidden; ++j)
                    total += Hiddens[j].Error * Inputs[i].Weights[j];

                this.Inputs[i].Error = total * Beta * this.Inputs[i].Value * (1 - this.Inputs[i].Value);
            }
        }

        private void OutputBackPropagation()
        {
            for (int j = 0; j < this.numberOfHidden; ++j)
            {
                for (int i = 0; i < this.numberOfOutput; ++i)
                {
                    Hiddens[j].Weights[i] += LearningRate * (Hiddens[j].Output) * Outputs[i].Error;
                }
            }
        }

        private void HiddenBackPropagation()
        {
            for (int j = 0; j < this.numberOfInput; ++j)
            {
                for (int i = 0; i < this.numberOfHidden; ++i)
                {
                    Inputs[j].Weights[i] += LearningRate * (Inputs[j].Value) * Hiddens[i].Error;
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

        private void UpdateProgress(int epoch, double error, double effectiveness)
        {
            Debug.WriteLine($"Epoch: {epoch} | Error: {error} | Effectiveness: {effectiveness}");

            if (OnUpdateStatus == null)
                return;

            var args = new TrainProgressEventArgs(epoch, error, effectiveness);
            OnUpdateStatus.Invoke(this, args);
        }

        private void UpdatePackageStatus(int epochNumber, int photoNumber)
        {
            Debug.WriteLine($"Epoch: {epochNumber} | Photo number: {photoNumber}");

            if (OnUpdatePackageStatus == null)
                return;

            var args = new PackageStatusEventArgs(epochNumber, photoNumber);
            OnUpdatePackageStatus(this, args);
        }

        private void UpdateTrainStatusEnded(bool successfullyTrained)
        {
            Debug.WriteLine($"Training ended. Successfully trained: {successfullyTrained}");

            if (OnTrainingEnded == null)
                return;

            var args = new TrainingEndedEventArgs(successfullyTrained);
            OnTrainingEnded.Invoke(this, args);
        }

        private void RecognizeEnded(OutputLayerOutputs outputInfo)
        {
            Debug.WriteLine($"Founded: {outputInfo.MaximumOutput.Value} | Output: {outputInfo.MaximumOutput.Output}");

            if (OnRecognizeEnded == null)
                return;

            var args = new RecognizeEndedEventArgs(outputInfo);
            OnRecognizeEnded.Invoke(this, args);
        }

        private void RecognizeStatusUpdated(int step)
        {
            Debug.WriteLine($"Recognize step number: {step}");

            if (OnRecognizeStatusUpdated == null)
                return;

            var args = new RecognizeStatusUpdatedEventArgs(step);
            OnRecognizeStatusUpdated.Invoke(this, args);
        }
    }
}
