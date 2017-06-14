﻿using System;
using Foundation;
using UIKit;
using CoreGraphics;


namespace ITAG_HBS
{

	public partial class PickerViewExampleController : UIViewController
	{

		public PickerViewExampleController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			AgePickerView.Model = new StatusModel();
            StatePickerView.Model = new StateModel();
            GenderPickerView.Model = new GenderModel();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
	}

	public class StatusModel : UIPickerViewModel
	{
		static string[] names = new string[] {
			"Choose One",
			"16 and Under",
			"17 to 20","21 to 25","26 to 30","31 to 35","36 to 40","41 to 45","46 to 50","51 to 55","56 to 60","61 to 65","66 to 70","70 and Above"
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
			return names.Length;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return names[row];
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
		static string[] States = new string[] {
			"Choose One",
			"Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "District of Columbia", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming"
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
	}
	public class GenderModel : UIPickerViewModel
	{
		static string[] Gender = new string[] {
			"Choose One",
			"Male", "Female", "Other", "Prefer Not to Respond"
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
	}
}
