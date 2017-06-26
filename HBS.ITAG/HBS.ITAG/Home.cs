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
using Java.Lang;
using Android.Support.V7.App;
using Com.Tapadoo.Alerter;

namespace HBS.ITAG
{
    [Activity(Label = "Home", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait, Theme = "@style/Theme.AppCompat.NoActionBar")]
    public class Home : AppCompatActivity, Android.Views.View.IOnClickListener, BeaconManager.IServiceReadyCallback, ActivityCompat.IOnRequestPermissionsResultCallback
    {
        BeaconManager beaconManager; 
        const string PROXIMITY_UUID = "B9407F30-F5F8-466E-AFF9-25556B57FE6D";
        ListView favoritedList;
        List<Event> favoritedEvents;
        List<Event> events;

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
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
            
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);
            SystemRequirementsChecker.CheckWithDefaultDialogs(this);
            ImageView appFeatures = FindViewById<ImageView>(Resource.Id.app_features);
            ImageView itagIcon = FindViewById<ImageView>(Resource.Id.itag_icon);
            TextView favoritesHeader = FindViewById<TextView>(Resource.Id.favorites_header);
            favoritedList = FindViewById<ListView>(Resource.Id.favoritedList);
            favoritedEvents = new List<Event>();
            TextView conferenceDetails = FindViewById<TextView>(Resource.Id.conference_details);

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

            // Code for Beacons
            beaconManager = new BeaconManager(this);
            beaconManager.SetBackgroundScanPeriod(1000, 1);
            beaconManager.ExitedRegion += (sender, e) =>
            {
                
                if (Store.Instance.Notify)
                {

                    Event tempEvent = Store.Instance.ProximityEvent(e.P0.Major.ToString(), e.P0.Minor.ToString());
                    //Toast.MakeText(this, "You are leaving the event : Test.", ToastLength.Long).Show();

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

                    /*
                    Bundle valueSend = new Bundle();
                    valueSend.PutString("sendContent", "This is content send from activity 1.");

                    Intent newIntent = new Intent(this, typeof(EventDetails));
                    newIntent.PutExtras(valueSend);

                    Android.Support.V4.App.TaskStackBuilder stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(this);
                    stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(EventDetails)));
                    stackBuilder.AddNextIntent(newIntent);

                    PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

                    Android.Support.V4.App.NotificationCompat.Builder builder = new Android.Support.V4.App.NotificationCompat.Builder(this)
                    .SetAutoCancel(true)
                    .SetContentIntent(resultPendingIntent)
                    .SetContentTitle("Itag Conference")
                    .SetSmallIcon(Resource.Drawable.itag_icon)
                    .SetContentText("You are near the event : Test. Click for more details.");

                    NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
                    notificationManager.Notify(1, builder.Build());


                    Alerter.Create(this).SetTitle("Event: Test Nearby")
                        .SetText("Click for more details.")
                        .SetOnClickListener(this)
                        .SetIcon(Resource.Drawable.wifiTower)
                        .SetBackgroundColor(Resource.Color.material_blue_grey_950)
                        .Show();
                        */

                    if (tempEvent != null)
                    {
                        OnRegionEnter(tempEvent);
                    }
                }
            };
            Store.Instance.GetTracks(LoadTracksComplete);
            //beaconManager.Connect(this);
            //OnServiceReady();
            //OnServiceReady();
            //LoadData();
            

        }

        public AsyncTask BeaconsNotifyInBackground()
        {

            return null;
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
            //LoadData();
            OldStore.Instance.InitializeFavorites();
            RunOnUiThread(() => LoadData());

            if (!isEmulator())
            {
                beaconManager.Connect(this);
                //InitializeBeacons();
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

            if (favoritedEvents.Count == 0)
            {
                favoritedEvents.Add(new Event(null, null, DateTime.Parse("6/24/2017"), DateTime.Parse("6/24/2017"), null, null, null, null, null, true));
            }

            MyEventsFavoritesListViewAdapter adapter = new MyEventsFavoritesListViewAdapter(Application.Context, favoritedEvents);
            favoritedList.Adapter = adapter;
            favoritedList.ItemClick += favoriteClick;

		} 

		private void InitializeBeacons()
		{
            //run on main thread
            //loop through all location entries
            //Region beaconRegionTest = new Region( "test", null, null, null);
            //beaconManager.StartMonitoring(beaconRegionTest);
            for (int i = 0; i < Store.Instance.Locations.Count; i++)
				{
				    Location tempLocation = Store.Instance.Locations[i];
                    //create new region
                    Region beaconRegion = new Region(tempLocation.Nickname, tempLocation.BeaconGuid, System.Convert.ToInt32(tempLocation.Major), System.Convert.ToInt32(tempLocation.Minor));
                    Console.WriteLine(tempLocation.Nickname + " " + tempLocation.BeaconGuid + " " + tempLocation.Major + " " + tempLocation.Minor );
                    //Region beaconRegion = new Region(tempLocation.Nickname, null, null, null);
                    beaconManager.StartMonitoring(beaconRegion);
                }
        }

        public void OnRegionExit(Event tempEvent)
        {
            Toast.MakeText(this, "You are leaving the event : " + tempEvent.Name + ".", ToastLength.Long).Show();
            int minutesSinceLastNotification = (tempEvent.LastExitNotified - DateTime.Now).Minutes;
            minutesSinceLastNotification = System.Math.Abs(minutesSinceLastNotification);
            if (minutesSinceLastNotification > 5)
            {
                Store.Instance.AddSession(tempEvent.Id, false, OnSessionAddComplete);
                tempEvent.LastExitNotified = DateTime.Now;
            }
        }

        private void favoriteClick(object sender, AdapterView.ItemClickEventArgs e)
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

        public void OnRegionEnter(Event tempEvent)
        {
            //Toast.MakeText(this, "You are near the event : " + tempEvent.Name + ".", ToastLength.Long).Show();

            
            Intent newIntent = new Intent(this, typeof(EventDetails));
            Android.Support.V4.App.TaskStackBuilder stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(this);
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(EventDetails)));
            stackBuilder.AddNextIntent(newIntent);

            PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

            Android.Support.V4.App.NotificationCompat.Builder builder = new Android.Support.V4.App.NotificationCompat.Builder(this)
            .SetAutoCancel(true)
            .SetContentIntent(resultPendingIntent)
            .SetContentTitle("Itag Conference")
            .SetSmallIcon(Resource.Drawable.itag_icon)
            .SetContentText("You are near : " + tempEvent.Name + ". Click for more details.")
            .SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate)
            .SetPriority((int)NotificationPriority.High);
            NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
            notificationManager.Notify(1, builder.Build());

            /*
            Alerter.Create(this).SetTitle("Event: " + tempEvent.Name + " Nearby")
                .SetText("Click for more details.")
                .SetOnClickListener(this)
                .SetIcon(Resource.Drawable.wifiTower)
                .SetBackgroundColor(Resource.Color.material_blue_grey_950)
                .Show();
                */



            int minutesSinceLastNotification = (tempEvent.LastEntryNotified - DateTime.Now).Minutes;
            minutesSinceLastNotification = System.Math.Abs(minutesSinceLastNotification);

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

        public void OnClick(View v)
        {
            Intent i = new Intent(Application.Context, typeof(EventDetails));
            i.SetFlags(ActivityFlags.ReorderToFront);
            StartActivity(i);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
