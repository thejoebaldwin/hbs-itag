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
    public class Event
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Presenter { get; set; }
        public string Summary { get; set; }
        public string Track { get; set; }
        public string EventWebId { get; set; }
        public Boolean ScheduleOnly { get; set; }


        public Event(string name, string id, DateTime startTime, DateTime endTime, string presenter, string summary, string track , string eventWebId, Boolean scheduleOnly )
        {
            Name = name;
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
            Presenter = presenter;
            Summary = summary;
            Track = track;
            EventWebId = eventWebId;
            ScheduleOnly = scheduleOnly;
        }

        public static Event FromJson(string json)
        {
            System.Collections.Generic.Dictionary<string, string> data = HBS.ITAG.Client.Utilities.ParseJson(json);

            //dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            string name = data["name"];
            //int id = System.Convert.ToInt32(data["event_id"]);
            string id = data["event_id"];
            DateTime startTime = DateTime.Parse(data["start_time"]);
            DateTime endTime = DateTime.Parse(data["end_time"]);
            string presenter = data["presenter"];
            string summary = data["summary"];
            //int track = System.Convert.ToInt32(data["track_id"]);
            //int eventWebId = System.Convert.ToInt32(data["event_web_id"]);
            string track = data["track_id"];
            string eventWebId = data["event_web_id"];
            Boolean scheduleOnly = System.Convert.ToBoolean(data["schedule_only"]);

            return new Event(name, id, startTime, endTime, presenter, summary, track, eventWebId, scheduleOnly);
        }


    }
}