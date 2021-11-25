using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeAuthSample
{
    public partial class SignoutForm : Form
    {
        public SignoutForm()
        {
            InitializeComponent();
            string signOutUrl = "https://login.microsoftonline.com/geoffrey1.onmicrosoft.com/uxlogout?SessionId=" + GlobalVar.sessionId + "&shouldforgetuser=true";

            webBrowser1.Url = new Uri(signOutUrl);
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
        }

        private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
