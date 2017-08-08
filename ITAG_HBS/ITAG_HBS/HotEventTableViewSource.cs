﻿using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using HBS.ITAG.Model;

namespace HBS.ITAG
{
	public class HotEventTableViewSource : UITableViewSource
	{
		public UIViewController parent { get; set; }
        List<Event> TableItems;
        Event hotEvent;

		string CellIdentifier = "TableCell";

        public HotEventTableViewSource(List<Event> items)
		{
			TableItems = items;
            foreach(var item in TableItems)
            {
                if(item.Name == "Estimote Beacon")
                {
                    //
                }
                if(item.NumberOfPeople != 0)
                {
                    if(hotEvent == null)
                    {
                        hotEvent = item;
                    }
                    else if(item.NumberOfPeople > hotEvent.NumberOfPeople)
                    {
                        hotEvent = item;
                    }
                }
            }
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
            return 1;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, true);
            if (hotEvent != null)
			{
				Event tempEvent = hotEvent;
				Store.Instance.SelectedEvent = tempEvent;
				if (!Store.Instance.SelectedEvent.ScheduleOnly)
				{
					EventDetailController tempEventDetails = null;
					if (parent.GetType() == typeof(HomeViewController))
					{
						HomeViewController temp = (HomeViewController)parent;
                        tempEventDetails = temp.eventDetailViewController;
					}
					parent.PresentViewController(tempEventDetails, true, null);
				}
			}
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);
			//---- if there are no cells to reuse, create a new one
			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);
			}
			if (hotEvent == null)
			{
				cell.TextLabel.Text = "Nobody is attending any of the events yet";
				cell.TextLabel.AdjustsFontSizeToFitWidth = true;
				cell.DetailTextLabel.Text = "";
				cell.Selected = false;
                cell.BackgroundColor = UIColorExtension.FromHex(0x99a1ac);
			}
			else
			{
				Event item = hotEvent;
				cell.TextLabel.Text = item.Name;
                cell.DetailTextLabel.Text = item.NumberOfPeople.ToString() + " Attending";
				if (!item.ScheduleOnly)
				{
					cell.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
					cell.TextLabel.TextColor = UIColor.White;
					cell.DetailTextLabel.TextColor = UIColor.White;
				}
				else
				{
					cell.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
					cell.TextLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
					cell.DetailTextLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
				}
			}
			return cell;
		}
	}
}

