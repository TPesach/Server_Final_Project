using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL;
using DTO;

namespace BLL
{
    public class BllOffice : IBllOffice
    {
        IDalOffice DalOffice;
        IMapper imapper;

        public BllOffice(IDalOffice DalOffice)
        {
            this.DalOffice = DalOffice;
            var config = new MapperConfiguration(cnf => cnf.AddProfile<Auto>());
            imapper = config.CreateMapper();
        }

        #region functions to office

        #region get

        public List<DTOOffice> GetAllOffices()
        {
            List<Office> Olist = DalOffice.GetAllOffices();
            return imapper.Map<List<Office>, List<DTOOffice>>(Olist);
        }
        public List<DTOOffice> GetOfficesByCity(string city)
        {
            List<Office> Olist = DalOffice.GetOfficesByCity(city);
            return imapper.Map<List<Office>, List<DTOOffice>>(Olist);
        }
        public DTOOffice GetOfficeById(Int32 id)
        {
            Office office = DalOffice.GetOfficeById(id);
            return imapper.Map<Office, DTOOffice>(office);
        }

        public List<DTOOffice> GetOfficesByHirer(DTOHirer hirer)
        {
            Hirer h = imapper.Map<DTOHirer, Hirer>(hirer);
            List<Office> Olist = DalOffice.GetOfficesByHirer(h);
            return imapper.Map<List<Office>, List<DTOOffice>>(Olist);
        }
        public List<DTOOffice> GetOfficesByRenter(DTORenter renter)
        {
            Renter r = imapper.Map<DTORenter, Renter>(renter);
            List<Office> Olist = DalOffice.GetOfficesByRenter(r);
            return imapper.Map<List<Office>, List<DTOOffice>>(Olist);
        }
        #endregion

        #region delete

        public List<DTOOffice> DeleteOfficeById(Int32 officeId)
        {
            List<Office> Olist = DalOffice.DeleteOfficeById(officeId);
            return imapper.Map<List<Office>, List<DTOOffice>>(Olist);
        }
        public List<DTOOffice> DeleteOffice(DTOOffice office)
        {
            Office office1 = imapper.Map<DTOOffice, Office>(office);
            List<Office> Olist = DalOffice.DeleteOffice(office1);
            return imapper.Map<List<Office>, List<DTOOffice>>(Olist);
        }
        #endregion

        #region update

        public List<DTOOffice> UpdateOffice(Int32 officeId, DTOOffice office)
        {
            Office office1 = imapper.Map<DTOOffice, Office>(office);
            List<Office> Olist = DalOffice.UpdateOffice(officeId, office1);
            return imapper.Map<List<Office>, List<DTOOffice>>(Olist);
        }
        #endregion

        #region add

        public List<DTOOffice> AddOffice(DTOOffice office)
        {
            Office office1 = imapper.Map<DTOOffice, Office>(office);
            List<Office> Olist = DalOffice.AddOffice(office1);
            return imapper.Map<List<Office>, List<DTOOffice>>(Olist);
        }
        #endregion

        #endregion

        #region functionToSchedule
        #region get

        public List<DTOSchedule> GetSchedulesByOffice(DTOOffice office)
        {
            return GetSchedulesByOfficeId(office.Id);
        }
        public List<DTOSchedule> GetSchedulesByOfficeId(Int32 officeId)
        {
            return imapper.Map<List<Schedule>, List<DTOSchedule>>(DalOffice.GetSchedulesByOfficeId(officeId));
        }
        //public List<Day> GetSchedulesByDayName(string officeId, string name)
        //{

        //}
        #endregion

        #region add

        public List<DTOSchedule> AddSchedule(Int32 officeId, DTOSchedule schedule)
        {

            Schedule schedule1 = imapper.Map<DTOSchedule, Schedule>(schedule);
            return imapper.Map<List<Schedule>, List<DTOSchedule>>(DalOffice.AddSchedule(officeId, schedule1));

        }
        #endregion

        #region delete
        public List<DTOSchedule> DeleteSchedule(DTOOffice office, DTOSchedule schedule)
        {
            Office office1 = imapper.Map<DTOOffice, Office>(office);
            Schedule schedule1 = imapper.Map<DTOSchedule, Schedule>(schedule);
            return imapper.Map<List<Schedule>, List<DTOSchedule>>(DalOffice.DeleteSchedule(office1, schedule1));
        }
        #endregion

        #region update
        public List<DTOSchedule> UpdateSchedule(Int32 officeId, DTOSchedule schedule, string scheduleId)
        {

            Schedule schedule1 = imapper.Map<DTOSchedule, Schedule>(schedule);
            return imapper.Map<List<Schedule>, List<DTOSchedule>>(DalOffice.UpdateSchedule(officeId, schedule1, scheduleId));
        }







        #endregion
        #endregion
    }
}
