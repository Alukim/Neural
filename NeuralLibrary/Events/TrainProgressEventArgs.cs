using System;

namespace NeuralLibrary.Events
{
    public class TrainProgressEventArgs : EventArgs
    {
        public TrainProgressEventArgs(int epoch, double error, double effectiveness)
        {
            Epoch = epoch;
            Error = error;
            Effectiveness = effectiveness;
        }

        public int Epoch { get; private set; }

        public int PhotoInEpoch { get; private set; }

        public double Error { get; private set; }

        public double Effectiveness { get; private set; }
    }
}
