using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBS.ITAG.Client
{

    public class Event
    {

        public string Name { get; set; }
        public int Id { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Presenter { get; set; }
        public string Summary { get; set; }
        public int Track { get; set; }
        public int EventWebId { get; set; }


        public Event(string name, int id, DateTime startTime, DateTime endTime, string presenter, string summary, int eventWebId)
        {
            Name = name;
            Id = id;
       }

        public static Event FromJson(string json)
        {
            System.Collections.Generic.Dictionary<string, string> data = HBS.ITAG.Client.Utilities.ParseJson(json);

            //dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            string name = data["name"];
            int id = System.Convert.ToInt32(data["event_id"]);
            DateTime startTime = DateTime.Parse(data["start_time"]);
            DateTime endTime = DateTime.Parse(data["end_time"]);
            string presenter = data["presenter"];
            string summary = data["summary"];
            //int eventWebId = data["event_web_id"];

            return new Event(name, id, startTime, endTime, presenter, summary, -1);
        }
    }
}