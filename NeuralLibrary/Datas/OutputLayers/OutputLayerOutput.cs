namespace NeuralLibrary.Datas.OutputLayers
{
    public class OutputLayerOutput
    {
        public OutputLayerOutput(string value, double output)
        {
            Value = value;
            Output = output;
        }

        public string Value { get; private set; }
        public double Output { get; private set; }
    }
}
