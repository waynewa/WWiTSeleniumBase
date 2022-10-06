using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using static SeleniumBase.Framework.Core.Helpers.LogHelper;

namespace SeleniumBase.Framework.Core.Helpers
{
    public abstract class ExtentReportHelper
    {
        public static AventStack.ExtentReports.ExtentReports Extent => extent ?? throw new NullReferenceException("extent is null. StartReport() first.");
        public static ExtentTest ExtentTest => extentTest ?? throw new NullReferenceException("extenttest is null. CreateTest() first.");

        public static ExtentV3HtmlReporter htmlReporter;

        [ThreadStatic]
        private static readonly AventStack.ExtentReports.ExtentReports extent;
        [ThreadStatic]
        private static ExtentTest extentTest;

        /// <summary>
        /// Create the extent report and resturn the report to be utilized
        /// </summary>
        /// <returns>returns extent report</returns>
        public static AventStack.ExtentReports.ExtentReports StartReport()
        {
            string projectPath = WORKSPACE_DIRECTORY;
            string reportPath = projectPath + "Reports\\TestRunReport.html";
            var extent = new AventStack.ExtentReports.ExtentReports();
            var htmlReporter = new ExtentV3HtmlReporter(reportPath);
            htmlReporter.Config.DocumentTitle = "Automation Testing Report";
            htmlReporter.Config.ReportName = "Regression Testing";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Machine", Environment.MachineName);
            extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
            return extent;
        }

        /// <summary>
        /// Creates test in the extent report 
        /// </summary>
        /// <param name="_extent"></param>
        /// <param name="testName"></param>
        /// <returns>returns test</returns>
        public static ExtentTest CreateTest(AventStack.ExtentReports.ExtentReports _extent, string testName)
        {
            extentTest = _extent.CreateTest(testName);
            return extentTest;
        }


        /// <summary>
        /// Writes the info messages in the report
        /// </summary>
        /// <param name="message">string message to be written in report</param>
        public void Info(string message)
        {
            extentTest.Info(message);
        }

        /// <summary>
        /// Writes the Warning messages in the report
        /// </summary>
        /// <param name="message">string message to be written in report</param>
        public void Warning(string message)
        {
            extentTest.Warning(message);
        }

        /// <summary>
        /// Writes the Error messages in the report
        /// </summary>
        /// <param name="message">string message to be written in report</param>
        public void Error(string message)
        {
            extentTest.Error(message);
        }

        /// <summary>
        /// Writes the Fatal messages in the report
        /// </summary>
        /// <param name="message">string message to be written in report</param>
        public void Fatal(string message)
        {
            extentTest.Fatal(message);
        }

        /// <summary>
        /// This method will add screen shot to the report
        /// </summary>
        public void AddScreenShots()
        {
            var mediaModel =
        MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build();
            extentTest.Fail("details", mediaModel);
        }
    }
}
