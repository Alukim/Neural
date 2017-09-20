using System;
using NeuralLibrary.TrainingViewsResponse;

namespace NeuralLibrary.Events
{
    public class TrainProgressEventArgs : EventArgs
    {
        public TrainingProgress TrainProgress { get; private set; }

        public TrainProgressEventArgs(TrainingProgress trainProgress)
        {
            this.TrainProgress = trainProgress;
        }
    }
}
