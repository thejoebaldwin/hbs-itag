using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using EstimoteSdk;
using HBS.ITAG.Model;

namespace HBS.ITAG
{
    [Service(Exported = true, Name = "net.hbs.itag.SimpleService")]
    public class SimpleService : Service, BeaconManager.IServiceReadyCallback
    {
        public static bool AppClosed;
        public static string current_Event;
        BeaconManager beaconManager;
        const string PROXIMITY_UUID = "B9407F30-F5F8-466E-AFF9-25556B57FE6D";
        
        // Runs the beacon code even when app is closed
        void StartServiceInForeground()
        {
            beaconManager = new BeaconManager(this);
            beaconManager.SetBackgroundScanPeriod(1000, 1);

            beaconManager.EnteredRegion += (sender, e) =>
            {
                if (Store.Instance.Notify)
                {
                    Event tempEvent = Store.Instance.ProximityEvent(e.Region.Major.ToString(), e.Region.Minor.ToString());


                    if (tempEvent != null)
                    {
                        Store.Instance.AddPerson(tempEvent);
                        OnRegionEnter(tempEvent);
                    }
                }
            };

            beaconManager.ExitedRegion += (sender, e) =>
            {
               
                if (Store.Instance.Notify)
                {
                    Event tempEvent = Store.Instance.ProximityEvent(e.P0.Major.ToString(), e.P0.Minor.ToString());
                    current_Event = "no event selected";

                    if (tempEvent != null)
                    {
                        OnRegionExit(tempEvent);
                        if (!Store.Instance.ToDoList.Contains(tempEvent))
                        {
                            Store.Instance.AddToDo(tempEvent);
                        }
                        Store.Instance.RemovePerson(tempEvent);

                        // TODO: Set up back end so this isn't always a null reference
                        /*
                        if (!Store.Instance.ToDoList.Contains(tempEvent))
                        {
                            Store.Instance.AddToDo(tempEvent);
                        }*/
                    }
                }
            };

            beaconManager.Connect(this);

            Notification temp = new Notification();
            StartForeground((int)NotificationFlags.AutoCancel, temp);
        }

        public override void OnCreate()
        {
            base.OnCreate();
            StartServiceInForeground();
        }
        
        public void OnServiceReady()
        {
            InitializeBeacons();
        }

        private void InitializeBeacons()
        {
            //Loop through all location entries
            Region beaconRegionTest = new Region("test", null, null, null);
            beaconManager.StartMonitoring(beaconRegionTest);
            for (int i = 0; i < Store.Instance.Locations.Count; i++)
            {
                Location tempLocation = Store.Instance.Locations[i];
                Region beaconRegion = new Region(tempLocation.Nickname, tempLocation.BeaconGuid, System.Convert.ToInt32(tempLocation.Major), System.Convert.ToInt32(tempLocation.Minor));
                Console.WriteLine(tempLocation.Nickname + " " + tempLocation.BeaconGuid + " " + tempLocation.Major + " " + tempLocation.Minor);
                beaconManager.StartMonitoring(beaconRegion);
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

            current_Event = tempEvent.Name;

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

            //Don't notify twice in a row and don't repeat the same notification more than once in 10 minutes
            if (Store.Instance.SelectedEvent != tempEvent && minutesSinceLastNotification > 5)
            {
                tempEvent.LastEntryNotified = DateTime.Now;
                Store.Instance.AddSession(tempEvent.Id, true, OnSessionAddComplete);
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

        public void OnSessionAddComplete(string message) { }
        
        public override IBinder OnBind(Intent intent)
        {
            // This is a started service, not a bound service, so we just return null.
            return null;
        }

        public override void OnTaskRemoved(Intent rootIntent)
        {
            AppClosed = true;
        }

        public override void OnDestroy()
        {
            beaconManager.Disconnect();
            base.OnDestroy();
        }
    }
}
