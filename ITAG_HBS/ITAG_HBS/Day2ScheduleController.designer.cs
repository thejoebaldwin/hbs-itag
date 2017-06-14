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
        UIKit.UIImageView D2LeftArrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView D2RightArrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView Day2TrackName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView DayTwo { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (D2LeftArrow != null) {
                D2LeftArrow.Dispose ();
                D2LeftArrow = null;
            }

            if (D2RightArrow != null) {
                D2RightArrow.Dispose ();
                D2RightArrow = null;
            }

            if (Day2TrackName != null) {
                Day2TrackName.Dispose ();
                Day2TrackName = null;
            }

            if (DayTwo != null) {
                DayTwo.Dispose ();
                DayTwo = null;
            }
        }
    }
}