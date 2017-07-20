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
    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { Android.Content.Intent.ActionBootCompleted, Android.Content.Intent.ActionPowerConnected, "test" })]
    public class MyBootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            // Do stuff here when device reboots.
            //context.ApplicationContext.StartService(new Intent(context, typeof(SimpleService)));
            //context.StartService(new Intent(context, typeof(SimpleService)));
            //context.ApplicationContext.StartService(new Intent(context, typeof(SimpleService)));
            //Toast.MakeText(context, " Boot Intent-action: " + intent.Action, ToastLength.Long).Show();
            //Console.WriteLine("THIS IS MY TEST");


            if ((intent.Action != null) && (intent.Action == Android.Content.Intent.ActionBootCompleted))
            { // Start the service or activity
              //context.ApplicationContext.StartService(new Intent(context, typeof(SimpleService)));

                //Android.Content.Intent start = new Android.Content.Intent(context, typeof(Home));

                // my activity name is MainActivity replace it with yours
                //start.AddFlags(ActivityFlags.NewTask);
                //context.ApplicationContext.StartActivity(start);
                
            }
        }
    }
}