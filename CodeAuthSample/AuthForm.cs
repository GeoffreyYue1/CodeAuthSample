using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeAuthSample
{
    public partial class AuthForm : Form
    {

        public AuthForm()
        {
            InitializeComponent();

            authWeb.Url = new Uri(GlobalVar.uriStr);
            authWeb.ScriptErrorsSuppressed = true;

            authWeb.DocumentCompleted += AuthWeb_DocumentCompleted;

        }

        private void AuthWeb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (Regex.Match(((WebBrowser)sender).Url.AbsoluteUri, "error=[^&]*|code=[^&]*").Success)
            {
                var queryOutput = System.Web.HttpUtility.ParseQueryString(((WebBrowser)sender).Url.Query);
                GlobalVar.code = queryOutput["Code"];
                GlobalVar.sessionId = queryOutput["session_state"];

                this.Close();
            }
        }
    }
}
