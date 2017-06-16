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
        public int Id { get; set; }
        public string State { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public Boolean EmailNotifications { get; set; }
        public int[] FavoritedEvents { get; set; }
        public Event[] FullFavoritedEvents { get; set; }


        public OldUser(int id, string state, string age, string gender, string jobTitle, string email, Boolean emailNotifications, int[] favoritedEvents, Event[] fullFavoritedEvents)
        {
            Id = id;
            State = state;
            Age = age;
            Gender = gender;
            JobTitle = jobTitle;
            Email = email;
            EmailNotifications = emailNotifications;
            FavoritedEvents = favoritedEvents;
            FullFavoritedEvents = fullFavoritedEvents;

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


            return new OldUser( id, state, age, gender, jobTitle, email, emailNotifications, favoritedEvents, fullFavoritedEvents);
        }
    }
}