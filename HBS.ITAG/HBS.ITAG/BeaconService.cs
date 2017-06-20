using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HBS.ITAG
{
    [Service]
    public class BeaconService : Service
    {

        public Home homeActivity;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public void SetHome(Home home)
        {
            homeActivity = home;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {



            return StartCommandResult.NotSticky;
        }
    }
}