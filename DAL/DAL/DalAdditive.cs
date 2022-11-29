using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using DAL.configuration;
using Microsoft.Extensions.Options;

namespace DAL
{
    public class DalAdditive : IDalAdditive
    {
        private readonly IMongoCollection<AdditiveGeneral> _AdditiveCollection;
        #region c-tor
        public DalAdditive(IOptions<CooperativeStoreDataBaseSetting> CooperativeStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");
            var mongoDatabase = mongoClient.GetDatabase("Cooperative_Offices");
            _AdditiveCollection = mongoDatabase.GetCollection<AdditiveGeneral>("Additives");
        }
        #endregion
        #region functions

        #region GetFunction
        public List<AdditiveGeneral> GetAllAdditive()
        {
            return _AdditiveCollection.Find(_ => true).ToList();
        }

        public AdditiveGeneral GetById(int id)
        {
            return (AdditiveGeneral)_AdditiveCollection.Find(_ => _.Id == id);
        }

        public AdditiveGeneral GetByName(string name)
        {
            return (AdditiveGeneral)_AdditiveCollection.Find(_ => _.Name == name);
        }
        #endregion
        #region deleteFunction
        public List<AdditiveGeneral> UpdateAdditive(int additiveId, AdditiveGeneral additiveGeneral)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region addFunction
        public List<AdditiveGeneral> AddAdditive(AdditiveGeneral additiveGeneral)
        {
            _AdditiveCollection.InsertOne(additiveGeneral);
            return _AdditiveCollection.Find(_ => true).ToList();
        }
        #endregion
        #region DeleteFunction
        public List<AdditiveGeneral> DeleteAdditive(AdditiveGeneral additiveGeneral)
        {
            _AdditiveCollection.DeleteOne(_ => _.Id == additiveGeneral.Id);
            return _AdditiveCollection.Find(_ => true).ToList();
        }

        public List<AdditiveGeneral> DeleteAdditiveById(int additiveId)
        {
            _AdditiveCollection.DeleteOne(_ => _.Id == additiveId);
            return _AdditiveCollection.Find(_ => true).ToList();
        }



        #endregion

        #endregion
    }
}
