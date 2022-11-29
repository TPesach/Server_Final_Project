using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Day
    {
        private bool[] hours = new bool[24];

        public bool[] Hours
        {
            get { return hours; }
        }
        public string DayName { get; set; }
    }
}
