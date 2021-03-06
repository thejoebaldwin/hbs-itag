﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Globalization;
using HBS.ITAG.Models;

namespace HBS.ITAG
{
    public class Utilities
    {

        public static String[] ParseJsonArray(string responseData)
        {
            responseData = responseData.Replace("[", string.Empty);
            responseData = responseData.Replace("]", string.Empty);
            string[] splitString = { "},{" };
            String[] arrTemp = responseData.Split(splitString, StringSplitOptions.None);
            for (int i = 0; i < arrTemp.Length; i++)
            {
                if (!arrTemp[i].StartsWith("{"))
                {
                    arrTemp[i] = "{" + arrTemp[i];
                }
                if (!arrTemp[i].EndsWith("}"))
                {
                    arrTemp[i] = arrTemp[i] + "}";
                }
            }

            return arrTemp;
        }

        /// <summary>
        /// Will Process json nested 1 level deep. Nested json will be original string value and require parsing to extract values into separate dictionary
        /// </summary>
        /// <param name="responseData"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ParseJson(string responseData)
        {
            try
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                responseData = responseData.Replace("\n", string.Empty);
                responseData = responseData.Substring(1, responseData.Length - 2);

                //loop through and look for "{".
                //if found { then look for end }. 
                //take the entire substring out and store in hash table, replace with [0],[1]. etc and use that has hash key
                //proceed as normal with splitting out rest of json
                //at the end, loop through the dictionary and test if the value containskey in the hashtable
                //if it does, then replace it with the value from the hash table.

                System.Collections.Hashtable hashJson = new System.Collections.Hashtable();

                int startSubstring = -1;
                int endSubString = -1;
                int subStringCount = 0;
                string adjustedresponseData = responseData;

                //look for arrays
                for (int i = 0; i < responseData.Length; i++)
                {
                    if (responseData[i] == '[')
                    {
                        startSubstring = i;
                    }
                    else if (responseData[i] == ']')
                    {
                        endSubString = i;
                        string tempSubstring = responseData.Substring(startSubstring, endSubString - startSubstring + 1);
                        hashJson.Add("**" + subStringCount.ToString() + "**", tempSubstring);
                        adjustedresponseData = adjustedresponseData.Replace(tempSubstring, "**" + subStringCount.ToString() + "**");
                        startSubstring = -1;
                        endSubString = -1;
                        subStringCount++;
                    }
                }
                responseData = adjustedresponseData;

                //look for nested entities
                for (int i = 0; i < responseData.Length; i++)
                {
                    if (responseData[i] == '{')
                    {
                        startSubstring = i;
                    }
                    else if (responseData[i] == '}')
                    {
                        endSubString = i;
                        string tempSubstring = responseData.Substring(startSubstring, endSubString - startSubstring + 1);
                        hashJson.Add("**" + subStringCount.ToString() + "**", tempSubstring);
                        adjustedresponseData = adjustedresponseData.Replace(tempSubstring, "**" + subStringCount.ToString() + "**");
                        startSubstring = -1;
                        endSubString = -1;
                        subStringCount++;
                    }
                }


                //flag json commas so text commas don't break split
                adjustedresponseData = adjustedresponseData.Replace("\",", "$$$$$$$$$$");
                string[] splitString = { "$$$$$$$$$$" };
                string[] arrData = adjustedresponseData.Split(splitString, StringSplitOptions.None);
                foreach (string s in arrData)
                {
                    splitString = new string[] { "\":" };
                    string name = s.Split(splitString, StringSplitOptions.None)[0];

                    name = name.Replace("\"", string.Empty);
                    name = name.Replace("\t", string.Empty);


                    name = name.Trim();
                    string value = s.Split(splitString, StringSplitOptions.None)[1];
                    value = value.Replace("\"", string.Empty);
                    value = value.Trim();
                    data.Add(name, value);
                }

                Dictionary<string, string> tempDictionary = new Dictionary<string, string>(data);

                foreach (KeyValuePair<string, string> entry in tempDictionary)
                {

                    if (hashJson.ContainsKey(entry.Value))
                    {
                        string realValue = (string)hashJson[entry.Value];
                        data[entry.Key] = realValue;
                    }
                }


                return data;
            }
            catch (Exception ex)
            {
                throw new Exception("Error Parsing Json, Please check that it is formed properly");
            }
        }

