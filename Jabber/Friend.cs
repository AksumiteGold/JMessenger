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
    public class Friend
    {
        public int Id { get; set; }
        public int ContactID { get; set; }

        public Friend(int id, int contactId)
        {
            Id = id;
            ContactID = contactId;
        }

    }
}