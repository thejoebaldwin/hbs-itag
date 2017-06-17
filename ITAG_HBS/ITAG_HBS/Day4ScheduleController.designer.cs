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

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton June20Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton June21Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton June22Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NextTrackButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PreviousTrackButton { get; set; }

        [Action ("HomeButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void HomeButtonClick (UIKit.UIButton sender);

        [Action ("June20ButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void June20ButtonClick (UIKit.UIButton sender);

        [Action ("June21ButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void June21ButtonClick (UIKit.UIButton sender);

        [Action ("June22ButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void June22ButtonClick (UIKit.UIButton sender);

        [Action ("MyEventsButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void MyEventsButtonClick (UIKit.UIButton sender);

        [Action ("NextTrackButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NextTrackButtonClick (UIKit.UIButton sender);

        [Action ("PreviousTrackButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PreviousTrackButtonClick (UIKit.UIButton sender);

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

            if (June20Button != null) {
                June20Button.Dispose ();
                June20Button = null;
            }

            if (June21Button != null) {
                June21Button.Dispose ();
                June21Button = null;
            }

            if (June22Button != null) {
                June22Button.Dispose ();
                June22Button = null;
            }

            if (NextTrackButton != null) {
                NextTrackButton.Dispose ();
                NextTrackButton = null;
            }

            if (PreviousTrackButton != null) {
                PreviousTrackButton.Dispose ();
                PreviousTrackButton = null;
            }
        }
    }
}