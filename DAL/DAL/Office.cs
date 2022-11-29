using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Office
    {
        #region fields
        //משתנה סטאטי להכנסת ID יחודי למשרד
        public static int uniqueId = 400;
        public Int32 Id { get; set; }
        public Address Address { get; set; }
        public int HirerId { get; set; }
        public int Size { get; set; }
        public int NumOfRoom { get; set; }
        public int Payment { get; set; }
        public int Floor { get; set; }

        public List<Renter> RenterList { get; set; }

        public List<Schedule> ScheduleList { get; set; }

        public Day[] TimeTable { get; set; } = new Day[6];


        public List<AdditiveForOffice> Additives { get; set; } = new List<AdditiveForOffice>();

        #endregion

        #region function
        public void addAdditive(AdditiveForOffice additive)
        {
            Additives.Add(additive);
        }
        public void AddSchedule(Schedule schedule)
        {
            ScheduleList.Add(schedule);
            //add to tabletime of this office
            //we have to check here if we can add to this office or we dont have empty place
            for (int i = 0; i < schedule.days.Length; i++)
            {
                for (int j = 0; j < schedule.days[i].Hours.Length; j++)
                {
                    if (schedule.days[i].Hours[j])
                    {
                        TimeTable[i].Hours[j] = true;
                    }
                }
            }
        }
        public void DeleteSchedule(Schedule schedule)
        {
            ScheduleList.Remove(schedule);
            for (int i = 0; i < schedule.days.Length; i++)
            {
                for (int j = 0; j < schedule.days[i].Hours.Length; j++)
                {
                    if (schedule.days[i].Hours[j])
                    {
                        TimeTable[i].Hours[j] = false;
                    }
                }
            }
        }
        public static int getIdToNewOffice()
        {
            uniqueId += 100;
            return uniqueId;
        }
        #endregion
    }
}
