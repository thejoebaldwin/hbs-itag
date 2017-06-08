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
    class Track
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int TrackDate { get; set; }
        public int BeaconGuid { get; set; }
    }
}