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

namespace Jabber
{
    public class SignIn
    {

        public bool checkUser(string username, string password, List<User> userlist)
        {
            bool check = false;

            List<User> tempList = new List<User>();

            foreach(User u in userlist)
            {
                //if (u.Username == username && u.Password == password)
                //{
                //check = true;
                //}

                tempList.Add(u);
            }

            return check;
        }
    }
}