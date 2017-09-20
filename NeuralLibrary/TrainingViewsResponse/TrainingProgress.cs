namespace NeuralLibrary.TrainingViewsResponse
{
    public class TrainingProgress
    {
        public TrainingProgress(int iteration, double error, double effectiveness)
        {
            Iteration = iteration;
            Error = error;
            Effectiveness = effectiveness;
        }

        public int Iteration { get; private set; }

        public double Error { get; private set; }

        public double Effectiveness { get; private set; }
    }
}
