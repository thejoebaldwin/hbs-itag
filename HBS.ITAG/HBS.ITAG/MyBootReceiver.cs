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
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    public class MyBootReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            // Do stuff here when device reboots.
            context.ApplicationContext.StartService(new Intent(context, typeof(SimpleService)));
            Toast.MakeText(context, " Boot Intent-action: " + intent.Action, ToastLength.Long).Show();
        }
    }
}