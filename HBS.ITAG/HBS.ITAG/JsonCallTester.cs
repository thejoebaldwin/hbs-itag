using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using HBS.ITAG.Model;

namespace HBS.ITAG
{
    [Activity(Label = "JsonCallTester")]
    public class JsonCallTester : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.JsonCallTester);

            // Tests created for Events
            List<Event> events = Store.Instance.Events;
            Char[] testArrEvents = null;
            String testEvents = null;
            for (int i = 0; i < 5; i++)
            {
                testEvents = testEvents + "Event Name: " + events[i].Name + System.Environment.NewLine 
                    + "Event Id: " + events[i].Id + System.Environment.NewLine 
                    + "Event StartTime: " + events[i].StartTime + System.Environment.NewLine 
                    + "Event EndTime: " + events[i].EndTime + System.Environment.NewLine 
                    + "Event Presenter: " + events[i].Presenter + System.Environment.NewLine 
                    + "Event Summary: " + events[i].Summary + System.Environment.NewLine 
                    + "Event TrackId: " + events[i].Track + System.Environment.NewLine
                    + "Event EventWebId: " + events[i].EventWebId + System.Environment.NewLine
                    + "Event ScheduleOnly: " + events[i].ScheduleOnly + System.Environment.NewLine
                    + System.Environment.NewLine;
            }
            testArrEvents = testEvents.ToCharArray();
            TextView view1 = FindViewById<TextView>(Resource.Id.JCTtextView1);
            view1.SetText(testArrEvents, 0, testArrEvents.Length - 1);

            // Tests created for Tracks
            List<Track> tracks = Store.Instance.Tracks;
            Char[] testArrTracks = null;
            String testTracks = null;
            for (int i = 0; i < 3; i++)
            {
                testTracks = testTracks + "Track Name: " + tracks[i].Name + System.Environment.NewLine 
                    + "Track Id: " + tracks[i].Id + System.Environment.NewLine 
                    + "Track Date: " + tracks[i].TrackDate + System.Environment.NewLine 
                    + "Track BeaconGuid: "   + tracks[i].BeaconGuid + System.Environment.NewLine 
                    + System.Environment.NewLine;
            }
            testArrTracks = testTracks.ToCharArray();
            TextView view2 = FindViewById<TextView>(Resource.Id.JCTtextView2);
            view2.SetText(testArrTracks, 0, testArrTracks.Length - 1);


            // Tests created for Users

            /*
            List<User> users = Store.Instance.Users;
            Char[] testArrUsers = null;
            String testUsers = null;
            for (int i = 0; i < users.Capacity - 1; i++)
            {
                testUsers = testUsers + "User Id: " + users[i].Id + System.Environment.NewLine
                    + "User State: " + users[i].State + System.Environment.NewLine
                    + "User Age: " + users[i].Age + System.Environment.NewLine
                    + "User Gender: " + users[i].Gender + System.Environment.NewLine
                    + "User JobTitle: " + users[i].JobTitle + System.Environment.NewLine
                    + "User Email: " + users[i].Email + System.Environment.NewLine
                    + "User EmailNotification: " + users[i].EmailNotifications + System.Environment.NewLine
                    + "User FavoritedEvents: " + users[i].FavoritedEvents + System.Environment.NewLine
                    + "User FullFavoritedEvents: " + users[i].FullFavoritedEvents + System.Environment.NewLine
                    + System.Environment.NewLine;
            }
            testArrUsers = testUsers.ToCharArray();
            TextView view3 = FindViewById<TextView>(Resource.Id.JCTtextView3);
            view3.SetText(testArrUsers, 0, testArrUsers.Length - 1);
            */


            // Tests created for Sessions

            /*
            List<Session> sessions = Store.Instance.Sessions;
            Char[] testArrSessions = null;
            String testSessions = null;
            for (int i = 0; i < sessions.Capacity - 1; i++)
            {
                testSessions = testSessions + "Session Id: " + sessions[i].Id + System.Environment.NewLine
                    + "Session Time: " + sessions[i].Time + System.Environment.NewLine
                    + "Session EventId: " + sessions[i].EventId + System.Environment.NewLine
                    + "Session UserId: " + sessions[i].UserId + System.Environment.NewLine
                    + System.Environment.NewLine;
            }
            testArrSessions = testSessions.ToCharArray();
            TextView view3 = FindViewById<TextView>(Resource.Id.JCTtextView4);
            view3.SetText(testArrSessions, 0, testArrSessions.Length - 1);
            */

        }
    }
}