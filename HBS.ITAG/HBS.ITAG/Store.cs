﻿using System;
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
using HBS.ITAG.Model;

namespace HBS.ITAG
{
    public class OldStore
    {
		private static OldStore instance;

        public List<Event> Events;
        public List<Track> Tracks;

		private OldStore() { }

		public static OldStore Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new OldStore();
                    instance.Init();
				}
				return instance;
			}
		}
        private ArrayList _arrFavoriteIds;

        public void InitializeFavorites()
        {
            if (_arrFavoriteIds == null)
            {
                var prefs = Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
                string favorites = prefs.GetString("favorites", string.Empty);
                string[] arrFavorites = favorites.Split(',');
                _arrFavoriteIds = new ArrayList();
                for (int i = 0; i < arrFavorites.Length; i++)
                {
                    _arrFavoriteIds.Add(arrFavorites[i]);
                }
                if (Store.Instance.Events != null)
                {
                    for (int i = 0; i < Store.Instance.Events.Count; i++)
                    {
                        if (IsFavorite(Store.Instance.Events[i]))
                        {
                            Store.Instance.Events[i].Favorited = true;
                        }
                    }
                }
            }
        }

		public bool IsFavorite(Event favoriteEvent)
		{
			bool isFavorite = false;
			for (int i = 0; i < _arrFavoriteIds.Count; i++)
			{
				if ((string) _arrFavoriteIds[i] == favoriteEvent.Id)
				{
					isFavorite = true;
					break;
				}
			}
			return isFavorite;
		}


		public void AddFavorite(Event favoriteEvent)
		{
			favoriteEvent.Favorited = true;
			if (!_arrFavoriteIds.Contains(favoriteEvent.Id))
			{
				_arrFavoriteIds.Add(favoriteEvent.Id);
			}
			string favorites = string.Empty;
			for (int i = 0; i < _arrFavoriteIds.Count; i++)
			{
				if (favorites != string.Empty) favorites += ",";
				favorites += _arrFavoriteIds[i];
			}

			var prefs = Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
			var prefEditor = prefs.Edit();
			prefEditor.PutString("favorites", favorites);
			prefEditor.Commit();
		}



		public void DeleteFavorite(Event favoriteEvent)
		{
			favoriteEvent.Favorited = false;
			if (_arrFavoriteIds.Contains(favoriteEvent.Id))
			{
				_arrFavoriteIds.Remove(favoriteEvent.Id);
			}

			string favorites = string.Empty;
			for (int i = 0; i < _arrFavoriteIds.Count; i++)
			{
				if (favorites != string.Empty) favorites += ",";
				favorites += _arrFavoriteIds[i];
			}

			var prefs = Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
			var prefEditor = prefs.Edit();
			prefEditor.PutString("favorites", favorites);
			prefEditor.Commit();


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
