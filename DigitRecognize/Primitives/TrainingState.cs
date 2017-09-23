namespace DigitRecognize.Primitives
{
    public enum TrainingState
    {
        Waiting,
        NeuralStateImport,
        FilesImport,
        ShuffleDatas,
        StartTraining,
        EndTraining
    }
}
