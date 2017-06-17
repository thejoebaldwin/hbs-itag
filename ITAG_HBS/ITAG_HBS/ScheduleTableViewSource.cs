﻿﻿﻿﻿using System; using UIKit; using Foundation; using System.Collections.Generic;

using HBS.ITAG.Model; 
namespace HBS.ITAG {     public class ScheduleTableViewSource : UITableViewSource     {
        //int eventLength = 0;          List<HBS.ITAG.Model.Event> TableItems;         string CellIdentifier = "TableCell";
		public UIViewController parent { get; set; }            public ScheduleTableViewSource(List<HBS.ITAG.Model.Event> items)         {             TableItems = new List<HBS.ITAG.Model.Event>(items);             TableItems.Sort((x,y) => x.StartTime.Ticks.CompareTo(y.StartTime.Ticks));         }          public override nint RowsInSection(UITableView tableView, nint section)         {             return TableItems.Count;         }

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)         {             tableView.DeselectRow(indexPath, true);             Event tempEvent = TableItems[indexPath.Row];             Store.Instance.SelectedEvent = tempEvent;             if (!Store.Instance.SelectedEvent.ScheduleOnly)             {
                //EventDetailController tempEventDetail = (EventDetailController)parent.Storyboard.InstantiateViewController("EventDetailController");
                EventDetailController tempEventDetail = null; 
                if (parent.GetType() == typeof(Day1ScheduleController))                 {                     Day1ScheduleController temp = (Day1ScheduleController)parent;                     tempEventDetail = temp.parent.eventDetailViewController;                 }
				else if (parent.GetType() == typeof(Day2ScheduleController))
				{
					Day2ScheduleController temp = (Day2ScheduleController)parent;
					tempEventDetail = temp.parent.eventDetailViewController;
				}
				else if (parent.GetType() == typeof(Day3ScheduleController))
				{
					Day3ScheduleController temp = (Day3ScheduleController)parent;
					tempEventDetail = temp.parent.eventDetailViewController;
				}
				else if (parent.GetType() == typeof(Day4ScheduleController))
				{
					Day4ScheduleController temp = (Day4ScheduleController)parent;
					tempEventDetail = temp.parent.eventDetailViewController;
				}                 parent.PresentViewController(tempEventDetail, true, null);             }         }          public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)         {             UITableViewCell cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);                 //tableView.DequeueReusableCell(CellIdentifier);             Event item = TableItems[indexPath.Row];              //---- if there are no cells to reuse, create a new one             if (cell == null)             {                 cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);             }             if (!item.ScheduleOnly)             {                 cell.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);                 cell.TextLabel.TextColor = UIColor.White;                 cell.DetailTextLabel.TextColor = UIColor.White;             }             else if(item.ScheduleOnly)             {                 cell.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);                 cell.TextLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);                 cell.DetailTextLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);             }             else             {                 cell.BackgroundColor = UIColor.White;                 cell.TextLabel.TextColor = UIColor.Black;                 cell.DetailTextLabel.TextColor = UIColor.Black;             }              cell.TextLabel.Text = item.Name;             cell.DetailTextLabel.Text = item.StartTime.ToLocalTime().ToShortTimeString() + " - " + item.EndTime.ToLocalTime().ToShortTimeString();              return cell;         }      } }