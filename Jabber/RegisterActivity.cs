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

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Register_Activity);

            Button btnCancel = FindViewById<Button>(Resource.Id.btn_cancel);

            btnCancel.Click += delegate {
                StartActivity(typeof(SignInActivity));
            };

            EditText tfRegFirstname = FindViewById<EditText>(Resource.Id.tf_regFirstname);
            EditText tfRegLastname = FindViewById<EditText>(Resource.Id.tf_regLastname);
            EditText tfRegUsername = FindViewById<EditText>(Resource.Id.tf_regUsername);
            EditText tfRegEmail = FindViewById<EditText>(Resource.Id.tf_regEmail);
            EditText tfRegPassword = FindViewById<EditText>(Resource.Id.tf_regPassword);

           User userTemp = new User (tfRegFirstname.Text, tfRegLastname.Text, tfRegUsername.Text, tfRegEmail.Text, tfRegPassword.Text);

            Button btnRegister = FindViewById<Button>(Resource.Id.btn_register);

            btnRegister.Click += delegate {
                Register register = new Register(userTemp);
                StartActivity(typeof(SignInActivity));
            };
            
            


        }

        
        
    }
}