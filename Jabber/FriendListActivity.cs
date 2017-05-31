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
    [Activity(Label = "Jabber - Friend list", MainLauncher = false, Icon = "@drawable/icon")]
    public class FriendListActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FriendList_Activity);
            ListView friendListview = FindViewById<ListView>(Resource.Id.friendsview);

            GetData getdata = new GetData();
            var FriendsID = new List<int>();
            var Friends = new List<string>();

            foreach (string i in getdata.getFriends())
            {
                Friends.Add(i);
                ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Friends);
                friendListview.Adapter = adapter;
            }

            Button btnGoBack = FindViewById<Button>(Resource.Id.btn_goBack);
            btnGoBack.Click += delegate {
                StartActivity(typeof(FriendsActivity));
                Finish();
            };
        }
    }
}