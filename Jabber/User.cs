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

namespace Jabber
{
    public class User
    {
        public string Firstname;
        public string Lastname;
        public string Username;
        public string Email;
        public string Password;

        public User(string firstname, string lastname, string username, string email, string password)
        {
            Firstname = firstname;
            Lastname = lastname;
            Username = username;
            Email = email;
            Password = password;
        }

    }
}