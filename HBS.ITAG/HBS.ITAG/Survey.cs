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
    [Activity(Label = "Survey")]
    public class Survey : Activity, SeekBar.IOnSeekBarChangeListener
    {
        SeekBar seekBar1;
        SeekBar seekBar2;
        SeekBar seekBar3;
        SeekBar seekBar4;
        TextView eventName;
        EditText comments;
        Button done;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            seekBar1 = FindViewById<SeekBar>(Resource.Id.seekBar1);
            seekBar2 = FindViewById<SeekBar>(Resource.Id.seekBar2);
            seekBar3 = FindViewById<SeekBar>(Resource.Id.seekBar3);
            seekBar4 = FindViewById<SeekBar>(Resource.Id.seekBar4);
            eventName = FindViewById<TextView>(Resource.Id.SurveytextView1);
            comments = FindViewById<EditText>(Resource.Id.SurveyOtherComments);
            done = FindViewById<Button>(Resource.Id.SurveyDoneButton);

            // Set Event Name at Top
            // TODO: change this to a more reliable solution
            eventName.Text = Store.Instance.SelectedEvent.Name;

            // Assign this class as a listener for the SeekBar events
            seekBar1.SetOnSeekBarChangeListener(this);
            seekBar2.SetOnSeekBarChangeListener(this);
            seekBar3.SetOnSeekBarChangeListener(this);
            seekBar4.SetOnSeekBarChangeListener(this);

            done.Click += (object sender, EventArgs e) =>
            {
                // Send off survey results
                String seekBar1Answer = seekBar1.Progress.ToString();
                String seekBar2Answer = seekBar2.Progress.ToString();
                String seekBar3Answer = seekBar3.Progress.ToString();
                String seekBar4Answer = seekBar4.Progress.ToString();
                String commentsAnswer = comments.Text;


                StartActivity(typeof(Home));
            };
        }

        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            if (fromUser)
            {
                
            }
        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
            System.Diagnostics.Debug.WriteLine("Tracking changes.");
        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
            System.Diagnostics.Debug.WriteLine("Stopped tracking changes.");
        }
    }
}