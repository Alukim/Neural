using System;

namespace NeuralLibrary.Events
{
    public class PackageStatusEventArgs : EventArgs
    {
        public PackageStatusEventArgs(int photoNumber)
        {
            PhotoNumber = photoNumber;
        }

        public int PhotoNumber { get; private set; }
    }
}
