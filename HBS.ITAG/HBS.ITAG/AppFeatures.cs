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

namespace HBS.ITAG
{
    [Activity(Label = "AppFeatures", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class AppFeatures : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.AppFeatures);
            Button BluetoothMsg = FindViewById<Button>(Resource.Id.BluetoothMsg);

            ImageView WifiTowerPicture = FindViewById<ImageView>(Resource.Id.bluetoothimage);
            TextView Title = FindViewById<TextView>(Resource.Id.Title);
            TextView Header1 = FindViewById<TextView>(Resource.Id.Header1);
            TextView Info1 = FindViewById<TextView>(Resource.Id.Info1);
            TextView Header2 = FindViewById<TextView>(Resource.Id.Header2);
            ImageView Blueprintimage = FindViewById<ImageView>(Resource.Id.blueprintexample);
            TextView Header3 = FindViewById<TextView>(Resource.Id.Header3);
            TextView BackHomeButton = FindViewById<TextView>(Resource.Id.backhomebutton);
            

            BackHomeButton.Click += (sender, e) =>
            {
                StartActivity(typeof(Home));
            };

            ImageView BackHomeArrow = FindViewById<ImageView>(Resource.Id.arrowbutton);

            BackHomeArrow.Click += (sender, e) =>
            {
                StartActivity(typeof(Home));
            };
        }
    }
}