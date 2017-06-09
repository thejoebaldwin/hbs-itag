using System;

using UIKit;

namespace ITAG_HBS
{
    public partial class ViewController : UIViewController
    {
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

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
