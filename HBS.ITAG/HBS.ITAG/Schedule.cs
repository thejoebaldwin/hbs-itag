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
    [Activity(Label = "Schedule", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Schedule : Activity, GestureDetector.IOnGestureListener, BeaconManager.IServiceReadyCallback
    {
        private List<Event> events = new List<Event>(Store.Instance.Events);
        private List<Event> trackEvents = new List<Event>();
        private List<Track> tracks = new List<Track>();
        private DateTime CurrentTrackDate;
        private int CurrentTrack;
        private int d1track;
        private int d2track;
        private int d3track;
        private int d4track;
        private bool d1, d2, d3, d4;
        private ListView scheduleList;

        ImageView leftArrow;
        ImageView rightArrow;
        Button day1btn;
        Button day2btn;
        Button day3btn;
        Button day4btn;
        TextView trackTitle;

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

        GestureDetector gestureDetector;

        public override bool OnTouchEvent(MotionEvent e)
        {
            gestureDetector.OnTouchEvent(e);
            return false;
        }

        public bool OnDown(MotionEvent e)
        {
            return false;
        }

        public bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
        {
            if(e1.RawX - 50 > e2.RawX)
            {
                //left swipe
                nextTrack();
            }
            if(e2.RawX - 50 > e1.RawX)
            {
                //right swipe
                previousTrack();
            }
            return true;
        }

        public void OnLongPress(MotionEvent e)
        {
        }

        public bool OnScroll(MotionEvent e1, MotionEvent e2, float distanceX, float distanceY)
        {
            return false;
        }

        public void OnShowPress(MotionEvent e)
        {
        }

        public bool OnSingleTapUp(MotionEvent e)
        {
            return false;
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Schedule);

            gestureDetector = new GestureDetector(this);

            CurrentTrackDate = DateTime.Parse("6/20/2017");
            CurrentTrack = 0;
            d1track = 0;
            d2track = 0;
            d3track = 0;
            d4track = 0;
            d1 = true;
            d2 = false;
            d3 = false;
            d4 = false;
            scheduleList = FindViewById<ListView>(Resource.Id.eventList);

            leftArrow = FindViewById<ImageView>(Resource.Id.leftArrow);
            rightArrow = FindViewById<ImageView>(Resource.Id.rightArrow);
            day1btn = FindViewById<Button>(Resource.Id.day_one_btn);
            day2btn = FindViewById<Button>(Resource.Id.day_two_btn);
            day3btn = FindViewById<Button>(Resource.Id.day_three_btn);
            day4btn = FindViewById<Button>(Resource.Id.day_four_btn);
            trackTitle = FindViewById<TextView>(Resource.Id.track_title);
            ReloadData();

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

            leftArrow.Click += (sender, e) =>
            {
                previousTrack();
            };

            rightArrow.Click += (sender, e) =>
            {
                nextTrack();
            };

            day1btn.Click += (sender, e) =>
            {
                day1btnClick();
            };

            day2btn.Click += (sender, e) =>
            {
                day2btnClick();
            };

            day3btn.Click += (sender, e) =>
            {
                day3btnClick();
            };

            day4btn.Click += (sender, e) =>
            {
                day4btnClick();
            };

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
            //Region beaconRegion = new Region("test", null, null, null);
            //beaconManager.StartMonitoring(beaconRegion);
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

        private void nextTrack()
        {
            if (tracks.Count > CurrentTrack + 1)
            {
                CurrentTrack++;
                ReloadData();
            }
        }

        private void previousTrack()
        {
            if (CurrentTrack >= 1)
            {
                CurrentTrack--;
                ReloadData();
            }
        }

        private void day1btnClick()
        {
            CurrentTrackDate = DateTime.Parse("6/20/2017");
            day1btn.SetBackgroundResource(Resource.Drawable.selected_day);
            day2btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day3btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day4btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            if(d2)
            {
                d2track = CurrentTrack;
                d2 = false;
                d1 = true;
            }
            else if(d3)
            {
                d3track = CurrentTrack;
                d3 = false;
                d1 = true;
            }
            else if(d4)
            {
                d4track = CurrentTrack;
                d4 = false;
                d1 = true;
            }
            else
            {
                d1track = CurrentTrack;
            }
            CurrentTrack = d1track;
            ReloadData();
        }

        private void day2btnClick()
        {
            CurrentTrackDate = DateTime.Parse("6/21/2017");
            day1btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day2btn.SetBackgroundResource(Resource.Drawable.selected_day);
            day3btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day4btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            if (d1)
            {
                d1track = CurrentTrack;
                d1 = false;
                d2 = true;
            }
            else if (d3)
            {
                d3track = CurrentTrack;
                d3 = false;
                d2 = true;
            }
            else if (d4)
            {
                d4track = CurrentTrack;
                d4 = false;
                d2 = true;
            }
            else
            {
                d2track = CurrentTrack;
            }
            CurrentTrack = d2track;
            ReloadData();
        }

        private void day3btnClick()
        {
            CurrentTrackDate = DateTime.Parse("6/22/2017");
            day1btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day2btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day3btn.SetBackgroundResource(Resource.Drawable.selected_day);
            day4btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            if (d1)
            {
                d1track = CurrentTrack;
                d1 = false;
                d3 = true;
            }
            else if (d2)
            {
                d2track = CurrentTrack;
                d2 = false;
                d3 = true;
            }
            else if (d4)
            {
                d4track = CurrentTrack;
                d4 = false;
                d3 = true;
            }
            else
            {
                d3track = CurrentTrack;
            }
            CurrentTrack = d3track;
            ReloadData();
        }

        private void day4btnClick()
        {
            CurrentTrackDate = DateTime.Parse("6/23/2017");
            day1btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day2btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day3btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day4btn.SetBackgroundResource(Resource.Drawable.selected_day);
            if (d1)
            {
                d1track = CurrentTrack;
                d1 = false;
                d4 = true;
            }
            else if (d2)
            {
                d2track = CurrentTrack;
                d2 = false;
                d4 = true;
            }
            else if (d3)
            {
                d3track = CurrentTrack;
                d3 = false;
                d4 = true;
            }
            else
            {
                d4track = CurrentTrack;
            }
            CurrentTrack = d4track;
            ReloadData();
        }

        private void ReloadData()
        {
            tracks = new List<Track>();
            foreach (var t in Store.Instance.Tracks)
            {
                if (t.TrackDate == CurrentTrackDate)
                {
                    tracks.Add(t);
                }
            }

            if (tracks.Count == 0)
            {
                //trackName.Text = string.Empty;
                tracks.Add(new Track("No Tracks Today", "-1", DateTime.Today, ""));
                leftArrow.Visibility = ViewStates.Invisible;
                rightArrow.Visibility = ViewStates.Invisible;
            }
            else
            {
                trackTitle.Text = tracks[CurrentTrack].Name;

                if (CurrentTrack == 0)
                {
                    leftArrow.Visibility = ViewStates.Invisible;
                }
                else
                {
                    leftArrow.Visibility = ViewStates.Visible;
                }

                if (CurrentTrack + 1 < tracks.Count)
                {
                    rightArrow.Visibility = ViewStates.Visible;
                }
                else
                {
                    rightArrow.Visibility = ViewStates.Invisible;
                }

                trackEvents = new List<Event>();
                foreach (var e in events)
                {
                    if (e.TrackId == tracks[CurrentTrack].Id)
                    {
                        trackEvents.Add(e);
                    }
                }

                trackEvents.Sort((x, y) => x.StartTime.Ticks.CompareTo(y.StartTime.Ticks));

            }

            ScheduleAdapter adapter = new ScheduleAdapter(this, trackEvents);
            scheduleList.Adapter = adapter;
            scheduleList.ItemClick += eventClick;
        }
        
        private void eventClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (!trackEvents[e.Position].ScheduleOnly)
            {
                Store.Instance.SelectedEvent = trackEvents[e.Position];
                //StartActivity(typeof(EventDetails));

				Intent i = new Intent(Application.Context, typeof(EventDetails));
				i.SetFlags(ActivityFlags.ReorderToFront);
				StartActivity(i);

            }
        }
    }
}