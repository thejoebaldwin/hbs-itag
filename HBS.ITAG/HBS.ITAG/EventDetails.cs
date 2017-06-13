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
using Android.Text;
using Android.Text.Method;
using Android.Graphics.Drawables;
using Android;

namespace HBS.ITAG
{
    [Activity(Label = "EventDetails", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class EventDetails : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EventDetails);

            List<Event> events = Store.Instance.Events;
            int indexedEvent = 0;

            // Sets Event name
            TextView name = FindViewById<TextView>(Resource.Id.EDtextView3);
            String newText = events[indexedEvent].Name;
            Char[] newTextArr = newText.ToCharArray();
            name.SetText(newTextArr, 0, newTextArr.Length);

            //Sets Event time
            TextView time = FindViewById<TextView>(Resource.Id.EDtextView5);
            DateTime newStartTime = events[indexedEvent].StartTime;
            DateTime newEndTime = events[indexedEvent].EndTime;
            String temp = newStartTime.ToShortTimeString().ToString() + "  to  " + newEndTime.ToShortTimeString().ToString();
            Char[] newTimeArr = temp.ToCharArray();
            time.SetText(newTimeArr, 0, newTimeArr.Length);

            //Sets Event location
            TextView location = FindViewById<TextView>(Resource.Id.EDtextView7);

            // Sets up link on the bottom of page
            TextView link = FindViewById<TextView>(Resource.Id.EDtextView9);
            int eventWebId = events[indexedEvent].EventWebId;
            String endOfLink = "/" + newStartTime.DayOfWeek + "/#event-" + eventWebId;
            link.TextFormatted = Html.FromHtml("" +
                            "<a href=https://iowacountiesit.org/itag-conference/schedule/" + endOfLink + "\">Click Here</a> " +
                            "");
            link.MovementMethod = LinkMovementMethod.Instance;


            // Favorites Button functionality
            var button = FindViewById<ImageButton>(Resource.Id.EDimageButton1);
            int count = 0;

            /*User user = null;
            if (user.FavoritedEvents.Contains(events[indexedEvent].Id))
            {
                button.SetImageDrawable(GetDrawable(17301516));
                count = 1;
            }
            else
            {
                button.SetImageDrawable(GetDrawable(17301515));
                count = 0;
            } */ 


            button.Click += (object sender, EventArgs e) =>
                {

                    if (count % 2 == 0)
                    {
                        Toast toast = Toast.MakeText(this, "Added to Favorites", ToastLength.Short);
                        toast.Show();
                        button.SetImageDrawable(GetDrawable(17301516));
                        count++;
                    }
                    else
                    {
                        Toast toast = Toast.MakeText(this, "Removed from Favorites", ToastLength.Short);
                        toast.Show();
                        button.SetImageDrawable(GetDrawable(17301515));
                        count++;
                    }
                     
                };
           
           
            
        }
    }
}