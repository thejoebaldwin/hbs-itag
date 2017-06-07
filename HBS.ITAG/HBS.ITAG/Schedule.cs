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
    [Activity(Label = "Schedule")]
    public class Schedule : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Schedule);

            //ImageView leftArrow = FindViewById<ImageView>(Resource.Id.left_arrow);
            //ImageView rightArrow = FindViewById<ImageView>(Resource.Id.right_arrow);

            Button day1btn = FindViewById<Button>(Resource.Id.day_one);
            Button day2btn = FindViewById<Button>(Resource.Id.day_two);
            Button day3btn = FindViewById<Button>(Resource.Id.day_three);
            Button day4btn = FindViewById<Button>(Resource.Id.day_four);

            //TextView TrackTitle = FindViewById<TextView>(Resource.Id.track_title);

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