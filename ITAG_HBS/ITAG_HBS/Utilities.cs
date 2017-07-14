using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Globalization;

namespace HBS.ITAG.Client
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
}
