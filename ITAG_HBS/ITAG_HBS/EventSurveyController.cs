using Foundation;
using System;
using UIKit;
using HBS.ITAG;
using ITAG_HBS;
using System.Collections.Generic;
using HBS.ITAG.Model;
using System.Globalization;

namespace HBS.ITAG
{
    public partial class EventSurveyController : UIViewController
    {
        public HomeViewController parent { get; set; }
        public EventSurvey survey = new EventSurvey();

        public EventSurveyController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            QuestionOneRating.Value = 3;
            QuestionTwoRating.Value = 3;
            QuestionThreeRating.Value = 3;
            QuestionFourRating.Value = 3;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            RefreshPage();
            SubmitButton.UserInteractionEnabled = true;
            UITapGestureRecognizer SubmitSurvey = new UITapGestureRecognizer(SubmitSurveyClick);
            SubmitSurvey.NumberOfTapsRequired = 1;
            SubmitButton.AddGestureRecognizer(SubmitSurvey);

            QuestionOneRating.ValueChanged += HandleValueChanged;
            QuestionTwoRating.ValueChanged += HandleValueChanged;
            QuestionThreeRating.ValueChanged += HandleValueChanged;
            QuestionFourRating.ValueChanged += HandleValueChanged;
        }

		void HandleValueChanged(object sender, EventArgs e)
		{
            var rating = (UISlider)sender;
            if (rating.Value >= 4.5)
            {
                rating.Value = 5;
            }
		    else if (rating.Value >= 3.5)
            {
                rating.Value = 4;
            }
            else if (rating.Value >= 2.5)
            {
                rating.Value = 3;
            }
            else if (rating.Value >= 1.5)
            {
                rating.Value = 2;
            }
            else
            {
                rating.Value = 1;
            }
		}

		public void RefreshPage()
		{
            EventName.Text = Store.Instance.SelectedEvent.Name;
		}

		public void SubmitSurveyClick()
		{
            survey.knowledgeable = 0;
            survey.preparedness = 0;
            survey.understandability = 0;
            survey.usefulness = 0;
            survey.overall = 0;
            survey.otherComments = "";
            //Store.Instance.AddSurvey(survey);
			this.DismissViewController(true, null);
		}
    }
}