using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace Jabber
{
    [Activity(Label = "Jabber - Start", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            TextView displayUsername = FindViewById<TextView>(Resource.Id.tv_DisplayUsername);
            GetData getdata = new GetData();
            displayUsername.Text = getdata.getUsername();

            Button signout = FindViewById<Button>(Resource.Id.btn_SignOut);
            signout.Click += delegate
            {
                SignIn signin = new SignIn();
                signin.DeleteCredentials();
                StartActivity(typeof(SignInActivity));
            };

            Button btnOpenChat = FindViewById<Button>(Resource.Id.btn_OpenChat);
            btnOpenChat.Click += delegate {
                StartActivity(typeof(ChatActivity));
            };

            Button btnOpenFriendList = FindViewById<Button>(Resource.Id.btn_OpenFriendList);
            btnOpenFriendList.Click += delegate {
                StartActivity(typeof(FriendListActivity));
            };


        }
    }
}

