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
    [Register ("Day4ScheduleController")]
    partial class Day4ScheduleController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView D4LeftArrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView D4RightArrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView Day4TrackName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView DayFour { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (D4LeftArrow != null) {
                D4LeftArrow.Dispose ();
                D4LeftArrow = null;
            }

            if (D4RightArrow != null) {
                D4RightArrow.Dispose ();
                D4RightArrow = null;
            }

            if (Day4TrackName != null) {
                Day4TrackName.Dispose ();
                Day4TrackName = null;
            }

            if (DayFour != null) {
                DayFour.Dispose ();
                DayFour = null;
            }
        }
    }
}