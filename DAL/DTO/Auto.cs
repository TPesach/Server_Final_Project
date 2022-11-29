using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace DTO
{
    public class Auto : AutoMapper.Profile
    {
        public Auto()
        {
            //מיפוי למחלקות-המרה מסוגי הטיפוסים השונים

            CreateMap<Additive, DTOAdditive>();
            CreateMap<DTOAdditive, Additive>();

            CreateMap<AdditiveForRenter, DTOAdditiveForRenter>();
            CreateMap<DTOAdditiveForRenter, AdditiveForRenter>();

            CreateMap<AdditiveForOffice, DTOAdditiveForOffice>();
            CreateMap<DTOAdditiveForOffice, AdditiveForOffice>();

            CreateMap<AdditiveGeneral, DTOAdditiveGeneral>();
            CreateMap<DTOAdditiveGeneral, AdditiveGeneral>();


            CreateMap<Hirer, DTOHirer>();
            CreateMap<DTOHirer, Hirer>();

            CreateMap<Manager, DTOManager>();
            CreateMap<DTOManager, Manager>();

            CreateMap<Office, DTOOffice>();
            CreateMap<DTOOffice, Office>();

            CreateMap<User, DTOUser>();
            CreateMap<DTOUser, User>();

            CreateMap<Renter, DTORenter>();
            CreateMap<DTORenter, Renter>();

            CreateMap<DTOSchedule, Schedule>();
            CreateMap<Schedule, DTOSchedule>();


            CreateMap<DTODay, Day>();
            CreateMap<Day, DTODay>();
        }
    }
}