        public static string TimeAgo(DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {

                result = string.Format("{0} seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("about {0} minutes ago", timeSpan.Minutes) :
                    "about a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("about {0} hours ago", timeSpan.Hours) :
                    "about an hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("about {0} days ago", timeSpan.Days) :
                    "yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("about {0} months ago", timeSpan.Days / 30) :
                    "about a month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("about {0} years ago", timeSpan.Days / 365) :
                    "about a year ago";
            }

            return result;
        }


    }


    public class Client
    {
        System.Net.HttpWebRequest _Request;
        string _AccessToken;
        string _UserId;
        string _ConnectionUrl;
        string _Response = string.Empty;
        string _Operation = "";
        public delegate void Action(string message);
        private Action _Completion;
        private List<Event> _arrEvents;
        private List<Location> _arrLocations;
        private List<Track> _arrTracks;
        private List<User> _arrUsers;

        private string _deviceId;
        private List<string> _purchasedThemes;

        public User CurrentUser { get; set; }

        public string AccessToken
        {
            get { return _AccessToken; }
        }

        public List<Event> Events
        {
            get { return _arrEvents; }
        }

        public List<Track> Tracks
        {
            get { return _arrTracks; }
        }

        public List<User> Users
        {
            get { return _arrUsers; }
        }

        public List<Location> Locations
        {
            get { return _arrLocations; }
        }



        public Client(string connectionUrl)
        {
            _ConnectionUrl = connectionUrl;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }


        public void UpdateTrack(Track updatedTrack, Action completion)
        {
            _Operation = "update_track";
            string trackDate = updatedTrack.TrackDate.ToString();

            //string json = "{\"event_id\":\"" + updatedEvent.Id + "\",\"schedule_only\": \"" + updatedEvent.ScheduleOnly.ToString() + "\",\"event_web_id\": \"" + updatedEvent.EventWebId + "\",\"name\": \"" + updatedEvent.Name +  "\",\"end_time\": \"" + endTime + "\",\"start_time\": \"" + startTime +   "\",\"track_id\": \"" + updatedEvent.TrackId + "\",\"location_id\":\"" + updatedEvent.LocationId + "\"}";
            string json = "{\"track_id\":\"<track_id>\",\"beacon_guid\": \"<beacon_guid>\",\"name\": \"<name>\",";
            json += "\"track_date\": \"<track_date>\"}";

            json = json.Replace("<track_id>", updatedTrack.Id);
            json = json.Replace("<beacon_guid>", updatedTrack.BeaconGuid);
            json = json.Replace("<name>", updatedTrack.Name);
            json = json.Replace("<track_date>", trackDate);

            _Completion = completion;
            PostDataWithOperation("tracks", json, "PUT");
        }

        public void AddTrack(Track newTrack, Action completion)
        {
            _Operation = "add_track";
            string trackDate = newTrack.TrackDate.ToString();

            string json = "{\"beacon_guid\": \"<beacon_guid>\",\"name\": \"<name>\",";
            json += "\"track_date\": \"<track_date>\"}";

            json = json.Replace("<beacon_guid>", newTrack.BeaconGuid);
            json = json.Replace("<name>", newTrack.Name);
            json = json.Replace("<track_date>", trackDate);

            _Completion = completion;
            PostDataWithOperation("tracks", json, "POST");
        }

