// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace ITAG_HBS
{
    [Register ("DataViewController")]
    partial class DataViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ScheduleTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ScheduleTableView2 { get; set; }

        void ReleaseDesignerOutlets ()
        {
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