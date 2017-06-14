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
        UIKit.UIImageView D3LeftArrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView D3RightArrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView Day3TrackName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView DayThree { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (D3LeftArrow != null) {
                D3LeftArrow.Dispose ();
                D3LeftArrow = null;
            }

            if (D3RightArrow != null) {
                D3RightArrow.Dispose ();
                D3RightArrow = null;
            }

            if (Day3TrackName != null) {
                Day3TrackName.Dispose ();
                Day3TrackName = null;
            }

            if (DayThree != null) {
                DayThree.Dispose ();
                DayThree = null;
            }
        }
    }
}