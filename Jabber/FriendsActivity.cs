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
    public class FriendsActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Friends_Activity);

            Button btnAddFriend = FindViewById<Button>(Resource.Id.btn_addFriend);
            btnAddFriend.Click += async delegate
            {
                GetData getuser = new GetData();
                Register register = new Register();
                EditText userToAdd = FindViewById<EditText>(Resource.Id.tf_UsernameAdd);
                Friend friendtoadd = new Friend(getuser.getUserID(), getuser.getUserIDbyUsername(userToAdd.Text));
                try
                {
                    if(userToAdd.Text != "")
                    {
                        await register.addFriend(friendtoadd);
                    }
                    
                }              
                catch(Exception)
                {
                    throw new ArgumentException();
                }
            };

            Button btnOpenFriendList = FindViewById<Button>(Resource.Id.btn_openFriendList);
            btnOpenFriendList.Click += delegate {
                StartActivity(typeof(FriendListActivity));
                Finish();
            };

            Button btnGoBackToMain = FindViewById<Button>(Resource.Id.btn_GoBackToMain1);
            btnGoBackToMain.Click += delegate
            {
                SetContentView(Resource.Layout.Main);
                Finish();
            };   
        }
    }
}