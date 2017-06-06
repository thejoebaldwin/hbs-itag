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
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Schedule);

            //ScrollView schedule = FindViewById<ScrollView>(Resource.Id.schedule);

            Button toEventDetails = FindViewById<Button>(Resource.Id.tempToEventDetails);
            toEventDetails.Click += (sender, e) =>
            {
                StartActivity(typeof(EventDetails));
            };
        }
    }
}