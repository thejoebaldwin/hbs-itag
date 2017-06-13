using System;
using UIKit;
using Foundation;

namespace ITAG_HBS
{
	public class ScheduleTableViewSource : UITableViewSource
	{

		string[] TableItems;
		string CellIdentifier = "TableCell";

		public ScheduleTableViewSource(string[] items)
		{
			TableItems = items;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Length;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			string item = TableItems[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

			cell.TextLabel.Text = item;


			return cell;
		}
	}
}
