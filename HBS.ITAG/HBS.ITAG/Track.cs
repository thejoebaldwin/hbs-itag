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
    class Track
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime TrackDate { get; set; }
        public int BeaconGuid { get; set; }

        public Track (string name,int id, DateTime trackDate, int beaconGuid)
        {
            Name = name;
            Id = id;
            TrackDate = trackDate;
            BeaconGuid = beaconGuid;
        }

        public static Track FromJson(string json)
        {
            System.Collections.Generic.Dictionary<string, string> data = HBS.ITAG.Client.Utilities.ParseJson(json);

            //dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            string name = data["name"];
            int id = System.Convert.ToInt32(data["track_id"]);
            DateTime trackDate = DateTime.Parse(data["track_date"]);
            int beaconGuid = System.Convert.ToInt32(data["beacon_guid"]);


            return new Track(name, id, trackDate, beaconGuid);
        }

    }
}