using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views;
using System.Collections;
using Android.Content;

namespace HBS.ITAG
{
    [Activity(Label = "HBS.ITAG", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(WindowFeatures.NoTitle);
            
            
            bool surveyDone = false;
            var prefs = Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
            var somePref = prefs.GetBoolean( "PrefName" , false );


            // if statement is here to set up code for later when we actually check to see if survey has already been done
            if (!somePref )
            {
                SetContentView (Resource.Layout.DemographicSurvey);

                Spinner state = FindViewById<Spinner>(Resource.Id.DSspinner1);
                Spinner age = FindViewById<Spinner>(Resource.Id.DSspinner2);
                Spinner gender = FindViewById<Spinner>(Resource.Id.DSspinner3);
                EditText jobTitle = FindViewById<EditText>(Resource.Id.DSedittext);
                Button done = FindViewById<Button>(Resource.Id.DSbutton1);

                // Sets Default Values for Spinners
                state.SetSelection(14);
                age.SetSelection(0);
                gender.SetSelection(0);
                

                done.Click += (object sender, EventArgs e) =>
                {
                    // Gets data from survey
                    String stateAnswer = state.SelectedItem.ToString();
                    String ageAnswer = age.SelectedItem.ToString();
                    String genderAnswer = gender.SelectedItem.ToString();
                    String jobTitleAnswer = jobTitle.Text;

                    surveyDone = true;
                    var prefEditor = prefs.Edit();
                    prefEditor.PutBoolean("PrefName", surveyDone );
                    prefEditor.Commit();

                    Console.WriteLine( prefs.GetBoolean("PrefName", false) );

                    StartActivity(typeof(Home));
                };


            }
            else
            {
                StartActivity(typeof(Home));
            }
            


        }

        

    }
}

