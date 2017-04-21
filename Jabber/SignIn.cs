using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Jabber
{

    public class SignIn
    {
        private static HttpClient Client = new HttpClient();

        //Autentiserar användaren mot databasen genom api
        public string authenticateUser(string username, string password)
        {
            var status = "";
            var authData = string.Format("{0}:{1}", username, password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

            for (int i = 0; i < 4; i++)
            {
                var result = Client.GetAsync("http://aksumitegold.se/REST/public/api/users").Result;
                status = result.StatusCode.ToString();
            }

            return status;
        }
    }
}