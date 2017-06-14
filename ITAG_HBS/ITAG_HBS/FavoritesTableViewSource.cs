﻿using System;
using UIKit;
using Foundation;
using System.Collections.Generic;

namespace ITAG_HBS
{
	public class FavoritesTableViewSource : UITableViewSource
	{
        int eventLength = 0;

        List<HBS.ITAG.Event> TableItems;
		
		string CellIdentifier = "TableCell";

        public FavoritesTableViewSource(List<HBS.ITAG.Event> items)
		{
            items.Sort((x, y) => x.StartTime.Ticks.CompareTo(y.StartTime.Ticks));
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
			{
                cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); 
            }
            if(!item.ScheduleOnly)
            {
				cell.BackgroundColor = ITAG.HBS.UIColorExtension.FromHex(0x0E1D52);
				cell.TextLabel.TextColor = UIColor.White;
				cell.DetailTextLabel.TextColor = UIColor.White;
			}
			else if (item.ScheduleOnly)
			{
				cell.BackgroundColor = ITAG.HBS.UIColorExtension.FromHex(0x99A1AC);
				cell.TextLabel.TextColor = ITAG.HBS.UIColorExtension.FromHex(0x0E1D52);
				cell.DetailTextLabel.TextColor = ITAG.HBS.UIColorExtension.FromHex(0x0E1D52);
			}
			else
			{
				cell.BackgroundColor = UIColor.White;
				cell.TextLabel.TextColor = UIColor.Black;
				cell.DetailTextLabel.TextColor = UIColor.Black;
			}

			cell.TextLabel.Text = item.Name;
			cell.DetailTextLabel.Text = item.StartTime.ToLocalTime().ToShortTimeString() + " - " + item.EndTime.ToLocalTime().ToShortTimeString();
			eventLength = item.EndTime.Hour * 60 + item.EndTime.Minute - (item.StartTime.Hour * 60 + item.StartTime.Minute);
            
			    return cell;
		}
	}
}
