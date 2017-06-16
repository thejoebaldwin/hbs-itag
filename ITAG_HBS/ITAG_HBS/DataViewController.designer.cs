// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace HBS.ITAG
{
    [Register ("DataViewController")]
    partial class DataViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton HomeButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton MyEventsButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ScheduleButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ScheduleTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ScheduleTableView2 { get; set; }

        [Action ("HomeButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void HomeButtonClick (UIKit.UIButton sender);

        [Action ("MyEventsButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void MyEventsButtonClick (UIKit.UIButton sender);

        [Action ("ScheduleButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ScheduleButtonClick (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (HomeButton != null) {
                HomeButton.Dispose ();
                HomeButton = null;
            }

            if (MyEventsButton != null) {
                MyEventsButton.Dispose ();
                MyEventsButton = null;
            }

            if (ScheduleButton != null) {
                ScheduleButton.Dispose ();
                ScheduleButton = null;
            }

            if (ScheduleTableView != null) {
                ScheduleTableView.Dispose ();
                ScheduleTableView = null;
            }

            if (ScheduleTableView2 != null) {
                ScheduleTableView2.Dispose ();
                ScheduleTableView2 = null;
            }
        }
    }
}