using System;
using System.Collections.Generic;
using UIKit;

namespace HBS.ITAG
{
    internal class GenderModel : UIPickerViewModel
    {
        private List<string> genderOptions;
        public string selectedGender { get; set; }
        public event EventHandler genderChanged;

        public GenderModel(List<string> genderOptions)
        {
            this.genderOptions = genderOptions;
        }

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return genderOptions.Count;
		}

		public override nint GetComponentCount(UIPickerView v)
		{
			return 1;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return genderOptions[(int)row];
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			selectedGender = genderOptions[(int)row];
			genderChanged?.Invoke(null, null);
		}
	}
}