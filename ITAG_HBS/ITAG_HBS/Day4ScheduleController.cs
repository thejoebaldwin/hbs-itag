using Foundation;
using System;
using UIKit;
using ITAG_HBS;
using HBS.ITAG;
using System.Collections.Generic;
using HBS.ITAG.Model;

namespace HBS.ITAG
{
	public partial class Day4ScheduleController : UIViewController
	{
		partial void PreviousTrackButtonClick(UIButton sender)
		{

			rightSwipeDetected();
		}

		partial void NextTrackButtonClick(UIButton sender)
		{
			leftSwipeDetected();
		}

        partial void MyEventsButtonClick(UIButton sender)
        {
            this.DismissViewController(false, new Action(parent.NavigateToMyEvents));
        }

        partial void HomeButtonClick(UIButton sender)
        {
            this.DismissViewController(false, null);
        }

        partial void June22ButtonClick(UIButton sender)
        {
			this.DismissViewController(false, new Action(parent.NavigationScheduleJune22));
        }

        partial void June21ButtonClick(UIButton sender)
        {
			this.DismissViewController(false, new Action(parent.NavigationScheduleJune21));
        }

        partial void June20ButtonClick(UIButton sender)
        {
			this.DismissViewController(false, new Action(parent.NavigationScheduleJune20));
        }

        //pick track here
        int currentTrack = 0;
		List<Track> tracks = new List<Track>();

		public HomeViewController parent { get; set; }

		public string DataObject
        {
			get; set;
		}

		public Day4ScheduleController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			UISwipeGestureRecognizer leftSwipe = new UISwipeGestureRecognizer(leftSwipeDetected);
			leftSwipe.Direction = UISwipeGestureRecognizerDirection.Left;
			View.AddGestureRecognizer(leftSwipe);

			UISwipeGestureRecognizer rightSwipe = new UISwipeGestureRecognizer(rightSwipeDetected);
			rightSwipe.Direction = UISwipeGestureRecognizerDirection.Right;
			View.AddGestureRecognizer(rightSwipe);

			UITapGestureRecognizer RightArrow = new UITapGestureRecognizer(leftSwipeDetected);
            RightArrow.NumberOfTapsRequired = 1;
			D4RightArrow.AddGestureRecognizer(RightArrow);

			UITapGestureRecognizer LeftArrow = new UITapGestureRecognizer(rightSwipeDetected);
            LeftArrow.NumberOfTapsRequired = 1;
			D4LeftArrow.AddGestureRecognizer(LeftArrow);

			for (int i = 0; i < tracks.Count; i++)
			{
				tracks.Remove(tracks[i]);
			}

			//get tracks for day 4
			tracks = new List<Track>();
			foreach (var t in Store.Instance.Tracks)
			{
				if (t.TrackDate == DateTime.Parse("6/23/2017"))
				{
					tracks.Add(t);
				}
			}

			//Somehow filter to the correct track
			//var name = this.GetType();

			//Arrows on Page for Tracks
			if (currentTrack == 0)
			{
				D4LeftArrow.Hidden = true;
			}
			else
			{
				D4LeftArrow.Hidden = false;
			}
			if (currentTrack == tracks.Count - 1 || tracks.Count == 0)
			{
				D4RightArrow.Hidden = true;
			}
			else
			{
				D4RightArrow.Hidden = false;
			}

			//get events for current track
			if (tracks.Count == 0)
			{
				tracks.Add(new Track("No Tracks Today", "-1", DateTime.Today, ""));
			}
			Day4TrackName.Text = tracks[currentTrack].Name;
			List<Event> trackEvents = new List<Event>();
			trackEvents = new List<Event>();
			foreach (var e in Store.Instance.Events)
			{
				if (e.TrackId == tracks[currentTrack].Id)
				{
					trackEvents.Add(e);
				}
			}

			//use the array contents to build the table view source
			ScheduleTableViewSource data = new ScheduleTableViewSource(trackEvents);
			data.parent = (UIViewController)this;
            DayFour.Source = data;
			DayFour.ReloadData();

		}

		private void leftSwipeDetected()
		{
			if (currentTrack != tracks.Count - 1)
			{
				currentTrack++;
				ViewDidLoad();
			}
			else
			{
				return;
			}
		}

		private void rightSwipeDetected()
		{
			if (currentTrack != 0)
			{
				currentTrack--;
				ViewDidLoad();
			}
			else
			{
				return;
			}
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}
	}
}
