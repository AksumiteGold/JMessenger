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
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Jabber
{
    public class Register
    {
        private static HttpClient Client = new HttpClient();

        public async Task registerUser(User user)
        {
            string RestUrl = "http://aksumitegold.se/REST/public/api/user/add";
            var uri = new Uri(string.Format(RestUrl));

            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            try
            {
                response = await Client.PostAsync(uri, content);
            }
            catch (Exception)
            {
                throw new ArgumentException();
            }
        }
    }
}