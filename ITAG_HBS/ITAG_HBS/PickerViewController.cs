using System;
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
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
	}

	public class StatusModel : UIPickerViewModel
	{
		static string[] names = new string[] {
			"Pending",
			"In Progress",
			"Complete",
		};

		//UILabel lbl;

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
			//  names[picker.SelectedRowInComponent(0)],
			//  picker.SelectedRowInComponent(1),
			//  picker.SelectedRowInComponent(2));
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

