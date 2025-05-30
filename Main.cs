using System;
using System.Windows.Forms;
using SnakeNet;

// .NET 3.5 non supporta ApplicationConfiguration.Initialize()
// Avvio classico WinForms
static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}
