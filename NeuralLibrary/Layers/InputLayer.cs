namespace NeuralLibrary.Layers
{
    public struct InputLayer
    {
        public double Value { get; set; }
        public double Error { get; set; }
        public double[] Weights { get; set; }
    }
}
