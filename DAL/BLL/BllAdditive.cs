using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL;
using DTO;


namespace BLL
{
    public class BllAdditive : IBllAdditive
    {
        IMapper imapper;
        IDalAdditive DalAdditive;
        public BllAdditive(IDalAdditive dalAdditive)
        {
            this.DalAdditive = dalAdditive;
            var config = new MapperConfiguration(cnf => cnf.AddProfile<Auto>());
            //משתנה זה זמין לשימוש לביצוע ההמרות בפועל
            imapper = config.CreateMapper();
        }
        #region function

        #region get
        public List<DTOAdditiveGeneral> GetAllAdditive()
        {
            List<AdditiveGeneral> aList = DalAdditive.GetAllAdditive();
            return imapper.Map<List<AdditiveGeneral>, List<DTOAdditiveGeneral>>(aList);
        }

        public DTOAdditiveGeneral GetById(int id)
        {
            AdditiveGeneral AdditiveGeneral = DalAdditive.GetById(id);
            return imapper.Map<AdditiveGeneral, DTOAdditiveGeneral>(AdditiveGeneral);
        }

        public DTOAdditiveGeneral GetByName(string name)
        {
            AdditiveGeneral AdditiveGeneral = DalAdditive.GetByName(name);
            return imapper.Map<AdditiveGeneral, DTOAdditiveGeneral>(AdditiveGeneral);
        }
        #endregion
        #region delete
        public List<DTOAdditiveGeneral> DeleteAdditive(DTOAdditiveGeneral AdditiveGeneral)
        {
            return DeleteAdditiveById(AdditiveGeneral.Id);

        }

        public List<DTOAdditiveGeneral> DeleteAdditiveById(int AdditiveId)
        {
            List<AdditiveGeneral> additives = DalAdditive.DeleteAdditiveById(AdditiveId);
            return imapper.Map<List<AdditiveGeneral>, List<DTOAdditiveGeneral>>(additives);
        }
        #endregion
        #region add
        public List<DTOAdditiveGeneral> AddAdditive(DTOAdditiveGeneral AdditiveGeneral)
        {
            AdditiveGeneral additive1 = imapper.Map<DTOAdditiveGeneral, AdditiveGeneral>(AdditiveGeneral);
            return imapper.Map<List<AdditiveGeneral>, List<DTOAdditiveGeneral>>(DalAdditive.AddAdditive(additive1));
        }

        #endregion
        #region update
        public List<DTOAdditiveGeneral> UpdateAdditive(int AdditiveId, DTOAdditiveGeneral AdditiveGeneral)
        {
            AdditiveGeneral additive1 = imapper.Map<DTOAdditiveGeneral, AdditiveGeneral>(AdditiveGeneral);
            return imapper.Map<List<AdditiveGeneral>, List<DTOAdditiveGeneral>>(DalAdditive.UpdateAdditive(AdditiveId, additive1));
        }
        #endregion
        #endregion
    }
}
