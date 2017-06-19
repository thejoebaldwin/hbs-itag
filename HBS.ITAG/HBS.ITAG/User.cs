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
using HBS.ITAG.Model;

namespace HBS.ITAG
{
    class OldUser
    {
        public string Id { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string PositionTitle { get; set; }
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }
        public string TechFocus { get; set; }
        public string OrganizationAnswer { get; set; }


        public OldUser( string id, string age, string gender, string positionTitle, string deviceId, string deviceType, string techFocus, string organizationAnswer)
        {
            Id = id;
            Age = age;
            Gender = gender;
            PositionTitle = positionTitle;
            DeviceId = deviceId;
            DeviceType = deviceType;
            TechFocus = techFocus;
            OrganizationAnswer = organizationAnswer;

        }

        public static OldUser FromJson(string json)
        {
            System.Collections.Generic.Dictionary<string, string> data = HBS.ITAG.Client.Utilities.ParseJson(json);

            //dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);


            int id = System.Convert.ToInt32(data["user_id"]);
            string state = data["state"];
            string age = data["age"];
            string gender = data["gender"];
            string jobTitle = data["job_title"];
            string email = data["email"];
            Boolean emailNotifications = System.Convert.ToBoolean(data["email_notifications"]);

            // Have these link to JSON calls once that is set up.
            int[] favoritedEvents = null;
            Event[] fullFavoritedEvents = null;

            return null;
            //return new OldUser( id, state, age, gender, jobTitle, email, emailNotifications, favoritedEvents, fullFavoritedEvents);
        }
    }
}