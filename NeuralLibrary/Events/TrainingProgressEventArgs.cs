using System;

namespace NeuralLibrary.Events
{
    public class TrainingProgressEventArgs : EventArgs
    {
        public TrainingProgressEventArgs(int epoch, int photoInEpoch, int iteration, double error)
        {
            Epoch = epoch;
            PhotoInEpoch = photoInEpoch;
            Iteration = iteration;
            Error = error;
        }

        public int Epoch { get; private set; }

        public int PhotoInEpoch { get; private set; }

        public int Iteration { get; private set; }

        public double Error { get; private set; }
    }
}
