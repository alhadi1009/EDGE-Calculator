using System;
using System.Windows.Forms;

namespace FileTransferApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        ///  Starts with the Source Form.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SourceForm());
        }
    }
}
