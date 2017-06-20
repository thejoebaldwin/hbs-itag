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
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyEvents);

            // Populates Favorited Events table
            favoritedList = FindViewById<ListView>(Resource.Id.MElistView1);
            
            favoritedEvents = new List<Event>();

            foreach(var e in events)
            {
                if (e.Favorited && e.EndTime.Ticks >= DateTime.Now.Ticks)
                {
                    favoritedEvents.Add(e);
                }
            }

            favoritedEvents.Sort((x, y) => x.StartTime.Ticks.CompareTo(y.StartTime.Ticks));
            MyEventsFavoritesListViewAdapter adapter = new MyEventsFavoritesListViewAdapter(this, favoritedEvents);
            favoritedList.Adapter = adapter;
            favoritedList.ItemClick += mListView_ItemClick;

            // Populates Previous Events table
            previousEvents = new List<Event>();

            foreach(var e in events)
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
            previousList.ItemClick += mListView2_ItemClick;

            

            // Code for nav bar

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


        // Code for clicking items on ListView

        private void mListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (!favoritedEvents[e.Position].ScheduleOnly)
            {
                Store.Instance.SelectedEvent = favoritedEvents[e.Position];
                StartActivity(typeof(EventDetails));
            }
        }

        private void mListView2_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if(!previousEvents[e.Position].ScheduleOnly)
            {
                Store.Instance.SelectedEvent = previousEvents[e.Position];
                StartActivity(typeof(EventDetails));
            }
        }
    }
}