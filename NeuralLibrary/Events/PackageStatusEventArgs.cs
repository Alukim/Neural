using System;

namespace NeuralLibrary.Events
{
    public class PackageStatusEventArgs : EventArgs
    {
        public PackageStatusEventArgs(int epoch, int photoNumber)
        {
            Epoch = epoch;
            PhotoNumber = photoNumber;
        }

        public int Epoch { get; private set; }
        public int PhotoNumber { get; private set; }
    }
}
