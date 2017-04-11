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
using Newtonsoft.Json;

namespace Jabber
{
    public class JsonHandler : SignInActivity
    {
        public void DeserializeJsonString(string input)
        {
            User[] result = JsonConvert.DeserializeObject<User[]>(input);

            foreach (User u in result)
            {
                userList.Add(u);
                //Console.WriteLine(u.Firstname + " " + u.Lastname);
            }
        }
    }
}