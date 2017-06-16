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
        UIKit.UIPickerView GenderPickerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView OrganizationPickerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Position { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView StatePickerView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SubmitForm { get; set; }

        [Action ("SubmitForm_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SubmitForm_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AgePickerView != null) {
                AgePickerView.Dispose ();
                AgePickerView = null;
            }

            if (GenderPickerView != null) {
                GenderPickerView.Dispose ();
                GenderPickerView = null;
            }

            if (OrganizationPickerView != null) {
                OrganizationPickerView.Dispose ();
                OrganizationPickerView = null;
            }

            if (Position != null) {
                Position.Dispose ();
                Position = null;
            }

            if (StatePickerView != null) {
                StatePickerView.Dispose ();
                StatePickerView = null;
            }

            if (SubmitForm != null) {
                SubmitForm.Dispose ();
                SubmitForm = null;
            }
        }
    }
}