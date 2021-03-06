﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBS.ITAG.Model
{

    public class Event
    {
        private Event @event;
        private Event e;

        public string Name { get; set; }
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Presenter { get; set; }
        public string Summary { get; set; }
        public string TrackId { get; set; }
        public bool ScheduleOnly { get; set; }
        public string LocationId { get; set; }
        public string EventWebId { get; set; }
        public DateTime LastEntryNotified { get; set; }
        public DateTime LastExitNotified { get; set; }
        public int Track { get; set; }
        public bool Favorited { get; set; }
        public int NumberOfPeople { get; set; }

        public Event(string name, string id, DateTime startTime, DateTime endTime, string presenter, string summary, string eventWebId, string trackId, string locationId, bool scheduleOnly)
        {
            Name = name;
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Presenter = presenter;
            Summary = summary;
            EventWebId = eventWebId;
            TrackId = trackId;
            LocationId = locationId;
            ScheduleOnly = scheduleOnly;
            Favorited = false;
            LastEntryNotified = DateTime.Now.AddMinutes(-30);
            LastExitNotified = DateTime.Now.AddMinutes(-30);
            NumberOfPeople = 0;
        }

		public Event(string name, string id, DateTime startTime, DateTime endTime, string presenter, string summary, string eventWebId, string trackId, string locationId, bool scheduleOnly, List<EventSurvey> surveys)
		{
			Name = name;
			Id = id;
			StartTime = startTime;
			EndTime = endTime;
			Presenter = presenter;
			Summary = summary;
			EventWebId = eventWebId;
			TrackId = trackId;
			LocationId = locationId;
			ScheduleOnly = scheduleOnly;
			Favorited = false;
			LastEntryNotified = DateTime.Now.AddMinutes(-30);
			LastExitNotified = DateTime.Now.AddMinutes(-30);
			NumberOfPeople = 0;
		}

		public Event(string name, string id, DateTime startTime, DateTime endTime, string presenter, string summary, string eventWebId, string trackId, string locationId, bool scheduleOnly, int numberOfPeople)
		{
			Name = name;
			Id = id;
			StartTime = startTime;
			EndTime = endTime;
			Presenter = presenter;
			Summary = summary;
			EventWebId = eventWebId;
			TrackId = trackId;
			LocationId = locationId;
			ScheduleOnly = scheduleOnly;
			Favorited = false;
			LastEntryNotified = DateTime.Now.AddMinutes(-30);
			LastExitNotified = DateTime.Now.AddMinutes(-30);
            NumberOfPeople = numberOfPeople;
		}

		//public Event(string name, string id, DateTime startTime, DateTime endTime, string presenter, string summary, string eventWebId, string trackId, string locationId, bool scheduleOnly, List<EventSurvey> surveys ,int numberOfPeople)
		//{
		//	Name = name;
		//	Id = id;
		//	StartTime = startTime;
		//	EndTime = endTime;
		//	Presenter = presenter;
		//	Summary = summary;
		//	EventWebId = eventWebId;
		//	TrackId = trackId;
		//	LocationId = locationId;
		//	ScheduleOnly = scheduleOnly;
		//	Favorited = false;
		//	LastEntryNotified = DateTime.Now.AddMinutes(-30);
		//	LastExitNotified = DateTime.Now.AddMinutes(-30);
		//	NumberOfPeople = numberOfPeople;
		//}

        public Event()
        {
        }

        public Event(Event e)
        {
            this.Name = e.Name;
            this.EndTime = e.EndTime;
            this.StartTime = e.StartTime;
            this.EventWebId = e.EventWebId;
            this.Id = e.Id;
            this.Presenter = e.Presenter;
            this.LocationId = e.LocationId;
            this.ScheduleOnly = e.ScheduleOnly;
            this.Favorited = e.Favorited;
            this.Summary = e.Summary;
            this.NumberOfPeople = e.NumberOfPeople;
        }

        public static Event FromJson(string json)
        {
            System.Collections.Generic.Dictionary<string, string> data = HBS.ITAG.Model.Utilities.ParseJson(json);

            //dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            string name = data["name"];
            string id = data["event_id"];
            DateTime startTime = DateTime.Parse(data["start_time"]);
            DateTime endTime = DateTime.Parse(data["end_time"]);
            string presenter = data["presenter"];
            string trackId = data["track_id"];
            string locationId = data["location_id"];
            bool scheduleOnly = false;
            if (data["schedule_only"].ToLower() == "true")
            {
                scheduleOnly = true;
            }

            string eventWebId = "-1";
            if (data.ContainsKey("event_web_id"))
            {
                eventWebId = data["event_web_id"];
            }

            string summary = data["summary"];
            int numberOfPeople = Int32.Parse(data["number_of_people"]);
            return new Event(name, id, startTime, endTime, presenter, summary, eventWebId, trackId, locationId, scheduleOnly, numberOfPeople);
        }
    }
}