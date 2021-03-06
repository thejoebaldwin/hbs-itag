﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
using Foundation;
using UIKit;
using HBS.ITAG.Model;
using Estimote;
using HBS.ITAG;
using CoreLocation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HBS.ITAG
{
    public partial class HomeViewController : UIViewController
    {
        protected LoadingPage loadPop = null;

        //bool doneload;
        partial void NotifySwitchClicked(UISwitch sender)
        {
            Store.Instance.Notify = NotifySwitch.On;
        }

        partial void AboutButtonClick(UIButton sender)
        {
            this.PresentViewController(aboutViewController, true, null);
        }

        partial void EventsButtonClick(UIButton sender)
        {
            NavigateToMyEvents();
        }

        partial void ScheduleButtonClick(UIButton sender)
        {
            NavigateToSchedule();
        }

        BeaconManager beaconManager;

		const string PROXIMITY_UUID = "B9407F30-F5F8-466E-AFF9-25556B57FE6D";

		public ScheduleController ScheduleController { get; set; }
        public MyEventsViewController myEventsController { get; set; }
		public AppFeaturesViewController aboutViewController { get; set; }
        public EventDetailController eventDetailViewController { get; set; }
        public EventSurveyController eventSurveyController { get; set; }

		public string DataObject
		{
			get; set;
		}

        public HomeViewController(IntPtr handle) : base(handle)
        {
        }

        public void NavigateToSchedule()
        {
			var bounds = UIScreen.MainScreen.Bounds; // portrait bounds
                          //show the loading overlay on the UI thread using the correct orientation sizing
			loadPop = new LoadingPage(bounds);
            View.Add(loadPop);
			this.PresentViewController(ScheduleController, false, null);
        }

        public void NavigateToMyEvents()
        {
			var bounds = UIScreen.MainScreen.Bounds; // portrait bounds
													 //show the loading overlay on the UI thread using the correct orientation sizing
			loadPop = new LoadingPage(bounds);
			View.Add(loadPop);
			this.PresentViewController(myEventsController, false, null);
        }

        //For Testing Number Of People
        public void LogoClicked()
        {
            //Toggle testEvent number of Persons
            Store.Instance.RefreshEventAttendees(refreshEventsComplete);
            if(Store.Instance.clicked)
            {
                Store.Instance.clicked = false;
				foreach (var e in Store.Instance.Events)
				{
					if (e.Id == Store.Instance.testEvent.Id)
					{
						Store.Instance.RemovePerson(e);
                        testLabel.Text = "";
					}
				}
            }
    //        else
    //        {
    //            Store.Instance.clicked = true;
				//foreach (var e in Store.Instance.Events)
				//{
				//	if (e.Id == Store.Instance.testEvent.Id)
				//	{
				//		Store.Instance.AddPerson(e);
				//	}
    //                testLabel.Text = "";
				//}
            //}
            ReloadData();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Store.Instance.ToDoList = new List<Event>();

            NotifySwitch.On = Store.Instance.Notify;

			var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null);
			UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

			ScheduleController = (ScheduleController)this.Storyboard.InstantiateViewController("ScheduleController");
            ScheduleController.parent = this;
			myEventsController = (MyEventsViewController)this.Storyboard.InstantiateViewController("DataViewController");
            myEventsController.parent = this;
			eventDetailViewController = (EventDetailController)this.Storyboard.InstantiateViewController("EventDetailController");
            eventDetailViewController.parent = this;
            eventSurveyController = (EventSurveyController)this.Storyboard.InstantiateViewController("EventSurveyController");
            eventSurveyController.parent = this;
            aboutViewController = (AppFeaturesViewController)this.Storyboard.InstantiateViewController("AboutViewController");

			HotelName.UserInteractionEnabled = true;
            UITapGestureRecognizer HotelMapGesture = new UITapGestureRecognizer(HotelMapClick);
            HotelMapGesture.NumberOfTapsRequired = 1;
            HotelName.AddGestureRecognizer(HotelMapGesture);

            //ForTesting
            Logo.UserInteractionEnabled = true;
            UITapGestureRecognizer LogoClick = new UITapGestureRecognizer(LogoClicked);
            LogoClick.NumberOfTapsRequired = 1;
            Logo.AddGestureRecognizer(LogoClick);


            PhoneNumber.UserInteractionEnabled = true;
            UITapGestureRecognizer CallGesture = new UITapGestureRecognizer(CallClick);
            CallGesture.NumberOfTapsRequired = 1;
            PhoneNumber.AddGestureRecognizer(CallGesture);
			//Perform any additional setup after loading the view, typically from a nib.

			if (ObjCRuntime.Runtime.Arch == ObjCRuntime.Arch.DEVICE)
			{
				beaconManager = new BeaconManager();
				beaconManager.RequestAlwaysAuthorization();
			}
			//TODO: TURN ON LOADING INDICATOR
			Store.Instance.GetTracks(LoadTracksComplete);
		}

        public void ReloadData()
        {
            //TODO Store.Instance.GetEvents(refreshEventsComplete);
			ToDoTableViewSource data = new ToDoTableViewSource(Store.Instance.ToDoList);
            HotEventTableViewSource HotEventData = new HotEventTableViewSource(Store.Instance.Events);
			data.parent = this;
            HotEventData.parent = this;

            ToDoTableView.Source = data;
            ToDoTableView.ReloadData();
            HotEventTableView.Source = HotEventData;
            HotEventTableView.ReloadData();

            UIApplication.SharedApplication.ApplicationIconBadgeNumber = Store.Instance.ToDoList.Count;
        }

        public void refreshEventsComplete(string message)
        {
            loadPop.Hide();
        }

        public override void ViewDidAppear(bool animated)
        {
            Store.Instance.RefreshEventAttendees(refreshEventsComplete);
            ReloadData();
            if (!Store.Instance.UserCreated())
            {
				PickerViewController temp = (PickerViewController)this.Storyboard.InstantiateViewController("pickerview");
				this.PresentViewController(temp, true, null);
            }
        }

        bool initialized = false;

		private void LoadTracksComplete(string message)
		{
			Store.Instance.GetEvents(LoadEventsComplete);
            //Store.Instance.UpdateEventArray();
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
            ReloadData();
            initialized = true;
            if (ObjCRuntime.Runtime.Arch == ObjCRuntime.Arch.DEVICE)
            {
                InitializeBeacons();
            }
		}

        //TODO delete once done.. just an empty callback for initializing
        private void AddPeoplesInitializer(string message)
        {
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
                beaconManager.StartMonitoringForRegion(beaconRegion);
            }
            //on region exit
		    beaconManager.ExitedRegion += (sender, e) =>
		   {
               Store.Instance.RefreshEventAttendees(refreshEventsComplete);
               if (Store.Instance.Notify)
               {
                   Estimote.ExitedRegionEventArgs f = e;
                   CLBeaconRegion region = f.Region;
                   Event tempEvent = Store.Instance.ProximityEvent(region.Major.StringValue, region.Minor.StringValue);
                   if(tempEvent.Name == testLabel.Text)
                    {
                       testLabel.Text = "";
                    }
                   else
                    {
                       testLabel.Text = "connected to diff event still";        
                    }
                   if (tempEvent != null)
                   {
                        OnRegionExit(tempEvent);
                            //TODO How much time required to give them a survey
                        if(!Store.Instance.ToDoList.Contains(tempEvent))
	                    {
	                        Store.Instance.AddToDo(tempEvent);
	                    }
                            //TODO link with back end
                        Store.Instance.RemovePerson(tempEvent);
                        ReloadData();
                   }
               }
		   };
            //on region enter 
			beaconManager.EnteredRegion += (sender, e) =>
			{
                Store.Instance.RefreshEventAttendees(refreshEventsComplete);
                if (Store.Instance.Notify)
                {
                    Estimote.EnteredRegionEventArgs f = e;
                    CLBeaconRegion region = f.Region;
                    Event tempEvent = Store.Instance.ProximityEvent(region.Major.StringValue, region.Minor.StringValue);
                    if (tempEvent != null)
                    {
                        Store.Instance.AddPerson(tempEvent);
                        OnRegionEnter(tempEvent);
                        ReloadData();
                    }
                }
             };
            });
        }

        private void OnSessionAddComplete(string message)
        {
            
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

			if (initialized)
			{
				ReloadData();
			}
		}

        public void AddEventDetailViewController()
        {
			
        }

        public void OnRegionExit(Event tempEvent)
        {
            int minutesSinceLastNotification = (tempEvent.LastExitNotified - DateTime.Now).Minutes;
            minutesSinceLastNotification = Math.Abs(minutesSinceLastNotification);
			if (minutesSinceLastNotification > 5)
            {
				Store.Instance.AddSession(tempEvent.Id, false, OnSessionAddComplete);
                tempEvent.LastExitNotified = DateTime.Now;
            }
        }

		public void OnRegionEnter(Event tempEvent)
		{
            int minutesSinceLastNotification = (tempEvent.LastEntryNotified - DateTime.Now).Minutes;
            minutesSinceLastNotification = Math.Abs(minutesSinceLastNotification);
            //don't notify twice in a row and don't repeat the same notification more than once in 10 minutes
            if (Store.Instance.SelectedEvent != tempEvent && minutesSinceLastNotification > 5)
            {
                if (UIApplication.SharedApplication.ApplicationState == UIApplicationState.Background)
                {
                    Store.Instance.SelectedEvent = tempEvent;
                    var notification = new UILocalNotification();
                    notification.FireDate = NSDate.FromTimeIntervalSinceNow(0);
                    string message = string.Format("You are near an event in progress: {0}", tempEvent.Name);
                    // configure the alert
                    notification.AlertAction = "You are near an event!";
                    notification.AlertBody = message;
                    // modify the badge
                    notification.ApplicationIconBadgeNumber = 0;
                    // set the sound to be the default sound
                    notification.SoundName = UILocalNotification.DefaultSoundName;
                    // schedule it
                    UIApplication.SharedApplication.ScheduleLocalNotification(notification);
                }
                else
                {
                    var okAlertController = UIAlertController.Create("You are near an event!", tempEvent.Name, UIAlertControllerStyle.Alert);
                    okAlertController.AddAction(UIAlertAction.Create("Dismiss", UIAlertActionStyle.Default, null));

                    UIAlertAction action = UIAlertAction.Create("Show Me", UIAlertActionStyle.Default, alert => {
                        Store.Instance.SelectedEvent = tempEvent;
                        if (this.PresentedViewController != null && this.PresentedViewController == this.eventDetailViewController)
                        {
                            //refresh page if already on detail view controller
                            eventDetailViewController.RefreshPage();
                        }
                        else
                        {
                            if (this.PresentedViewController != null)
                            {
                                this.PresentedViewController.PresentViewController(eventDetailViewController, true, null);
                            }
                            else
                            {
                                this.PresentViewController(eventDetailViewController, true, null);
                            }
                        }
                    });
                    okAlertController.AddAction(action);
                    // Present Alert
                    //
                    if (this.PresentedViewController != null)
                    {
                        this.PresentedViewController.PresentViewController(okAlertController, true, null);
                    }
                    else
                    {
                        this.PresentViewController(okAlertController, true, null);
                    }
                }
                tempEvent.LastEntryNotified = DateTime.Now;
				Store.Instance.AddSession(tempEvent.Id, true, OnSessionAddComplete);
            }
		}
    }
}