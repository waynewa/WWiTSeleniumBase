using System;
using System.IO;
using SeleniumBase.Framework.Core.Logging;
using System.Diagnostics;
using System.Threading;

namespace SeleniumBase.Framework.Core.Helpers
{
    /// <summary>
    /// FrameWork Class housing Basic Logging functions
    /// </summary>
    public class LogHelper
    {

        public static string WORKSPACE_DIRECTORY = @"C:\temp\";//Path.GetFullPath(@"../../../../");

        public static Logger Log => _logger ?? throw new NullReferenceException("_logger is null. SetLogger() first.");

        [ThreadStatic]
        public static DirectoryInfo CurrentTestDirectory;
        [ThreadStatic]
        private static Logger _logger;

        /// <summary>
        /// Method Creates the test results directory
        /// </summary>
        /// <returns>Created Test result Directory</returns>
        public static DirectoryInfo CreateTestResultsDirectory()
        {
            var testDirectory = WORKSPACE_DIRECTORY;
            if (Directory.Exists(testDirectory))
            {
                Debug.WriteLine("Driectory Exists!");
                Directory.Delete(testDirectory, recursive: true);
            }
            Debug.WriteLine(WORKSPACE_DIRECTORY);
            return Directory.CreateDirectory(testDirectory);
        }

        /// <summary>
        /// Method sets the instance of the logger class, with directory and file names
        /// per test
        /// </summary>
        public static void SetLogger(string testName)
        {
            lock (_setLoggerLock)
            {
                var testResultsDir = WORKSPACE_DIRECTORY + "TestResults";
                var fullPath = $"{testResultsDir}\\{testName}";
                CurrentTestDirectory = Directory.CreateDirectory(fullPath);
                _logger = new Logger(testName, CurrentTestDirectory.FullName + "/log.txt");
                Debug.WriteLine("Log File Created");
                if (Directory.Exists(fullPath))
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullPath + Thread.CurrentThread.ManagedThreadId);
                }
                else
                {
                    CurrentTestDirectory = Directory.CreateDirectory(fullPath);
                }

            }
        }

        /// <summary>
        /// Create a Object for the Logger Lock function
        /// </summary>
        private static object _setLoggerLock = new object();
    }
}
