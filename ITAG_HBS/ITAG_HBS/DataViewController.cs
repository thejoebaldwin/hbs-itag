using System;
using Foundation;
using ITAG_HBS;
using HBS.ITAG;
using UIKit;
using HBS.ITAG.Model;

namespace HBS.ITAG
{
	public partial class DataViewController : UIViewController
	{
        partial void MyEventsButtonClick(UIButton sender)
        {
            //do nothing
        }

        partial void ScheduleButtonClick(UIButton sender)
        {
            this.DismissViewController(false, new Action(parent.NavigateToSchedule));
        }

        partial void HomeButtonClick(UIButton sender)
        {
            this.DismissViewController(false, null);
        }

        public string DataObject
		{
			get; set;
		}

        public FavoritesViewController parent { get; set; }

        protected DataViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            //create the tableview contents
            //ReloadData();
		}

        public override void ViewDidAppear(bool animated)
        {
            ReloadData();
        }

        public void ReloadData()
        {
            var trackEvents = Store.Instance.Events;
            PreviousTableViewSource pastEvents = new PreviousTableViewSource(trackEvents);
            FavoritesTableViewSource upcomingEvents = new FavoritesTableViewSource(trackEvents);
            pastEvents.parent = this;
            upcomingEvents.parent = this;
            if (ScheduleTableView2 != null)
            {
                ScheduleTableView2.Source = pastEvents;
                ScheduleTableView.ReloadData();
                ScheduleTableView.Source = upcomingEvents;
                ScheduleTableView.ReloadData();
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
			//dataLabel.Text = DataObject;
		}
	}
}