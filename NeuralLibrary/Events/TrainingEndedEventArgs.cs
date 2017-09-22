using System;

namespace NeuralLibrary.Events
{
    public class TrainingEndedEventArgs : EventArgs
    {
        public TrainingEndedEventArgs(bool successfullyTrained)
        {
            SuccessfullyTrained = successfullyTrained;
        }

        public bool SuccessfullyTrained { get; private set; }
    }
}
