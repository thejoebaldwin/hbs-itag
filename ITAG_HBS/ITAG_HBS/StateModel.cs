using System;
using System.Collections.Generic;
using UIKit;

namespace HBS.ITAG
{
    internal class StateModel : UIPickerViewModel
    {
        private List<string> stateOptions;
        public string selectedState { get; set; }
        public event EventHandler stateChanged;

        public StateModel(List<string> stateOptions)
        {
            this.stateOptions = stateOptions;
        }

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return stateOptions.Count;
		}

		public override nint GetComponentCount(UIPickerView v)
		{
			return 1;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return stateOptions[(int)row];
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			selectedState = stateOptions[(int)row];
			stateChanged?.Invoke(null, null);
		}
    }
}