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
    public class SignIn: SignInActivity
    {

        public bool checkUser(string username, string password)
        {
            bool check = false;

            foreach(User u in userList)
            {
                if (u.Username == username && u.Password == password)
                {
                   check = true;
                }
            }

            return check;
        }
    }
}