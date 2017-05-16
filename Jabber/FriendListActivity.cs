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
    [Activity(Label = "Jabber - Friends", MainLauncher = false, Icon = "@drawable/icon")]
    public class FriendListActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.testing);
            ListView friendListview = FindViewById<ListView>(Resource.Id.friendsview);

            GetData getdata = new GetData();
            var Friends = new List<int>();
            foreach (int i in getdata.getFriends())
            {
                Friends.Add(i);
                ArrayAdapter<int> adapter = new ArrayAdapter<int>(this, Android.Resource.Layout.SimpleListItem1, Friends);
                friendListview.Adapter = adapter;
            }
        }
    }
}