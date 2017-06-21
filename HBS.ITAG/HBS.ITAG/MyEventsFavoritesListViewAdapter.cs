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
    class MyEventsFavoritesListViewAdapter : BaseAdapter<Event>
    {

        private List<Event> tableItems;
        private Context mContext;

        public override int Count
        {
            get { return tableItems.Count; }
        }

        public MyEventsFavoritesListViewAdapter(Context context, List<Event> events)
        {
            tableItems = events;
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
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.MyEventsFavoritesListView, null, false);
                //LayoutInflater inflater = (LayoutInflater)mContext.GetSystemService(Context.LayoutInflaterService);
            }
            LinearLayout eventItem = row.FindViewById<LinearLayout>(Resource.Id.eventItem);
            TextView eventName = row.FindViewById<TextView>(Resource.Id.MElistViewTextView1);
            TextView eventTime = row.FindViewById<TextView>(Resource.Id.faveEventTime);
            if (tableItems[position].Name == null)
            {
                eventName.Text = "No Favorites Selected";
                eventTime.Text = "Favorites selectable via Schedule Page";
            }
            else
            {
                eventName.Text = tableItems[position].Name;
                eventTime.Text = tableItems[position].StartTime.ToLocalTime().ToShortTimeString() + " - " + tableItems[position].EndTime.ToLocalTime().ToShortTimeString();
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