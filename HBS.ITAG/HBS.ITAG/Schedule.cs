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
    [Activity(Label = "Schedule")]
    public class Schedule : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Carousel);

            //ImageView leftArrow = FindViewById<ImageView>(Resource.Id.left_arrow);
            //ImageView rightArrow = FindViewById<ImageView>(Resource.Id.right_arrow);

            Android.Widget.Button day1btn = FindViewById<Android.Widget.Button>(Resource.Id.day_one_btn);
            Android.Widget.Button day2btn = FindViewById<Android.Widget.Button>(Resource.Id.day_two_btn);
            Android.Widget.Button day3btn = FindViewById<Android.Widget.Button>(Resource.Id.day_three_btn);
            Android.Widget.Button day4btn = FindViewById<Android.Widget.Button>(Resource.Id.day_four_btn);

            FrameLayout day1 = FindViewById<FrameLayout>(Resource.Id.day_one);
            FrameLayout day2 = FindViewById<FrameLayout>(Resource.Id.day_two);
            FrameLayout day3 = FindViewById<FrameLayout>(Resource.Id.day_three);
            FrameLayout day4 = FindViewById<FrameLayout>(Resource.Id.day_four);

            CarouselView day1tracks = FindViewById<CarouselView>(Resource.Id.day1tracks);

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