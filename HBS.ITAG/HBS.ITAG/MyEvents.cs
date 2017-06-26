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
using HBS.ITAG.Model;
using EstimoteSdk;
//using Android.Icu.Util;
using Android;
using Xamarin.Forms.PlatformConfiguration;
using Android.Support.V4.App;
using Permission = Android.Content.PM.Permission;
using Plugin.Permissions;
using Android.Support.V4.Content;
using Java.Util;

namespace HBS.ITAG
{
    [Activity(Label = "My Events", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MyEvents : Activity 
    {
        private List<Event> favoritedEvents;
        private List<Event> previousEvents;
        private ListView favoritedList;
        private ListView previousList;
        private List<Event> events = new List<Event>(Store.Instance.Events);

        protected override void OnResume()
        {
            base.OnResume();
            LoadData();
        }

        private void LoadData()
        {
            favoritedEvents = new List<Event>();

            foreach (var e in events)
            {
                if (e.Favorited && e.EndTime.Ticks >= DateTime.Now.Ticks)
                {
                    favoritedEvents.Add(e);
                }
            }

            favoritedEvents.Sort((x, y) => x.StartTime.Ticks.CompareTo(y.StartTime.Ticks));
            MyEventsFavoritesListViewAdapter adapter = new MyEventsFavoritesListViewAdapter(this, favoritedEvents);
            favoritedList.Adapter = adapter;

            previousEvents = new List<Event>();

            foreach (var e in events)
            {
                if (e.Favorited && e.EndTime.Ticks < DateTime.Now.Ticks)
                {
                    previousEvents.Add(e);
                }
            }

            previousEvents.Sort((y, x) => x.EndTime.Ticks.CompareTo(y.EndTime.Ticks));
            previousList = FindViewById<ListView>(Resource.Id.MElistView2);
            MyEventsPreviousEventsListViewAdapter adapter2 = new MyEventsPreviousEventsListViewAdapter(this, previousEvents);
            previousList.Adapter = adapter2;

            favoritedList.ItemClick += mListView_ItemClick;

            // Populates Previous Events table

            previousList.ItemClick += mListView2_ItemClick;
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyEvents);

            // Populates Favorited Events table
            favoritedList = FindViewById<ListView>(Resource.Id.MElistView1);

            // Code for nav bar

            ImageButton Homeimagebutton = FindViewById<ImageButton>(Resource.Id.house);

            Homeimagebutton.Click += (sender, e) =>
            {
                Intent i = new Intent(Application.Context, typeof(Home));
                i.SetFlags(ActivityFlags.ReorderToFront);
                StartActivity(i);
            };

            ImageButton Scheduleimagebutton = FindViewById<ImageButton>(Resource.Id.calendar);

            Scheduleimagebutton.Click += (sender, e) =>
            {
                Intent i = new Intent(Application.Context, typeof(Schedule));
                i.SetFlags(ActivityFlags.ReorderToFront);
                StartActivity(i);
            };

            ImageButton Profileimagebutton = FindViewById<ImageButton>(Resource.Id.profileimage);

            Profileimagebutton.Click += (sender, e) =>
            {
                Intent i = new Intent(Application.Context, typeof(MyEvents));
                i.SetFlags(ActivityFlags.ReorderToFront);
                StartActivity(i);
            };

            
        }

            // Code for clicking items on ListView

            private void mListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
            {
                if (!favoritedEvents[e.Position].ScheduleOnly)
                {
                    Store.Instance.SelectedEvent = favoritedEvents[e.Position];
                    //StartActivity(typeof(EventDetails));
                    Intent i = new Intent(Application.Context, typeof(EventDetails));
                    i.SetFlags(ActivityFlags.ReorderToFront);
                    StartActivity(i);
                }
            }

            private void mListView2_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
            {
                if (!previousEvents[e.Position].ScheduleOnly)
                {
                    Store.Instance.SelectedEvent = previousEvents[e.Position];
                    //StartActivity(typeof(EventDetails));

                    Intent i = new Intent(Application.Context, typeof(EventDetails));
                    i.SetFlags(ActivityFlags.ReorderToFront);
                    StartActivity(i);
                }
            }
        
    }
}