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
using Android.Icu.Util;
using Android;
using Xamarin.Forms.PlatformConfiguration;
using Android.Support.V4.App;
using Permission = Android.Content.PM.Permission;
using Plugin.Permissions;
using Android.Support.V4.Content;
using Java.Util;

namespace HBS.ITAG
{
    [Activity(Label = "Home", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Home : Activity, BeaconManager.IServiceReadyCallback, ActivityCompat.IOnRequestPermissionsResultCallback
    {

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
            Store.Instance.GetTracks(LoadTracksComplete);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);
            SystemRequirementsChecker.CheckWithDefaultDialogs(this);
            
            ImageView appFeatures = FindViewById<ImageView>(Resource.Id.app_features);
            ImageView itagIcon = FindViewById<ImageView>(Resource.Id.itag_icon);
            TextView favoritesHeader = FindViewById<TextView>(Resource.Id.favorites_header);

            LinearLayout firstFavorite = FindViewById<LinearLayout>(Resource.Id.first_favorite);
            LinearLayout secondFavorite = FindViewById<LinearLayout>(Resource.Id.second_favorite);
            LinearLayout thirdFavorite = FindViewById<LinearLayout>(Resource.Id.third_favorite);
            LinearLayout fourthFavorite = FindViewById<LinearLayout>(Resource.Id.fourth_favorite);
            TextView noFavorites = FindViewById<TextView>(Resource.Id.no_favorites);

            itagIcon.Click += (object sender, EventArgs e) =>
            {
                //Toast toast = Toast.MakeText(this, beaconMessage, ToastLength.Long);
                // toast.Show();

                //StartActivity(typeof(JsonCallTester));

                noFavorites.Visibility = ViewStates.Invisible;


                firstFavorite.Visibility = ViewStates.Visible;
                secondFavorite.Visibility = ViewStates.Visible;
                thirdFavorite.Visibility = ViewStates.Visible;
                fourthFavorite.Visibility = ViewStates.Visible;

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



            firstFavorite.Click += (object sender, EventArgs e) =>
            {
                StartActivity(typeof(EventDetails));
            };

            //Store.Instance.LoadEventsFromFile();
            //Store.Instance.LoadTracksFromFile();


            beaconManager = new BeaconManager(this);
            beaconManager.SetBackgroundScanPeriod(1000, 0);

            beaconManager.StartMonitoring(new Region(
                        "monitored region",
                        (string)UUID.FromString("b9407f30-f5f8-466e-aff9-25556b57fe6d"),
                        17998, 11342));
            
        
        

            //StartService(new Intent(this, typeof(EstimoteMonitoringService)));

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
            OnServiceReady();
        }

        private IntPtr getApplicationContext()
        {
            throw new NotImplementedException();
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

		private void InitializeBeacons()
		{
			//run on main thread
		
			   //loop through all location entries
			   for (int i = 0; i < Store.Instance.Locations.Count; i++)
				{
					Location tempLocation = Store.Instance.Locations[i];
                   //create new region
                    Region beaconRegion = new Region(tempLocation.Nickname, PROXIMITY_UUID,System.Convert.ToInt32(tempLocation.Major), System.Convert.ToInt32(tempLocation.Minor));
                    beaconManager.StartMonitoring(beaconRegion);
				}

			


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