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
    public class JsonHandler
    {
        public List<User> DeserializeJsonString(string input)
        {
            var userlist = new List<User>();
            User[] result = JsonConvert.DeserializeObject<User[]>(input);

            foreach (User u in result)
            {
                userlist.Add(u);
            }

            return userlist;
        }

        public List<Friend> DeserializeFriendsJsonString(string input)
        {
            var friendlist = new List<Friend>();
            Friend[] result = JsonConvert.DeserializeObject<Friend[]>(input);

            foreach (Friend f in result)
            {
                friendlist.Add(f);
            }

            return friendlist;
        }
    }
}