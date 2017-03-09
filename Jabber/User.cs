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
        private string Name;
        private string Lastname;
        private string Username;
        private string Email;
        private string Password;

        public User(string name, string lastname, string username, string email, string password)
        {
            Name = name;
            Lastname = lastname;
            Username = username;
            Email = email;
            Password = password;
        }

    }
}