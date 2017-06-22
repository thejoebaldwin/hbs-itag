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
    public class MyEvents : Activity, BeaconManager.IServiceReadyCallback
    {
        private List<Event> favoritedEvents;
        private List<Event> previousEvents;
        private ListView favoritedList;
        private ListView previousList;
        private List<Event> events = new List<Event>(Store.Instance.Events);
        BeaconManager beaconManager;
        const string PROXIMITY_UUID = "B9407F30-F5F8-466E-AFF9-25556B57FE6D";

        public bool isEmulator()
        {
            string fing = Build.Fingerprint;
            bool isEmulator = false;
            if (fing != null)
            {
                isEmulator = fing.Contains("vbox") || fing.Contains("generic");
            }
            return isEmulator;
        }

        public void OnServiceReady()
        {
            if (!isEmulator())
            {
            }
            InitializeBeacons();
            //Store.Instance.GetTracks(LoadTracksComplete);
        }

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

            // beacon code
            beaconManager = new BeaconManager(this);
            beaconManager.SetBackgroundScanPeriod(1000, 1);
            beaconManager.ExitedRegion += (sender, e) =>
            {
                if (Store.Instance.Notify)
                {

                    Event tempEvent = Store.Instance.ProximityEvent(e.P0.Major.ToString(), e.P0.Minor.ToString());
                    if (tempEvent != null)
                    {
                        OnRegionExit(tempEvent);
                    }
                }
            };
            
            beaconManager.EnteredRegion += (sender, e) =>
            {
                if (Store.Instance.Notify)
                {
                    Event tempEvent = Store.Instance.ProximityEvent(e.Region.Major.ToString(), e.Region.Minor.ToString());
                    if (tempEvent != null)
                    {
                        OnRegionEnter(tempEvent);
                    }
                }
            };
            beaconManager.Connect(this);

        }

        private void InitializeBeacons()
        {
            //run on main thread
            //loop through all location entries
            Region beaconRegionTest = new Region("test", null, null, null);
            beaconManager.StartMonitoring(beaconRegionTest);
            for (int i = 0; i < Store.Instance.Locations.Count; i++)
            {
                Location tempLocation = Store.Instance.Locations[i];
                //create new region
                Region beaconRegion = new Region(tempLocation.Nickname, tempLocation.BeaconGuid, System.Convert.ToInt32(tempLocation.Major), System.Convert.ToInt32(tempLocation.Minor));
                Console.WriteLine(tempLocation.Nickname + " " + tempLocation.BeaconGuid + " " + tempLocation.Major + " " + tempLocation.Minor);
                //Region beaconRegion = new Region(tempLocation.Nickname, null, null, null);
                beaconManager.StartMonitoring(beaconRegion);
            }
        }

        public void OnRegionExit(Event tempEvent)
        {
            Toast.MakeText(this, "You are leaving the event : " + tempEvent.Name + ".", ToastLength.Long).Show();
            int minutesSinceLastNotification = (tempEvent.LastExitNotified - DateTime.Now).Minutes;
            minutesSinceLastNotification = Math.Abs(minutesSinceLastNotification);
            if (minutesSinceLastNotification > 5)
            {
                Store.Instance.AddSession(tempEvent.Id, false, OnSessionAddComplete);
                tempEvent.LastExitNotified = DateTime.Now;
            }
        }

        public void OnRegionEnter(Event tempEvent)
        {
            Toast.MakeText(this, "You are near the event : " + tempEvent.Name + ".", ToastLength.Long).Show();
            int minutesSinceLastNotification = (tempEvent.LastEntryNotified - DateTime.Now).Minutes;
            minutesSinceLastNotification = Math.Abs(minutesSinceLastNotification);

            //don't notify twice in a row and don't repeat the same notification more than once in 10 minutes
            if (Store.Instance.SelectedEvent != tempEvent && minutesSinceLastNotification > 5)
            {
                //TODO: If app open, ask user if they want to see the information
                //      if app closed, add notification that event is in range

                tempEvent.LastEntryNotified = DateTime.Now;
                Store.Instance.AddSession(tempEvent.Id, true, OnSessionAddComplete);
            }
        }

        public void OnSessionAddComplete(string message)
        {

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
            if(!previousEvents[e.Position].ScheduleOnly)
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