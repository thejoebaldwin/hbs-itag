using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace ITAG_HBS
{
	public class FavoritesTableViewSource : UITableViewSource
	{
        List<HBS.ITAG.Event> TableItems;
		//string[] TableItems;
		string CellIdentifier = "TableCell";

        public FavoritesTableViewSource(List<HBS.ITAG.Event> items)
		{
			TableItems = items;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
            return TableItems.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            //This is the old one//UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            UITableViewCell cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);
            HBS.ITAG.Event item = TableItems[indexPath.Row];

			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{ cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

			

			return cell;
		}
	}
}
