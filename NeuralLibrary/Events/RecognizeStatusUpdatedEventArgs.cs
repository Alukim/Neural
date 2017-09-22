using System;

namespace NeuralLibrary.Events
{
    public class RecognizeStatusUpdatedEventArgs : EventArgs
    {
        public RecognizeStatusUpdatedEventArgs(int step)
        {
            Step = step;
        }

        public int Step { get; private set; }
    }
}
