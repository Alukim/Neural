namespace NeuralLibrary.Datas.Training
{
    public class NeuralTrainingParameters
    {
        public NeuralTrainingParameters(double beta, double learningRate, int maximumIterations)
        {
            Beta = beta;
            LearningRate = learningRate;
            MaximumIterations = maximumIterations;
        }

        public double Beta { get; private set; }
        public double LearningRate { get; private set; }
        public int MaximumIterations { get; private set; }
    }
}
