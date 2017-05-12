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
    [Activity(Label = "Jabber", MainLauncher = true, Icon = "@drawable/icon")]
    public class WelcomeActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.layout1);

            Button btnProceed = FindViewById<Button>(Resource.Id.btn_proceed);

            btnProceed.Click += delegate {
                StartActivity(typeof(SignInActivity));
            };

        }
    }

}