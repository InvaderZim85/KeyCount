using System;
using System.Windows.Forms;
using KeyCount.Global;
using KeyCount.Ui;
using Serilog;

namespace KeyCount;

/// <summary>
/// Provides the main logic of the program
/// </summary>
internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Helper.InitLogger();

        try
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
        catch (Exception ex)
        {
            ex.ShowLogError();
        }
        finally
        {
            Log.CloseAndFlush();
        }
            
    }
}