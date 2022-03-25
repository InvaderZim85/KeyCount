using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using Serilog;

namespace KeyCount.Global
{
    /// <summary>
    /// Provides several helper functions
    /// </summary>
    internal static class Helper
    {
        /// <summary>
        /// Gets the path of the base directory
        /// </summary>
        /// <returns>The path of the base directory</returns>
        public static string GetBaseDirPath()
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            return Path.GetDirectoryName(assemblyPath) ?? "";
        }

        /// <summary>
        /// Init the logger
        /// </summary>
        public static void InitLogger()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
        }

        /// <summary>
        /// Shows a message box with the error information and logs the error
        /// </summary>
        /// <param name="ex">The exception</param>
        public static void ShowLogError(this Exception ex)
        {
            MessageBox.Show("An error has occurred. For more information see log.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            Log.Error(ex, "");
        }

        /// <summary>
        /// Sets the taskbar progress
        /// </summary>
        /// <param name="max">The max value</param>
        /// <param name="current">The current value</param>
        public static void SetTaskbarProgress(int max, int current)
        {
            if (!TaskbarManager.IsPlatformSupported)
                return;

            var instance = TaskbarManager.Instance;

            if (current > max)
            {
                instance.SetProgressState(TaskbarProgressBarState.Normal); // Reset the progress
                return;
            }

            instance.SetProgressState(TaskbarProgressBarState.Indeterminate);
            instance.SetProgressValue(current, max);
        }
    }
}
