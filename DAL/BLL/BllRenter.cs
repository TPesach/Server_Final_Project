using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL;
using DTO;

namespace BLL
{
    public class BllRenter : IBllRenter
    {
        IDalRenter DalRenter;
        IMapper imapper;
        public BllRenter(IDalRenter DalRenter)
        {
            this.DalRenter = DalRenter;
            var config = new MapperConfiguration(cnf => cnf.AddProfile<Auto>());
            imapper = config.CreateMapper();
        }

        #region RenterFunction

        #region get
        public List<DTORenter> GetAllRenters()
        {

            List<Renter> lRenter = DalRenter.GetAllRenters();
            List<DTORenter> ldtoRenter = imapper.Map<List<Renter>, List<DTORenter>>(lRenter);
            return ldtoRenter;

        }

        public DTORenter GetRenterById(int id)
        {
            Renter renter = DalRenter.GetRenterById(id);
            return imapper.Map<Renter, DTORenter>(renter);
        }

        public DTORenter GetRenterByMail(string mail)
        {
            Renter renter = DalRenter.GetRenterByMail(mail);
            return imapper.Map<Renter, DTORenter>(renter);
        }

        public DTORenter GetRenterByNameAndPassword(string name, string password)
        {
            Renter renter = DalRenter.GetRenterByNameAndPassword(name, password);
            return imapper.Map<Renter, DTORenter>(renter);
        }



        public List<DTORenter> GetRentersByOfficeId(string OfficeId)
        {
            List<Renter> renters = DalRenter.GetRentersByOfficeId(OfficeId);
            return imapper.Map<List<Renter>, List<DTORenter>>(renters);
        }

        public DTORenter GetRenterByPhone(string mail)
        {
            Renter renter = DalRenter.GetRenterByMail(mail);
            return imapper.Map<Renter, DTORenter>(renter);
        }
        #endregion

        #region add
        public List<DTORenter> AddRenter(DTORenter renter)
        {
            Renter r = imapper.Map<DTORenter, Renter>(renter);
            List<Renter> lRenter = DalRenter.AddRenter(r);
            return imapper.Map<List<Renter>, List<DTORenter>>(lRenter);
        }
        #endregion

        #region delete
        public List<DTORenter> DeleteRenter(DTORenter renter)
        {
            Renter r = imapper.Map<DTORenter, Renter>(renter);
            List<Renter> lRenter = DalRenter.DeleteRenter(r);
            return imapper.Map<List<Renter>, List<DTORenter>>(lRenter);
        }

        public List<DTORenter> DeleteRenterById(int renterId)
        {
            List<Renter> lRenter = DalRenter.DeleteRenterById(renterId);
            return imapper.Map<List<Renter>, List<DTORenter>>(lRenter);
        }
        #endregion

        #region update
        public List<DTORenter> UpdateRenterById(int RenterId, DTORenter Renter)
        {
            Renter r = imapper.Map<DTORenter, Renter>(Renter);
            List<Renter> lRenter = DalRenter.UpdateRenterById(RenterId, r);
            return imapper.Map<List<Renter>, List<DTORenter>>(lRenter);
        }
        #endregion

        #endregion

        #region AdditiveFunction

        #region get
        public DTOAdditiveForRenter GetAdditiveDetailsById(int UserId, int additiveDetailsId)
        {
            throw new NotImplementedException();
        }

        public DTOAdditiveForRenter GetAdditiveDetailsByName(int RenterId, string additiveDetailsName)
        {
            throw new NotImplementedException();
        }

        public List<DTOAdditiveForRenter> GetAllAdditiveByRenter(int RenterId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region add
        public List<DTOAdditiveForRenter> AddAdditiveDetails(int UserId, DTOAdditiveForRenter additiveDetails)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region delete
        public List<DTOAdditiveForRenter> DeleteAdditiveDetails(int UserId, DTOAdditiveForRenter additiveDetails)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region update
        public List<DTOAdditiveForRenter> UpdateAdditiveDetails(int RenterId, int additiveDetailsId, DTOAdditiveForRenter additiveDetails)
        {
            {
                throw new NotImplementedException();
            }
            #endregion

            #endregion
        }
    }
    }
