namespace NeuralLibrary.Layers
{
    public struct HiddenLayer
    {
        public double InputSum { get; set; }
        public double Output { get; set; }
        public double Error { get; set; }
        public double[] Weights { get; set; }
    }
}
