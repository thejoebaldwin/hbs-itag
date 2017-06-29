using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HBS.ITAG
{
    public class EventOld
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Presenter { get; set; }
        public string Summary { get; set; }
        public int Track { get; set; }
        public string EventWebId { get; set; }
        public Boolean ScheduleOnly { get; set; }

        public EventOld(string name, string id, DateTime startTime, DateTime endTime, string presenter, string summary, int track ,string eventWebId, Boolean scheduleOnly)
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

        public static EventOld FromJson(string json)
        {
            System.Collections.Generic.Dictionary<string, string> data = HBS.ITAG.Client.Utilities.ParseJson(json);

            //dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            string name = data["name"];
            string id = data["event_id"];
            DateTime startTime = DateTime.Parse(data["start_time"]);
            DateTime endTime = DateTime.Parse(data["end_time"]);
            string presenter = data["presenter"];
            string summary = data["summary"];
            int track = System.Convert.ToInt32(data["track_id"]);
            string eventWebId = data["event_web_id"];
            Boolean scheduleOnly = System.Convert.ToBoolean(data["schedule_only"]);

            return new EventOld(name, id, startTime, endTime, presenter, summary, track, eventWebId, scheduleOnly);
        }


    }
}