using System;
using NeuralLibrary.Datas.OutputLayers;

namespace NeuralLibrary.Events
{
    public class RecognizeEndedEventArgs : EventArgs
    {
        public RecognizeEndedEventArgs(OutputLayerOutputs outputInfo)
        {
            OutputInfo = outputInfo;
        }

        public OutputLayerOutputs OutputInfo { get; private set; }
    }
}
