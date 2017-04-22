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
using Xamarin.Auth;
using Xamarin.Forms;
using Android.Security.Keystore;
using Java.Security;
using System.Reflection;

namespace Jabber
{
    public class SignIn
    {
        private static HttpClient Client = new HttpClient();

        //Autentiserar användaren mot databasen genom api
        public bool authenticateUser(string username, string password)
        {
            var authStatus = false;
            var authData = string.Format("{0}:{1}", username, password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

            for (int i = 0; i < 4; i++)
            {
                var result = Client.GetAsync("http://aksumitegold.se/REST/public/api/users").Result;
                if(result.StatusCode.ToString() == "OK")
                {
                    authStatus = true;
                    //Uppgifter sparas 
                    SaveCredentials(username, password);
                }
                else
                {
                    authStatus = false;
                }
            }
            //retunerar status på autentisering
            return authStatus;
        }

        //Sparar användaruppgifter 
        public void SaveCredentials(string userName, string passWord)
        {

            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(passWord))
            {
                Account account = new Account
                {
                    Username = userName
                };

                account.Properties.Add("Password", passWord);
                AccountStore.Create(Android.App.Application.Context).Save(account, "BasicAuth");
            }
        }

        //Tar bort användaruppgifter
        public void DeleteCredentials()
        {
            var account = AccountStore.Create(Android.App.Application.Context).FindAccountsForService("BasicAuth").FirstOrDefault();
            if (account != null)
            {
                AccountStore.Create(Android.App.Application.Context).Delete(account, "BasicAuth");
            }
        }
    }
}