using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBS.ITAG.Model
{

    public class Event
    {

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
		public int Track { get; set; }
        public bool Favorited { get; set; }

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
            return new Event(name, id, startTime, endTime, presenter, summary, eventWebId, trackId, locationId, scheduleOnly);
        }
    }
}