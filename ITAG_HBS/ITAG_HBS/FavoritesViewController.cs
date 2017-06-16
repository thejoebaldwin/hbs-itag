﻿﻿﻿﻿using System;
using Foundation;

using UIKit;
using HBS.ITAG.Model;
using Estimote;

using HBS.ITAG;

using CoreLocation;

namespace HBS.ITAG
{ //THIS IS FOR THE HOME PAGE//
    public partial class FavoritesViewController : UIViewController
    {
        partial void EventsButtonClick(UIButton sender)
        {
            NavigateToMyEvents();
        }

        partial void ScheduleButtonClick(UIButton sender)
        {
            NavigateToSchedule();
        }

        bool didRegister = false;
        BeaconManager beaconManager;

		const string PROXIMITY_UUID = "B9407F30-F5F8-466E-AFF9-25556B57FE6D";

		public Day1ScheduleController day1ScheduleController { get; set; }
		public Day2ScheduleController day2ScheduleController { get; set; }
		public Day3ScheduleController day3ScheduleController { get; set; }
		public Day4ScheduleController day4ScheduleController { get; set; }
        public DataViewController myEventsController { get; set; }

		public string DataObject
		{
			get; set;
		}

        public FavoritesViewController(IntPtr handle) : base(handle)
        {
        }

        public void NavigateToSchedule()
        {
			this.PresentViewController(day1ScheduleController, false, null);
        }

        public void NavigateToMyEvents()
        {
			this.PresentViewController(myEventsController, false, null);
        }

        public void NavigationScheduleJune20()
        {
			this.PresentViewController(day1ScheduleController, false, null);
        }

		public void NavigationScheduleJune21()
		{
			this.PresentViewController(day2ScheduleController, false, null);
		}

		public void NavigationScheduleJune22()
		{
			this.PresentViewController(day3ScheduleController, false, null);
		}

		public void NavigationScheduleJune23()
		{
			this.PresentViewController(day1ScheduleController, false, null);
		}


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


			var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
			UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

			day1ScheduleController = (Day1ScheduleController)this.Storyboard.InstantiateViewController("Day1ScheduleController");
            day1ScheduleController.parent = this;
			day2ScheduleController = (Day2ScheduleController)this.Storyboard.InstantiateViewController("Day2ScheduleController");
            day2ScheduleController.parent = this;
			day3ScheduleController = (Day3ScheduleController)this.Storyboard.InstantiateViewController("Day3ScheduleController");
            day3ScheduleController.parent = this;
			day4ScheduleController = (Day4ScheduleController)this.Storyboard.InstantiateViewController("Day4ScheduleController");
            day4ScheduleController.parent = this;
			myEventsController = (DataViewController)this.Storyboard.InstantiateViewController("DataViewController");
            myEventsController.parent = this;


			HotelName.UserInteractionEnabled = true;
            UITapGestureRecognizer HotelMapGesture = new UITapGestureRecognizer(HotelMapClick);
            HotelMapGesture.NumberOfTapsRequired = 1;
            HotelName.AddGestureRecognizer(HotelMapGesture);

            PhoneNumber.UserInteractionEnabled = true;
            UITapGestureRecognizer CallGesture = new UITapGestureRecognizer(CallClick);
            CallGesture.NumberOfTapsRequired = 1;
            PhoneNumber.AddGestureRecognizer(CallGesture);
			//Perform any additional setup after loading the view, typically from a nib.

			//beaconManager = new BeaconManager();
			//beaconManager.RequestAlwaysAuthorization();

			//TODO: TURN ON LOADING INDICATOR
			Store.Instance.GetTracks(LoadTracksComplete);
		}
        public override void ViewDidAppear(bool animated)
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

   		    InitializeBeacons();
		}

        private void InitializeBeacons()
        {
            //run on main thread
		   UIApplication.SharedApplication.InvokeOnMainThread(delegate
		   {
                //loop through all location entries
            for (int i = 0; i < Store.Instance.Locations.Count; i++)
            {
                Location tempLocation = Store.Instance.Locations[i];
                    //create new region
                CLBeaconRegion beaconRegion = new CLBeaconRegion(new Foundation.NSUuid(PROXIMITY_UUID), ushort.Parse(tempLocation.Major), ushort.Parse(tempLocation.Minor), tempLocation.Nickname);
                beaconRegion.NotifyOnExit = true;
                beaconRegion.NotifyOnEntry = true;
                beaconRegion.NotifyEntryStateOnDisplay = true;
                beaconManager.StartRangingBeaconsInRegion(beaconRegion);
                beaconManager.StartMonitoringForRegion(beaconRegion);
            }
                //on region exit
		    beaconManager.ExitedRegion += (sender, e) =>
		   {
			   var notification = new UILocalNotification();
			   Estimote.ExitedRegionEventArgs f =  e;
			   CLBeaconRegion region = f.Region;

			   UIAlertView alert = new UIAlertView()
			   {
				   Title = "alert title",
				   Message = "Exiting region:" + region.Major + "," + region.Minor
		       };
			   alert.AddButton("OK");
			   //alert.Show();
		   };
                //on region enter
			   beaconManager.EnteredRegion += (sender, e) =>
			   {
				   var notification = new UILocalNotification();



                    Estimote.EnteredRegionEventArgs f =  e;
				   CLBeaconRegion region = f.Region;

				   UIAlertView alert = new UIAlertView()
				   {
					   Title = "alert title",
					   Message = "Entering region:" + region.Major + "," + region.Minor
				   };
				   alert.AddButton("OK");
				   //alert.Show();

			   };
                //this is for when app is open, may be able to use above instead and get rid of this
			beaconManager.RangedBeacons += (sender, e) =>
			{
				if (e.Beacons.Length == 0)
					return;

                Foundation.NSNumber major = e.Beacons[0].Major;
				Foundation.NSNumber minor = e.Beacons[0].Minor;
                Event proximityEvent = Store.Instance.ProximityEvent(major.ToString(), minor.ToString());
                if (proximityEvent != null){
                    //TODO: prompt user for dismiss/load event
                    //TODO: check if current visible view controller is detail page, and if selected event = proximity event
                    //       if yes then display "you are near this event" message on that screen
                    //TODO: submit new session to web service

                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "alert title",
                        Message = proximityEvent.Name
					};
					alert.AddButton("OK");
					//alert.Show();
				}

			};

                });
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

