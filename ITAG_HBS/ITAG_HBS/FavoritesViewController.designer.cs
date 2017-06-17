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
    partial class FavoritesViewController
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
        UIKit.UIButton MyEventsButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView PhoneNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ScheduleButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ScheduleTableViewFavs { get; set; }

        [Action ("AboutButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AboutButtonClick (UIKit.UIButton sender);

        [Action ("EventsButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void EventsButtonClick (UIKit.UIButton sender);

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

            if (MyEventsButton != null) {
                MyEventsButton.Dispose ();
                MyEventsButton = null;
            }

            if (PhoneNumber != null) {
                PhoneNumber.Dispose ();
                PhoneNumber = null;
            }

            if (ScheduleButton != null) {
                ScheduleButton.Dispose ();
                ScheduleButton = null;
            }

            if (ScheduleTableViewFavs != null) {
                ScheduleTableViewFavs.Dispose ();
                ScheduleTableViewFavs = null;
            }
        }
    }
}