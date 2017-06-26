using System;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;
using EstimoteSdk;
using HBS.ITAG.Model;

namespace HBS.ITAG
{
    [Service]
    public class SimpleService : Service, BeaconManager.IServiceReadyCallback
    {

        BeaconManager beaconManager;
        const string PROXIMITY_UUID = "B9407F30-F5F8-466E-AFF9-25556B57FE6D";

        public override void OnCreate()
        {
            base.OnCreate();
            beaconManager = new BeaconManager(this);
            beaconManager.SetBackgroundScanPeriod(1000, 1);
            beaconManager.ExitedRegion += (sender, e) =>
            {

                if (Store.Instance.Notify)
                {

                    Event tempEvent = Store.Instance.ProximityEvent(e.P0.Major.ToString(), e.P0.Minor.ToString());

                    if (tempEvent != null)
                    {
                        OnRegionExit(tempEvent);
                    }
                }
            };

            beaconManager.EnteredRegion += (sender, e) =>
            {

                if (Store.Instance.Notify)
                {
                    Event tempEvent = Store.Instance.ProximityEvent(e.Region.Major.ToString(), e.Region.Minor.ToString());
                    
                    if (tempEvent != null)
                    {
                        OnRegionEnter(tempEvent);
                    }
                }
            };
            beaconManager.Connect(this);
        }
        
        public void OnServiceReady()
        {
            InitializeBeacons();
        }

        private void InitializeBeacons()
        {
            //run on main thread
            //loop through all location entries
            Region beaconRegionTest = new Region("test", null, null, null);
            beaconManager.StartMonitoring(beaconRegionTest);
            for (int i = 0; i < Store.Instance.Locations.Count; i++)
            {
                Location tempLocation = Store.Instance.Locations[i];
                //create new region
                Region beaconRegion = new Region(tempLocation.Nickname, tempLocation.BeaconGuid, System.Convert.ToInt32(tempLocation.Major), System.Convert.ToInt32(tempLocation.Minor));
                Console.WriteLine(tempLocation.Nickname + " " + tempLocation.BeaconGuid + " " + tempLocation.Major + " " + tempLocation.Minor);
                //Region beaconRegion = new Region(tempLocation.Nickname, null, null, null);
                beaconManager.StartMonitoring(beaconRegion);
            }
        }

        public void OnRegionExit(Event tempEvent)
        {
            Toast.MakeText(this, "You are leaving the event : " + tempEvent.Name + ".", ToastLength.Long).Show();
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
            Store.Instance.SelectedEvent = tempEvent;
            Intent newIntent = new Intent(this, typeof(EventDetails));
            Android.Support.V4.App.TaskStackBuilder stackBuilder = Android.Support.V4.App.TaskStackBuilder.Create(this);
            stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(EventDetails)));
            stackBuilder.AddNextIntent(newIntent);

            PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

            Android.Support.V4.App.NotificationCompat.Builder builder = new Android.Support.V4.App.NotificationCompat.Builder(this)
            .SetAutoCancel(true)
            .SetContentIntent(resultPendingIntent)
            .SetContentTitle("Itag Conference")
            .SetSmallIcon(Resource.Drawable.itag_icon)
            .SetContentText("You are near : " + tempEvent.Name + ". Click for more details.")
            .SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate)
            .SetPriority((int)NotificationPriority.High);
            NotificationManager notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
            notificationManager.Notify(1, builder.Build());
            
            int minutesSinceLastNotification = (tempEvent.LastEntryNotified - DateTime.Now).Minutes;
            minutesSinceLastNotification = Math.Abs(minutesSinceLastNotification);

            //don't notify twice in a row and don't repeat the same notification more than once in 10 minutes
            if (Store.Instance.SelectedEvent != tempEvent && minutesSinceLastNotification > 5)
            {
                //TODO: If app open, ask user if they want to see the information
                //      if app closed, add notification that event is in range

                tempEvent.LastEntryNotified = DateTime.Now;
                Store.Instance.AddSession(tempEvent.Id, true, OnSessionAddComplete);
            }
        }

        public void OnSessionAddComplete(string message)
        {

        }

        
        public override IBinder OnBind(Intent intent)
        {
            // This is a started service, not a bound service, so we just return null.
            return null;
        }


        public override void OnDestroy()
        {
            beaconManager.Disconnect();
            base.OnDestroy();
        }

    }
}