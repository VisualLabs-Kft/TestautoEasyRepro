using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample.VLTestCases.VLUCI
{
    [TestClass]
    public class _14878TestCase
    {
        private readonly SecureString _username = System.Configuration.ConfigurationManager.AppSettings["OnlineUsername"].ToSecureString();
        private readonly SecureString _password = System.Configuration.ConfigurationManager.AppSettings["OnlinePassword"].ToSecureString();
        private readonly SecureString _mfaSecretKey = System.Configuration.ConfigurationManager.AppSettings["MfaSecretKey"].ToSecureString();
        private readonly Uri _xrmUri = new Uri(System.Configuration.ConfigurationManager.AppSettings["OnlineCrmUrl"].ToString());

        [TestMethod]
        public void UCITestCreateHFEDisassembleCase()
        {
            var client = new WebClient(TestSettings.Options);
            using (var xrmApp = new XrmApp(client))
            {
                xrmApp.OnlineLogin.Login(_xrmUri, _username, _password, _mfaSecretKey);

                xrmApp.Navigation.OpenApp(UCIAppName.FieldService);

                xrmApp.Navigation.OpenSubArea(UCIAppName.FieldService, "Cases");

                // new contact

                xrmApp.CommandBar.ClickCommand("New Case");

                xrmApp.Entity.SelectForm("HFE form");

                xrmApp.Entity.SetValue("customerid", "Horvath, Bettina");

                xrmApp.Entity.SetValue("title", "HFE EasyRepro - Test 1");

                LookupItem subject_field = new LookupItem { Name = "subject" };
                xrmApp.Entity.SelectLookup(subject_field);
                xrmApp.Lookup.Search(subject_field, "HFE leszerelés");

                LookupItem casetype_field = new LookupItem { Name = "mpf_esettipus_kategoria" };
                xrmApp.Lookup.Search(casetype_field, "HFE leszerelés");



            }
        }
    }
}
