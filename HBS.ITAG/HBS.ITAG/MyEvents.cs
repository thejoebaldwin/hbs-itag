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
    [Activity(Label = "My Events")]
    public class MyEvents : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyEvents);

            ImageButton Homeimagebutton = FindViewById<ImageButton>(Resource.Id.house);

            Homeimagebutton.Click += (sender, e) =>
            {
                StartActivity(typeof(Home));
            };

            ImageButton Scheduleimagebutton = FindViewById<ImageButton>(Resource.Id.calendar);

            Scheduleimagebutton.Click += (sender, e) =>
            {
                StartActivity(typeof(Schedule));
            };

            ImageButton Profileimagebutton = FindViewById<ImageButton>(Resource.Id.profileimage);

            Profileimagebutton.Click += (sender, e) =>
            {
                StartActivity(typeof(MyEvents));
            };
            

        }
    }
}