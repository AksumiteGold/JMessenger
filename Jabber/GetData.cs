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

        //Hämtar användarID med hjälp av JsonHandler klassen 
        public string getUserID()
        {
            var userID = "";
            var authData = string.Format("{0}:{1}", UserName, Password);
            var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            JsonHandler json = new JsonHandler();
            var result = Client.GetStringAsync("http://aksumitegold.se/REST/public/api/user").Result;

            List<User> range = json.DeserializeJsonString(result);
            foreach (User u in range)
            {
                userID = u.Id;
            }

            return userID;
        }

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

        //gör om så att den retunerar en lista istället för ett tal
        public string getFriends()
        {
            var friends = "";
            JsonHandler json = new JsonHandler();
            var result = Client.GetStringAsync("http://aksumitegold.se/Friends/public/api/friends/all").Result;

            List<Friend> range = json.DeserializeFriendsJsonString(result);
            foreach (Friend f in range)
            {
                if(f.Id == 20)
                {
                    friends = f.ContactID.ToString();
                }
                
            }

            return friends;
        }
    }
}