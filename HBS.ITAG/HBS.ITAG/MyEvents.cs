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

namespace HBS.ITAG
{
    [Activity(Label = "My Events", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MyEvents : Activity
    {
        private List<string> mItems;
        private ListView mListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyEvents);
            mListView = FindViewById<ListView>(Resource.Id.MElistView1);


            List<Event> events = Store.Instance.Events;
            mItems = new List<string>();
            for ( int i = 0; i < 6; i++)
            {
                 mItems.Add(events[i].Name);
            }
           

            //mItems.Add("Bob");
            //mItems.Add("Jim");
            //mItems.Add("Tom");

            
            ListViewAdapter adapter = new ListViewAdapter(this, mItems);
            mListView.Adapter = adapter;




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
            
           /* TextView firstInScrollBar = FindViewById<TextView>(Resource.Id.MEtextView3);

            firstInScrollBar.Click += (object sender, EventArgs e) =>
            {
                StartActivity(typeof(EventDetails));
            }; */
        }
    }
}