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
    public class Home : Activity
    {
        ListView SurveyList;
        ListView HottestEventList;
        List<Event> Surveys;
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
            SurveyList = FindViewById<ListView>(Resource.Id.favoritedList);
            HottestEventList = FindViewById<ListView>(Resource.Id.HottestEventList);
            HottestEvent = new List<Event>();
            Surveys = new List<Event>();
            TextView conferenceDetails = FindViewById<TextView>(Resource.Id.conference_details);
            TextView contactNumber = FindViewById<TextView>(Resource.Id.contactnumber);
            Switch notificationSwitch = FindViewById<Switch>(Resource.Id.switch1);

            itagIcon.Click += (sender, e) =>
            {
                StartActivity(typeof(Survey));
            };

            TextView currentEvent = FindViewById<TextView>(Resource.Id.textViewTest);

            currentEvent.Click += (sender, e) =>
            {
                string label = "You are at : " + SimpleService.current_Event + ".";
                char[] labelArray = label.ToCharArray();
                int temp = label.Length;
                currentEvent.SetText(labelArray, 0, temp);
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

        private void LoadData()
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
            SurveyList.ItemClick += SurveyClick;
        } 
        
        private void favoriteClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (!Surveys[e.Position].ScheduleOnly)
            {
                Store.Instance.SelectedEvent = Surveys[e.Position];
				Intent i = new Intent(Application.Context, typeof(EventDetails));
				i.SetFlags(ActivityFlags.ReorderToFront);
				StartActivity(i);
            }
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

        private void OnSessionAddComplete(string message)
        {

        }

        public void refreshEventsComplete(string message)
        {

        }
        public void OnRegionEnter(Event tempEvent)
        {
            int minutesSinceLastNotification = (tempEvent.LastEntryNotified - DateTime.Now).Minutes;
            minutesSinceLastNotification = Math.Abs(minutesSinceLastNotification);

            if(Store.Instance.SelectedEvent != tempEvent && minutesSinceLastNotification >5)
            {
                Store.Instance.SelectedEvent = tempEvent;
                //make notification here
                tempEvent.LastEntryNotified = DateTime.Now;
                Store.Instance.AddSession(tempEvent.Id, true, OnSessionAddComplete);
            }
        }
    }
}
