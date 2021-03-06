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
using HBS.ITAG.Model;

namespace HBS.ITAG
{
    class HotEventAdapter : BaseAdapter<Event>
    {
        List<Event> tableItems;
        Event hotEvent;
        private Context mContext;

        string CellIdentifier = "TableCell";

        public override int Count
        {
            get { return tableItems.Count; }
        }

        public HotEventAdapter(Context context, List<Event> events)
        {
            tableItems = events;
            mContext = context;

            foreach(var item in tableItems)
            {
                if(item.Name == "Person Tester")
                {
                    //
                }

                if(item.NumberOfPeople != 0)
                {
                    if(hotEvent == null)
                    {
                        hotEvent = item;
                    }
                    else if (item.NumberOfPeople > hotEvent.NumberOfPeople)
                    {
                        hotEvent = item;
                    }
                }
            }
        }

        public override Event this[int position]
        {
            get { return tableItems[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.HottestEventListView, null, false);
                //LayoutInflater inflater = (LayoutInflater)mContext.GetSystemService(Context.LayoutInflaterService);
            }
            RelativeLayout eventItem = row.FindViewById<RelativeLayout>(Resource.Id.eventItem);
            TextView eventName = row.FindViewById<TextView>(Resource.Id.HotEventName);
            TextView Attendees = row.FindViewById<TextView>(Resource.Id.Attendee);
            if (hotEvent == null)
            {
                eventName.Text = "Nobody is attending any events yet";
                Attendees.Text = "";
            }

            else
            {
                Event item = hotEvent;
                eventName.Text = tableItems[position].Name;
                Attendees.Text = tableItems[position].NumberOfPeople.ToString() + " Attending";
                if(!item.ScheduleOnly)
                {
                    row.SetBackgroundColor(Android.Graphics.Color.ParseColor("#0e1d52"));
                    eventName.SetTextColor(Android.Graphics.Color.White);
                    Attendees.SetTextColor(Android.Graphics.Color.White);
                }
                else
                {
                    row.SetBackgroundColor(Android.Graphics.Color.ParseColor("#99a1ac"));
                    eventName.SetTextColor(Android.Graphics.Color.ParseColor("#0e1d52"));
                    Attendees.SetTextColor(Android.Graphics.Color.ParseColor("#0e1d52"));
                }
            }

            if (tableItems[position].ScheduleOnly)
            {
                eventItem.SetBackgroundResource(Resource.Drawable.secondaryBox);
            }
            else
            {
                eventItem.SetBackgroundResource(Resource.Drawable.primaryBox);
            }
            return row;
        }
    }
}