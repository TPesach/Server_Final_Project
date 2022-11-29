using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using DAL.configuration;
using Microsoft.Extensions.Options;

namespace DAL
{
    public class DalManager : IDalManager
    {
        private readonly IMongoCollection<User> _UserCollection;


        #region c-tor
        public DalManager(IOptions<CooperativeStoreDataBaseSetting> CooperativeStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("Cooperative_Offices");
            _UserCollection = mongoDatabase.GetCollection<User>("Users");

        }
        #endregion


        #region functions

        #region convert

        public Manager convertUserToManager(User user)
        {
            if (user is Manager)
            {
                return (Manager)user;
            }
            return null;
        }

        public List<Manager> convertUserListToManagerList(List<User> users)
        {
            List<Manager> MList = new List<Manager>();
            foreach (User user in users)
            {
                MList.Add(convertUserToManager(user));
            }
            return MList;
        }
        #endregion

        #region add

        public List<Manager> AddManager(Manager manager)
        {
            _UserCollection.InsertOne(manager);
            List<User> UList = _UserCollection.Find(user => user is Manager).ToList();
            return convertUserListToManagerList(UList);
        }
        #endregion

        #region delete

        public List<Manager> DeleteManager(Manager manager)
        {
            _UserCollection.DeleteOneAsync(_ => _.Id == manager.Id);
            List<User> UList = _UserCollection.Find(user => user is Manager).ToList();
            return convertUserListToManagerList(UList);
        }

        public List<Manager> DeleteManagerById(int managerId)
        {
            _UserCollection.DeleteOneAsync(_ => _.Id == managerId);
            List<User> UList = _UserCollection.Find(user => user is Manager).ToList();
            return convertUserListToManagerList(UList);
        }
        #endregion

        #region get

        public List<Manager> GetAllManager()
        {
            List<User> UList = _UserCollection.Find(user => user is Manager).ToList();
            return convertUserListToManagerList(UList);
        }

        public Manager GetManagerById(int id)
        {
            User user = _UserCollection.Find(_ => _.Id == id).First();
            return convertUserToManager(user);
        }

        public Manager GetManagerByMail(string mail)
        {
            User user = _UserCollection.Find(_ => _.Mail.Equals(mail)).First();
            return convertUserToManager(user);
        }

        public Manager GetManagerByNameAndPassword(string name, string password)
        {
            User user = _UserCollection.Find(_ => _.Name.Equals(name) && _.Password.Equals(password)).First();
            return convertUserToManager(user);
        }

        public Manager GetManagerByPhone(string phone)
        {
            User user = _UserCollection.Find(_ => _.Phone.Equals(phone)).First();
            return convertUserToManager(user);
        }
        #endregion

        #region update

        public List<Manager> UpdateManagerById(int managerId, Manager manager)
        {
            _UserCollection.ReplaceOne(_ => _.Id == managerId, manager);
            List<User> UList = _UserCollection.Find(user => user is Manager).ToList();
            return convertUserListToManagerList(UList);
        }
        #endregion

        #endregion
    }
}
