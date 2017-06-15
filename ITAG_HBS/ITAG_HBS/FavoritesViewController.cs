using System;
using Foundation;
using ITAG_HBS;
using HBS.ITAG;
using UIKit;
using HBS.ITAG.Model;

namespace ITAG_HBS
{ //THIS IS FOR THE HOME PAGE//
    public partial class FavoritesViewController : UIViewController
    {
        bool didRegister = false;

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

          

            HotelName.UserInteractionEnabled = true;
            UITapGestureRecognizer HotelMapGesture = new UITapGestureRecognizer(HotelMapClick);
            HotelMapGesture.NumberOfTapsRequired = 1;
            HotelName.AddGestureRecognizer(HotelMapGesture);

            PhoneNumber.UserInteractionEnabled = true;
            UITapGestureRecognizer CallGesture = new UITapGestureRecognizer(CallClick);
            CallGesture.NumberOfTapsRequired = 1;
            PhoneNumber.AddGestureRecognizer(CallGesture);
			//Perform any additional setup after loading the view, typically from a nib.

            //TODO: TURN ON LOADING INDICATOR
			Store.Instance.GetTracks(LoadTracksComplete);
		}
        public override void ViewDidAppear(bool animiated)
        {
			
            if(!didRegister)
            {
				PickerViewController temp = (PickerViewController)this.Storyboard.InstantiateViewController("pickerview");
				this.PresentViewController(temp, true, null);
                didRegister = true;
            }
        }

		private void LoadTracksComplete(string message)
		{
			Store.Instance.GetEvents(LoadEventsComplete);
		}

        private void LoadEventsComplete(string message)
        {
            Store.Instance.GetLocations(LoadLocationsComplete);
        }

		private void LoadLocationsComplete(string message)
		{
			//TODO: HERE IS WHERE WE WOULD INITIALIZE ESTIMOTES SDK
			//TURN OFF LOADING INDICATOR

            //now load events because we have all the data
			var trackEvents = Store.Instance.Events;
			FavoritesTableViewSource data = new FavoritesTableViewSource(trackEvents);
			data.parent = (UIViewController)this;
            ScheduleTableViewFavs.Source = data;
		}

        private void HotelMapClick()
        {
          
            UIApplication.SharedApplication.OpenUrl(new NSUrl("http://www.starwoodhotels.com/sheraton/property/overview/index.html?propertyID=1557&language=en_US"));

		}

       private void CallClick()
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl(urlString:@"telprompt://5152231800"));
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

