using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;

namespace HBS.ITAG
{
    [Activity(Label = "JsonCallTester")]
    public class JsonCallTester : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.JsonCallTester);

            // Create your application here
            // StreamReader reader = new StreamReader(Android.App.Application.Context.Assets.Open("events.txt"));
            //string json = reader.ReadToEnd();
            //StreamReader reader2 = new StreamReader(Android.App.Application.Context.Assets.Open("tracks.txt"));
            // string json2 = reader.ReadToEnd();
            /* System.Collections.Generic.Dictionary<string, string> data = HBS.ITAG.Client.Utilities.ParseJson(json);
             string eventJson = data["events"];
             string[] events = HBS.ITAG.Client.Utilities.ParseJsonArray(eventJson);
             ArrayList arrEvents = new ArrayList();
             foreach (string s in events)
             {
                 Event tempEvent = Event.FromJson(s);
                 arrEvents.Add(tempEvent);
             }
             Console.WriteLine("here");
             for (int i = 0; i < arrEvents.Capacity; i++)
             {
                 Console.WriteLine(arrEvents.IndexOf(i));
             } */

           /* List<Event> events = Store.Instance.Events;
            List<Track> tracks = Store.Instance.Tracks;
            Console.WriteLine("here");
            

            String test = events[0].Name + System.Environment.NewLine + tracks[0].Name;
            Char[] testArr = test.ToCharArray();

            TextView view = FindViewById<TextView>(Resource.Id.JCTtextView1);
            view.SetText(testArr, 0, testArr.Length); */

        }
    }
}