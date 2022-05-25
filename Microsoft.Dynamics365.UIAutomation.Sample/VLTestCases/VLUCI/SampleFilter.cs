using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Security;
using OpenQA.Selenium;

namespace Microsoft.Dynamics365.UIAutomation.Sample.VLTestCases.VLUCI
{
    [TestClass]
    public class SampleFilter
    {
        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly SecureString _mfaSecretKey = System.Configuration.ConfigurationManager.AppSettings["MfaSecretKey"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());


        //
        // NOTE: Not working fully yet.
        //
        // Test case for checking whether elements can be reached through their full XPath.
        //
        // Conclusion: they are reachable, however, it is recommended only for specific cases, since finding the correct path to the element can be hard.
        //

        [TestMethod]
        public void FilterBookings()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmApp = new XrmApp(client))
            {
                xrmApp.OnlineLogin.Login(_xrmUri, _username, _password, _mfaSecretKey);

                xrmApp.Navigation.OpenApp(UCIAppName.FieldService);

                xrmApp.Navigation.OpenSubArea(UCIAppName.FieldService, "Bookings");

                IWebElement munkarendelesButton = client.Browser.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div[1]/div/div/div[2]/div/section/div[3]/div/div/div/div/div[1]/div/div/div/div/div[2]/div[2]/div[1]/div[2]/div/div/div[3]/div[3]/div/div/div[1]/div/label"));
                munkarendelesButton.Click();
                IWebElement filterByButton = client.Browser.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div[1]/div/div/div[2]/div/section/div[3]/div/div/div/div/div[1]/div/div/div/div/div[2]/div[2]/div[1]/div[2]/div/div/div[3]/div[3]"));
                filterByButton.Click();


                IWebElement filterField = client.Browser.Driver.FindElement(By.XPath("/html/body/div[8]/div/div/div/div/div/div/ul/li[4]/button"));
                filterField.Click();
                IWebElement filterOption = client.Browser.Driver.FindElement(By.XPath("/html/body/div[9]/div/div/div/div/div/div[2]"));
                filterByButton.Click();
                IWebElement applyButton = client.Browser.Driver.FindElement(By.XPath("/html/body/div[8]/div/div/div/div/div/div[3]/form/div[3]/button[1]/span/span/span"));
                applyButton.Click();
                IWebElement firstOption = client.Browser.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div[1]/div/div/div[2]/div/section/div[3]/div/div/div/div/div[1]/div/div/div/div/div[2]/div[2]/div[3]/div[2]/div/div/div[1]/div[1]"));
                firstOption.Click();
                IWebElement editButton = client.Browser.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div[1]/div/div/div[2]/div/section/div[1]/div/div/ul/li[2]/button"));
                editButton.Click();

            }
        }
    }
}
