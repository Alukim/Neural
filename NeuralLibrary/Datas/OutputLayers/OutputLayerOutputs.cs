using System.Collections.Generic;

namespace NeuralLibrary.Datas.OutputLayers
{
    public class OutputLayerOutputs
    {
        public OutputLayerOutputs(IReadOnlyCollection<OutputLayerOutput> outputs, OutputLayerOutput maximumOutput)
        {
            Outputs = outputs;
            MaximumOutput = maximumOutput;
        }

        public IReadOnlyCollection<OutputLayerOutput> Outputs { get; private set; }
        public OutputLayerOutput MaximumOutput { get; private set; }
    }
}
