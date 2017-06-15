﻿using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using HBS.ITAG.Model;

namespace ITAG_HBS
{
    public class PreviousTableViewSource : UITableViewSource
    {

		List<Event> TableItems;

		string CellIdentifier = "TableCell";

        public PreviousTableViewSource(List<Event> previousitems)
        {
            TableItems = new List<Event>(previousitems);
            TableItems.Sort((y, x) => x.StartTime.Ticks.CompareTo(y.StartTime.Ticks));
        }
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);
		    Event item = TableItems[indexPath.Row];
			cell.TextLabel.Text = item.Name;
			cell.DetailTextLabel.Text = item.StartTime.ToLocalTime().ToShortTimeString() + " - " + item.EndTime.ToLocalTime().ToShortTimeString();
			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);
			}
			if (!item.ScheduleOnly)
			{
				cell.BackgroundColor = ITAG.HBS.UIColorExtension.FromHex(0x0E1D52);
				cell.TextLabel.TextColor = UIColor.White;
                cell.DetailTextLabel.TextColor = UIColor.White;

			}
			else if (item.ScheduleOnly)
			{
                //cell.BackgroundColor = ITAG.HBS.UIColorExtension.FromHex(0x99A1AC);
                //cell.TextLabel.TextColor = ITAG.HBS.UIColorExtension.FromHex(0x0E1D52);
                //cell.DetailTextLabel.TextColor = ITAG.HBS.UIColorExtension.FromHex(0x0E1D52);
                cell.Hidden = true;
			}
			else
			{
				cell.BackgroundColor = UIColor.White;
				cell.TextLabel.TextColor = UIColor.Black;
				cell.DetailTextLabel.TextColor = UIColor.Black;
			}

			

			return cell;
		}
    }

}
