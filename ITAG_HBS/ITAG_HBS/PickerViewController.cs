﻿﻿﻿﻿using System;
using Foundation;
using UIKit;
using CoreGraphics;
using HBS.ITAG.Model;
using System.Drawing;
using CoreAnimation;

namespace HBS.ITAG
{

    public partial class PickerViewController : UIViewController
    {
        User tempUser;

		public PickerViewController(IntPtr handle) : base(handle)
        {
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			AgePickerView.Model = new StatusModel();
            //TechFocusPickerView.Model = new TechFocusModel();
            StatePickerView.Model = new StateModel();
            GenderPickerView.Model = new GenderModel();
           // OrganizationPickerView.Model = new OrganizationModel();



            SubmitForm.UserInteractionEnabled = true;
            UITapGestureRecognizer SubmitFormGesture = new UITapGestureRecognizer(SubmitFormClick);
            SubmitFormGesture.NumberOfTapsRequired = 1;
            SubmitForm.AddGestureRecognizer(SubmitFormGesture);


			UIToolbar toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, (float) this.View.Frame.Size.Width, 44.0f));

			toolbar.TintColor = UIColor.White;
			toolbar.BarStyle = UIBarStyle.Black;

			toolbar.Translucent = true;

			

			toolbar.Items = new UIBarButtonItem[]{
	
		new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
		new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate {
			this.PositionTitle.ResignFirstResponder();
	})
	 };
			this.PositionTitle.KeyboardAppearance = UIKeyboardAppearance.Dark;
			this.PositionTitle.InputAccessoryView = toolbar;
		}

		public void AddBarButtonText(object sender, EventArgs e)
		{
			var barButtonItem = sender as UIBarButtonItem;
			if (barButtonItem != null)
				this.PositionTitle.Text += barButtonItem.Title;

		}

		private void SubmitFormClick()
		{
            //string id, string age, string gender, string positionTitle, string state, string deviceType, string deviceId
			tempUser = new User("-1",
                                StatusModel.ages[AgePickerView.SelectedRowInComponent(0)],
                                GenderModel.Gender[GenderPickerView.SelectedRowInComponent(0)],
                                PositionTitle.Text,
                                StateModel.States[StatePickerView.SelectedRowInComponent(0)],
                                "iOS",
                                UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString());
			Store.Instance.AddUser(tempUser, AddUserComplete);
		}

	
        private void AddUserComplete(string message)
        {
            this.DismissViewController(true, null);
        }

	

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
	}

	public class StatusModel : UIPickerViewModel
	{
        public static string[] ages = new string[] {
            "Choose One",
            "16 and Under",
            "17 to 20",
            "21 to 25",
            "26 to 30",
            "31 to 35",
            "36 to 40",
            "41 to 45",
            "46 to 50",
            "51 to 55",
            "56 to 60",
            "61 to 65",
            "66 to 70",
            "70 and Above"
        };

		public StatusModel()
		{
            
		}

		public override nint GetComponentCount(UIPickerView v)
		{
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
            return ages.Length;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
            return ages[row];
		}
		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
            //lbl.Text = String.Format("{0} : {1} : {2}",

            //pickerView.SelectedRowInComponent(1),
            //pickerView.SelectedRowInComponent(2));


        }

		public override nfloat GetComponentWidth(UIPickerView pickerView, nint component)
		{
			if (component == 0)
				return 220f;
			else
				return 30f;
		}
		public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
		{
			UILabel lbl = new UILabel(new RectangleF(0, 0, 130f, 40f));
			lbl.Font = UIFont.SystemFontOfSize(16f);
			lbl.TextAlignment = UITextAlignment.Center;
            lbl.Text = ages[row];
			return lbl;
		}
	}
	public class TechFocusModel : UIPickerViewModel
	{
		public static string[] TechFocus = new string[] {
			"Choose One",
			"IT",
            "GIS",
            "Both",
            "None"
         
		};

		public TechFocusModel()
		{

		}

		public override nint GetComponentCount(UIPickerView v)
		{
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
            return TechFocus.Length;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
            return TechFocus[row];
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{

			//lbl.Text = String.Format("{0} : {1} : {2}",
			//names[pickerView.SelectedRowInComponent(0)],
			//pickerView.SelectedRowInComponent(1),
			//pickerView.SelectedRowInComponent(2));


		}

		public override nfloat GetComponentWidth(UIPickerView pickerView, nint component)
		{
			if (component == 0)
				return 220f;
			else
				return 30f;
		}
	}
	public class GenderModel : UIPickerViewModel
	{
		public static string[] Gender = new string[] {
			"Choose One",
			"Male",
            "Female",
            "Other",
            "Prefer Not to Respond"
		};

        public GenderModel()
		{

		}

		public override nint GetComponentCount(UIPickerView v)
		{
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
            return Gender.Length;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
            return Gender[row];
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{

			//lbl.Text = String.Format("{0} : {1} : {2}",
			//names[pickerView.SelectedRowInComponent(0)],
			//pickerView.SelectedRowInComponent(1),
			//pickerView.SelectedRowInComponent(2));


		}


		public override nfloat GetComponentWidth(UIPickerView pickerView, nint component)
		{
			if (component == 0)
				return 220f;
			else
				return 30f;
		}
		public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
		{
			UILabel lbl = new UILabel(new RectangleF(0, 0, 130f, 40f));
			lbl.Font = UIFont.SystemFontOfSize(16f);
			lbl.TextAlignment = UITextAlignment.Center;
            lbl.Text = Gender[row];
			return lbl;
		}
	}
	public class OrganizationModel : UIPickerViewModel
	{
		public static string[] Organization = new string[] {
			"Choose One",
			"IGIC",
			"ICIT",
			"Both",
			"None"

		};

		public OrganizationModel()
		{

		}

		public override nint GetComponentCount(UIPickerView v)
		{
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
            return Organization.Length;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
            return Organization[row];
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{

			//lbl.Text = String.Format("{0} : {1} : {2}",
			//names[pickerView.SelectedRowInComponent(0)],
			//pickerView.SelectedRowInComponent(1),
			//pickerView.SelectedRowInComponent(2));


		}

		public override nfloat GetComponentWidth(UIPickerView pickerView, nint component)
		{
			if (component == 0)
				return 220f;
			else
				return 30f;
		}

	}

	public class StateModel : UIPickerViewModel
	{
		public static string[] States = new string[] {
			"AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DC", "DE", "FL", "GA", "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MS", "MT", "NC", "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VT", "WA", "WI", "WV", "WY"
		};

		public StateModel()
		{

		}

		public override nint GetComponentCount(UIPickerView v)
		{
			return 1;
		}

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return States.Length;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return States[row];
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{

			//lbl.Text = String.Format("{0} : {1} : {2}",
			//names[pickerView.SelectedRowInComponent(0)],
			//pickerView.SelectedRowInComponent(1),
			//pickerView.SelectedRowInComponent(2));
		}

		public override nfloat GetComponentWidth(UIPickerView pickerView, nint component)
		{
			if (component == 0)
				return 220f;
			else
				return 30f;
		}
        public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
        {
            UILabel lbl = new UILabel(new RectangleF(0, 0, 130f, 40f));
            lbl.Font = UIFont.SystemFontOfSize(16f);
            lbl.TextAlignment = UITextAlignment.Center;
            lbl.Text = States[row];
            return lbl;
        }
	}
}

