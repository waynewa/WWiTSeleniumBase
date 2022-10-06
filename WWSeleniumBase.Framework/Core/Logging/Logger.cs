using AventStack.ExtentReports;
using Microsoft.Identity.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumBase.Framework.Core.Helpers;
using System;
using System.Diagnostics;
using System.IO;

namespace SeleniumBase.Framework.Core.Logging
{
    public class Logger : Helpers.ExtentReportHelper

    {

        //Define variable for file path 
        private readonly string _filePath;

        /// <summary>
        /// Logger function setup to create log file 
        /// </summary>
        /// <param name="testName">Test Name relative to test running</param>
        /// <param name="filepath">File path </param>
        public Logger(string testName, string filepath)
        {
            _filePath = filepath;

            using (var log = File.CreateText(_filePath))
            {
                log.WriteLine($"Starting timestamp: {DateTime.Now.ToLocalTime()}");
                log.WriteLine($"Test: {testName}");
            }
        }

        /// <summary>
        /// Write Line function, writes in new line
        /// </summary>
        /// <param name="text">Text to be written</param>
        private void WriteLine(string text)
        {
            using (var log = File.AppendText(_filePath))
            {
                log.WriteLine(text);
                Debug.WriteLine(text);
            }
        }

        /// <summary>
        /// Write function, write to current line
        /// </summary>
        /// <param name="text">Text to be written</param>
        private void Write(string text)
        {
            using (var log = File.AppendText(_filePath))
            {
                log.Write(text);
                Debug.Write(text);
            }
        }

        /// <summary>
        /// Logging with prefix of Info
        /// </summary>
        /// <param name="message">Text to be written</param>
        public new void Info(string message)
        {
            WriteLine($"[INFO]: {message}");
            ExtentTest.Info($"[INFO]: {message}");
        }

        /// <summary>
        /// Logging with prefix of Step
        /// </summary>
        /// <param name="message">Text to be written</param>
        public void Step(string message)
        {
            WriteLine($"     [STEP]: {message}");
            ExtentTest.Info($"     [STEP]: {message}");
        }

        /// <summary>
        /// Logging with prefix of Warning
        /// </summary>
        /// <param name="message">Text to be written</param>
        public new void Warning(string message)
        {
            WriteLine($"[WARNING]: {message}");
            ExtentTest.Warning($"[WARNING]: {message}");
        }

        /// <summary>
        /// Logging with prefix of Pass
        /// </summary>
        /// <param name="message">Text to be written</param>
        public void Pass(string message)
        {
            WriteLine($"[PASS]: {message}");
            ExtentTest.Pass($"[PASS]: {message}");
        }

        /// <summary>
        /// Logging with prefix of Error
        /// </summary>
        /// <param name="message">Text to be written</param>
        public new void Error(string message)
        {
            WriteLine($"[ERROR]: {message}");
            ExtentTest.Error($"[ERROR]: {message}");
            Assert.Fail($"[ERROR]: {message}]");
        }

        /// <summary>
        /// Logging with prefix of Fatal
        /// </summary>
        /// <param name="message">Text to be written</param>
        public new void Fatal(string message)
        {
            WriteLine($"[FATAL]: {message}");
            ExtentTest.Fatal($"[FATAL]: {message}");
            Assert.Fail($"[FATAL]: {message}]");
        }
    }

}

