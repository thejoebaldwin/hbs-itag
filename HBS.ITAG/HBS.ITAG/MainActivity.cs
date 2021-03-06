﻿using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views;
using Android.Content;
using HBS.ITAG.Model;
using Android.Telecom;
using Android.Graphics;

namespace HBS.ITAG
{
    [Activity(Label = "HBS.ITAG", MainLauncher = true, Icon = "@drawable/itag_icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);

            SimpleService.AppClosed = false;

            // Checks if user has completed survey
            bool surveyDone = false;
            var prefs = Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
            var somePref = prefs.GetBoolean( "PrefName" , false );
            
            if (!somePref)
            {
                SetContentView (HBS.ITAG.Resource.Layout.DemographicSurvey);
                Spinner techFocus = FindViewById<Spinner>(Resource.Id.DSspinner1);
                Spinner organization = FindViewById<Spinner>(Resource.Id.DSspinner4);
                Spinner age = FindViewById<Spinner>(Resource.Id.DSspinner2);
                Spinner gender = FindViewById<Spinner>(Resource.Id.DSspinner3);
                EditText jobTitle = FindViewById<EditText>(Resource.Id.DSedittext);
                Button done = FindViewById<Button>(Resource.Id.DSbutton1);

                // Sets Default Values for Spinners
                organization.SetSelection(0);
                techFocus.SetSelection(0);
                age.SetSelection(0);
                gender.SetSelection(0);

               

            done.Click += (object sender, EventArgs e) =>
                {
                    if (age.SelectedItem.ToString().Trim().Equals("Choose One")|| organization.SelectedItem.ToString().Trim().Equals("Choose One")|| gender.SelectedItem.ToString().Trim().Equals("Choose One")|| techFocus.SelectedItem.ToString().Trim().Equals("Choose One"))
                    {
                        if(age.SelectedItem.ToString().Trim().Equals("Choose One"))
                        {
                            age.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FF0000"));
                            Toast.MakeText(this, "Please select a valid age", ToastLength.Short).Show();
                        }

                        if (gender.SelectedItem.ToString().Trim().Equals("Choose One"))
                        {
                            gender.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FF0000"));
                            Toast.MakeText(this, "Please select a valid gender", ToastLength.Short).Show();
                        }

                        if (organization.SelectedItem.ToString().Trim().Equals("Choose One"))
                        {
                            organization.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FF0000"));
                            Toast.MakeText(this, "Please select a valid organization", ToastLength.Short).Show();
                        }

                        if (techFocus.SelectedItem.ToString().Trim().Equals("Choose One"))
                        {
                            techFocus.SetBackgroundColor(Android.Graphics.Color.ParseColor("#FF0000"));
                            Toast.MakeText(this, "Please select a valid technical focus", ToastLength.Short).Show();
                        }
                    }


                   /* if (organization.SelectedItem.ToString().Trim().Equals("Choose One"))
                    {
                        Toast.MakeText(this, "Please select a valid organization", ToastLength.Short).Show();
                    }

                    if (gender.SelectedItem.ToString().Trim().Equals("Choose One"))
                    {
                        Toast.MakeText(this, "Please select a valid gender", ToastLength.Short).Show();
                    }

                    if (techFocus.SelectedItem.ToString().Trim().Equals("Choose One"))
                    {
                        Toast.MakeText(this, "Please select a valid technical focus", ToastLength.Short).Show();
                    }
                    */
                    // Gets data from survey
                    else
                    {
                        String ageAnswer = age.SelectedItem.ToString();
                        String genderAnswer = gender.SelectedItem.ToString();
                        String techFocusAnswer = techFocus.SelectedItem.ToString();
                        String organizationAnswer = organization.SelectedItem.ToString();
                        String jobTitleAnswer = jobTitle.Text;


                        Store.Instance.AddUser(
                            new User("-1", ageAnswer,
                            genderAnswer, techFocusAnswer,
                            organizationAnswer, jobTitleAnswer,
                            "Android", Android.OS.Build.Serial), AddUserComplete);


                        surveyDone = true;
                        var prefEditor = prefs.Edit();
                        prefEditor.PutBoolean("PrefName", surveyDone);
                        prefEditor.Commit();

                        Intent i = new Intent(Application.Context, typeof(Home));
                        i.SetFlags(ActivityFlags.ReorderToFront);
                        StartActivity(i);
                    }
                };
            }
            else
            {
                Intent i = new Intent(Application.Context, typeof(Home));
                i.SetFlags(ActivityFlags.ReorderToFront);
                StartActivity(i);
            }
        }
        private void AddUserComplete(string message) { }
    }
}

