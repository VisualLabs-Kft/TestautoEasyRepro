using Microsoft.VisualStudio.TestTools.UnitTesting;

using Microsoft.Dynamics365.UIAutomation.Api.UCI;

using Microsoft.Dynamics365.UIAutomation.Browser;

using System;

using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample.VLTestCases.VLUCI

{

    [TestClass]

    public class _14986TestCase

    {



        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();

        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();

        private readonly SecureString _mfaSecretKey = System.Configuration.ConfigurationManager.AppSettings["MfaSecretKey"].ToSecureString();

        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());



        [TestMethod]

        public void UCITestShowAllCasesSagemcom()

        {

            var client = new WebClient(TestSettings.Options);

            using (var xrmApp = new XrmApp(client))

            {



                // Login Dynamics

                xrmApp.OnlineLogin.Login(_xrmUri, _username, _password, _mfaSecretKey);



                // Open FieldService

                xrmApp.Navigation.OpenApp(UCIAppName.FieldService);



                // Open Cases

                xrmApp.Navigation.OpenSubArea(UCIAppName.FieldService, "Cases");



                // Switch view

                xrmApp.Grid.SwitchView("Sagemcom szerviz esetek - Összes eset");



                // Check exist record

                xrmApp.Grid.OpenRecord(0);





            }



        }

    }

}