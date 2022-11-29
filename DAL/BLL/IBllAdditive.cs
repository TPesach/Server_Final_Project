using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BLL
{
    public interface IBllAdditive
    {
        #region function

        //get
        public List<DTOAdditiveGeneral> GetAllAdditive();
        public DTOAdditiveGeneral GetById(int id);
        public DTOAdditiveGeneral GetByName(string name);
        //delete
        public List<DTOAdditiveGeneral> DeleteAdditiveById(int AdditiveId);
        public List<DTOAdditiveGeneral> DeleteAdditive(DTOAdditiveGeneral additive);
        //update
        public List<DTOAdditiveGeneral> UpdateAdditive(int AdditiveId, DTOAdditiveGeneral additive);
        //add
        public List<DTOAdditiveGeneral> AddAdditive(DTOAdditiveGeneral additive);
        #endregion
    }
}
