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
        private List<string> mItems;
        private List<string> mItems2;
        private ListView mListView;
        private ListView mListView2;
        private List<Event> events = Store.Instance.Events;

        //public string clickIndex { get; set; }
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyEvents);

            // Populates Favorited Events table
            mListView = FindViewById<ListView>(Resource.Id.MElistView1);
            
            mItems = new List<string>();
            for ( int i = 0; i < events.Capacity; i++)
            {
                if ( events[i].Favorited )
                {
                    mItems.Add(events[i].Name);
                }
                 
            } 
            MyEventsFavoritesListViewAdapter adapter = new MyEventsFavoritesListViewAdapter(this, mItems);
            mListView.Adapter = adapter;
            mListView.ItemClick += mListView_ItemClick;

            // Populates Previous Events table
            mItems2 = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                if (events[i].Favorited)
                {
                    mItems2.Add(events[i].Name);
                }

            }

            mListView2 = FindViewById<ListView>(Resource.Id.MElistView2);
            MyEventsPreviousEventsListViewAdapter adapter2 = new MyEventsPreviousEventsListViewAdapter(this, mItems2);
            mListView2.Adapter = adapter2;
            mListView2.ItemClick += mListView2_ItemClick;

            

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
            string value = mItems[e.Position];
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
            StartActivity(typeof(EventDetails));
        }
    }
}