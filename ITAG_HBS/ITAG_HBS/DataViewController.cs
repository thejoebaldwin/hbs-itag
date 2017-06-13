using System;

using UIKit;

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
			string[] tableItems = new string[] { "Building Apps with Web AppBuilder", "What's New in vSphere 6.5", "Basic Python Workshop", "Drones! - The Process", "Intermediate Python Workshop", "The Dark Web" };
            string[] tableItems2 = new string[] { "Building Apps with Web AppBuilder", "What's New in vSphere 6.5", "Basic Python Workshop", "Drones! - The Process", "Intermediate Python Workshop", "The Dark Web" };
           
			//use the array contents to build the table view source
			ScheduleTableView.Source = new ScheduleTableViewSource(tableItems);
            ScheduleTableView2.Source = new ScheduleTableViewSource(tableItems2);



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