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
    [Register ("EventDetailController")]
    partial class EventDetailController
    {
		[Outlet]
		[GeneratedCode("iOS Designer", "1.0")]
		UIKit.UIButton BackEventArrow { get; set; }

		[Outlet]
		[GeneratedCode("iOS Designer", "1.0")]
		UIKit.UIButton BackEventButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView EventDay { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView EventLocation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView EventName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView EventTime { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView GrayStar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LinkToDescription { get; set; }

        [Action ("BackEventButtonClick:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BackEventButtonClick (UIKit.UIButton sender);

		[Action("BackEventArrowClick:")]
		[GeneratedCode("iOS Designer", "1.0")]
		partial void BackEventArrowClick(UIKit.UIButton sender);

		void ReleaseDesignerOutlets ()
        {
            if (EventDay != null) {
                EventDay.Dispose ();
                EventDay = null;
            }

            if (EventLocation != null) {
                EventLocation.Dispose ();
                EventLocation = null;
            }

            if (EventName != null) {
                EventName.Dispose ();
                EventName = null;
            }

            if (EventTime != null) {
                EventTime.Dispose ();
                EventTime = null;
            }

            if (GrayStar != null) {
                GrayStar.Dispose ();
                GrayStar = null;
            }

            if (LinkToDescription != null) {
                LinkToDescription.Dispose ();
                LinkToDescription = null;
            }

            if (BackEventArrow != null)
			{
                BackEventArrow.Dispose();
                BackEventArrow = null;
			}

            if (BackEventButton != null)
			{
                BackEventButton.Dispose();
                BackEventButton = null;
			}
        }
    }
}