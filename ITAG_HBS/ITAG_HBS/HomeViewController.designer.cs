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
    [Register ("FavoritesViewController")]
    partial class HomeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AboutButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton HomeButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView HotelName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView HotEventTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton MyEventsButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch NotifySwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView PhoneNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ScheduleButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ToDoTableView { get; set; }

        [Action ("AboutButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AboutButtonClick (UIKit.UIButton sender);

        [Action ("EventsButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EventsButtonClick (UIKit.UIButton sender);

        [Action ("NotifySwitchClicked:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NotifySwitchClicked (UIKit.UISwitch sender);

        [Action ("ScheduleButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ScheduleButtonClick (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (AboutButton != null) {
                AboutButton.Dispose ();
                AboutButton = null;
            }

            if (HomeButton != null) {
                HomeButton.Dispose ();
                HomeButton = null;
            }

            if (HotelName != null) {
                HotelName.Dispose ();
                HotelName = null;
            }

            if (HotEventTableView != null) {
                HotEventTableView.Dispose ();
                HotEventTableView = null;
            }

            if (MyEventsButton != null) {
                MyEventsButton.Dispose ();
                MyEventsButton = null;
            }

            if (NotifySwitch != null) {
                NotifySwitch.Dispose ();
                NotifySwitch = null;
            }

            if (PhoneNumber != null) {
                PhoneNumber.Dispose ();
                PhoneNumber = null;
            }

            if (ScheduleButton != null) {
                ScheduleButton.Dispose ();
                ScheduleButton = null;
            }

            if (ToDoTableView != null) {
                ToDoTableView.Dispose ();
                ToDoTableView = null;
            }
        }
    }
}