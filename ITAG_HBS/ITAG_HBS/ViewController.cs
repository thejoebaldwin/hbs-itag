﻿using System;

using UIKit;

namespace ITAG_HBS
{
    public partial class ViewController : UIViewController
    {
        UIPickerView agepicker;
        public object ServiceLocator { get; private set; }

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
       

            GoToPage2Button.AccessibilityIdentifier = "myButton";
            GoToPage2Button.TouchUpInside += (s,e) =>
			{
				

			};

            HBS.ITAG.Store.Instance.LoadEventsFromFile();
            HBS.ITAG.Store.Instance.LoadTracksFromFile();







            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
    public partial class StatusPickerPopoverView : UIViewController
    {
        UIPickerView agepicker;
        public StatusPickerPopoverView (IntPtr handle) : base (handle)
        {
            
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            agepicker = new UIPickerView();
          
        }

    }
}
