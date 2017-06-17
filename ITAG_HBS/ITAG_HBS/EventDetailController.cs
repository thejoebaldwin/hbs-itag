using Foundation;
using System;
using UIKit;
using HBS.ITAG;
using ITAG_HBS;
using System.Collections.Generic;
using HBS.ITAG.Model;
using System.Globalization;

namespace HBS.ITAG
{
    public partial class EventDetailController : UIViewController
    {
        partial void HomeButtonClick(UIButton sender)
        {
            this.DismissViewController(true, null);
        }

        List<Event> events = Store.Instance.Events;
        public EventDetailController (IntPtr handle) : base (handle)
        {
        }

		public FavoritesViewController parent { get; set; }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//Store.Instance.LoadEventsFromFile();
			//Store.Instance.LoadTracksFromFile();

			GrayStar.UserInteractionEnabled = true;

			UITapGestureRecognizer Favoritedtapguesture = new UITapGestureRecognizer(StarClick);
			Favoritedtapguesture.NumberOfTapsRequired = 1;
			GrayStar.AddGestureRecognizer(Favoritedtapguesture);

			LinkToDescription.UserInteractionEnabled = true;


			UITapGestureRecognizer Link = new UITapGestureRecognizer(LinkClick);
			Link.NumberOfTapsRequired = 1;
			LinkToDescription.AddGestureRecognizer(Link);


			// Perform any additional setup after loading the view, typically from a nib.
		}

        public void RefreshPage()
        {
			EventName.Text = Store.Instance.SelectedEvent.Name;
			EventDay.Text = Store.Instance.SelectedEvent.StartTime.DayOfWeek.ToString() + ", " + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Store.Instance.SelectedEvent.StartTime.Month) + " " + Store.Instance.SelectedEvent.StartTime.Day.ToString();
			EventTime.Text = Store.Instance.SelectedEvent.StartTime.ToLocalTime().ToShortTimeString() + " to " + Store.Instance.SelectedEvent.EndTime.ToLocalTime().ToShortTimeString();
			if (Store.Instance.SelectedEvent.LocationId != null && Store.Instance.SelectedEvent.LocationId != "-1")
			{
				EventLocation.Text = Store.Instance.Locations.Find(x => x.Id == Store.Instance.SelectedEvent.LocationId).Name.ToString();
			}
			else
			{
				EventLocation.Text = "TBD";
			}

			if (Store.Instance.SelectedEvent.Favorited)
			{
				GrayStar.Highlighted = true;
			}
			else
			{
				GrayStar.Highlighted = false;
			}
			
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            RefreshPage();

        }

        private void StarClick()
        {
            if (Store.Instance.SelectedEvent.Favorited)
            {
                GrayStar.Highlighted = false;
				Store.Instance.DeleteFavorite(Store.Instance.SelectedEvent);
            }
            else
            {
                GrayStar.Highlighted = true;
				Store.Instance.AddFavorite(Store.Instance.SelectedEvent);
            }

			//parent.ReloadData();
			//parent.myEventsController.ReloadData();

        }

		private void FavoritedClick()
		{
			GrayStar.Highlighted = true;
            //Store.Instance.SelectedEvent.Favorited = true;
            Store.Instance.AddFavorite(Store.Instance.SelectedEvent);
            parent.ReloadData();
            parent.myEventsController.ReloadData();

			UITapGestureRecognizer Unfavoritedtapgesture = new UITapGestureRecognizer(UnfavoritedClick);
			Unfavoritedtapgesture.NumberOfTapsRequired = 1;
			GrayStar.AddGestureRecognizer(Unfavoritedtapgesture);

		}
		public void UnfavoritedClick()
		{
			GrayStar.Highlighted = false;
            //Store.Instance.SelectedEvent.Favorited = false;
            Store.Instance.DeleteFavorite(Store.Instance.SelectedEvent);
            parent.ReloadData();
			parent.myEventsController.ReloadData();
            //ViewDidLoad();
            RefreshPage();
		}
        public void LinkClick()
        {
            //TODO Not all web ids link to the correct event
            string endofLink = "/" + Store.Instance.SelectedEvent.StartTime.DayOfWeek + "/#event-" + Store.Instance.SelectedEvent.EventWebId;
            UIApplication.SharedApplication.OpenUrl(new NSUrl("https://iowacountiesit.org/itag-conference/schedule/"+endofLink));
        }
    }
}