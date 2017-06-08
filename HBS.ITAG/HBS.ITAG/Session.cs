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
    class Session
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }
    }
}