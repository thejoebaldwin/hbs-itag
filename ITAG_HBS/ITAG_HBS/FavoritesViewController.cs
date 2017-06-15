﻿using System;
using Foundation;
using ITAG_HBS;
using HBS.ITAG;
using UIKit;
using HBS.ITAG.Model;

namespace ITAG_HBS
{ //THIS IS FOR THE HOME PAGE//
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


            //this.PresentViewController();
            PickerViewController temp = (PickerViewController)this.Storyboard.InstantiateViewController("pickerview");
            this.PresentViewController(temp,true,null);

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
			ScheduleTableViewFavs.Source = new FavoritesTableViewSource(trackEvents);
		}

        private void HotelMapClick()
        {
          
            UIApplication.SharedApplication.OpenUrl(new NSUrl("https://www.google.com/maps/dir/''/west+des+moines+sheraton/@41.59935,-93.8430521,12z/data=!3m1!4b1!4m8!4m7!1m0!1m5!1m1!1s0x87ec20e82abf28f7:0xd2055049c83ddfb4!2m2!1d-93.7730122!2d41.5993713"));

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

