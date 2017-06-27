using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Text;
using Android.Text.Method;
using HBS.ITAG.Model;
using System.Globalization;
using Android.Content;

namespace HBS.ITAG
{
    [Activity(Label = "EventDetails", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class EventDetails : Activity
    {
        protected override void OnResume()
        {
            base.OnResume();
            LoadData();
        }

        private void LoadData()
        {
			List<Event> events = Store.Instance.Events;

			// Sets Event name
			TextView name = FindViewById<TextView>(Resource.Id.EDtextView3);
			name.Text = Store.Instance.SelectedEvent.Name;

			//Sets Event time
			TextView time = FindViewById<TextView>(Resource.Id.EDtextView5);
			TextView day = FindViewById<TextView>(Resource.Id.eventDay);
			day.Text = Store.Instance.SelectedEvent.StartTime.DayOfWeek.ToString() + ", " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Store.Instance.SelectedEvent.StartTime.Month) + " " + Store.Instance.SelectedEvent.StartTime.Day.ToString();
			time.Text = Store.Instance.SelectedEvent.StartTime.ToLocalTime().ToShortTimeString() + " to " + Store.Instance.SelectedEvent.EndTime.ToLocalTime().ToShortTimeString();

			//Sets Event location
			TextView location = FindViewById<TextView>(Resource.Id.EDtextView7);
			if (Store.Instance.SelectedEvent.LocationId != null && Store.Instance.SelectedEvent.LocationId != "-1")
			{
				location.Text = Store.Instance.Locations.Find(x => x.Id == Store.Instance.SelectedEvent.LocationId).Name.ToString();
			}
			else
			{
				location.Text = "TBD";
			}

			// Sets up link on the bottom of page
			TextView link = FindViewById<TextView>(Resource.Id.EDtextView9);
			String endOfLink = "/" + Store.Instance.SelectedEvent.StartTime.DayOfWeek + "/#event-" + Store.Instance.SelectedEvent.EventWebId;
			link.TextFormatted = Html.FromHtml("" + "<a href=https://iowacountiesit.org/itag-conference/schedule/" + endOfLink + "\">Link to Full Description</a> " + "");
			link.MovementMethod = LinkMovementMethod.Instance;


            // Favorites Button functionality
            ImageButton button = FindViewById<ImageButton>(Resource.Id.EDimageButton1);

			if (Store.Instance.SelectedEvent.Favorited)
			{
				button.SetImageDrawable(GetDrawable(17301516));
			}
			else
			{
				button.SetImageDrawable(GetDrawable(17301515));
			}


			button.Click += (object sender, EventArgs e) =>
				{
					if (Store.Instance.SelectedEvent.Favorited)
					{
						Store.Instance.SelectedEvent.Favorited = false;
						Toast.MakeText(this, "Removed from Favorites", ToastLength.Short).Show();
						button.SetImageDrawable(GetDrawable(17301515));
						OldStore.Instance.DeleteFavorite(Store.Instance.SelectedEvent);
					}
					else
					{
						Store.Instance.SelectedEvent.Favorited = true;
						Toast.MakeText(this, "Added to Favorites", ToastLength.Short).Show();
						button.SetImageDrawable(GetDrawable(17301516));
						OldStore.Instance.AddFavorite(Store.Instance.SelectedEvent);
					}
				};
		}

        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EventDetails);
            
        }
        

    }
}