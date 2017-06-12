using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views;
using System.Collections;

namespace HBS.ITAG
{
    [Activity(Label = "HBS.ITAG", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView (Resource.Layout.DemographicSurvey);
            
            Spinner state = FindViewById<Spinner>(Resource.Id.DSspinner1);
            Spinner age = FindViewById<Spinner>(Resource.Id.DSspinner2);
            Spinner gender = FindViewById<Spinner>(Resource.Id.DSspinner3);
            EditText jobTitle = FindViewById<EditText>(Resource.Id.DSedittext);
            EditText email = FindViewById<EditText>(Resource.Id.DSedittext2);
            CheckBox emailNotifications = FindViewById<CheckBox>(Resource.Id.DScheckBox1);
            Button done = FindViewById<Button>(Resource.Id.DSbutton1);

            // Sets Default Values for Spinners
            state.SetSelection(14);
            age.SetSelection(0);
            gender.SetSelection(0);


            done.Click += (object sender, EventArgs e) =>
            {
                StartActivity(typeof(Home));
            };
        }

        

    }
}

