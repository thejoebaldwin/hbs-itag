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
        nfloat startingX;

		public List<string> options = new List<string>
		{
			"No", "Yes"
		};

        public EventSurveyController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            startingX = QuestionFourTextView.Frame.X;

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

            EmailTextView.Started += (sender, e) =>
            {
                View.Frame = new CoreGraphics.CGRect(View.Frame.X, View.Frame.Y - 55, View.Frame.Size.Width, View.Frame.Size.Height);
            };

			EmailTextView.Ended += (sender, e) =>
			{
				View.Frame = new CoreGraphics.CGRect(View.Frame.X, View.Frame.Y + 55, View.Frame.Size.Width, View.Frame.Size.Height);
			};

			UIToolbar toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, (float)this.View.Frame.Size.Width, 44.0f));
			toolbar.TintColor = UIColor.White;
			toolbar.BarStyle = UIBarStyle.Black;
			toolbar.Translucent = true;
            toolbar.Items = new UIBarButtonItem[]{
                new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
				new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate
				{
					if(this.QuestionFourTextView.ResignFirstResponder())
					{
						this.QuestionFourTextView.Text = options[(int)this.YesNoQuestionPicker.SelectedRowInComponent(0)];
					}
					
                    this.OtherComments.ResignFirstResponder();
                    this.QuestionFour.ResignFirstResponder();
                    this.EmailTextView.ResignFirstResponder();
				})
			 };

			this.YesNoQuestionPicker.RemoveFromSuperview();
			this.QuestionFourTextView.InputView = YesNoQuestionPicker;
			this.QuestionFourTextView.InputAccessoryView = toolbar;
			var QuestionFourViewModel = new SurveyYesNoModel(options);
			QuestionFourViewModel.answerChanged += (sender, e) =>
			{
				QuestionFourTextView.Text = QuestionFourViewModel.selectedAnswer;
				if (options[(int)this.YesNoQuestionPicker.SelectedRowInComponent(0)] == "Yes" && QuestionFourTextView.Frame.X == startingX)
				{
					QuestionFourTextView.Frame = new CoreGraphics.CGRect(QuestionFourTextView.Frame.X - 100, QuestionFourTextView.Frame.Y, QuestionFourTextView.Frame.Size.Width, QuestionFourTextView.Frame.Size.Height);
					EmailTextView.Hidden = false;
				}
				else if(options[(int)this.YesNoQuestionPicker.SelectedRowInComponent(0)] == "No" && QuestionFourTextView.Frame.X != startingX)
				{
					QuestionFourTextView.Frame = new CoreGraphics.CGRect(QuestionFourTextView.Frame.X + 100, QuestionFourTextView.Frame.Y, QuestionFourTextView.Frame.Size.Width, QuestionFourTextView.Frame.Size.Height);
					EmailTextView.Hidden = true;
				}
			};

            this.QuestionFourTextView.TintColor = UIColor.Clear;
            this.EmailTextView.KeyboardAppearance = UIKeyboardAppearance.Dark;
            this.EmailTextView.KeyboardType = UIKeyboardType.ASCIICapable;
            this.EmailTextView.InputAccessoryView = toolbar;
			this.OtherComments.KeyboardAppearance = UIKeyboardAppearance.Dark;
            this.OtherComments.KeyboardType = UIKeyboardType.ASCIICapable;
            this.OtherComments.InputAccessoryView = toolbar;

            YesNoQuestionPicker.Model = QuestionFourViewModel;

            QuestionOneRating.Value = 3;
            QuestionTwoRating.Value = 3;
            QuestionThreeRating.Value = 3;
            QuestionFourViewModel.selectedAnswer = "No";
            OtherComments.Text = "";
			OtherComments.Layer.BorderColor = UIColorExtension.FromHex(0x0E1D52).CGColor;
			OtherComments.Layer.BorderWidth = 1;
            QuestionFourTextView.Text = "Choose One";
            EmailTextView.Hidden = true;
            EmailTextView.Text = "";
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
			QuestionOneRating.Value = 3;
			QuestionTwoRating.Value = 3;
			QuestionThreeRating.Value = 3;
			OtherComments.Text = "";
			OtherComments.Layer.BorderColor = UIColorExtension.FromHex(0x0E1D52).CGColor;
			OtherComments.Layer.BorderWidth = 1;
			QuestionFourTextView.Text = "Choose One";
			EmailTextView.Hidden = true;
			EmailTextView.Text = "";
            YesNoQuestionPicker.Select(0, 0, true);
		}

		public void SubmitSurveyClick()
		{
            if (QuestionFourTextView.Frame.X != startingX)
			{
				QuestionFourTextView.Frame = new CoreGraphics.CGRect(QuestionFourTextView.Frame.X + 100, QuestionFourTextView.Frame.Y, QuestionFourTextView.Frame.Size.Width, QuestionFourTextView.Frame.Size.Height);
				EmailTextView.Hidden = true;
			}
            survey.QuestionOneRating = (int) QuestionOneRating.Value;
            survey.QuestionTwoRating = (int) QuestionTwoRating.Value;
            survey.QuestionThreeRating = (int) QuestionThreeRating.Value;
            survey.QuestionFourAnswer = options[(int)YesNoQuestionPicker.SelectedRowInComponent(0)];
            survey.OtherComments = OtherComments.Text;
            survey.UserDeviceId = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
            survey.EventId = Store.Instance.SelectedEvent.Id;
            survey.Email = EmailTextView.Text;
            Store.Instance.DeleteToDo(Store.Instance.SelectedEvent);
            //Store.Instance.ToDoList.Remove(Store.Instance.SelectedEvent);
            Store.Instance.AddSurvey(survey, AddSurveyComplete);
            this.DismissViewController(true, null);
		}

		private void AddSurveyComplete(string message)
		{
		}
    }

    internal class SurveyYesNoModel : UIPickerViewModel
    {
        private List<string> options = new List<string>();
        public string selectedAnswer { get; set; }
        public event EventHandler answerChanged;

        public SurveyYesNoModel(List<string> options)
        {
            this.options = options;
        }

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return options.Count;
		}

		public override nint GetComponentCount(UIPickerView v)
		{
			return 1;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return options[(int)row];
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			selectedAnswer = options[(int)row];
			answerChanged?.Invoke(null, null);
		}
    }
}