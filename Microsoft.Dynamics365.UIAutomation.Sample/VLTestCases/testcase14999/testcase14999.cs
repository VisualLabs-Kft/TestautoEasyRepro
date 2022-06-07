
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Security;
using OpenQA.Selenium;

namespace Microsoft.Dynamics365.UIAutomation.Sample.VLTestCases.VLUCI
{
    [TestClass]
    public class VLAccountTestUCI
    {

        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly SecureString _mfaSecretKey = System.Configuration.ConfigurationManager.AppSettings["MfaSecretKey"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void UCITestCreateUpdateVLAccount()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmApp = new XrmApp(client))
            {
                xrmApp.OnlineLogin.Login(_xrmUri, _username, _password, _mfaSecretKey);

                xrmApp.Navigation.OpenApp(UCIAppName.FieldService);

                xrmApp.Navigation.OpenSubArea(UCIAppName.FieldService, "Esetek");

                // new contact

                xrmApp.CommandBar.ClickCommand("New");

                xrmApp.Grid.Search("Üzemeltetési Kft.");

                xrmApp.Grid.OpenRecord(0);

                xrmApp.Entity.SetValue("customerid", "Üzemeltetési Kft.");

                xrmApp.Entity.SetValue("title", "EasyRepro teszt eset");

                xrmApp.Entity.SetValue("subjectid", "AFE telepítés");

                xrmApp.Entity.SetValue("mpf_esettipus_kategori", "AFE telepítés");

                xrmApp.Entity.SetValue("mpf_installwithownftu"), "No");

                xrmApp.Entity.Save();

                IWebElement firstName = client.Browser.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div[1]/div/div/div/div/div[1]/div[2]/div/div/section[1]/section[1]/div/div/div/div[1]/div/div/div[2]/div/div/div[2]/div/div[2]/div[1]/div/input"));

                firstName.SendKeys("Aron");

                xrmApp.Entity.SetValue("lastname", "Pal-Jakab");

                IWebElement button1 = client.Browser.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div[1]/div/div/div/div/div[1]/div[1]/div[5]/div/ul/li[1]"));
                IWebElement button2 = client.Browser.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div[1]/div/div/div/div/div[1]/div[1]/div[5]/div/ul/li[2]"));
                IWebElement button3 = client.Browser.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div[1]/div/div/div/div/div[1]/div[1]/div[5]/div/ul/li[3]"));

                button2.Click();
                button3.Click();
                button1.Click();

                xrmApp.Entity.SetValue("emailaddress1", "aronpj@visuallabs.hu");

                IWebElement saveAndClose = client.Browser.Driver.FindElement(By.XPath("/html/body/div[2]/div/div[4]/div[2]/div/div[1]/div/div/div/div/div[1]/div[1]/div[1]/div[3]/div/ul/li[2]/button/span/span[2]"));
                saveAndClose.Click();
            }

        }
    }
}