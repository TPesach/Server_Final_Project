using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDalRenter
    {
        #region functionToUser
        //get
        public List<Renter> GetAllRenters();
        public Renter GetRenterById(int id);
        public List<Renter> GetRentersByOfficeId(string OfficeId);
        public Renter GetRenterByNameAndPassword(string name, string password);
        public Renter GetRenterByMail(string mail);
        public Renter GetRenterByPhone(string mail);
        //delete
        public List<Renter> DeleteRenter(Renter renter);
        public List<Renter> DeleteRenterById(int renterId);

        //update
        public List<Renter> UpdateRenterById(int RenterId, Renter Renter);

        //add

        public List<Renter> AddRenter(Renter renter);

        #endregion

        #region functionToadditiveDetails
        //get

        public List<AdditiveForRenter> GetAllAdditiveByRenter(int RenterId);
        public AdditiveForRenter GetAdditiveDetailsById(int UserId, int additiveDetailsId);

        public AdditiveForRenter GetAdditiveDetailsByName(int RenterId, string additiveDetailsName);

        //delete

        public List<AdditiveForRenter> DeleteAdditiveDetails(int UserId, AdditiveForRenter additiveDetails);

        //update

        public List<AdditiveForRenter> UpdateAdditiveDetails(int RenterId, int additiveDetailsId, AdditiveForRenter additiveDetails);

        //add

        public List<AdditiveForRenter> AddAdditiveDetails(int UserId, AdditiveForRenter additiveDetails);
        #endregion
    }
}
