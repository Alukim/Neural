using System.Collections.Generic;

namespace NeuralLibrary.Recognize
{
    public class RecognizeDigit
    {
        public RecognizeDigit(IReadOnlyCollection<double> pixels)
        {
            Pixels = pixels;
        }

        public IReadOnlyCollection<double> Pixels { get; private set; }
    }
}
