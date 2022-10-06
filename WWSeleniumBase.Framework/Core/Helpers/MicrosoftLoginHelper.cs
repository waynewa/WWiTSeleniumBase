using OpenQA.Selenium;
using SeleniumBase.Framework.Core.Selenium;
using System;
using System.Diagnostics;
using System.Threading;

namespace SeleniumBase.Framework.Core.Helpers
{
    public static class MicrosoftLoginHelper
    {
        private static string MSUrl = "https://login.microsoftonline.com/";
        private static string ClientId = "";
        private static string TenantId = "";
        private static string AuthEndPoint = "/oauth2/v2.0/authorize";
        private static string ScopeRead = "http://sample/project.read";
        private static string ScopeWrite = "http://sample/project.write";
        private static string State = "";
        private static string Nonce = "0001";
        private static string RedirectUrl = "https://sample/docs/oauth2-redirect.html";
        private static string UserEmailAddress = "sample@test.com";

        /// <summary>
        /// Microsoft Login Tile Elements 
        /// </summary>
        private static IWebElement MicroSoftAccountSelectionTile => Driver.FindElement(By.Id("loginHeader"));
        private static IWebElement MicroSoftAccountSignInTile => Driver.FindElement(By.Id("i0281"));
        private static IWebElement MicrosoftUseAnotherAccountTile => Driver.FindElement(By.Id("otherTile"));
        private static IWebElement MicrosoftUserEmailInput => Driver.FindElement(By.Id("i0116"));
        private static IWebElement MicrosoftUserPasswordInput => Driver.FindElement(By.Id("i0118"));
        private static IWebElement MicrosoftTileNextButton => Driver.FindElement(By.Id("idSIButton9"));


        public static void MicrosoftLoginFunction()

        {
            if (MicroSoftAccountSignInTile.Displayed)
            {
                if (MicroSoftAccountSelectionTile.Text == "Pick an account")
                {
                    
                    Utils.Utils.ClickOnElement(MicrosoftUseAnotherAccountTile, "Another Acount Selection Tile");
                    Utils.Utils.SendKeys(MicrosoftUserEmailInput, UserEmailAddress);
                    Utils.Utils.ClickOnElement(MicrosoftTileNextButton, "Next Button");
                    Thread.Sleep(20000);
                    try
                    {
                        if (MicrosoftUserPasswordInput.Displayed)
                        {
                            Utils.Utils.SendKeys(MicrosoftUserPasswordInput, "samplePassword");
                            Utils.Utils.ClickOnElement(MicrosoftTileNextButton, "NextButton");
                        }
                    }
                    catch (Exception e)
                    {
                        Driver.WaitForPageLoad(20);
                        Debug.WriteLine($"The Password input field is not displayed . : {e.Message}");
                    }

                }
                else
                {
                    Utils.Utils.SendKeys(MicrosoftUserEmailInput, UserEmailAddress);
                    Utils.Utils.ClickOnElement(MicrosoftTileNextButton, "Next Button");
                    Thread.Sleep(20000);
                    try
                    {
                        if (MicrosoftUserPasswordInput.Displayed)
                        {
                            Utils.Utils.SendKeys(MicrosoftUserPasswordInput, "samplePassword");
                            Utils.Utils.ClickOnElement(MicrosoftTileNextButton, "NextButton");
                        }
                    }
                    catch (Exception e)
                    {
                        Driver.WaitForPageLoad(20);
                        Debug.WriteLine($"The Password input field is not displayed . : {e.Message}");
                    }
                }
            }
            else
            {
                Debug.WriteLine("No Microsoft Login Tile Dislayed");
            }
        }

        public static string MicrosoftLoginGetAPICode()
        {
            string endPointRequest =
             $"?client_id={ClientId}" +
             $"&response_type=token" +
             $"&redirect_uri={RedirectUrl}" +
             $"&scope={ScopeRead} {ScopeWrite}" +
             $"&response_mode=fragment" +
             $"&state={State}" +
             $"&nonce={Nonce}";

            var BaseURL = MSUrl + TenantId + AuthEndPoint + endPointRequest;

            Driver.Init("Chrome");
            Thread.Sleep(3000);
            Driver.Goto(BaseURL);
            Driver.WaitForPageLoad(30);

            MicrosoftLoginFunction();

            var CurrentUrl = new Uri(Driver.Current.Url);
            var fragments = CurrentUrl.Fragment.Split('&');

            string accessToken = null;
            if (fragments.Length > 0 && fragments[0].StartsWith("#access_token="))
            {
                accessToken = fragments[0].Remove(0, "#access_token=".Length);
            }

            if (accessToken != null)
            {
                Debug.WriteLine("AccessToken Restrieved");
            }
            Driver.Quit();
            return accessToken;
        }
    }
}
