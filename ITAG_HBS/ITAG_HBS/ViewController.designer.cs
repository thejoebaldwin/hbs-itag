// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ITAG_HBS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView AgePicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton GoToPage2Button { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AgePicker != null) {
                AgePicker.Dispose ();
                AgePicker = null;
            }

            if (GoToPage2Button != null) {
                GoToPage2Button.Dispose ();
                GoToPage2Button = null;
            }
        }
    }
}