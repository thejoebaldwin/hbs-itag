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
            RequestWindowFeature(WindowFeatures.NoTitle);
            
            
            // if statement is here to set up code for later when we actually check to see if survey has already been done
            if ( true )
            {
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
                    // Gets data from survey
                    String stateAnswer = state.SelectedItem.ToString();
                    String ageAnswer = age.SelectedItem.ToString();
                    String genderAnswer = gender.SelectedItem.ToString();
                    String jobTitleAnswer = jobTitle.Text;
                    String emailAnswer = email.Text;
                    String emailNotificationsAnswer;
                    if (emailNotifications.Checked)
                    {
                        emailNotificationsAnswer = "true";
                    }
                    else
                    {
                        emailNotificationsAnswer = "false";
                    }
                    
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

