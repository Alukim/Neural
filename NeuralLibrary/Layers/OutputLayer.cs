namespace NeuralLibrary.Layers
{
    public struct OutputLayer
    {
        public double InputSum { get; set; }
        public double Output { get; set; }
        public double Error { get; set; }
        public double Target { get; set; }
        public string Value { get; set; }
    }
}
