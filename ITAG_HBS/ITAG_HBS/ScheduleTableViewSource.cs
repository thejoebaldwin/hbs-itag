﻿﻿﻿using System; using UIKit; using Foundation; using System.Collections.Generic;
using ITAG.HBS;
using HBS.ITAG.Model; 
namespace ITAG_HBS {     public class ScheduleTableViewSource : UITableViewSource     {
        //int eventLength = 0;          List<HBS.ITAG.Model.Event> TableItems;         string CellIdentifier = "TableCell";
		public UIViewController parent { get; set; }            public ScheduleTableViewSource(List<HBS.ITAG.Model.Event> items)         {             TableItems = new List<HBS.ITAG.Model.Event>(items);             TableItems.Sort((x,y) => x.StartTime.Ticks.CompareTo(y.StartTime.Ticks));         }          public override nint RowsInSection(UITableView tableView, nint section)         {             return TableItems.Count;         }

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)         {             tableView.DeselectRow(indexPath, true);             Event tempEvent = TableItems[indexPath.Row];             Store.Instance.SelectedEvent = tempEvent;             if (!Store.Instance.SelectedEvent.ScheduleOnly)             {
                EventDetailController tempEventDetail = (EventDetailController)parent.Storyboard.InstantiateViewController("EventDetailController");                 parent.PresentViewController(tempEventDetail, true, null);             }         }          public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)         {             UITableViewCell cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);                 //tableView.DequeueReusableCell(CellIdentifier);             Event item = TableItems[indexPath.Row];              //---- if there are no cells to reuse, create a new one             if (cell == null)             {                 cell = new UITableViewCell(UITableViewCellStyle.Subtitle, CellIdentifier);             }             if (!item.ScheduleOnly)             {                 cell.BackgroundColor = ITAG.HBS.UIColorExtension.FromHex(0x0E1D52);                 cell.TextLabel.TextColor = UIColor.White;                 cell.DetailTextLabel.TextColor = UIColor.White;             }             else if(item.ScheduleOnly)             {                 cell.BackgroundColor = ITAG.HBS.UIColorExtension.FromHex(0x99A1AC);                 cell.TextLabel.TextColor = ITAG.HBS.UIColorExtension.FromHex(0x0E1D52);                 cell.DetailTextLabel.TextColor = ITAG.HBS.UIColorExtension.FromHex(0x0E1D52);             }             else             {                 cell.BackgroundColor = UIColor.White;                 cell.TextLabel.TextColor = UIColor.Black;                 cell.DetailTextLabel.TextColor = UIColor.Black;             }              cell.TextLabel.Text = item.Name;             cell.DetailTextLabel.Text = item.StartTime.ToLocalTime().ToShortTimeString() + " - " + item.EndTime.ToLocalTime().ToShortTimeString();              return cell;         }      } }