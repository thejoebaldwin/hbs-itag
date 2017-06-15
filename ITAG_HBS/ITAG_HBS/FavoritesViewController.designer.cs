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
    [Register ("FavoritesViewController")]
    partial class FavoritesViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView HotelName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ScheduleTableViewFavs { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (HotelName != null) {
                HotelName.Dispose ();
                HotelName = null;
            }

            if (ScheduleTableViewFavs != null) {
                ScheduleTableViewFavs.Dispose ();
                ScheduleTableViewFavs = null;
            }
        }
    }
}