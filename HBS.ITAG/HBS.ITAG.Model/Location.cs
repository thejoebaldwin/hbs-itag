using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBS.ITAG.Model
{
    public class Location
    {

        public string Name { get; set; }
        public string Id { get; set; }
        public string BeaconGuid { get; set; }
        public string Minor { get; set; }
        public string Major { get; set; }
        public string Nickname { get; set; }

        public Location(string name, string id, string beaconGuid, string nickname, string minor, string major)
        {
            Name = name;
            Id = id;
            Nickname = nickname;
            BeaconGuid = beaconGuid;
            Major = major;
            Minor = minor;
        }

        public static Location FromJson(string json)
        {
            System.Collections.Generic.Dictionary<string, string> data = HBS.ITAG.Model.Utilities.ParseJson(json);

            //dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);

            string name = data["name"];
            string id = data["id"];
            string beaconGuid = data["beacon_guid"];
            string major = data["major"];
            string minor = data["minor"];
            string nickname = data["nickname"];

            return new Location(name, id, beaconGuid, nickname, minor, major);
        }


    }

}
