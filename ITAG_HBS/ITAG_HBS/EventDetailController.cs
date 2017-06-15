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



			// Perform any additional setup after loading the view, typically from a nib.
		}

		private void FavoritedClick()
		{
			GrayStar.Highlighted = true;
			UITapGestureRecognizer Unfavoritedtapgesture = new UITapGestureRecognizer(UnfavoritedClick);
			Unfavoritedtapgesture.NumberOfTapsRequired = 1;
			GrayStar.AddGestureRecognizer(Unfavoritedtapgesture);

		}
		public void UnfavoritedClick()
		{
			GrayStar.Highlighted = false;
			ViewDidLoad();
		}
    }
}