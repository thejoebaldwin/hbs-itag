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
//using SQLite;

namespace HBS.ITAG
{
    class Favorites
    {
        
        //[PrimaryKey]
        public int key { get; set; }
        public string name { get; set; }
        public Boolean value { get; set; }

        public Favorites ( int Key, string Name, Boolean Value )
        {
            key = Key;
            name = Name;
            value = Value;
        }

        public Favorites()  {  }

        public override string ToString()
        {
            return name + " " + value;
        }

    }
}