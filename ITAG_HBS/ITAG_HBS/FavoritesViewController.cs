using System;
using Foundation;
using ITAG_HBS;
using HBS.ITAG;
using UIKit;

namespace ITAG_HBS
{
    public partial class FavoritesViewController : UIViewController
    {
		public string DataObject
		{
			get; set;
		}

        public FavoritesViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
			UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

			//THIS IS FOR THE HOME PAGE//

            var trackEvents = Store.Instance.Events;
            ScheduleTableViewFavs.Source = new FavoritesTableViewSource(trackEvents);
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

