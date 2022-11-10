using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.Net;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumBase.Framework.Core.Selenium
{
    public class WebDriverFactory
    {
        IWebDriver Driver;

        /// <summary>
        /// Initilizes IWebDriver based on the given WebBrowser name.
        /// </summary>
        /// <param name="name">Browser name i.e.: Chrome</param>
        /// <returns></returns>
        public IWebDriver CreateWebDriver(string name,bool isHeadless, string remoteURL = "")
        {
            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
            try
            {
                switch (name)
                {
                    case "Firefox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        Driver = new FirefoxDriver();
                        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        return Driver;
                    case "Edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        Driver = new EdgeDriver();
                        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        return Driver;
                    case "InternetExplorer":
                        new DriverManager().SetUpDriver(new InternetExplorerConfig());
                        Driver = new InternetExplorerDriver();
                        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        return Driver;
                    case "Remote":
                        ChromeOptions Options = new WebDriverOptions().GetRemoteOptions();
                        Driver = new RemoteWebDriver(new Uri(remoteURL), Options.ToCapabilities());
                        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        return Driver;
                    case "Chrome":
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        ChromeOptions options = new WebDriverOptions().GetChromeOptions(isHeadless);
                        Driver = new ChromeDriver(options);
                        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                        return Driver;
                    default:
                        Assert.Fail("Unable to select valid browser");
                        return null;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Driver Factory failed to Initialize with error: {e.Message}");
                return null;
            }
        }
    }
}
