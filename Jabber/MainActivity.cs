using Android.App;
using Android.Widget;
using Android.OS;

namespace Jabber
{
    [Activity(Label = "Jabber - Start", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
        }
    }
}

