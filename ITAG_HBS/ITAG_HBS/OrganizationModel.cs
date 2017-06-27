using System;
using System.Collections.Generic;
using UIKit;

namespace HBS.ITAG
{
    internal class OrganizationModel : UIPickerViewModel
    {
        private List<string> organizationOptions;
        public string selectedOrganization { get; set; }
        public event EventHandler organizationChanged;

        public OrganizationModel(List<string> organizationOptions)
        {
            this.organizationOptions = organizationOptions;
        }

		public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
		{
			return organizationOptions.Count;
		}

		public override nint GetComponentCount(UIPickerView v)
		{
			return 1;
		}

		public override string GetTitle(UIPickerView pickerView, nint row, nint component)
		{
			return organizationOptions[(int)row];
		}

		public override void Selected(UIPickerView pickerView, nint row, nint component)
		{
			selectedOrganization = organizationOptions[(int)row];
			organizationChanged?.Invoke(null, null);
		}
    }
}