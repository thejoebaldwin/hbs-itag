using System;

using UIKit;

namespace ITAG_HBS
{
    public partial class FavoritesViewController : UIViewController
    {
		public string DataObject
		{
			get; set;
		}

        protected FavoritesViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			string[] tableItemsFavs = new string[] { "Building Apps with Web App Builder", "9:00 am - 10:30 am" ,"Basic Python Workshop","10:45 am - 12:00 pm","Drones! - The Process","11:30 am - 12:00 pm","The Dark Web","1:30 pm - 3:00 pm"};
            ScheduleTableViewFavs.Source = new FavoritesTableViewSource(tableItemsFavs);
			// Perform any additional setup after loading the view, typically from a nib.
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

