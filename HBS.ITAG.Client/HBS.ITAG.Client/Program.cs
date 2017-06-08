using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace HBS.ITAG.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = System.IO.File.ReadAllText("../../events.txt");
            System.Collections.Generic.Dictionary<string, string> data = HBS.ITAG.Client.Utilities.ParseJson(json);
            string eventJson = data["events"];
            string[] events = HBS.ITAG.Client.Utilities.ParseJsonArray(eventJson);
            ArrayList arrEvents = new ArrayList();
            foreach (string s in events)
            {
                Event tempEvent = Event.FromJson(s);
                arrEvents.Add(tempEvent);
            }
        }
    }
}
