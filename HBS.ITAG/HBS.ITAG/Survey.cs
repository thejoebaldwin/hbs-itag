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
using Java.Util;
using static Android.App.ActionBar;

namespace HBS.ITAG
{
    [Activity(Label = "Survey")]
    public class Survey : Activity, SeekBar.IOnSeekBarChangeListener
    {
        SeekBar seekBar1;
        SeekBar seekBar2;
        SeekBar seekBar3;
        TextView eventName;
        EditText comments;
        EditText email;
        Spinner emailNotifications;
        Button done;
        EventSurvey survey;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Survey);

            seekBar1 = FindViewById<SeekBar>(Resource.Id.seekBar1);
            seekBar2 = FindViewById<SeekBar>(Resource.Id.seekBar2);
            seekBar3 = FindViewById<SeekBar>(Resource.Id.seekBar3);
            eventName = FindViewById<TextView>(Resource.Id.SurveytextView1);
            comments = FindViewById<EditText>(Resource.Id.SurevyEdittext);
            email = FindViewById<EditText>(Resource.Id.SurevyEmailEdittext);
            emailNotifications = FindViewById<Spinner>(Resource.Id.SurveySpinner);
            done = FindViewById<Button>(Resource.Id.SurveyDoneButton);
            survey = new EventSurvey();

            // Set Event Name at Top
            // TODO: change this to a more reliable solution
            //eventName.Text = Store.Instance.SelectedEvent.Name;

            // Assign this class as a listener for the SeekBar events
            seekBar1.SetOnSeekBarChangeListener(this);
            seekBar2.SetOnSeekBarChangeListener(this);
            seekBar3.SetOnSeekBarChangeListener(this);
          
            emailNotifications.ItemSelected += EmailNotifications_ItemSelected;

            done.Click += (object sender, EventArgs e) =>
            {
                // Send off survey results
                survey.QuestionOneRating = seekBar1.Progress;
                survey.QuestionTwoRating = seekBar2.Progress;
                survey.QuestionThreeRating = seekBar3.Progress;
                survey.OtherComments = comments.Text;
                if (email != null && email.Text != "")
                {
                    survey.Email = email.Text;
                    survey.QuestionFourAnswer = "Yes";
                }
                else
                {
                    survey.QuestionFourAnswer = "No";
                }
                Store.Instance.DeleteToDo(Store.Instance.SelectedEvent);
                Store.Instance.AddSurvey(survey, AddSurveyComplete);

                StartActivity(typeof(Home));
            };

            void AddSurveyComplete(string message)
            {
            }
        }

        private void EmailNotifications_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            if (emailNotifications.SelectedItem.ToString().Equals("Yes"))
            {
                email.Visibility = ViewStates.Visible;
                ViewGroup.MarginLayoutParams temp = (RelativeLayout.LayoutParams)emailNotifications.LayoutParameters;
                temp.SetMargins(50, 0, 0, 0);
            }
            else
            {
                email.Visibility = ViewStates.Gone;
                ViewGroup.MarginLayoutParams temp = (RelativeLayout.LayoutParams)emailNotifications.LayoutParameters;
                temp.SetMargins(0, 0, 0, 0);
            }
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