using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace SeleniumBase.Framework.Core.Selenium
{
    public class WebDriverOptions
    {
        /// <summary>
        /// Method returns the Chrome browser options to be utilised when loading the chrome driver
        /// </summary>
        /// <returns>ChromeOptions</returns>
        public ChromeOptions GetChromeOptions()
        {
            ChromeOptions chromeOption = new ChromeOptions();
            chromeOption.AddArguments("disable-extensions");
            chromeOption.AddArguments("start-maximized");
            //chromeOption.AddArguments("incognito");
            chromeOption.AddArguments("test-type");
            chromeOption.AddArgument("no-sandbox");
            chromeOption.AddArgument("headless");
            return chromeOption;
        }

        /// <summary>
        /// Method returns the Chrome browser options to be utilised when loading the chrome driver
        /// </summary>
        /// <returns>ChromeOptions</returns>
        public ChromeOptions GetRemoteOptions()
        {
            ChromeOptions chromeOption = new ChromeOptions();
            chromeOption.AddArguments("disable-extensions");
            chromeOption.AddArguments("start-maximized");
            chromeOption.AddArguments("incognito");
            chromeOption.AddArguments("test-type");

            return chromeOption;
        }

        /// <summary>
        /// Method returns the Firefox browser options to be utilised when loading the firefox driver
        /// </summary>
        /// <returns>FirefoxOptions</returns>
        public FirefoxOptions GetFireFoxOptions()
        {
            FirefoxOptions fireFoxOption = new FirefoxOptions();
            fireFoxOption.AddArguments("--disable-extensions");
            return fireFoxOption;
        }

        /// <summary>
        /// Method returns the IE browser options to be utilised when loading the IE driver
        /// </summary>
        /// <returns>InternetExplorerOptions</returns>
        public InternetExplorerOptions GetInternetExplorerOptions()
        {
            InternetExplorerOptions ieOptions = new InternetExplorerOptions();
            return ieOptions;
        }

        /// <summary>
        /// Method returns the Edge browser options to be utilised when loading the Edge driver
        /// </summary>
        /// <returns>EdgeOptions</returns>
        public EdgeOptions GetEdgeOptions()
        {
            EdgeOptions edgeOptions = new EdgeOptions();
            edgeOptions.AddAdditionalOption("InPrivate", true);
            edgeOptions.AddAdditionalOption("ignoreZoomSetting", true);
            return edgeOptions;
        }
    }
}
