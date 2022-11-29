using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using DAL.configuration;
using Microsoft.Extensions.Options;

namespace DAL
{
    public class DalOffice : IDalOffice
    {
        private readonly IMongoCollection<Office> _OfficeCollection;

        #region c-tor
        public DalOffice(IOptions<CooperativeStoreDataBaseSetting> CooperativeStoreDatabaseSettings)
        {


            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("Cooperative_Offices");
            _OfficeCollection = mongoDatabase.GetCollection<Office>("Offices");


        }
        #endregion

        #region help function

        public Office FindCurrentoffice(Int32 OfficeId)
        {
            return _OfficeCollection.Find(o => o.Id.Equals(OfficeId)).First();
        }

        #endregion

        #region functionsToOffice

        #region GetFunction
        public List<Office> GetAllOffices()
        {
            //{
            //    Office office = new Office() { Id = 102, Floor = 5 };
            //    office.addAdditive(new AdditiveForOffice() { Id = 7, Name = "dgfhj" ,Value= "dwsfg"});
            //    office.addAdditive(new AdditiveForOffice() { Id = 5, Name = "dgfhj",Value="f" });
            //_OfficeCollection.InsertOne(office);
            //Office office1 = _OfficeCollection.Find(a => a.Id == 100).First();
            //Office office2 = _OfficeCollection.Find(a => a.Id == 200).First();
            //Office office3 = _OfficeCollection.Find(a => a.Id == 300).First();
            //Office office4 = _OfficeCollection.Find(a => a.Id == 400).First();
            //Office office5 = _OfficeCollection.Find(a => a.Id == 99).First();
            //Office office6 = _OfficeCollection.Find(a => a.Id == 101).First();


            List<Office> OList = _OfficeCollection.Find(_ => true).ToList();

            //Console.WriteLine(OList.ToList().ToString());
            return OList;
        }

        public List<Office> GetOfficesByCity(string city)
        {
            return (List<Office>)_OfficeCollection.Find(_ => _.Address.City.Equals(city)).ToList();
        }

        public Office GetOfficeById(Int32 id)
        {
            return (Office)_OfficeCollection.Find(_ => _.Id == id).First();
        }

        public List<Office> GetOfficesByHirer(Hirer hirer)
        {
            return _OfficeCollection.Find(_ => _.HirerId.Equals(hirer.Id)).ToList();
        }

        public List<Office> GetOfficesByRenter(Renter renter)
        {
            throw new NotImplementedException();
        }



        #endregion

        #region UpdateFunction
        public List<Office> UpdateOffice(Int32 officeId, Office office)
        {
            _OfficeCollection.ReplaceOneAsync(o => o.Id.Equals(officeId), office);
            return _OfficeCollection.Find(_ => true).ToList();
        }
        #endregion

        #region deleteFunction
        public List<Office> DeleteOffice(Office office)
        {
            _OfficeCollection.DeleteOne(_ => _.Id == office.Id);
            return _OfficeCollection.Find(_ => true).ToList();
        }

        public List<Office> DeleteOfficeById(Int32 officeId)
        {
            _OfficeCollection.DeleteOne(_ => _.Id.Equals(officeId));
            return _OfficeCollection.Find(_ => true).ToList();
        }




        #endregion

        #region addFunction
        public List<Office> AddOffice(Office office)
        {
            office.Id = Office.getIdToNewOffice();
            _OfficeCollection.InsertOne(office);
            return _OfficeCollection.Find(_ => true).ToList();
        }
        #endregion

        #endregion

        #region functionToSchedule
        #region get
        public List<Schedule> GetSchedulesByOffice(Office office)
        {
            return FindCurrentoffice(office.Id).ScheduleList;
        }
        public List<Schedule> GetSchedulesByOfficeId(Int32 officeId)
        {
            return FindCurrentoffice(officeId).ScheduleList;
        }
        //public List<Day> GetSchedulesByDayName(int officeId, string name)
        //{

        //}


        #endregion
        #region add
        public List<Schedule> AddSchedule(Int32 officeId, Schedule schedule)
        {
            Office office1 = FindCurrentoffice(officeId);
            office1.AddSchedule(schedule);
            return office1.ScheduleList;

        }
        #endregion
        #region delete
        public List<Schedule> DeleteSchedule(Office office, Schedule schedule)
        {
            Office office1 = FindCurrentoffice(office.Id);
            office1.DeleteSchedule(schedule);
            return office1.ScheduleList;

        }
        #endregion
        #region update
        public List<Schedule> UpdateSchedule(Int32 officeId, Schedule schedule, string scheduleId)
        {
            Office office1 = FindCurrentoffice(officeId);
            Schedule schedule1 = office1.ScheduleList.Find(s => s.Id.Equals(scheduleId));
            schedule1 = schedule;
            return office1.ScheduleList;
        }
        #endregion
        #endregion
    }
}
