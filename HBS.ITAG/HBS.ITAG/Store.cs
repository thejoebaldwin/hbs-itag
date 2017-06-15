using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Xamarin;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HBS.ITAG
{
    public class Store
    {
		private static Store instance;

        public List<Event> Events;
        public List<Track> Tracks;

		private Store() { }

		public static Store Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Store();
                    instance.Init();
				}
				return instance;
			}
		}


		public void SaveKey(string key, string value)
		{
			var prefs = Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
			var prefEditor = prefs.Edit();
			prefEditor.PutString(key, value);
			prefEditor.Commit();
		}

		public void LoadTracksFromFile()
        {
            //open android asset text file
            StreamReader reader = new StreamReader(Android.App.Application.Context.Assets.Open("tracks.txt"));
            //read file
			string json = reader.ReadToEnd();
            //convert raw json into dictionary
            Dictionary<string, string> data = HBS.ITAG.Client.Utilities.ParseJson(json);
            //get tracks array json
            string[] arrTrackJson = HBS.ITAG.Client.Utilities.ParseJsonArray(data["tracks"]);
            //instantiate list for tracks
            Tracks = new List<Track>();
            //reach each raw track json, add to list
            foreach (string s in arrTrackJson)
            {
                Tracks.Add(Track.FromJson(s));
            }
        }

		public void LoadEventsFromFile()
		{
			//open android asset text file
			StreamReader reader = new StreamReader(Android.App.Application.Context.Assets.Open("events.txt"));
			//read file
			string json = reader.ReadToEnd();
			//convert raw json into dictionary
			Dictionary<string, string> data = HBS.ITAG.Client.Utilities.ParseJson(json);
			//get events array json
			string[] arrEventJson = HBS.ITAG.Client.Utilities.ParseJsonArray(data["events"]);
			//instantiate list for events
			Events = new List<Event>();
			//reach each raw event json, add to list
			foreach (string s in arrEventJson)
			{
				Events.Add(Event.FromJson(s));
			}
		}


		public void Init()
        {
            //get tracks
            //get events
            LoadTracksFromFile();
            LoadEventsFromFile();



        }
    }
}
