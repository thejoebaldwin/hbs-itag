﻿using System;
using Foundation;
using CoreLocation;
using UIKit;

namespace HBS.ITAG
{
    public partial class AppFeaturesViewController : UIViewController
    {
		protected AppFeaturesViewController(IntPtr handle) : base(handle)
        {
			// Note: this .ctor should not contain any initialization logic.
		}


		public AppFeaturesViewController() : base("AboutViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            BluetoothMsg.UserInteractionEnabled = true;
            UITapGestureRecognizer BluetoothMsgGesture = new UITapGestureRecognizer(BluetoothMsgClick);
            BluetoothMsgGesture.NumberOfTapsRequired = 1;
            BluetoothMsg.AddGestureRecognizer(BluetoothMsgGesture);

            BackButton.UserInteractionEnabled = true;
			UITapGestureRecognizer BackButtonGesture = new UITapGestureRecognizer(BackButtonClick);
			BackButtonGesture.NumberOfTapsRequired = 1;
            BackButton.AddGestureRecognizer(BackButtonGesture);

			BackArrow.UserInteractionEnabled = true;
			UITapGestureRecognizer BackArrowGesture = new UITapGestureRecognizer(BackArrowClick);
			BackArrowGesture.NumberOfTapsRequired = 1;
            BackArrow.AddGestureRecognizer(BackArrowGesture);

			// Perform any additional setup after loading the view, typically from a nib.
		}

        private void BluetoothMsgClick()
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl(urlString:@"App-prefs:root=Bluetooth"));
        }

        private void BackButtonClick()
        {
            this.DismissViewController(true,null);
        }

		private void BackArrowClick()
		{
			this.DismissViewController(true, null);
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

