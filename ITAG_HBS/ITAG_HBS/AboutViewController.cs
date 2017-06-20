using System;
using Foundation;
using CoreLocation;
using UIKit;

namespace HBS.ITAG
{
    public partial class AboutViewController : UIViewController
    {
        partial void BackButtonClick(UIButton sender)
        {
            this.DismissViewController(true, null);
        }

		protected AboutViewController(IntPtr handle) : base(handle)
        {
			// Note: this .ctor should not contain any initialization logic.
		}


		public AboutViewController() : base("AboutViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            BluetoothMsg.UserInteractionEnabled = true;
            UITapGestureRecognizer BluetoothMsgGesture = new UITapGestureRecognizer(BluetoothMsgClick);
            BluetoothMsgGesture.NumberOfTapsRequired = 1;
            BluetoothMsg.AddGestureRecognizer(BluetoothMsgGesture);

            // Perform any additional setup after loading the view, typically from a nib.
        }

        private void BluetoothMsgClick()
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl(urlString:@"App-prefs:root=Bluetooth"));
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

