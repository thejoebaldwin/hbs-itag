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
    [Register ("EventDetailController")]
    partial class EventDetailController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView GrayStar { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (GrayStar != null) {
                GrayStar.Dispose ();
                GrayStar = null;
            }
        }
    }
}