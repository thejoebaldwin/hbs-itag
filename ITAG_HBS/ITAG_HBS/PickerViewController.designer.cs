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
    [Register ("PickerViewController")]
    partial class PickerViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView AgePickerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView AgeTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView GenderPickerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView GenderTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView OrganizationPickerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView OrganizationTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView PositionTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SubmitForm { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView TechFocusPickerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView TechFocusTextView { get; set; }

        [Action ("SubmitForm_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SubmitForm_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AgePickerView != null) {
                AgePickerView.Dispose ();
                AgePickerView = null;
            }

            if (AgeTextView != null) {
                AgeTextView.Dispose ();
                AgeTextView = null;
            }

            if (GenderPickerView != null) {
                GenderPickerView.Dispose ();
                GenderPickerView = null;
            }

            if (GenderTextView != null) {
                GenderTextView.Dispose ();
                GenderTextView = null;
            }

            if (OrganizationPickerView != null) {
                OrganizationPickerView.Dispose ();
                OrganizationPickerView = null;
            }

            if (OrganizationTextView != null) {
                OrganizationTextView.Dispose ();
                OrganizationTextView = null;
            }

            if (PositionTitle != null) {
                PositionTitle.Dispose ();
                PositionTitle = null;
            }

            if (SubmitForm != null) {
                SubmitForm.Dispose ();
                SubmitForm = null;
            }

            if (TechFocusPickerView != null) {
                TechFocusPickerView.Dispose ();
                TechFocusPickerView = null;
            }

            if (TechFocusTextView != null) {
                TechFocusTextView.Dispose ();
                TechFocusTextView = null;
            }
        }
    }
}