        public void AddEvent(Event newEvent, Action completion)
        {
            _Operation = "add_event";
            
            string startTime = newEvent.StartTime.ToString();
            string endTime = newEvent.EndTime.ToString();

            string json = "{\"schedule_only\": \"<schedule_only>\",\"event_web_id\": \"<event_web_id>\",";
            json += "\"name\": \"<name>\",\"end_time\": \"<end_time>\",\"start_time\": \"<start_time>\",\"track_id\": \"<track_id>\",";
            json += "\"location_id\":\"<location_id>\", \"summary\":\"<summary>\", \"presenter\":\"<presenter>\", \"event_web_id\":\"<event_web_id>\"}";
            
            json = json.Replace("<schedule_only>", newEvent.ScheduleOnly.ToString().ToLower());
            json = json.Replace("<event_web_id>", newEvent.EventWebId);
            json = json.Replace("<name>", newEvent.Name);
            json = json.Replace("<end_time>", endTime);
            json = json.Replace("<start_time>", startTime);
            json = json.Replace("<track_id>", newEvent.TrackId);
            json = json.Replace("<location_id>", newEvent.LocationId);
            json = json.Replace("<summary>", newEvent.Summary);
            json = json.Replace("<presenter>", newEvent.Presenter);
            json = json.Replace("<event_web_id>", newEvent.EventWebId);

            _Completion = completion;
            PostDataWithOperation("events", json, "POST");
        }

        public void DeleteUser(User deleteUser, Action completion)
        {
            _Operation = "delete_user";
            string json = "{\"user_id\":\"<user_id>\" }";
            json = json.Replace("<user_id>", deleteUser.Id);
            _Completion = completion;
            PostDataWithOperation("users", json, "DELETE");
        }

        public void AddUser(User newUser, Action completion)
        {
            _Operation = "add_user";
            string json = "{\"user_id\":\"<user_id>\", \"gender\":\"<gender>\", \"age\":\"<age>\",\"state\":\"<state>\",";
            json += "\"position_title\":\"<position_title>\",\"device_type\":\"<device_type>\",\"device_id\":\"<device_id>\"    }";
            json = json.Replace("<user_id>", newUser.Id);
            json = json.Replace("<gender>", newUser.Gender);
            json = json.Replace("<age>", newUser.Age);
            json = json.Replace("<state>", newUser.State);
            json = json.Replace("<position_title>", newUser.PositionTitle);
            json = json.Replace("<device_type>", newUser.DeviceType);
            json = json.Replace("<device_id>", newUser.DeviceId);
            _Completion = completion;
            PostDataWithOperation("users", json, "POST");
        }

        public void DeleteEvent(Event updatedEvent, Action completion)
        {
            _Operation = "delete_event";
      
            string json = "{\"event_id\":\"<event_id>\" }";
            json = json.Replace("<event_id>", updatedEvent.Id);

            _Completion = completion;
            PostDataWithOperation("events", json, "DELETE");
        }
        public void UpdateEvent(Event updatedEvent, Action completion)
        {
            _Operation = "update_event";

            string startTime = updatedEvent.StartTime.ToString();
            string endTime = updatedEvent.EndTime.ToString();

            string json = "{\"event_id\":\"<event_id>\",\"schedule_only\": \"<schedule_only>\",\"event_web_id\": \"<event_web_id>\",";
            json += "\"name\": \"<name>\",\"end_time\": \"<end_time>\",\"start_time\": \"<start_time>\",\"track_id\": \"<track_id>\",";
            json += "\"location_id\":\"<location_id>\", \"summary\":\"<summary>\", \"presenter\":\"<presenter>\", \"event_web_id\":\"<event_web_id>\"}";

            json = json.Replace("<event_id>", updatedEvent.Id);
            json = json.Replace("<schedule_only>", updatedEvent.ScheduleOnly.ToString().ToLower());
            json = json.Replace("<event_web_id>", updatedEvent.EventWebId);
            json = json.Replace("<name>", updatedEvent.Name);
            json = json.Replace("<end_time>", endTime);
            json = json.Replace("<start_time>", startTime);
            json = json.Replace("<track_id>", updatedEvent.TrackId);
            json = json.Replace("<location_id>", updatedEvent.LocationId);
            json = json.Replace("<summary>", updatedEvent.Summary);
            json = json.Replace("<presenter>", updatedEvent.Presenter);
            json = json.Replace("<event_web_id>", updatedEvent.EventWebId);


            _Completion = completion;
            PostDataWithOperation("events", json, "PUT");
        }

