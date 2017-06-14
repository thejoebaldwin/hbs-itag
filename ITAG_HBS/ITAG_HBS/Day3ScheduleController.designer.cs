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

namespace ITAG.HBS
{
    [Register ("Day3ScheduleController")]
    partial class Day3ScheduleController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView Day3TrackName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Day3TrackName != null) {
                Day3TrackName.Dispose ();
                Day3TrackName = null;
            }
        }
    }
}