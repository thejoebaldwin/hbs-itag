using Foundation;
using System;
using UIKit;
using HBS.ITAG;
using ITAG_HBS;
using System.Collections.Generic;
using HBS.ITAG.Model;
using System.Globalization;
using System.Drawing;

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

            OtherComments.Started += (sender, e) =>
            {
                View.Frame = new CoreGraphics.CGRect(View.Frame.X, View.Frame.Y - 175, View.Frame.Size.Width, View.Frame.Size.Height);
                Q1Numbers.Hidden = true;
            };

            OtherComments.Ended += (sender, e) =>
            {
                View.Frame = new CoreGraphics.CGRect(View.Frame.X, View.Frame.Y + 175, View.Frame.Size.Width, View.Frame.Size.Height);
                Q1Numbers.Hidden = false;
            };

			UIToolbar toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, (float)this.View.Frame.Size.Width, 44.0f));
			toolbar.TintColor = UIColor.White;
			toolbar.BarStyle = UIBarStyle.Black;
			toolbar.Translucent = true;
            toolbar.Items = new UIBarButtonItem[]{
                new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
				new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate
				{
                    this.OtherComments.ResignFirstResponder();
				})
			 };
			this.OtherComments.KeyboardAppearance = UIKeyboardAppearance.Dark;
            //OtherComments.
            this.OtherComments.InputAccessoryView = toolbar;
            QuestionOneRating.Value = 3;
            QuestionTwoRating.Value = 3;
            QuestionThreeRating.Value = 3;
            QuestionFourRating.Value = 3;
            OtherComments.Text = "";
			OtherComments.Layer.BorderColor = UIColorExtension.FromHex(0x0E1D52).CGColor;
			OtherComments.Layer.BorderWidth = 1;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            RefreshPage();
            SubmitButton.UserInteractionEnabled = true;
            UITapGestureRecognizer SubmitSurvey = new UITapGestureRecognizer(SubmitSurveyClick);
            SubmitSurvey.NumberOfTapsRequired = 1;
            SubmitButton.AddGestureRecognizer(SubmitSurvey);
			OtherComments.Layer.BorderColor = UIColorExtension.FromHex(0x0E1D52).CGColor;
			OtherComments.Layer.BorderWidth = 1;
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
            Store.Instance.ToDoList.Remove(Store.Instance.SelectedEvent);
            //TODO Save Survey to Back End
			this.DismissViewController(true, null);
		}
    }
}