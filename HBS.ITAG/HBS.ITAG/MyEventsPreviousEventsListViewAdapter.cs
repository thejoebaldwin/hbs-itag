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
using HBS.ITAG.Model;

namespace HBS.ITAG
{
    class MyEventsPreviousEventsListViewAdapter : BaseAdapter<Event>
    {

        private List<Event> tableItems;
        private Context mContext;

        public override int Count
        {
            get { return tableItems.Count; }
        }

        public MyEventsPreviousEventsListViewAdapter(Context context, List<Event> items)
        {
            tableItems = items;
            mContext = context;
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
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.MyEventsPreviousEventsListView, null, false);
            }
            LinearLayout eventItem = row.FindViewById<LinearLayout>(Resource.Id.eventItem);
            TextView txtname = row.FindViewById<TextView>(Resource.Id.MElistViewTextView2);
            TextView eventTime = row.FindViewById<TextView>(Resource.Id.prevEventTime);
            txtname.Text = tableItems[position].Name;
            eventTime.Text = tableItems[position].StartTime.ToLocalTime().ToShortTimeString() + " - " + tableItems[position].EndTime.ToLocalTime().ToShortTimeString();

            if(tableItems[position].ScheduleOnly)
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