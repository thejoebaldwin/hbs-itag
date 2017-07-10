﻿using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using HBS.ITAG.Model;
using EstimoteSdk;
using Android.Support.V4.Content;

namespace HBS.ITAG
{
    [Activity(Label = "Home", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Home : Activity
    {
        ListView favoritedList;
        ListView HottestEventList;
        List<Event> favoritedEvents;
        List<Event> HottestEvent;
        List<Event> events;

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Home);
            SystemRequirementsChecker.CheckWithDefaultDialogs(this);
            ImageView appFeatures = FindViewById<ImageView>(Resource.Id.app_features);
            ImageView itagIcon = FindViewById<ImageView>(Resource.Id.itag_icon);
            TextView favoritesHeader = FindViewById<TextView>(Resource.Id.favorites_header);
            favoritedList = FindViewById<ListView>(Resource.Id.favoritedList);
            HottestEventList = FindViewById<ListView>(Resource.Id.HottestEventList);
            HottestEvent = new List<Event>();
            favoritedEvents = new List<Event>();
            TextView conferenceDetails = FindViewById<TextView>(Resource.Id.conference_details);
            TextView contactNumber = FindViewById<TextView>(Resource.Id.contactnumber);
            Switch notificationSwitch = FindViewById<Switch>(Resource.Id.switch1);

            itagIcon.Click += (sender, e) =>
            {
                StartActivity(typeof(Survey));
            };

            // Nav bar code
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
            
            appFeatures.Click += (sender, e) =>
            {
                StartActivity(typeof(AppFeatures));
            };

            contactNumber.Click += delegate {
                var uri = Android.Net.Uri.Parse("tel:(515) 223-1800");
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
            };
            // Initializes Beacons and Data
            Store.Instance.GetTracks(LoadTracksComplete);
            StartService(new Intent(this, typeof(SimpleService)));

            // Notification Toggle
            notificationSwitch.CheckedChange += delegate (object sender, CompoundButton.CheckedChangeEventArgs e) {
                 if (!notificationSwitch.Checked)
                 {
                    StopService(new Intent(this, typeof(SimpleService)));
                 }
                 else
                 {
                    StartService(new Intent(this, typeof(SimpleService)));
                 }
            };
        }

        protected override void OnResume()
        {
            base.OnResume();
            LoadData();
        }

        private void LoadTracksComplete(string message)
        {
            Store.Instance.GetEvents(LoadEventsComplete);
        }

        private void LoadEventsComplete(string message)
        {
            Store.Instance.GetLocations(LoadLocationsComplete);
        }

        private void LoadLocationsComplete(string message)
        {
            OldStore.Instance.InitializeFavorites();
            RunOnUiThread(() => LoadData());
        }

        private void LoadData()
        {
            events = new List<Event>(Store.Instance.Events);
            favoritedEvents = new List<Event>();
            HottestEvent = new List<Event>();
            foreach (var e in events)
            {
                if (e.Favorited && e.EndTime.Ticks >= DateTime.Now.Ticks)
                {
                    favoritedEvents.Add(e);
                    HottestEvent.Add(e);
                }
            }

            if (favoritedEvents.Count == 0)
            {
                favoritedEvents.Add(new Event(null, null, DateTime.Parse("6/24/2017"), DateTime.Parse("6/24/2017"), null, null, null, null, null, true));
            }

            MyEventsFavoritesListViewAdapter adapter = new MyEventsFavoritesListViewAdapter(Application.Context, favoritedEvents);
            favoritedList.Adapter = adapter;
            favoritedList.ItemClick += favoriteClick;

            if (HottestEvent.Count == 0)
            {
                HottestEvent.Add(new Event(null, null, DateTime.Parse("6/24/2017"), DateTime.Parse("6/24/2017"), null, null, null, null, null, true));
            }

            MyEventsFavoritesListViewAdapter adapter2 = new MyEventsFavoritesListViewAdapter(Application.Context, HottestEvent);
            HottestEventList.Adapter = adapter2;
            HottestEventList.ItemClick += favoriteClick;
        } 
        
        private void favoriteClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (!favoritedEvents[e.Position].ScheduleOnly)
            {
                Store.Instance.SelectedEvent = favoritedEvents[e.Position];
				Intent i = new Intent(Application.Context, typeof(EventDetails));
				i.SetFlags(ActivityFlags.ReorderToFront);
				StartActivity(i);
            }
        }
    }
}
