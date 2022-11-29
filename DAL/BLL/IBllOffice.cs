using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BLL
{
    public interface IBllOffice
    {
        #region functions to office
        //get

        public List<DTOOffice> GetAllOffices();
        public DTOOffice GetOfficeById(Int32 id);
        public List<DTOOffice> GetOfficesByCity(string city);
        public List<DTOOffice> GetOfficesByHirer(DTOHirer hirer);
        public List<DTOOffice> GetOfficesByRenter(DTORenter renter);

        //delete
        public List<DTOOffice> DeleteOfficeById(Int32 officeId);
        public List<DTOOffice> DeleteOffice(DTOOffice office);
        //update
        public List<DTOOffice> UpdateOffice(Int32 officeId, DTOOffice office);


        //add

        public List<DTOOffice> AddOffice(DTOOffice office);
        #endregion


        #region functionTOSchedule


        //get
        public List<DTOSchedule> GetSchedulesByOffice(DTOOffice office);
        public List<DTOSchedule> GetSchedulesByOfficeId(Int32 officeId);
        //public List<DTODay> GetSchedulesByDayName(string officeId,string name);
        //add
        public List<DTOSchedule> AddSchedule(Int32 officeId, DTOSchedule schedule);

        //delete
        public List<DTOSchedule> DeleteSchedule(DTOOffice office, DTOSchedule schedule);
        //update
        public List<DTOSchedule> UpdateSchedule(Int32 officeId, DTOSchedule schedule, string scheduleId);


        #endregion
    }
}
