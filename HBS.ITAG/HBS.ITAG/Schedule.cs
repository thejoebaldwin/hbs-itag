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

            Button toEventDetails = FindViewById<Button>(Resource.Id.tempToEventDetails);
            toEventDetails.Click += (sender, e) =>
            {
                StartActivity(typeof(EventDetails));
            };
        }
    }
}