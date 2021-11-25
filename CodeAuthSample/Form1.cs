using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;

namespace CodeAuthSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthForm authForm = new AuthForm();
            authForm.ShowDialog();

            IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
  .Create(GlobalVar.clientId)
  .WithTenantId(GlobalVar.TenantId)
  .WithClientSecret(GlobalVar.secret)
  .WithRedirectUri(GlobalVar.redirectUri)
  .WithAuthority(AzureCloudInstance.AzurePublic, AadAuthorityAudience.AzureAdMyOrg)
  .Build();
            if (string.IsNullOrEmpty(GlobalVar.code))
            {
                MessageBox.Show("No Auth Code generated, please try again");
                return;

            }

            AcquireTokenByAuthorizationCodeParameterBuilder acb = confidentialClientApplication.AcquireTokenByAuthorizationCode(GlobalVar.scopes, GlobalVar.code);

            AuthenticationResult result = acb.ExecuteAsync().Result;



            var delegateAuthProvider = new DelegateAuthenticationProvider((requestMessage) =>
            {
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", result.AccessToken);

                return Task.FromResult(0);
            });

            GlobalVar.graphClient = new GraphServiceClient(delegateAuthProvider);

            GlobalVar.codeAuth = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            SignoutForm signoutForm = new SignoutForm();
            signoutForm.ShowDialog();
        }
    
    }
}
