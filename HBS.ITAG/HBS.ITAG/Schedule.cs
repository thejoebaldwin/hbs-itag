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
using Xamarin.Forms;

namespace HBS.ITAG
{
    [Activity(Label = "Schedule", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Schedule : Activity
    {
        //bool d1nextTrack = true;
        //bool d1previousTrack = false;
        //bool d2nextTrack = true;
        //bool d2previousTrack = false;
        //bool d3nextTrack = true;
        //bool d3previousTrack = false;
        //bool d4nextTrack = true;
        //bool d4previousTrack = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Schedule);

            ImageView d1t1right = FindViewById<ImageView>(Resource.Id.d1t1right_arrow);
            ImageView d1t2left = FindViewById<ImageView>(Resource.Id.d1t2left_arrow);
            ImageView d1t2right = FindViewById<ImageView>(Resource.Id.d1t2right_arrow);
            ImageView d1t3left = FindViewById<ImageView>(Resource.Id.d1t3left_arrow);

            ImageView d2t1right = FindViewById<ImageView>(Resource.Id.d2t1right_arrow);
            ImageView d2t2left = FindViewById<ImageView>(Resource.Id.d2t2left_arrow);
            ImageView d2t2right = FindViewById<ImageView>(Resource.Id.d2t2right_arrow);
            ImageView d2t3left = FindViewById<ImageView>(Resource.Id.d2t3left_arrow);

            ImageView d3t1right = FindViewById<ImageView>(Resource.Id.d3t1right_arrow);
            ImageView d3t2left = FindViewById<ImageView>(Resource.Id.d3t2left_arrow);
            ImageView d3t2right = FindViewById<ImageView>(Resource.Id.d3t2right_arrow);
            ImageView d3t3left = FindViewById<ImageView>(Resource.Id.d3t3left_arrow);

            ImageView d4t1right = FindViewById<ImageView>(Resource.Id.d4t1right_arrow);
            ImageView d4t2left = FindViewById<ImageView>(Resource.Id.d4t2left_arrow);
            ImageView d4t2right = FindViewById<ImageView>(Resource.Id.d4t2right_arrow);
            ImageView d4t3left = FindViewById<ImageView>(Resource.Id.d4t3left_arrow);

            Android.Widget.Button day1btn = FindViewById<Android.Widget.Button>(Resource.Id.day_one_btn);
            Android.Widget.Button day2btn = FindViewById<Android.Widget.Button>(Resource.Id.day_two_btn);
            Android.Widget.Button day3btn = FindViewById<Android.Widget.Button>(Resource.Id.day_three_btn);
            Android.Widget.Button day4btn = FindViewById<Android.Widget.Button>(Resource.Id.day_four_btn);

            FrameLayout day1 = FindViewById<FrameLayout>(Resource.Id.day_one);
            FrameLayout d1t1 = FindViewById<FrameLayout>(Resource.Id.dayoneTrack1);
            FrameLayout d1t2 = FindViewById<FrameLayout>(Resource.Id.dayoneTrack2);
            FrameLayout d1t3 = FindViewById<FrameLayout>(Resource.Id.dayoneTrack3);
            FrameLayout day2 = FindViewById<FrameLayout>(Resource.Id.day_two);
            FrameLayout d2t1 = FindViewById<FrameLayout>(Resource.Id.daytwoTrack1);
            FrameLayout d2t2 = FindViewById<FrameLayout>(Resource.Id.daytwoTrack2);
            FrameLayout d2t3 = FindViewById<FrameLayout>(Resource.Id.daytwoTrack3);
            FrameLayout day3 = FindViewById<FrameLayout>(Resource.Id.day_three);
            FrameLayout d3t1 = FindViewById<FrameLayout>(Resource.Id.daythreeTrack1);
            FrameLayout d3t2 = FindViewById<FrameLayout>(Resource.Id.daythreeTrack2);
            FrameLayout d3t3 = FindViewById<FrameLayout>(Resource.Id.daythreeTrack3);
            FrameLayout day4 = FindViewById<FrameLayout>(Resource.Id.day_four);
            FrameLayout d4t1 = FindViewById<FrameLayout>(Resource.Id.dayfourTrack1);
            FrameLayout d4t2 = FindViewById<FrameLayout>(Resource.Id.dayfourTrack2);
            FrameLayout d4t3 = FindViewById<FrameLayout>(Resource.Id.dayfourTrack3);

            // Day 1 Track Arrow Clicks
            d1t1right.Click += delegate
            {
                d1t1.Visibility = ViewStates.Gone;
                d1t2.Visibility = ViewStates.Visible;
            };
            d1t2left.Click += delegate
            {
                d1t1.Visibility = ViewStates.Visible;
                d1t2.Visibility = ViewStates.Gone;
            };
            d1t2right.Click += delegate
            {
                d1t2.Visibility = ViewStates.Gone;
                d1t3.Visibility = ViewStates.Visible;
            };
            d1t3left.Click += delegate
            {
                d1t3.Visibility = ViewStates.Gone;
                d1t2.Visibility = ViewStates.Visible;
            };

            // Day 2 Track Arrow Clicks
            d2t1right.Click += delegate
            {
                d2t1.Visibility = ViewStates.Gone;
                d2t2.Visibility = ViewStates.Visible;
            };
            d2t2left.Click += delegate
            {
                d2t1.Visibility = ViewStates.Visible;
                d2t2.Visibility = ViewStates.Gone;
            };
            d2t2right.Click += delegate
            {
                d2t2.Visibility = ViewStates.Gone;
                d2t3.Visibility = ViewStates.Visible;
            };
            d2t3left.Click += delegate
            {
                d2t3.Visibility = ViewStates.Gone;
                d2t2.Visibility = ViewStates.Visible;
            };

            // Day 3 Track Arrow Clicks
            d3t1right.Click += delegate
            {
                d3t1.Visibility = ViewStates.Gone;
                d3t2.Visibility = ViewStates.Visible;
            };
            d3t2left.Click += delegate
            {
                d3t1.Visibility = ViewStates.Visible;
                d3t2.Visibility = ViewStates.Gone;
            };
            d3t2right.Click += delegate
            {
                d3t2.Visibility = ViewStates.Gone;
                d3t3.Visibility = ViewStates.Visible;
            };
            d3t3left.Click += delegate
            {
                d3t3.Visibility = ViewStates.Gone;
                d3t2.Visibility = ViewStates.Visible;
            };

            // Day 4 Track Arrow Clicks
            d4t1right.Click += delegate
            {
                d4t1.Visibility = ViewStates.Gone;
                d4t2.Visibility = ViewStates.Visible;
            };
            d4t2left.Click += delegate
            {
                d4t1.Visibility = ViewStates.Visible;
                d4t2.Visibility = ViewStates.Gone;
            };
            d4t2right.Click += delegate
            {
                d4t2.Visibility = ViewStates.Gone;
                d4t3.Visibility = ViewStates.Visible;
            };
            d4t3left.Click += delegate
            {
                d4t3.Visibility = ViewStates.Gone;
                d4t2.Visibility = ViewStates.Visible;
            };

            day1btn.Click += delegate 
            {
                day1btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.selected_day));
                day2btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.unselected_day));
                day3btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.unselected_day));
                day4btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.unselected_day));
                day1.Visibility = ViewStates.Visible;
                day2.Visibility = ViewStates.Gone;
                day3.Visibility = ViewStates.Gone;
                day4.Visibility = ViewStates.Gone;
            };

            

            day2btn.Click += delegate
            {
                day1btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.unselected_day));
                day2btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.selected_day));
                day3btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.unselected_day));
                day4btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.unselected_day));
                day1.Visibility = ViewStates.Gone;
                day2.Visibility = ViewStates.Visible;
                day3.Visibility = ViewStates.Gone;
                day4.Visibility = ViewStates.Gone;
            };

            day3btn.Click += delegate
            {
                day1btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.unselected_day));
                day2btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.unselected_day));
                day3btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.selected_day));
                day4btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.unselected_day));
                day1.Visibility = ViewStates.Gone;
                day2.Visibility = ViewStates.Gone;
                day3.Visibility = ViewStates.Visible;
                day4.Visibility = ViewStates.Gone;
            };

            day4btn.Click += delegate
            {
                day1btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.unselected_day));
                day2btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.unselected_day));
                day3btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.unselected_day));
                day4btn.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.selected_day));
                day1.Visibility = ViewStates.Gone;
                day2.Visibility = ViewStates.Gone;
                day3.Visibility = ViewStates.Gone;
                day4.Visibility = ViewStates.Visible;
            };

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