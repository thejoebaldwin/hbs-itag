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

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton June20Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton June22Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton June23Button { get; set; }

        [Action ("June20ButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void June20ButtonClick (UIKit.UIButton sender);

        [Action ("June22ButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void June22ButtonClick (UIKit.UIButton sender);

        [Action ("June23ButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void June23ButtonClick (UIKit.UIButton sender);

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

            if (June20Button != null) {
                June20Button.Dispose ();
                June20Button = null;
            }

            if (June22Button != null) {
                June22Button.Dispose ();
                June22Button = null;
            }

            if (June23Button != null) {
                June23Button.Dispose ();
                June23Button = null;
            }
        }
    }
}