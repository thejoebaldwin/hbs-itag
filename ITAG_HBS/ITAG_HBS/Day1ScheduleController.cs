using Foundation; using System; using UIKit; using ITAG_HBS; using HBS.ITAG;  namespace ITAG.HBS {     public partial class Day1ScheduleController : UIViewController     {         public string DataObject        {           get; set;         }       public Day1ScheduleController (IntPtr handle) : base (handle)         {         }          public override void ViewDidLoad()        {            base.ViewDidLoad();               // Perform any additional setup after loading the view, typically from a nib.            //create the tableview contents                string[] eventTimes = new string[] { "8:00 am", "Event", "8:30 am", "Event", "9:00 am", "Event", "9:30 am", "Lunch", "10:00 am", "10:30 am", "11:00 am", "11:30 am", "12:00 pm", "12:30 pm",                                                    "1:00 pm", "1:30 pm", "2:00 pm", "2:30 pm", "3:00 pm", "3:30 pm", "4:00 pm", "4:30 pm", "5:00 pm", "5:30 pm", "6:00 pm" };             //public Event(string name, int id, DateTime startTime, DateTime endTime, string presenter, string summary, int track ,int eventWebId, Boolean scheduleOnly)             var trackEvents = Store.Instance.Events;                //use the array contents to build the table view source                 DayOne.Source = new ScheduleTableViewSource(trackEvents);          }         public override void DidReceiveMemoryWarning()          {            base.DidReceiveMemoryWarning();               // Release any cached data, images, etc that aren't in use.             }        public override void ViewWillAppear(bool animated)          {            base.ViewWillAppear(animated);         }     } } 