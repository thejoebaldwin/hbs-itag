using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HBS.ITAG
{
    class Session
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }

        public Session(int id, DateTime time, int eventId, int userId)
        {
            Id = id;
            Time = time;
            EventId = eventId;
            UserId = userId;
        }

        public static Session FromJson(string json)
        {
            System.Collections.Generic.Dictionary<string, string> data = HBS.ITAG.Client.Utilities.ParseJson(json);

            //dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);


            int id = System.Convert.ToInt32(data["user_id"]);
            DateTime time = DateTime.Parse(data["track_date"]);
            int eventId = System.Convert.ToInt32(data["event_id"]);
            int userId = System.Convert.ToInt32(data["user_id"]);

            return new Session(id, time, eventId, userId);
        }

    }
}