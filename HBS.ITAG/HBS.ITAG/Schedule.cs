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
    [Activity(Label = "Schedule", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Schedule : Activity
    {
        private List<Event> events = new List<Event>(Store.Instance.Events);
        private List<Event> trackEvents = new List<Event>();
        private List<Track> tracks = new List<Track>();
        private DateTime CurrentTrackDate;
        private int CurrentTrack;
        private ListView scheduleList;

        ImageView leftArrow;
        ImageView rightArrow;
        Button day1btn;
        Button day2btn;
        Button day3btn;
        Button day4btn;
        TextView trackTitle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Schedule);

            CurrentTrackDate = DateTime.Parse("6/20/2017");
            CurrentTrack = 0;
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
                StartActivity(typeof(Schedule));
            };

            ImageButton Profileimagebutton = FindViewById<ImageButton>(Resource.Id.profileimage);
            Profileimagebutton.Click += (sender, e) =>
            {
                StartActivity(typeof(MyEvents));
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
        }


        private void nextTrack()
        {
            if(tracks[CurrentTrack + 1] != null)
            {
                CurrentTrack++;
                ReloadData();
            }
        }

        private void previousTrack()
        {
            if(tracks[CurrentTrack - 1] != null)
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
            CurrentTrack = 0;
            ReloadData();
        }

        private void day2btnClick()
        {
            CurrentTrackDate = DateTime.Parse("6/21/2017");
            day1btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day2btn.SetBackgroundResource(Resource.Drawable.selected_day);
            day3btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day4btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            CurrentTrack = 0;
            ReloadData();
        }

        private void day3btnClick()
        {
            CurrentTrackDate = DateTime.Parse("6/22/2017");
            day1btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day2btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day3btn.SetBackgroundResource(Resource.Drawable.selected_day);
            day4btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            CurrentTrack = 0;
            ReloadData();
        }

        private void day4btnClick()
        {
            CurrentTrackDate = DateTime.Parse("6/23/2017");
            day1btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day2btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day3btn.SetBackgroundResource(Resource.Drawable.unselected_day);
            day4btn.SetBackgroundResource(Resource.Drawable.selected_day);
            CurrentTrack = 0;
            ReloadData();
        }

        private void ReloadData()
        {
            tracks = new List<Track>();
            foreach(var t in Store.Instance.Tracks)
            {
                if(t.TrackDate == CurrentTrackDate)
                {
                    tracks.Add(t);
                }
            }

            if(tracks.Count == 0)
            {
                //trackName.Text = string.Empty;
                tracks.Add(new Track("No Tracks Today", "-1", DateTime.Today, ""));
                leftArrow.Visibility = ViewStates.Invisible;
                rightArrow.Visibility = ViewStates.Invisible;
            }
            else
            {
                trackTitle.Text = tracks[CurrentTrack].Name;

                if(CurrentTrack == 0)
                {
                    leftArrow.Visibility = ViewStates.Invisible;
                }
                else
                {
                    leftArrow.Visibility = ViewStates.Visible;
                }

                if(CurrentTrack == tracks.Count - 1 || tracks.Count == 0)
                {
                    rightArrow.Visibility = ViewStates.Invisible;
                }
                else
                {
                    rightArrow.Visibility = ViewStates.Visible;
                }

                trackEvents = new List<Event>();
                foreach(var e in events)
                {
                    if(e.TrackId == tracks[CurrentTrack].Id)
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
            if(!trackEvents[e.Position].ScheduleOnly)
            {
                Store.Instance.SelectedEvent = trackEvents[e.Position];
                StartActivity(typeof(EventDetails));
            }
        }
    }
}