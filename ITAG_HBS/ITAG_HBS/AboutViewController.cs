using System;

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
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

