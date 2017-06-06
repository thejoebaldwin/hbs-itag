using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views;

namespace HBS.ITAG
{
    [Activity(Label = "HBS.ITAG", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView (Resource.Layout.DemographicSurvey);

            var button = FindViewById<Button>(Resource.Id.DSbutton1);

            button.Click += (object sender, EventArgs e) =>
            {
                StartActivity(typeof(Home));
            };
        }
    }
}