        public void SignIn(string email, string password, Action completion)
        {
            string loginJson = "{ \"email\": \"<email>\", \"password\":\"<password>\" }";
            loginJson = loginJson.Replace("<email>", email);
            loginJson = loginJson.Replace("<password>", password);
            _Operation = "sign_in";
            _Completion = completion;
            PostDataWithOperation("sign_in", loginJson, "POST");
        }

        public void GetEvents(Action completion)
        {
                _Completion = completion;
                _Operation = "get_events";
                PostDataWithOperation("events", string.Empty, "GET");
        }

        public void GetTracks(Action completion)
        {
            _Completion = completion;
            _Operation = "get_tracks";
            PostDataWithOperation("tracks", string.Empty, "GET");
        }

        public void GetLocations(Action completion)
        {
            _Completion = completion;
            _Operation = "get_locations";
            PostDataWithOperation("locations", string.Empty, "GET");
        }

        public void GetUsers(Action completion)
        {
            _Completion = completion;
            _Operation = "get_users";
            PostDataWithOperation("users", string.Empty, "GET");
        }

        private void PostDataWithOperation(string entity, string JSON, string method)
        {
            try
            {
                //build request
                _Request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(_ConnectionUrl + "/" + entity + "/");
                if (_AccessToken != null && _AccessToken != string.Empty)
                {
                    _Request.Headers.Add("authorization", _AccessToken);
                }
                //set http method
                _Request.Method = method;
                //content type
                _Request.ContentType = "application/json";
                //build json
                //encode json
                if (method != "GET")
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(JSON);
                    //write to request body
                    Stream PostData = _Request.GetRequestStream();
                    PostData.Write(buffer, 0, buffer.Length);
                    PostData.Close();
                }
                //get response
                Stream response = _Request.GetResponse().GetResponseStream();
                _Request.BeginGetResponse(EndResponse, _Request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




        private void EndResponse(IAsyncResult result)
        {
            //_request.EndGetResponse(result);
            Stream response = (result.AsyncState as System.Net.HttpWebRequest).EndGetResponse(result).GetResponseStream();
            StreamReader response_reader = new StreamReader(response);
            string response_json = response_reader.ReadToEnd();
            processResponse(response_json);
            _Completion(response_json);
        }





        private void processResponse(string response_json)
        {
            try
            {
                switch (_Operation)
                {
                   
                    case "get_tracks":
                        {
                            Dictionary<string, string> data = Utilities.ParseJson(response_json);
                            string tracks = data["tracks"];
                            string[] arrJson = Utilities.ParseJsonArray(tracks);
                            _arrTracks = new List<Track>();
                            for (int i = 0; i < arrJson.Length; i++)
                            {
                                Track tempTrack = Track.FromJson(arrJson[i]);
                                _arrTracks.Add(tempTrack);
                            }
                            break;
                        }
                    case "get_events":
                        {
                            Dictionary<string, string> data = Utilities.ParseJson(response_json);
                            string events = data["events"];
                            string[] arrJson = Utilities.ParseJsonArray(events);
                            _arrEvents = new List<Event>();
                            for (int i = 0; i < arrJson.Length; i++)
                            {
                                Event tempEvent = Event.FromJson(arrJson[i]);
                                _arrEvents.Add(tempEvent);
                            }
                            break;
                        }
                    case "get_locations":
                        {
                            Dictionary<string, string> data = Utilities.ParseJson(response_json);
                            string locations = data["locations"];
                            string[] arrJson = Utilities.ParseJsonArray(locations);
                            _arrLocations = new List<Location>();
                            for (int i = 0; i < arrJson.Length; i++)
                            {
                                Location tempLocation = Location.FromJson(arrJson[i]);
                                _arrLocations.Add(tempLocation);
                            }
                            break;
                        }
                    case "get_users":
                        {
                            Dictionary<string, string> data = Utilities.ParseJson(response_json);
                            string locations = data["users"];
                            string[] arrJson = Utilities.ParseJsonArray(locations);
                            _arrUsers = new List<User>();
                            for (int i = 0; i < arrJson.Length; i++)
                            {
                                User tempUser = User.FromJson(arrJson[i]);
                                _arrUsers.Add(tempUser);
                            }
                            break;
                        }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

