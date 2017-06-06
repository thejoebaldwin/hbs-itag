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
    [Activity(Label = "Home")]
    public class Home : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);

            ImageView appFeatures = FindViewById<ImageView>(Resource.Id.app_features);

            ImageView itagIcon = FindViewById<ImageView>(Resource.Id.itag_icon);

            TextView favoritesHeader = FindViewById<TextView>(Resource.Id.favorites_header);

            TextView firstFavorite = FindViewById<TextView>(Resource.Id.first_favorite);
            
            TextView secondFavorite = FindViewById<TextView>(Resource.Id.second_favorite);
            TextView thirdFavorite = FindViewById<TextView>(Resource.Id.third_favorite);
            TextView fourthFavorite = FindViewById<TextView>(Resource.Id.fourth_favorite);

            TextView firstStatus = FindViewById<TextView>(Resource.Id.first_status);
            TextView secondStatus = FindViewById<TextView>(Resource.Id.second_status);
            TextView thirdStatus = FindViewById<TextView>(Resource.Id.third_status);
            TextView fourthStatus = FindViewById<TextView>(Resource.Id.fourth_status);

            TextView conferenceDetails = FindViewById<TextView>(Resource.Id.conference_details);

            appFeatures.Click += (sender, e) =>
            {
                StartActivity(typeof(AppFeatures));
            };

            Button toSchedule = FindViewById<Button>(Resource.Id.tempToSchedule);
            toSchedule.Click += (sender, e) =>
            {
                StartActivity(typeof(Schedule));
            };

            Button toMyEvents = FindViewById<Button>(Resource.Id.tempToMyEvents);
            toMyEvents.Click += (sender, e) =>
            {
                StartActivity(typeof(MyEvents));
            };
        }
    }
}