namespace DigitRecognize.Errors
{
    public class ErrorElement
    {
        public ErrorElement(int iteration, double error)
        {
            Iteration = iteration;
            Error = error;
        }

        public int Iteration { get; private set; }
        public double Error { get; private set; }
    }
}
