using System;
using System.Windows.Forms;

namespace Multithreading
{
    static class Program
    {
        // Punkt wej�cia do aplikacji
        [STAThread]
        static void Main()
        {
            // Uruchamiamy proces konsoli
            System.Diagnostics.Process.Start("cmd.exe");

            // Ustawienie stylu aplikacji na Windows
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Uruchomienie g��wnego formularza
            Application.Run(new Form1());
        }
    }
}
