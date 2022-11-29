using System;
using System.Collections.Generic;
using System.Text;
using DAL.configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DAL
{
    public class DalRenter : IDalRenter
    {
        private readonly IMongoCollection<User> _UserCollection;
        private readonly IMongoCollection<Office> _OfficesCollection;

        #region c-tor
        public DalRenter(IOptions<CooperativeStoreDataBaseSetting> CooperativeStoreDatabaseSettings)
        {


            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("Cooperative_Offices");
            _UserCollection = mongoDatabase.GetCollection<User>("Users");
            _OfficesCollection = mongoDatabase.GetCollection<Office>("Offices");
        }
        #endregion

        #region HelpFunction
        public Renter convertUserToRenter(User user)
        {
            if (user is Renter)
            {
                return (Renter)user;
            }
            return null;
        }
        public Renter SearchRenterById(int RenterId)
        {
            User u = _UserCollection.Find(u => u.Id == RenterId).First();
            if (u is Renter)
                return (Renter)u;
            return null;
        }
        #endregion

        #region functionToUser



        #region DeleteFunctions

        public List<Renter> DeleteRenter(Renter renter)
        {
            _UserCollection.DeleteOne(_ => _.Id == renter.Id);
            List<User> UList = _UserCollection.Find(_ => true).ToList();
            List<Renter> URenter = null;
            foreach (User user in UList)
            {
                URenter.Add(convertUserToRenter(user));
            }
            return URenter;
        }

        public List<Renter> DeleteRenterById(int renterId)
        {
            _UserCollection.DeleteOne(_ => _.Id == renterId);
            List<User> UList = _UserCollection.Find(u => u is Renter).ToList();
            List<Renter> URenter = null;
            foreach (User user in UList)
            {
                URenter.Add(convertUserToRenter(user));
            }
            return URenter;
        }


        #endregion

        #region getFunction
        public List<Renter> GetAllRenters()
        {
            List<User> UList = _UserCollection.Find(u => u is Renter).ToList();
            List<Renter> URenter = new List<Renter>();
            foreach (User user in UList)
            {
                URenter.Add(convertUserToRenter(user));
            }
            return URenter;
        }

        public Renter GetRenterById(int id)
        {
            User user = _UserCollection.Find(_ => _.Id == id).First();
            return convertUserToRenter(user);
        }

        public Renter GetRenterByMail(string mail)
        {
            User user = _UserCollection.Find(_ => _.Mail.Equals(mail)).First();
            return convertUserToRenter(user);
        }

        public Renter GetRenterByNameAndPassword(string name, string password)
        {
            User user = _UserCollection.Find(_ => _.Name.Equals(name) && _.Password.Equals(password)).First();
            return convertUserToRenter(user);
        }



        public List<Renter> GetRentersByOfficeId(string OfficeId)
        {
            Office officeFound = _OfficesCollection.Find(o => o.Id.Equals(OfficeId)).First();
            return officeFound.RenterList;
        }

        public Renter GetRenterByPhone(string phone)
        {
            User user = _UserCollection.Find(_ => _.Phone.Equals(phone)).First();
            return convertUserToRenter(user);
        }
        #endregion 

        #region updateFunction
        public List<Renter> UpdateRenterById(int RenterId, Renter Renter)
        {
            _UserCollection.ReplaceOneAsync(renter => renter.Id == RenterId, Renter);
            return (List<Renter>)_UserCollection;
        }
        #endregion

        #region AddFunction
        public List<Renter> AddRenter(Renter renter)
        {
            _UserCollection.InsertOne(new Renter() { Id = renter.Id, Name = renter.Name, Address = renter.Address, Kind = renter.Kind, Phone = renter.Phone, Mail = renter.Mail, Password = renter.Password, OfficeId = renter.OfficeId, additives = renter.additives });
            return (List<Renter>)_UserCollection;
        }





        #endregion
        #endregion

        #region additiveDetailsHendler

        #region AddFunction
        public List<AdditiveForRenter> AddAdditiveDetails(int RenterId, AdditiveForRenter additiveDetails)
        {
            {
                User u = _UserCollection.Find(u => u.Id == RenterId).First();
                if (u is Renter)
                {
                    Renter r = (Renter)u;
                    r.additives.Add(additiveDetails);
                    return (List<AdditiveForRenter>)_UserCollection;
                }
                else
                    return null;

            }
        }
        #endregion

        #region DeleteFunction
        public List<AdditiveForRenter> DeleteAdditiveDetails(int UserId, AdditiveForRenter additiveDetails)
        {
            Renter r = SearchRenterById(UserId);

            if (r != null)
            {
                r.additives.Remove(additiveDetails);
                return (List<AdditiveForRenter>)_UserCollection;
            }
            else
                return null;

        }

        #endregion

        #region getFunction

        public AdditiveForRenter GetAdditiveDetailsById(int UserId, int additiveDetailsId)
        {
            Renter r = SearchRenterById(UserId);

            if (r != null)
            {
                return r.additives.Find(a => a.Id == additiveDetailsId);
            }
            else
                return null;
        }

        public AdditiveForRenter GetAdditiveDetailsByName(int RenterId, string additiveDetailsName)
        {
            Renter r = SearchRenterById(RenterId);

            if (r != null)
            {
                return r.additives.Find(a => a.Name.Equals(additiveDetailsName));
            }
            else
                return null;
        }

        public List<AdditiveForRenter> GetAllAdditiveByRenter(int RenterId)
        {
            Renter r = SearchRenterById(RenterId);

            if (r != null)
            {
                return r.additives;
            }
            else
                return null;
        }
        #endregion

        #region updateFunction

        public List<AdditiveForRenter> UpdateAdditiveDetails(int RenterId, int additiveDetailsId, AdditiveForRenter additiveDetails)
        {
            Renter r = SearchRenterById(RenterId);

            if (r != null)
            {
                AdditiveForRenter add = r.additives.Find(add2 => add2.Id == additiveDetailsId);
                add = additiveDetails;
                return r.additives;
            }
            else
                return null;

        }


        #endregion

        #endregion
    }
}
