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


namespace HBS.ITAG
{
    [Activity(Label = "Home", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Home : Activity, BeaconManager.IServiceReadyCallback
    {
        BeaconManager beaconManager;
        const string PROXIMITY_UUID = "B9407F30-F5F8-466E-AFF9-25556B57FE6D";

        ListView favoritedList;
        List<Event> favoritedEvents;
        List<Event> events;
        TextView noFavorites;

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
                beaconManager = new BeaconManager(this);
            }
            Store.Instance.GetTracks(LoadTracksComplete);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);

            ImageView appFeatures = FindViewById<ImageView>(Resource.Id.app_features);
            ImageView itagIcon = FindViewById<ImageView>(Resource.Id.itag_icon);
            TextView favoritesHeader = FindViewById<TextView>(Resource.Id.favorites_header);
            //noFavorites = FindViewById<TextView>(Resource.Id.no_favorites);

            favoritedList = FindViewById<ListView>(Resource.Id.favoritedList);

            favoritedEvents = new List<Event>();

            itagIcon.Click += (object sender, EventArgs e) =>
            {
                //Toast toast = Toast.MakeText(this, beaconMessage, ToastLength.Long);
                // toast.Show();

                //StartActivity(typeof(JsonCallTester));

                noFavorites.Visibility = ViewStates.Invisible;
            };

            TextView conferenceDetails = FindViewById<TextView>(Resource.Id.conference_details);

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


            appFeatures.Click += (sender, e) =>
            {
                StartActivity(typeof(AppFeatures));
            };

            OnServiceReady();
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
            if (!isEmulator())
            {
                InitializeBeacons();
            }
        }

        private void LoadData()
        {
            events = new List<Event>(Store.Instance.Events);
            favoritedEvents = new List<Event>();
            foreach (var e in events)
            {
                if (e.Favorited && e.EndTime.Ticks >= DateTime.Now.Ticks)
                {
                    favoritedEvents.Add(e);
                }
            }
            if (favoritedEvents.Count != 0)
            {
                favoritedEvents.Sort((x, y) => x.StartTime.Ticks.CompareTo(y.StartTime.Ticks));
            }
            else
            {
                favoritedEvents.Add(new Event("No Favorites Selected", "-1", DateTime.Now, DateTime.Parse("6/29/2017"),"" , "Please select an event on the schedule page to add to your favorites", "", "", null, true));
            }

            MyEventsFavoritesListViewAdapter adapter = new MyEventsFavoritesListViewAdapter(this, favoritedEvents);
            favoritedList.Adapter = adapter;
            favoritedList.ItemClick += favoriteClick;
        }

        private void favoriteClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if(!favoritedEvents[e.Position].ScheduleOnly)
            {
                Store.Instance.SelectedEvent = favoritedEvents[e.Position];
                StartActivity(typeof(EventDetails));
            }
        }

        private void InitializeBeacons()
        {
            //run on main thread

            //loop through all location entries
            for (int i = 0; i < Store.Instance.Locations.Count; i++)
            {
                Location tempLocation = Store.Instance.Locations[i];
                //create new region
                Region beaconRegion = new Region(tempLocation.Nickname, PROXIMITY_UUID, System.Convert.ToInt32(tempLocation.Major), System.Convert.ToInt32(tempLocation.Minor));
                beaconManager.StartMonitoring(beaconRegion);
            }

            //on region exit
            beaconManager.ExitedRegion += (sender, e) =>
            {
                Toast.MakeText(this, "Exited", ToastLength.Long).Show();
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
                Toast.MakeText(this, "Entered", ToastLength.Long).Show();
                if (Store.Instance.Notify)
                {
                    Event tempEvent = Store.Instance.ProximityEvent(e.Region.Major.ToString(), e.Region.Minor.ToString());
                    if (tempEvent != null)
                    {
                        OnRegionEnter(tempEvent);
                    }
                }
            };


        }

        public void OnRegionExit(Event tempEvent)
        {
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
    }
}