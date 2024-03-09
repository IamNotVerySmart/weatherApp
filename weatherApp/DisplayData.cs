using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace weatherApp
{
    class DisplayData
    {
        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }
        }

        public class main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
        }

        public class wind
        {
            public double speed { get; set; }
        }

        public class sys
        {
            public long sunrise { get; set; }
            public long sunset { get; set; }
            
        }

        public class list
        {
            public main main { get; set; }
            public List<weather> weather { get; set; }
            public wind wind { get; set; }
            public int visibility { get; set; }
            public sys sys { get; set; }
        }
        public class city
        {
            public string name { get; set; }
            public string country { get; set; }
        }
        public class root
        {
            public string cod { get; set; }
            public List<list> list { get; set; }
            public city city { get; set; }
        }
    }
}
