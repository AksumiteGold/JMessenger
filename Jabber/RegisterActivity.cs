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
    [Activity(Label = "Jabber - Create account!", MainLauncher = false, Icon = "@drawable/icon")]
    public class RegisterActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Register_Activity);
            Button btnRegister = FindViewById<Button>(Resource.Id.btn_register);
            Button btnCancel = FindViewById<Button>(Resource.Id.btn_cancel);

            btnRegister.Click += delegate {
                EditText tfRegFirstname = FindViewById<EditText>(Resource.Id.tf_regFirstname);
                EditText tfRegLastname = FindViewById<EditText>(Resource.Id.tf_regLastname);
                EditText tfRegUsername = FindViewById<EditText>(Resource.Id.tf_regUsername);
                EditText tfRegEmail = FindViewById<EditText>(Resource.Id.tf_regEmail);
                EditText tfRegPassword = FindViewById<EditText>(Resource.Id.tf_regPassword);
                EditText tfRegConfirmPassword = FindViewById<EditText>(Resource.Id.tf_regConfirmPass);

                try
                {
                    User userTemp = new User(tfRegFirstname.Text, tfRegLastname.Text, tfRegUsername.Text, tfRegEmail.Text, tfRegPassword.Text);
                    //Register register = new Register();
                    //register.RegisterUser(userTemp);
                    StartActivity(typeof(SignInActivity));
                }
                catch(Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long);
                }
            };

            btnCancel.Click += delegate {
                StartActivity(typeof(SignInActivity));
                Toast.MakeText(this, "Going back to login", ToastLength.Long);
            };
        }
    }
}