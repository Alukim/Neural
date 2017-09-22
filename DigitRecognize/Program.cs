using System;
using System.Windows.Forms;
using RozpoznawaniePisma;

namespace DigitRecognize
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Neural());
        }
    }
}
