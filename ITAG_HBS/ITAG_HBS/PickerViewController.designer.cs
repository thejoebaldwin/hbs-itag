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

namespace ITAG_HBS
{
	[Register("PickerViewExampleController")]
	partial class PickerViewExampleController
	{
		[Outlet]
		[GeneratedCode("iOS Designer", "1.0")]
		UIKit.UIPickerView AgePickerView { get; set; }

		void ReleaseDesignerOutlets()
		{
			if (AgePickerView != null)
			{
				AgePickerView.Dispose();
				AgePickerView = null;
			}
		}
	}
}