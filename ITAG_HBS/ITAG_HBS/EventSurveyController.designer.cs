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
        UIKit.UITextField EmailTextView { get; set; }

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
        UIKit.UITextView QuestionFour { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView QuestionFourTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView QuestionOne { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider QuestionOneRating { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView QuestionThree { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider QuestionThreeRating { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView QuestionTwo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISlider QuestionTwoRating { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SubmitButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView YesNoQuestionPicker { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (EmailTextView != null) {
                EmailTextView.Dispose ();
                EmailTextView = null;
            }

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

            if (QuestionFour != null) {
                QuestionFour.Dispose ();
                QuestionFour = null;
            }

            if (QuestionFourTextView != null) {
                QuestionFourTextView.Dispose ();
                QuestionFourTextView = null;
            }

            if (QuestionOne != null) {
                QuestionOne.Dispose ();
                QuestionOne = null;
            }

            if (QuestionOneRating != null) {
                QuestionOneRating.Dispose ();
                QuestionOneRating = null;
            }

            if (QuestionThree != null) {
                QuestionThree.Dispose ();
                QuestionThree = null;
            }

            if (QuestionThreeRating != null) {
                QuestionThreeRating.Dispose ();
                QuestionThreeRating = null;
            }

            if (QuestionTwo != null) {
                QuestionTwo.Dispose ();
                QuestionTwo = null;
            }

            if (QuestionTwoRating != null) {
                QuestionTwoRating.Dispose ();
                QuestionTwoRating = null;
            }

            if (SubmitButton != null) {
                SubmitButton.Dispose ();
                SubmitButton = null;
            }

            if (YesNoQuestionPicker != null) {
                YesNoQuestionPicker.Dispose ();
                YesNoQuestionPicker = null;
            }
        }
    }
}