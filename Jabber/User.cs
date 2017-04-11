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
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(string id, string firstname, string lastname, string email, string username, string password)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Username = username;
            Password = password;
        }

    }
}