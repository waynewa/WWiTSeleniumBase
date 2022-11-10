using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static SeleniumBase.Framework.Core.Helpers.LogHelper;


namespace SeleniumBase.Framework.Core.Selenium
{
    public class Wait
    {
        //Initial instatiation of the WebDriverWait Function
        private readonly WebDriverWait _wait;

        /// <summary>
        /// Wait function, allows waiting for a specified time 
        /// </summary>
        /// <param name="waitSeconds">Init time in seconds</param>
        public Wait(int waitSeconds)
        {
            _wait = new WebDriverWait(Driver.Current, TimeSpan.FromSeconds(waitSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };

            _wait.IgnoreExceptionTypes(
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException)
                );
        }

        /// <summary>
        /// Wait Until function, this allows to wait unitl a condition is met
        /// </summary>
        /// <param name="condition"> Condition of the element</param>
        /// <returns></returns>
        public bool Until(Func<IWebDriver, bool> condition)
        {
            return _wait.Until(condition);
        }

        /// <summary>
        /// This methond waits for a element to be displayed , and has additional description attribute
        /// </summary>
        /// <param name="webElement">Element to be displayed</param>
        /// <param name="elementDescription">Description of the element </param>
        public void WaitForElementToBeDisplayed(IWebElement webElement, string elementDescription = "Element")
        {
            try
            {
                Driver.Wait.Until(driver => webElement.Displayed);
                Log.Info($"The {elementDescription} is Displayed");
            }
            catch (Exception e)
            {
                Log.Error($"Element not Displayed error: {e.Message}");
            }
        }

        /// <summary>
        /// This methond waits for a element to be displayed , and has additional description attribute
        /// </summary>
        /// <param name="webElement">Element to be displayed</param>
        /// <param name="elementDescription">Description of the element </param>
        public void WaitForElementToBeEnabled(IWebElement webElement, string elementDescription = "Element")
        {
            try
            {
                Driver.Wait.Until(driver => webElement.Enabled);
                Log.Info($"The {elementDescription} is Enabled");
            }
            catch (Exception e)
            {
                Log.Error($"Element not Enabled error: {e.Message}");
            }
        }

    }
}
