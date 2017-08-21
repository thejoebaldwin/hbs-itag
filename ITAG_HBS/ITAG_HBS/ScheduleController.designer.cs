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
    [Register ("ScheduleController")]
    partial class ScheduleController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView D1LeftArrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView D1RightArrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton HomeButton { get; set; }

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
        UIKit.UIButton June23Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton MyEventsButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NextTrackButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PreviousBackButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ScheduleButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ScheduleTable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Tab1Label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Tab2Label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Tab3Label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Tab4Label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView TrackName { get; set; }

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

        [Action ("June23ButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void June23ButtonClick (UIKit.UIButton sender);

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
            if (D1LeftArrow != null) {
                D1LeftArrow.Dispose ();
                D1LeftArrow = null;
            }

            if (D1RightArrow != null) {
                D1RightArrow.Dispose ();
                D1RightArrow = null;
            }

            if (HomeButton != null) {
                HomeButton.Dispose ();
                HomeButton = null;
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

            if (June23Button != null) {
                June23Button.Dispose ();
                June23Button = null;
            }

            if (MyEventsButton != null) {
                MyEventsButton.Dispose ();
                MyEventsButton = null;
            }

            if (NextTrackButton != null) {
                NextTrackButton.Dispose ();
                NextTrackButton = null;
            }

            if (PreviousBackButton != null) {
                PreviousBackButton.Dispose ();
                PreviousBackButton = null;
            }

            if (ScheduleButton != null) {
                ScheduleButton.Dispose ();
                ScheduleButton = null;
            }

            if (ScheduleTable != null) {
                ScheduleTable.Dispose ();
                ScheduleTable = null;
            }

            if (Tab1Label != null) {
                Tab1Label.Dispose ();
                Tab1Label = null;
            }

            if (Tab2Label != null) {
                Tab2Label.Dispose ();
                Tab2Label = null;
            }

            if (Tab3Label != null) {
                Tab3Label.Dispose ();
                Tab3Label = null;
            }

            if (Tab4Label != null) {
                Tab4Label.Dispose ();
                Tab4Label = null;
            }

            if (TrackName != null) {
                TrackName.Dispose ();
                TrackName = null;
            }
        }
    }
}