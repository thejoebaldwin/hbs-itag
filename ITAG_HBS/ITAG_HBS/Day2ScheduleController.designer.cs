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
    [Register ("Day2ScheduleController")]
    partial class Day2ScheduleController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView Day2TrackName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Day2TrackName != null) {
                Day2TrackName.Dispose ();
                Day2TrackName = null;
            }
        }
    }
}