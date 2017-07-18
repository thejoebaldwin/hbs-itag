﻿using System;
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
    public class MyBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            // Do stuff here
            context.ApplicationContext.StartService(intent);
            Toast.MakeText(context, "Intent-action: " + intent.Action, ToastLength.Long).Show();
        }
    }
}