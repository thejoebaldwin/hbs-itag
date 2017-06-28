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
    [Register ("AboutViewController")]
    partial class AppFeaturesViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BackArrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BackButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView BluetoothMsg { get; set; }

        [Action ("BackButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackButtonClick (UIKit.UIButton sender);

		[Action("BackArrowClick:")]
		[GeneratedCode("iOS Designer", "1.0")]
		partial void BackArrowClick(UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BackArrow != null) {
                BackArrow.Dispose ();
                BackArrow = null;
            }

            if (BackButton != null) {
                BackButton.Dispose ();
                BackButton = null;
            }

            if (BluetoothMsg != null) {
                BluetoothMsg.Dispose ();
                BluetoothMsg = null;
            }
        }
    }
}