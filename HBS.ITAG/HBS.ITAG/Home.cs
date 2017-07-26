using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using HBS.ITAG.Model;
using EstimoteSdk;
using Android.Text.Method;
using Android.Text;
using Android.Support.V4.Content;

namespace HBS.ITAG
{
    [Activity(Label = "Home", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Home : Activity, BeaconManager.IServiceReadyCallback
    {
        ListView SurveyList;
        ListView HottestEventList;
        List<Event> Surveys;
        List<Event> HottestEvent;
        List<Event> events;
        public static TextView currentEvent;

        public static bool AppClosed;
        public static string current_Event;
        BeaconManager beaconManager;
        const string PROXIMITY_UUID = "B9407F30-F5F8-466E-AFF9-25556B57FE6D";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Home);
            SystemRequirementsChecker.CheckWithDefaultDialogs(this);
            ImageView appFeatures = FindViewById<ImageView>(Resource.Id.app_features);
            ImageView itagIcon = FindViewById<ImageView>(Resource.Id.itag_icon);
            TextView favoritesHeader = FindViewById<TextView>(Resource.Id.favorites_header);
            SurveyList = FindViewById<ListView>(Resource.Id.favoritedList);
            HottestEventList = FindViewById<ListView>(Resource.Id.HottestEventList);
            HottestEvent = new List<Event>();
            Surveys = new List<Event>();
            TextView conferenceDetails = FindViewById<TextView>(Resource.Id.conference_details);
            TextView contactNumber = FindViewById<TextView>(Resource.Id.contactnumber);
            Switch notificationSwitch = FindViewById<Switch>(Resource.Id.switch1);
            Store.Instance.ToDoList = new List<Event>();

            itagIcon.Click += (sender, e) =>
            {
                StartActivity(typeof(Survey));
            };

            currentEvent = FindViewById<TextView>(Resource.Id.textViewTest);

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

            //Make hotel website link
            TextView weblink = FindViewById<TextView>(Resource.Id.HotelName);
            string HotelName = "<a href='http://www.starwoodhotels.com/sheraton/property/overview/index.html?propertyID=1557&language=en_US'> West Des Moines Sheraton </a>";
            weblink.TextFormatted = Html.FromHtml(HotelName);
            weblink.MovementMethod = LinkMovementMethod.Instance;

            // Makes phone number clickable
            contactNumber.Click += delegate {
                var uri = Android.Net.Uri.Parse("tel:(515) 223-1800");
                var intent = new Intent(Intent.ActionDial, uri);
                StartActivity(intent);
            };

            // Initializes Beacons and Data
            StopService(new Intent(this, typeof(SimpleService)));
            Store.Instance.GetTracks(LoadTracksComplete);

            beaconManager = new BeaconManager(this);
            beaconManager.SetBackgroundScanPeriod(1000, 1);

            beaconManager.EnteredRegion += (sender, e) =>
            {
                if (Store.Instance.Notify)
                {
                    Event tempEvent = Store.Instance.ProximityEvent(e.Region.Major.ToString(), e.Region.Minor.ToString());


                    if (tempEvent != null)
                    {
                        Store.Instance.AddPerson(tempEvent);
                        OnRegionEnter(tempEvent);
                    }
                }
            };

            beaconManager.ExitedRegion += (sender, e) =>
            {

                if (Store.Instance.Notify)
                {
                    Event tempEvent = Store.Instance.ProximityEvent(e.P0.Major.ToString(), e.P0.Minor.ToString());

                    current_Event = "no event selected";
                    string label = "You are not currently at an event.";
                    char[] labelArray = label.ToCharArray();
                    int temp2 = label.Length;
                    Home.currentEvent.SetText(labelArray, 0, temp2);

                    if (tempEvent != null)
                    {
                        OnRegionExit(tempEvent);
                        if (!Store.Instance.ToDoList.Contains(tempEvent))
                        {
                            Store.Instance.AddToDo(tempEvent);
                        }
                        Store.Instance.RemovePerson(tempEvent);
                        LoadData();
                    }
                }
            };
            beaconManager.Connect(this);
            StartService(new Intent(this, typeof(SimpleService)));


            // Notification Toggle
            notificationSwitch.CheckedChange += delegate (object sender, CompoundButton.CheckedChangeEventArgs e) {
                 if (!notificationSwitch.Checked)
                 {
                    StopService(new Intent(this, typeof(SimpleService)));
                    beaconManager.Disconnect();
                }
                 else
                 {
                    StartService(new Intent(this, typeof(SimpleService)));
                    beaconManager.Connect(this);
                }
            };
        }

        protected override void OnResume()
        {
            Store.Instance.RefreshEventAttendees(refreshEventsComplete);
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

        public void LoadData()
        {
            
            events = new List<Event>(Store.Instance.Events);
            Surveys = new List<Event>();
            HottestEvent = new List<Event>();
    
            foreach (var e in events)
            {
                if(e.NumberOfPeople > 0)
                {
                    if (HottestEvent == null || HottestEvent.Count == 0)
                    {
                        HottestEvent.Add(e);
                    }
                    else if (e.NumberOfPeople > HottestEvent[0].NumberOfPeople)
                    {
                        HottestEvent.Remove(HottestEvent[0]);
                        HottestEvent.Add(e);
                    }
                }
            }

            foreach (var e in events)
            {
                if (Store.Instance.ToDoList.Contains(e))
                {
                    Surveys.Add(e);
                    SurveyList.ItemClick += SurveyClick;
                }
            }


            if (Surveys.Count == 0)
            {
                Surveys.Add(new Event(null, null, DateTime.Parse("6/24/2017"), DateTime.Parse("6/24/2017"), null, null, null, null, null, true));
            }
            

            if (HottestEvent.Count == 0)
            {
                HottestEvent.Add(new Event(null, null, DateTime.Parse("6/24/2017"), DateTime.Parse("6/24/2017"), null, null, null, null, null, true));
            }

            HotEventAdapter HotAdapter = new HotEventAdapter(Application.Context, HottestEvent);
            HottestEventList.Adapter = HotAdapter;
            HottestEventList.ItemClick += HotClick;

            SurveyAdapter SurveyAdapter = new SurveyAdapter(Application.Context, Surveys);
            SurveyList.Adapter = SurveyAdapter;
        } 

        private void HotClick(object sender, AdapterView.ItemClickEventArgs e)
        {
                Store.Instance.SelectedEvent = HottestEvent[e.Position];
                Intent i = new Intent(Application.Context, typeof(EventDetails));
                i.SetFlags(ActivityFlags.ReorderToFront);
                StartActivity(i);
        }

        private void SurveyClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Store.Instance.SelectedEvent = Surveys[e.Position];
            Intent i = new Intent(Application.Context, typeof(Survey));
            i.SetFlags(ActivityFlags.ReorderToFront);
            StartActivity(i);

        }

        public void refreshEventsComplete(string message) { }
        
        public void OnServiceReady()
        {
            InitializeBeacons();
        }

        private void InitializeBeacons()
        {
            //Loop through all location entries
            Region beaconRegionTest = new Region("test", null, null, null);
            beaconManager.StartMonitoring(beaconRegionTest);
            for (int i = 0; i < Store.Instance.Locations.Count; i++)
            {
                Location tempLocation = Store.Instance.Locations[i];
                Region beaconRegion = new Region(tempLocation.Nickname, tempLocation.BeaconGuid, System.Convert.ToInt32(tempLocation.Major), System.Convert.ToInt32(tempLocation.Minor));
                Console.WriteLine(tempLocation.Nickname + " " + tempLocation.BeaconGuid + " " + tempLocation.Major + " " + tempLocation.Minor);
                beaconManager.StartMonitoring(beaconRegion);
            }
        }

        public void OnRegionEnter(Event tempEvent)
        {
            Store.Instance.SelectedEvent = tempEvent;
            Intent newIntent = new Intent(this, typeof(EventDetails));
            Android.Support.V4.App.TaskStackBuilder stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(this);
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(EventDetails)));
            stackBuilder.AddNextIntent(newIntent);
            PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

            current_Event = tempEvent.Name;
            string label = "You are at : " + current_Event + ".";
            char[] labelArray = label.ToCharArray();
            int temp = label.Length;
            Home.currentEvent.SetText(labelArray, 0, temp);

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

            int minutesSinceLastNotification = (tempEvent.LastEntryNotified - DateTime.Now).Minutes;
            minutesSinceLastNotification = Math.Abs(minutesSinceLastNotification);

            //Don't notify twice in a row and don't repeat the same notification more than once in 10 minutes
            if (Store.Instance.SelectedEvent != tempEvent && minutesSinceLastNotification > 5)
            {
                tempEvent.LastEntryNotified = DateTime.Now;
                Store.Instance.AddSession(tempEvent.Id, true, OnSessionAddComplete);
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

        public void OnSessionAddComplete(string message) { }
        
    }
}

