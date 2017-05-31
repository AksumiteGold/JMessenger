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
    [Activity(Label = "Jabber - Sign in", MainLauncher = false, Icon = "@drawable/icon")]
    public class SignInActivity : Activity
    {

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
                SignIn signin = new SignIn();
                signin.DeleteCredentials();

                if (signin.authenticateUser(tfUsername.Text, tfPassword.Text) == false)
                {
                    Toast.MakeText(this, "Wrong credentials. Try again...", ToastLength.Short);
                }
                else
                {                    
                    StartActivity(typeof(MainActivity));
                    Finish();
                }
                
            };

            btnCreateAccount.Click += delegate {
                StartActivity(typeof(RegisterActivity));
                Finish();
            };
        }
    }
}