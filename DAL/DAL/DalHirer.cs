using System;
using System.Collections.Generic;
using System.Text;
using DAL.configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DAL
{
    public class DalHirer : IDalHirer
    {
        private readonly IMongoCollection<User> _UserCollection;
        private readonly IMongoCollection<Office> _OfficeCollection;
        #region c-tor
        public DalHirer(IOptions<CooperativeStoreDataBaseSetting> CooperativeStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("Cooperative_Offices");
            _UserCollection = mongoDatabase.GetCollection<User>("Users");
            _OfficeCollection = mongoDatabase.GetCollection<Office>("Offices");
        }
        #endregion


        #region function


        #region convert

        //user-מהמסד נתונים חוזר אובייקט מסוג 
        //יש להמירו hirer-וכדי להשתמש בו כ
        //במקום לעשות המרה בכל פונקציה שמבצעת קריאה למסד נתונים
        //עשינו פונקציה שמבצעת את ההמרה
        public Hirer convertUserToHirer(User user)
        {
            if (user is Hirer)
            {
                return (Hirer)user;
            }
            return null;
        }

        public List<Hirer> convertUserListToHirerList(List<User> users)
        {
            List<Hirer> HList = new List<Hirer>();
            foreach (User user in users)
            {
                HList.Add(convertUserToHirer(user));
            }
            return HList;
        }
        #endregion

        #region GetFunction
        public List<Hirer> GetAllHirer()
        {
            List<User> UList = _UserCollection.Find(user => user is Hirer).ToList();
            return convertUserListToHirerList(UList);
        }

        public Hirer GetHirerById(string id)
        {
            User foundUser = _UserCollection.Find(user => user.Id.Equals(id)).First();
            return convertUserToHirer(foundUser);

        }

        public Hirer GetHirerByMail(string mail)
        {
            User foundUser = _UserCollection.Find(user => user.Mail.Equals(mail)).First();
            return convertUserToHirer(foundUser);
        }

        public Hirer GetHirerByNameAndPassword(string name, string password)
        {
            User foundUser = _UserCollection.Find(user => user.Name.Equals(name) && user.Password.Equals(password)).First();
            return convertUserToHirer(foundUser);
        }

        public Hirer GetHirerByOffice(string officeId)
        {
            Office office1 = _OfficeCollection.Find(o => o.Id.Equals(officeId)).First();
            User u = _UserCollection.Find(u => u.Id.Equals(office1.HirerId)).First();
            if (u is Hirer)
            {
                return (Hirer)u;
            }
            return null;
        }

        public Hirer GetHirerByPhone(string phone)
        {
            User foundUser = _UserCollection.Find(user => user.Phone.Equals(phone)).First();
            return convertUserToHirer(foundUser);
        }
        #endregion

        #region deleteFunction
        public List<Hirer> DeleteHirer(Hirer hirer)
        {
            _UserCollection.DeleteOneAsync(_ => _.Id == hirer.Id);
            List<User> UList = _UserCollection.Find(user => user is Hirer).ToList();
            return convertUserListToHirerList(UList);
        }



        public List<Hirer> DeleteHirerById(string hirerId)
        {
            _UserCollection.DeleteOne(_ => _.Id.Equals(hirerId));
            List<User> UList = _UserCollection.Find(user => user is Hirer).ToList();
            return convertUserListToHirerList(UList);
        }


        #endregion

        #region updateFunction
        public List<Hirer> UpdateHirerById(string hirerId, Hirer hirer)
        {
            _UserCollection.ReplaceOne(user => user.Id.Equals(hirerId), hirer);
            List<User> UList = _UserCollection.Find(user => user is Hirer).ToList();
            return convertUserListToHirerList(UList);

        }




        #endregion

        #region AddFuncion
        public List<Hirer> AddHirer(Hirer hirer)
        {
            _UserCollection.InsertOne(hirer);
            List<User> UList = _UserCollection.Find(user => user is Hirer).ToList();
            return convertUserListToHirerList(UList);
        }
        public List<Hirer> AddOfficeToHirer(int hirerId, int officeId)
        {
            User u = _UserCollection.Find(u => u.Id == hirerId).First();
            Hirer h;
            if (u is Hirer)
            {

                h = (Hirer)u;
                h.OfficesList.Add(officeId);
            }
            List<User> UList = _UserCollection.Find(user => user is Hirer).ToList();
            return convertUserListToHirerList(UList);
        }
        #endregion

        #endregion
    }
}
