using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace DTO
{
    public class DTOSchedule
    {
        public Int32 Id { get; set; }
        public Int32 RenterId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime UntilDate { get; set; }

        public Day[] days = new Day[6];
    }
}
