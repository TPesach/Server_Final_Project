using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDalAdditive
    {
        #region function

        //get
        public List<AdditiveGeneral> GetAllAdditive();
        public AdditiveGeneral GetById(int id);
        public AdditiveGeneral GetByName(string name);
        //delete
        public List<AdditiveGeneral> DeleteAdditiveById(int additiveId);
        public List<AdditiveGeneral> DeleteAdditive(AdditiveGeneral additiveGeneral);
        //update
        public List<AdditiveGeneral> UpdateAdditive(int additiveId, AdditiveGeneral additiveGeneral);
        //add
        public List<AdditiveGeneral> AddAdditive(AdditiveGeneral additiveGeneral);
        #endregion
    }
}
