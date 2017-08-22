using Foundation; using System; using UIKit; using ITAG_HBS; using HBS.ITAG; using System.Collections.Generic;
using HBS.ITAG.Model; using CoreGraphics; using System.Threading.Tasks; 
namespace HBS.ITAG {     public partial class ScheduleController : UIViewController     {
		protected LoadingPage loadPop = null;         List<DateTime> listOfTrackDates = new List<DateTime>();
        partial void FirstTabClick(UIButton sender)
        {
            FirstTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);             FirstTab.TitleLabel.TextColor = UIColor.White; 			SecondTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            SecondTab.TitleLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);             ThirdTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            ThirdTab.TitleLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);             FourthTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
            FourthTab.TitleLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			currentTrack = 0;
            CurrentTrackDate = listOfTrackDates[0];
			ReloadData();
        }

		partial void SecondTabClick(UIButton sender)
		{
			FirstTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
			FirstTab.TitleLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			SecondTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
            SecondTab.TitleLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0xFFFFFF);
			ThirdTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
			ThirdTab.TitleLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			FourthTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
			FourthTab.TitleLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			currentTrack = 0;
            CurrentTrackDate = listOfTrackDates[1];
			ReloadData();
		}

		partial void ThirdTabClick(UIButton sender)
		{
			FirstTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
			FirstTab.TitleLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			SecondTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
			SecondTab.TitleLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			ThirdTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			ThirdTab.TitleLabel.TextColor = UIColor.White;
			FourthTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
			FourthTab.TitleLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);

			currentTrack = 0;
            CurrentTrackDate = listOfTrackDates[2];
			ReloadData();
		}

		partial void FourthTabClick(UIButton sender)
		{
			FirstTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
			FirstTab.TitleLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			SecondTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
			SecondTab.TitleLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			ThirdTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
			ThirdTab.TitleLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			FourthTab.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
			FourthTab.TitleLabel.TextColor = UIColor.White;

			currentTrack = 0;
			CurrentTrackDate = listOfTrackDates[3];
			ReloadData();
		}          private DateTime CurrentTrackDate;
        partial void PreviousTrackButtonClick(UIButton sender)
        {             rightSwipeDetected();
        }          partial void NextTrackButtonClick(UIButton sender)
        {
            leftSwipeDetected();
        }          partial void MyEventsButtonClick(UIButton sender)
        {
            this.DismissViewController(false, new Action(parent.NavigateToMyEvents));         }          partial void HomeButtonClick(UIButton sender)
        {             this.DismissViewController(false, null);
        }
        //pick track here
        int currentTrack = 0;         List<Track> tracks = new List<Track>();

        public HomeViewController parent { get; set; }          public string DataObject         {             get; set;         }          public ScheduleController (IntPtr handle) : base (handle)         {         }          private void ReloadData()         {
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
			D1LeftArrow.AddGestureRecognizer(LeftArrow); 
			currentTrack = 0;             ReloadData();             GetTrackDates();             CurrentTrackDate = listOfTrackDates[0];             FirstTab.SetTitle(listOfTrackDates[0].Month + "/" + listOfTrackDates[0].Day, UIControlState.Normal);             SecondTab.SetTitle(listOfTrackDates[1].Month + "/" + listOfTrackDates[1].Day, UIControlState.Normal);             ThirdTab.SetTitle(listOfTrackDates[2].Month + "/" + listOfTrackDates[2].Day, UIControlState.Normal);             FourthTab.SetTitle(listOfTrackDates[3].Month + "/" + listOfTrackDates[3].Day, UIControlState.Normal);             ReloadData();         }          private void leftSwipeDetected ()         {             if (currentTrack != tracks.Count - 1)             {                 currentTrack++;                 ReloadData();             }             else             {                 return;             }         }

		private void rightSwipeDetected()
		{
			if (currentTrack != 0)
			{
				currentTrack--;                 ReloadData();
			}             else             {                 return;             }
		}          public void GetTrackDates()         {             listOfTrackDates = new List<DateTime>();             //put tracks in list             foreach(var t in Store.Instance.Tracks)             {                 if(!listOfTrackDates.Contains(t.TrackDate.Date))                 {                     listOfTrackDates.Add(t.TrackDate.Date);                 }             }
            listOfTrackDates.Sort((x, y) => x.Ticks.CompareTo(y.Ticks));         }          public override void DidReceiveMemoryWarning()         {             base.DidReceiveMemoryWarning();             // Release any cached data, images, etc that aren't in use.         }     } } 