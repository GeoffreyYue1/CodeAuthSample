﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace CodeAuthSample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    static class GlobalVar
    {


        public static string adTenant = "geoffrey1.onmicrosoft.com";
        public static string TenantId = "66c34abb-b963-4041-8808-e0a7f4b5b7aa";
        public static string clientId = "c22703f6-083c-4000-8977-e50c9db27e5d";
        public static string secret = "XiI7Q~GkIzwIupGgEzgPHiB_XC1xiB-5net-S";

        public static string secret_encoded = HttpUtility.UrlEncode(secret);

        public static string scope = @"User.Read";

        public static string[] scopes = new string[] { "User.Read" };

        public static string redirectUri = "https://localhost/";

        //public static string resource = HttpUtility.UrlEncode("https://microsoftgraph.chinacloudapi.cn/");

        public static string authority = "https://login.microsoftonline.com/" + adTenant + "/oauth2/v2.0/authorize?";

        public static Microsoft.Graph.GraphServiceClient graphClient;

        public static string uriStr = authority
            + "client_id=" + clientId
            + "&response_type=code"
            + "&redirect_uri=" + redirectUri
            + "&response_mode=query"
            + "&scope=" + scope
            + "&state =12345"
            ;


        public static string code = string.Empty;
        public static string sessionId = string.Empty;

        public static bool codeAuth = false;

    }
}
