﻿﻿using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using HBS.ITAG.Model;

namespace HBS.ITAG
{
	public class ToDoTableViewSource : UITableViewSource
	{
		public UIViewController parent { get; set; }
		List<Event> TableItems;

		string CellIdentifier = "TableCell";

		public ToDoTableViewSource(List<Event> items)
		{
            TableItems = items;
			//List<Event> FilteredItems = new List<Event>();
			//for (int i = 0; i < items.Count; i++)
			//{
			//	if (items[i].Favorited && items[i].EndTime > DateTime.Now)
			//	{
			//		FilteredItems.Add((items[i]));
			//	}
			//}

			//TableItems = new List<Event>(FilteredItems);
			//TableItems.Sort((x, y) => x.StartTime.Ticks.CompareTo(y.StartTime.Ticks));
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			if (TableItems.Count == 0)
			{
				return 1;
			}
			else
			{
				return TableItems.Count;
			}
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, true);
			if (TableItems.Count != 0)
			{
				Event tempEvent = TableItems[indexPath.Row];
				Store.Instance.SelectedEvent = tempEvent;
				if (!Store.Instance.SelectedEvent.ScheduleOnly)
				{
                    //EventDetailController tempEventDetail = (EventDetailController)parent.Storyboard.InstantiateViewController("EventDetailController");

                    EventSurveyController tempEventSurvey = null;
                    if(parent.GetType() == typeof(HomeViewController))
                    {
                        HomeViewController temp = (HomeViewController)parent;
                        tempEventSurvey = temp.eventSurveyController;
                    }
                    parent.PresentViewController(tempEventSurvey, true, null);
					//EventDetailController tempEventDetail = null;
					//if (parent.GetType() == typeof(HomeViewController))
					//{
					//	HomeViewController temp = (HomeViewController)parent;
					//	tempEventDetail = temp.eventDetailViewController;
					//}
					//else if (parent.GetType() == typeof(MyEventsViewController))
					//{
					//	MyEventsViewController temp = (MyEventsViewController)parent;
					//	tempEventDetail = temp.parent.eventDetailViewController;
					//}
					//parent.PresentViewController(tempEventDetail, true, null);
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
			if (TableItems.Count == 0)
			{
				cell.TextLabel.Text = "You do not have any surveys to complete";
				cell.TextLabel.AdjustsFontSizeToFitWidth = true;
				cell.DetailTextLabel.Text = "Click Schedule to find events!";
				cell.Selected = false;
			}
			else
			{

				Event item = TableItems[indexPath.Row];
				cell.TextLabel.Text = item.Name;
				cell.DetailTextLabel.Text = item.StartTime.ToLocalTime().ToShortTimeString() + " - " + item.EndTime.ToLocalTime().ToShortTimeString();
				if (!item.ScheduleOnly)
				{
					cell.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
					cell.TextLabel.TextColor = UIColor.White;
					cell.DetailTextLabel.TextColor = UIColor.White;
				}
				else//(item.EndTime < DateTime.Now)
				{
					cell.BackgroundColor = HBS.ITAG.UIColorExtension.FromHex(0x99A1AC);
					cell.TextLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
					cell.DetailTextLabel.TextColor = HBS.ITAG.UIColorExtension.FromHex(0x0E1D52);
				}
				/*else
                {
                    cell.BackgroundColor = UIColor.White;
                    cell.TextLabel.TextColor = UIColor.Black;
                    cell.DetailTextLabel.TextColor = UIColor.Black;
                    cell.DetailTextLabel.Text = "Upcoming";
                }*/
			}
			return cell;
		}
	}
}

