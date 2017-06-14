﻿using System;
using Foundation;
using ITAG_HBS;
using UIKit;
using System.CodeDom.Compiler;

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

            GrayStar.UserInteractionEnabled = true;

            UITapGestureRecognizer Favoritedtapguesture = new UITapGestureRecognizer(FavoritedClick);
            Favoritedtapguesture.NumberOfTapsRequired = 1;
            GrayStar.AddGestureRecognizer(Favoritedtapguesture);


           
            // Perform any additional setup after loading the view, typically from a nib.
        }

        private void FavoritedClick()
        {
            GrayStar.Highlighted = true;
			UITapGestureRecognizer Unfavoritedtapgesture = new UITapGestureRecognizer(UnfavoritedClick);
			Unfavoritedtapgesture.NumberOfTapsRequired = 1;
			GrayStar.AddGestureRecognizer(Unfavoritedtapgesture);

        }
        public void UnfavoritedClick()
        {
            GrayStar.Highlighted = false;
            ViewDidLoad();
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
