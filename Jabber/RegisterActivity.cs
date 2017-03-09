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

        }

        
        
    }
}