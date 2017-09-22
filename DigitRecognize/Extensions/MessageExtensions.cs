using System.Windows.Forms;

namespace DigitRecognize.Extensions
{
    public static class MessageExtensions
    {
        public static void ShowError(string message)
            => MessageBox.Show($"{message}\nTry again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void ShowInfo(string message)
            => MessageBox.Show($"INFO: {message}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
