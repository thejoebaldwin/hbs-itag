﻿using System;

using UIKit;

namespace ITAG_HBS
{
    public partial class ViewController : UIViewController
    {
        public object ServiceLocator { get; private set; }

        public string DataObject { get; set; }

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            HBS.ITAG.Store.Instance.LoadEventsFromFile();
            HBS.ITAG.Store.Instance.LoadTracksFromFile();

            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }
    }
}
