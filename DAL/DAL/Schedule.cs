using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Schedule
    {
        public int Id { get; set; }
        public int RenterId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime UntilDate { get; set; }

        public Day[] days = new Day[6];
    }
}
