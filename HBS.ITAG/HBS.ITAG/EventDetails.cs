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
using Android.Text;
using Android.Text.Method;
using Android.Graphics.Drawables;
using Android;

namespace HBS.ITAG
{
    [Activity(Label = "EventDetails")]
    public class EventDetails : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EventDetails);
            // Create your application here


            //TextView t2 = (TextView)FindViewById(Resource.Id.EDtextView9);
            //t2.MovementMethod = LinkMovementMethod.Instance;

             TextView textView = FindViewById<TextView>(Resource.Id.EDtextView9);
             textView.TextFormatted = Html.FromHtml("" +
                             "<a href=https://iowacountiesit.org/itag-conference/schedule/tuesday/#event-166\">Click Here</a> " +
                             "");

             textView.MovementMethod = LinkMovementMethod.Instance;

            var button = FindViewById<ImageButton>(Resource.Id.EDimageButton1);
            int count = 0;
            button.Click += (object sender, EventArgs e) =>
                {

                    if (count % 2 == 0)
                    {
                        Toast toast = Toast.MakeText(this, "Added to Favorites", ToastLength.Short);
                        toast.Show();
                        button.SetImageDrawable(GetDrawable(17301516));
                        count++;
                    }
                    else
                    {
                        Toast toast = Toast.MakeText(this, "Removed from Favorites", ToastLength.Short);
                        toast.Show();
                        button.SetImageDrawable(GetDrawable(17301515));
                        count++;
                    }
                     
                };
           
           
            
        }
    }
}