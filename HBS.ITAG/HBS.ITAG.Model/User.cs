﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBS.ITAG.Model
{
    public class User
    {
        public string Id { get; set; }
        public string Age { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        public string PositionTitle { get; set; }
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }

        //new objects for updated survey page
        public string TechFocus { get; set; }
        public string Organization { get; set; }

        public User(string id, string age, string gender, string positionTitle, string state, string deviceType, string deviceId)
        {
            Id = id;
            Age = age;
            Gender = gender;
            PositionTitle = positionTitle;
            State = state;
            DeviceType = deviceType;
            DeviceId = deviceId;
        }

        public User(string id, string age, string gender, string techFocus, string organization, string positionTitle, string deviceType, string deviceId)
        {
            Id = id;
            Age = age;
            Gender = gender;
            TechFocus = techFocus;
            Organization = organization;
            PositionTitle = positionTitle;
            DeviceType = deviceType;
            DeviceId = deviceId;
        }

        public static User FromJson(string json)
        {
            System.Collections.Generic.Dictionary<string, string> data = HBS.ITAG.Model.Utilities.ParseJson(json);
            string id = data["user_id"];
            string age = data["age"];
            string gender = data["gender"];
            string techFocus = data["tech_focus"];
            string organization = data["organization"];
            string positionTitle = data["position_title"];
            string state = data["state"];
            string deviceType = data["device_type"];
            string deviceId = data["device_id"];
            return new User(id, age, gender, techFocus, organization, positionTitle, deviceType, deviceId);
        }
    }
}
