using System;
using System.Collections.Generic;
using UIKit;

namespace HBS.ITAG
{
    internal class TechFocusModel : UIPickerViewModel
    {
        private List<string> techFocusOptions;
        public string selectedTechFocus { get; set; }
        public event EventHandler techFocusChanged;

        public TechFocusModel(List<string> techFocusOptions)
        {
            this.techFocusOptions = techFocusOptions;
        }

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return techFocusOptions.Count;
		}

		public override nint GetComponentCount(UIPickerView v)
		{
			return 1;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return techFocusOptions[(int)row];
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			selectedTechFocus = techFocusOptions[(int)row];
			techFocusChanged?.Invoke(null, null);
		}
    }
}

//public class TechFocusModel : UIPickerViewModel
//{
//	public static string[] TechFocus = new string[] {
//			"Choose One",
//			"IT",
//			"GIS",
//			"Both",
//			"None"
//		};

//	public TechFocusModel()
//	{

//	}

//	public override nint GetComponentCount(UIPickerView v)
//	{
//		return 1;
//	}

//	public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
//	{
//		return TechFocus.Length;
//	}

//	public override string GetTitle(UIPickerView pickerView, nint row, nint component)
//	{
//		return TechFocus[row];
//	}

//	public override void Selected(UIPickerView pickerView, nint row, nint component)
//	{

//		//lbl.Text = String.Format("{0} : {1} : {2}",
//		//names[pickerView.SelectedRowInComponent(0)],
//		//pickerView.SelectedRowInComponent(1),
//		//pickerView.SelectedRowInComponent(2));
//	}

//	public override nfloat GetComponentWidth(UIPickerView pickerView, nint component)
//	{
//		if (component == 0)
//			return 220f;
//		else
//			return 30f;
//	}
//}