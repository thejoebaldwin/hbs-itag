// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace HBS.ITAG
{
    [Register ("EventSurveyController")]
    partial class EventSurveyController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView EventName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView OtherComments { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView Q1Numbers { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider QuestionFourRating { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider QuestionOneRating { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider QuestionThreeRating { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider QuestionTwoRating { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SubmitButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (EventName != null) {
                EventName.Dispose ();
                EventName = null;
            }

            if (OtherComments != null) {
                OtherComments.Dispose ();
                OtherComments = null;
            }

            if (Q1Numbers != null) {
                Q1Numbers.Dispose ();
                Q1Numbers = null;
            }

            if (QuestionFourRating != null) {
                QuestionFourRating.Dispose ();
                QuestionFourRating = null;
            }

            if (QuestionOneRating != null) {
                QuestionOneRating.Dispose ();
                QuestionOneRating = null;
            }

            if (QuestionThreeRating != null) {
                QuestionThreeRating.Dispose ();
                QuestionThreeRating = null;
            }

            if (QuestionTwoRating != null) {
                QuestionTwoRating.Dispose ();
                QuestionTwoRating = null;
            }

            if (SubmitButton != null) {
                SubmitButton.Dispose ();
                SubmitButton = null;
            }
        }
    }
}