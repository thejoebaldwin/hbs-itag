using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views;
using System.Collections;
using Android.Content;
using HBS.ITAG.Model;
using EstimoteSdk;
using Android;

namespace HBS.ITAG
{
    [Activity(Label = "HBS.ITAG", MainLauncher = true, Icon = "@drawable/itag_icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);

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
                    // Gets data from survey
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
                    prefEditor.PutBoolean("PrefName", surveyDone );
                    prefEditor.Commit();
                    
                    StartActivity(typeof(Home));
                };
            }
            else
            {
                StartActivity(typeof(Home));
            }
        }

        private void AddUserComplete(string message)
        {
        }

    }
}

