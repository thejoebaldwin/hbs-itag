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
    [Register ("Day1ScheduleController")]
    partial class Day1ScheduleController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView Day1TrackName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView DayOne { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Day1TrackName != null) {
                Day1TrackName.Dispose ();
                Day1TrackName = null;
            }

            if (DayOne != null) {
                DayOne.Dispose ();
                DayOne = null;
            }
        }
    }
}