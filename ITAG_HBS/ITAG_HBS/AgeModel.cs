using System;
using System.Collections.Generic;
using UIKit;

namespace HBS.ITAG
{
    internal class AgeModel : UIPickerViewModel
    {
        private List<string> ageOptions;
        public string selectedAge { get; set; } 
        public event EventHandler ageChanged;

        public AgeModel(List<string> ageOptions)
        {
            this.ageOptions = ageOptions;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return ageOptions.Count;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            return ageOptions[(int)row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            selectedAge = ageOptions[(int)row];
            ageChanged?.Invoke(null, null);
        }
    }
}