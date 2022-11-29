using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDalOffice
    {
        #region functionToOffice
        //get

        public List<Office> GetAllOffices();
        public List<Office> GetOfficesByCity(string city);
        public Office GetOfficeById(Int32 id);
        public List<Office> GetOfficesByHirer(Hirer hirer);
        public List<Office> GetOfficesByRenter(Renter renter);

        //delete
        public List<Office> DeleteOfficeById(Int32 officeId);
        public List<Office> DeleteOffice(Office office);
        //update
        public List<Office> UpdateOffice(Int32 officeId, Office office);


        //add

        public List<Office> AddOffice(Office office);
        #endregion

        #region functionTOSchedule


        //get
        public List<Schedule> GetSchedulesByOffice(Office office);
        public List<Schedule> GetSchedulesByOfficeId(Int32 officeId);
        //public List<Day> GetSchedulesByDayName(string officeId,string name);
        //add
        public List<Schedule> AddSchedule(Int32 officeId, Schedule schedule);

        //delete
        public List<Schedule> DeleteSchedule(Office office, Schedule schedule);
        //update
        public List<Schedule> UpdateSchedule(Int32 officeId, Schedule schedule, string scheduleId);


        #endregion
    }
}
