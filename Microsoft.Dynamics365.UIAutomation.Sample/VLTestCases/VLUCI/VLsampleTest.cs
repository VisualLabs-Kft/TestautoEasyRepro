// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.
// Visuallabs test sample

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Dynamics365.UIAutomation.Api.UCI;
using Microsoft.Dynamics365.UIAutomation.Browser;
using System;
using System.Security;

namespace Microsoft.Dynamics365.UIAutomation.Sample.UCI
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

                xrmApp.Navigation.OpenApp(UCIAppName.Sales);

                xrmApp.Navigation.OpenSubArea(UCIAppName.Sales, "Contacts");

                // new contact

                xrmApp.CommandBar.ClickCommand("New");

                xrmApp.Entity.SetValue("lastname", "EasyRepro Teszt");

                xrmApp.Entity.SetValue("firstname", "Elek");

                xrmApp.Entity.SetValue("emailaddress1", "elek.teszt@visuallabs.hu");

                xrmApp.Entity.Save();

                //update contact

                xrmApp.Navigation.OpenSubArea(UCIAppName.Sales, "Contacts");

                //search desired contact

                xrmApp.Grid.Search("EasyRepro Teszt");

                xrmApp.Grid.OpenRecord(0);

                xrmApp.Entity.SetValue("jobtitle", "Sofware Tester");

                // look up and select

                LookupItem customer_field = new LookupItem { Name = "parentcustomerid" };

                xrmApp.Entity.SelectLookup(customer_field);

                xrmApp.Lookup.Search(customer_field, "VisualLabs Kft.");

                xrmApp.Entity.SetValue("phone1", "+36521234567");

                xrmApp.Entity.SetValue("mobilephone", "+36301234567");

                // select from dropdown

                xrmApp.Entity.SetValue(new OptionSet { Name = "preferredcontactmethodcode", Value = "Email" });

                xrmApp.Entity.Save();

            }

        }
    }
}