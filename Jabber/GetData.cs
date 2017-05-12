﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using Xamarin.Auth;
using Xamarin.Forms;
using System.Net.Http.Headers;

namespace Jabber
{
    public class GetData
    {
        public string UserName
        {
            get
            {
                var account = AccountStore.Create(Android.App.Application.Context).FindAccountsForService("BasicAuth").FirstOrDefault();
                return (account != null) ? account.Username : null;
            }
        }

        public string Password
        {
            get
            {
                var account = AccountStore.Create(Android.App.Application.Context).FindAccountsForService("BasicAuth").FirstOrDefault();
                return (account != null) ? account.Properties["Password"] : null;
            }
        }

        private static HttpClient Client = new HttpClient();

        //Hämtar användarnamnet med hjälp av JsonHandler klassen 
        public string getUsername()
        {
            var username = "";
            var authData = string.Format("{0}:{1}", UserName, Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            JsonHandler json = new JsonHandler();
            var result = Client.GetStringAsync("http://aksumitegold.se/REST/public/api/user").Result;
            
            List<User> range = json.DeserializeJsonString(result);
            foreach (User u in range)
            {
                username = u.Username;
            }

            return username;
        }
    }
}