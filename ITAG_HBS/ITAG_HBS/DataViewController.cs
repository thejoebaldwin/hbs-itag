using System;
using Foundation;
using ITAG_HBS;
using HBS.ITAG;
using UIKit;
using HBS.ITAG.Model;

namespace ITAG_HBS
{
	public partial class DataViewController : UIViewController
	{
		public string DataObject
		{
			get; set;
		}


        protected DataViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			//create the tableview contents
			
            var trackEvents = Store.Instance.Events;
			ScheduleTableView2.Source = new PreviousTableViewSource(trackEvents);
            ScheduleTableView.Source = new FavoritesTableViewSource(trackEvents);
           


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