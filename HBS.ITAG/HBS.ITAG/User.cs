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
    class User
    {
        public int Id { get; set; }
        public string State { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string JobTitle { get; set; }
        public string Email { get; set; }
        public Boolean EmailNotifications { get; set; }
        public int[] FavoritedEvents { get; set; }
    }
}