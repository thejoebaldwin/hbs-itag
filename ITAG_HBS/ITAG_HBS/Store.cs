using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

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

        public void LoadTracksFromFile()
        {
            //open android asset text file
          

             string json =  System.IO.File.ReadAllText("Tracks.txt");

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
			string json = System.IO.File.ReadAllText("Events.txt");

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
