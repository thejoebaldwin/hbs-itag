using Foundation;
using System;
using UIKit;
using HBS.ITAG;

namespace ITAG.HBS
{
    public partial class EventDetailController : UIViewController
    {
        public EventDetailController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			Store.Instance.LoadEventsFromFile();
			Store.Instance.LoadTracksFromFile();

			GrayStar.UserInteractionEnabled = true;

			UITapGestureRecognizer Favoritedtapguesture = new UITapGestureRecognizer(FavoritedClick);
			Favoritedtapguesture.NumberOfTapsRequired = 1;
			GrayStar.AddGestureRecognizer(Favoritedtapguesture);

            //EventName.Text = "";
            //EventTime.Text = "";
            //EventLocation.Text = "";
            //LinkToDescription.Text = "";

            LinkToDescription.UserInteractionEnabled = true;
            UITapGestureRecognizer Link = new UITapGestureRecognizer(LinkClick);
            Link.NumberOfTapsRequired = 1;
            LinkToDescription.AddGestureRecognizer(Link);

			// Perform any additional setup after loading the view, typically from a nib.
		}

		private void FavoritedClick()
		{
			GrayStar.Highlighted = true;
            //TODO add event to favorites for the user
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
            UIApplication.SharedApplication.OpenUrl(new NSUrl("https://iowacountiesit.org/itag-conference/schedule/"));
        }
    }
}