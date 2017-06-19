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
    [Activity(Label = "My Events", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MyEvents : Activity
    {
        private List<Event> favoritedEvents;
        private List<Event> previousEvents;
        private ListView favoritedList;
        private ListView previousList;
        private List<Event> events = new List<Event>(Store.Instance.Events);

        //public string clickIndex { get; set; }
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyEvents);

            // Populates Favorited Events table
            favoritedList = FindViewById<ListView>(Resource.Id.MElistView1);
            
            favoritedEvents = new List<Event>();

            foreach(var e in events)
            {
                //if(e.Favorited && e.EndTime.Ticks <= DateTime.Now.Ticks)
                //{
                    favoritedEvents.Add(e);
                //}
            }
            //for (int i = 0; i < events.Capacity; i++)
            //{
            //    if (events[i].Favorited)
            //    {
            //        mItems.Add(events[i].Name);
            //    }

            //}
            MyEventsFavoritesListViewAdapter adapter = new MyEventsFavoritesListViewAdapter(this, Android.Resource.Layout.SimpleListItem2, favoritedEvents);
            favoritedList.Adapter = adapter;
            favoritedList.ItemClick += mListView_ItemClick;

            // Populates Previous Events table
            previousEvents = new List<Event>();

            foreach(var e in events)
            {
               // if(e.Favorited && e.EndTime.Ticks > DateTime.Now.Ticks)
                //{
                    previousEvents.Add(e);
               // }
            }
            //for (int i = 0; i < events.Count; i++)
            //{
            //    if (events[i].Favorited)
            //    {
            //        mItems2.Add(events[i].Name);
            //    }

            //}
            

            previousList = FindViewById<ListView>(Resource.Id.MElistView2);
            MyEventsPreviousEventsListViewAdapter adapter2 = new MyEventsPreviousEventsListViewAdapter(this, previousEvents);
            previousList.Adapter = adapter2;
            previousList.ItemClick += mListView2_ItemClick;

            

            // Code for nav bar

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
            
        }


        // Code for clicking items on ListView

        private void mListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Event value = favoritedEvents[e.Position];
            Store.Instance.SelectedEvent = favoritedEvents[e.Position];
            /*
           for (int i = 0; i < events.Capacity; i++)
            {
                if (events[i].Name == value)
                {
                    clickIndex = events[i].Id;
                }

            } */ 
            StartActivity(typeof(EventDetails));
            
        }

        private void mListView2_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Store.Instance.SelectedEvent = previousEvents[e.Position];
            StartActivity(typeof(EventDetails));
        }
    }
}