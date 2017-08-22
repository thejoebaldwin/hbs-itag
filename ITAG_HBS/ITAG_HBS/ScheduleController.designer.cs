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
        UIKit.UIButton FirstTab { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton FourthTab { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton HomeButton { get; set; }

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
        UIKit.UIButton SecondTab { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ThirdTab { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView TrackName { get; set; }

        [Action ("HomeButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void HomeButtonClick (UIKit.UIButton sender);

        [Action ("FirstTabClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void FirstTabClick (UIKit.UIButton sender);

        [Action ("SecondTabClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SecondTabClick (UIKit.UIButton sender);

        [Action ("ThirdTabClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ThirdTabClick (UIKit.UIButton sender);

        [Action ("FourthTabClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void FourthTabClick (UIKit.UIButton sender);

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

            if (FirstTab != null) {
                FirstTab.Dispose ();
                FirstTab = null;
            }

            if (FourthTab != null) {
                FourthTab.Dispose ();
                FourthTab = null;
            }

            if (HomeButton != null) {
                HomeButton.Dispose ();
                HomeButton = null;
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

            if (SecondTab != null) {
                SecondTab.Dispose ();
                SecondTab = null;
            }

            if (ThirdTab != null) {
                ThirdTab.Dispose ();
                ThirdTab = null;
            }

            if (TrackName != null) {
                TrackName.Dispose ();
                TrackName = null;
            }
        }
    }
}