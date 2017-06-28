using Foundation;
using System;
using UIKit;
using HBS.ITAG.Model;

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

        }

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			RefreshPage();
            SubmitButton.UserInteractionEnabled = true;
            UITapGestureRecognizer SubmitSurvey = new UITapGestureRecognizer(SubmitSurveyClick);
            SubmitSurvey.NumberOfTapsRequired = 1;
            SubmitButton.AddGestureRecognizer(SubmitSurvey);
		}

		public void RefreshPage()
		{
            EventName.Text = Store.Instance.SelectedEvent.Name;
		}

		public void SubmitSurveyClick()
		{
			this.DismissViewController(true, null);
		}
    }
}