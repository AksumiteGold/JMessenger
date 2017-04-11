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
    [Activity(Label = "Jabber - Sign in!", MainLauncher = false, Icon = "@drawable/icon")]
    public class SignInActivity : Activity
    {

        public List<User> userList = new List<User>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.SignIn_Activity);

            Button btnSignIn = FindViewById<Button>(Resource.Id.btn_signin);
            Button btnCreateAccount = FindViewById<Button>(Resource.Id.btn_createAccount);
            EditText tfUsername = FindViewById<EditText>(Resource.Id.tf_username);
            EditText tfPassword = FindViewById<EditText>(Resource.Id.tf_password);

            btnSignIn.Click += delegate
            {
                RestHandler rest = new RestHandler();
                rest.endPoint = "http://www.aksumitegold.se/REST/public/api/users";

                string response = string.Empty;

                response = rest.makeRequest();

                //response = HttpUtility.JavaScriptStringEncode(JsonConvert.SerializeObject(response));

                JsonHandler json = new JsonHandler();
                json.DeserializeJsonString(response);
                SignIn signIn = new SignIn();

                if (signIn.checkUser(tfUsername.Text, tfPassword.Text, userList))
                {
                    StartActivity(typeof(MainActivity));
                }
            };

            btnCreateAccount.Click += delegate {
                StartActivity(typeof(RegisterActivity));
            };
        }
    }
}