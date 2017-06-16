using Foundation;
using System;
using UIKit;
using HBS.ITAG;
using ITAG_HBS;
using System.Collections.Generic;
using HBS.ITAG.Model;
using System.Globalization;

namespace ITAG.HBS
{
    public partial class EventDetailController : UIViewController
    {
        List<Event> events = Store.Instance.Events;
        int indexedEvent = 0;
        public EventDetailController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			//Store.Instance.LoadEventsFromFile();
			//Store.Instance.LoadTracksFromFile();

			GrayStar.UserInteractionEnabled = true;

			UITapGestureRecognizer Favoritedtapguesture = new UITapGestureRecognizer(FavoritedClick);
			Favoritedtapguesture.NumberOfTapsRequired = 1;
			GrayStar.AddGestureRecognizer(Favoritedtapguesture);

            EventName.Text = Store.Instance.SelectedEvent.Name;
            EventDay.Text = Store.Instance.SelectedEvent.StartTime.DayOfWeek.ToString() + ", " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Store.Instance.SelectedEvent.StartTime.Month) + " " + Store.Instance.SelectedEvent.StartTime.Day.ToString();
            EventTime.Text = Store.Instance.SelectedEvent.StartTime.ToLocalTime().ToShortTimeString() + " to " + Store.Instance.SelectedEvent.EndTime.ToLocalTime().ToShortTimeString();
            if(Store.Instance.SelectedEvent.LocationId != null && Store.Instance.SelectedEvent.LocationId != "-1")
            {
                EventLocation.Text = Store.Instance.Locations.Find(x => x.Id == Store.Instance.SelectedEvent.LocationId).Name.ToString();
            }
            else
            {
                EventLocation.Text = "TBD";
            }

            LinkToDescription.Text = "Click Here to redirect";
            LinkToDescription.TextColor = UIColorExtension.FromHex(0x0000EE);

            LinkToDescription.UserInteractionEnabled = true;
            UITapGestureRecognizer Link = new UITapGestureRecognizer(LinkClick);
            Link.NumberOfTapsRequired = 1;
            LinkToDescription.AddGestureRecognizer(Link);


            if (events[indexedEvent].Favorited)
            {
                GrayStar.Highlighted = true;
            }

            else
            {
                GrayStar.Highlighted = false;
            }

			// Perform any additional setup after loading the view, typically from a nib.
		}
		
		private void FavoritedClick()
		{
			GrayStar.Highlighted = true;
            //TODO Not all webIds were linking to the correct page
			UITapGestureRecognizer Unfavoritedtapgesture = new UITapGestureRecognizer(UnfavoritedClick);
			Unfavoritedtapgesture.NumberOfTapsRequired = 1;
			GrayStar.AddGestureRecognizer(Unfavoritedtapgesture);

		}
		public void UnfavoritedClick()
		{
			GrayStar.Highlighted = false;
            //TODO remove event from favorites for the user
			ViewDidLoad();
		}
        public void LinkClick()
        {
            //TODO WEB IDs don't match
            string endofLink = "/" + Store.Instance.SelectedEvent.StartTime.DayOfWeek + "/#event-" + Store.Instance.SelectedEvent.EventWebId;
            UIApplication.SharedApplication.OpenUrl(new NSUrl("https://iowacountiesit.org/itag-conference/schedule/"+endofLink));
        }
    }
}