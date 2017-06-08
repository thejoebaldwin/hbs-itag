using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HBS.ITAG
{
    class Event
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Presenter { get; set; }
        public string Summary { get; set; }
        public int Track { get; set; }
        public int EventWebId { get; set; }
    }
}