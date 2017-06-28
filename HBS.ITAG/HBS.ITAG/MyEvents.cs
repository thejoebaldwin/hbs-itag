using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using HBS.ITAG.Model;
using Android.Views;

namespace HBS.ITAG
{
    [Activity(Label = "My Events", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MyEvents : Activity 
    {
        private List<Event> favoritedEvents;
        private List<Event> previousEvents;
        private ListView favoritedList;
        private ListView previousList;
        private TextView noFavorites;
        private TextView noPrevious;
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
            favoritedList = FindViewById<ListView>(Resource.Id.MElistView1);
            MyEventsFavoritesListViewAdapter adapter = new MyEventsFavoritesListViewAdapter(this, favoritedEvents);
            favoritedList.Adapter = adapter;

            noFavorites = FindViewById<TextView>(Resource.Id.MEtextViewNoFavorites);
            if (favoritedEvents.Count == 0)
            {
                noFavorites.Visibility = ViewStates.Visible;
                favoritedList.Visibility = ViewStates.Gone;
            }
            else
            {
                noFavorites.Visibility = ViewStates.Gone;
                favoritedList.Visibility = ViewStates.Visible;
            }

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

            noPrevious = FindViewById<TextView>(Resource.Id.MEtextViewNoPrevious);
            if (previousEvents.Count == 0)
            {
                noPrevious.Visibility = ViewStates.Visible;
                previousList.Visibility = ViewStates.Gone;
            }
            else
            {
                noPrevious.Visibility = ViewStates.Gone;
                previousList.Visibility = ViewStates.Visible;
            }

           

            favoritedList.ItemClick += mListView_ItemClick;

            previousList.ItemClick += mListView2_ItemClick;

        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyEvents);

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
                    Intent i = new Intent(Application.Context, typeof(EventDetails));
                    i.SetFlags(ActivityFlags.ReorderToFront);
                    StartActivity(i);
                }
            }
        
    }
}