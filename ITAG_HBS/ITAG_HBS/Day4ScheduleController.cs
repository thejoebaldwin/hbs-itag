using Foundation;
using System;
using UIKit;
using ITAG_HBS;
using HBS.ITAG;
using System.Collections.Generic;

namespace ITAG.HBS
{
	public partial class Day4ScheduleController : UIViewController
	{
		//pick track here
		int currentTrack = 0;
		List<Track> tracks = new List<Track>();

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
				tracks.Add(new Track("No Tracks Today", -1, DateTime.Today, ""));
			}
			Day4TrackName.Text = tracks[currentTrack].Name;
			List<Event> trackEvents = new List<Event>();
			trackEvents = new List<Event>();
			foreach (var e in Store.Instance.Events)
			{
				if (e.Track == tracks[currentTrack].Id)
				{
					trackEvents.Add(e);
				}
			}

			//use the array contents to build the table view source
			DayFour.Source = new ScheduleTableViewSource(trackEvents);
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
