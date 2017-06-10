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
    [Activity(Label = "Jabber - Create account", MainLauncher = false, Icon = "@drawable/icon")]
    public class RegisterActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Register_Activity);
            Button btnCreateReg = FindViewById<Button>(Resource.Id.btn_createReg);
            TextView btnCancelReg = FindViewById<TextView>(Resource.Id.btn_cancelReg);

            btnCreateReg.Click += async delegate
            {
                EditText tfRegFirstname = FindViewById<EditText>(Resource.Id.tf_regFirstname);
                EditText tfRegLastname = FindViewById<EditText>(Resource.Id.tf_regLastname);
                EditText tfRegEmail = FindViewById<EditText>(Resource.Id.tf_regEmail);
                EditText tfRegUsername = FindViewById<EditText>(Resource.Id.tf_regUsername);
                EditText tfRegPassword = FindViewById<EditText>(Resource.Id.tf_regPassword);

                try
                {
                    User userTemp = new User(tfRegFirstname.Text, tfRegLastname.Text, tfRegEmail.Text, tfRegUsername.Text, tfRegPassword.Text);
                    Register register = new Register();
                    await register.registerUser(userTemp);
                    StartActivity(typeof(SignInActivity));
                    Finish();
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long);
                }
            };

            btnCancelReg.Click += delegate {
                StartActivity(typeof(SignInActivity));
                Toast.MakeText(this, "Going back to login", ToastLength.Long);
                Finish();
            };
        }
    }
}