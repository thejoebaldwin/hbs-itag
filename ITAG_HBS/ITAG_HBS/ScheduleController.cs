using Foundation; using System; using UIKit; using ITAG_HBS; using HBS.ITAG; using System.Collections.Generic;
using HBS.ITAG.Model; using CoreGraphics; using System.Threading.Tasks; 
namespace HBS.ITAG {     public partial class ScheduleController : UIViewController     {
		protected LoadingPage loadPop = null; 
        partial void June20ButtonClick(UIButton sender)
        {
			var month = CurrentTrackDate.Month.ToString();
			var day = CurrentTrackDate.Day.ToString();
			Tab1Label.Text = month + "/" + day;
            June20Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);             Tab1Label.TextColor = UIColor.White; 			June21Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            Tab2Label.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);             June22Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            Tab3Label.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);             June23Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            Tab4Label.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			currentTrack = 0;
			CurrentTrackDate = DateTime.Parse("06/19/17");
			ReloadData();
        }          private DateTime CurrentTrackDate;
        partial void PreviousTrackButtonClick(UIButton sender)
        {             rightSwipeDetected();
        }          partial void NextTrackButtonClick(UIButton sender)
        {
            leftSwipeDetected();
        }          partial void June23ButtonClick(UIButton sender)
        {
			var month = CurrentTrackDate.Month.ToString();
			var day = CurrentTrackDate.Day.ToString();
			Tab4Label.Text = month + "/" + day;
			June20Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            Tab1Label.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			June21Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            Tab2Label.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			June22Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            Tab3Label.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			June23Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
            Tab4Label.TextColor = UIColor.White; 
			currentTrack = 0;
			CurrentTrackDate = DateTime.Parse("06/22/17");             ReloadData();
        }          partial void June22ButtonClick(UIButton sender)
        {
			var month = CurrentTrackDate.Month.ToString();
			var day = CurrentTrackDate.Day.ToString();
			Tab3Label.Text = month + "/" + day;
			June20Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            Tab1Label.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			June21Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            Tab2Label.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			June22Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
            Tab3Label.TextColor = UIColor.White;             June23Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            Tab4Label.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52); 
			currentTrack = 0;
			CurrentTrackDate = DateTime.Parse("06/21/17");
			ReloadData();
        }          partial void June21ButtonClick(UIButton sender)
        {
			var month = CurrentTrackDate.Month.ToString();
			var day = CurrentTrackDate.Day.ToString();
			Tab2Label.Text = month + "/" + day;
			June20Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            Tab1Label.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);             June21Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);             Tab2Label.TextColor = UIColor.White;
			June22Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            Tab3Label.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			June23Button.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            Tab4Label.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52); 
			currentTrack = 0;
            CurrentTrackDate = DateTime.Parse("06/20/17");
			ReloadData();
        }          partial void MyEventsButtonClick(UIButton sender)
        {
            this.DismissViewController(false, new Action(parent.NavigateToMyEvents));         }          partial void HomeButtonClick(UIButton sender)
        {             this.DismissViewController(false, null);
        }
        //pick track here
        int currentTrack = 0;         List<Track> tracks = new List<Track>();

        public HomeViewController parent { get; set; }          public string DataObject         {             get; set;         }          public ScheduleController (IntPtr handle) : base (handle)         {                      }          private void ReloadData()         {
			//get tracks for day 1
			tracks = new List<Track>();
			foreach (var t in Store.Instance.Tracks)
			{
                if (t.TrackDate.Date == CurrentTrackDate.Date)
				{
					tracks.Add(t);
				}
			}
			//Arrows on Page for Tracks
			if (currentTrack == 0)
			{
				D1LeftArrow.Hidden = true;
			} 
			else
			{
				D1LeftArrow.Hidden = false;
			} 
			if (currentTrack == tracks.Count - 1 || tracks.Count == 0)
			{
				D1RightArrow.Hidden = true;
			} 
			else
			{
				D1RightArrow.Hidden = false;
			}
            //get events for current track             List<Event> trackEvents = new List<Event>();
            if (tracks.Count == 0)
            {
                TrackName.Text = string.Empty;
                tracks.Add(new Track("No Tracks Today", "-1", DateTime.Today, ""));
            }              else             {
				TrackName.Text = tracks[currentTrack].Name;
				trackEvents = new List<Event>();
				foreach (var e in Store.Instance.Events)
				{
					if (e.TrackId == tracks[currentTrack].Id)
					{
						trackEvents.Add(e);
					}
				}             }
			ScheduleTableViewSource data = new ScheduleTableViewSource(trackEvents);
			data.parent = (UIViewController)this;
			ScheduleTable.Source = data;
			ScheduleTable.ReloadData();         }
         public override void ViewDidLoad()         {             base.ViewDidLoad();             // Perform any additional setup after loading the view, typically from a nib.             UISwipeGestureRecognizer leftSwipe = new UISwipeGestureRecognizer(leftSwipeDetected);             leftSwipe.Direction = UISwipeGestureRecognizerDirection.Left;             View.AddGestureRecognizer(leftSwipe);              UISwipeGestureRecognizer rightSwipe = new UISwipeGestureRecognizer(rightSwipeDetected);             rightSwipe.Direction = UISwipeGestureRecognizerDirection.Right;             View.AddGestureRecognizer(rightSwipe);              UITapGestureRecognizer RightArrow = new UITapGestureRecognizer(leftSwipeDetected);             RightArrow.NumberOfTapsRequired = 1;             D1RightArrow.AddGestureRecognizer(RightArrow);

			UITapGestureRecognizer LeftArrow = new UITapGestureRecognizer(rightSwipeDetected);             LeftArrow.NumberOfTapsRequired = 1;
			D1LeftArrow.AddGestureRecognizer(LeftArrow);              CurrentTrackDate = DateTime.Parse("06/19/17");
			currentTrack = 0;             ReloadData();             GetTrackDates();         }          private void leftSwipeDetected ()         {             if (currentTrack != tracks.Count - 1)             {                 currentTrack++;                 ReloadData();             }             else             {                 return;             }         }

		private void rightSwipeDetected()
		{
			if (currentTrack != 0)
			{
				currentTrack--;                 ReloadData();
			}             else             {                 return;             }
		}          public void GetTrackDates()         {             List<DateTime> listOfTrackDates = new List<DateTime>();             //get all tracks that have the same conference id and then sort from smallest to largest date             //foreach (track where conference id = conferenceid)             //{             //    then sort the list then add the dates that aren't in the list to the listOfTrackDates             //}         }          public override void DidReceiveMemoryWarning()         {             base.DidReceiveMemoryWarning();             // Release any cached data, images, etc that aren't in use.         }     } } 