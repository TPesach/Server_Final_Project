using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BLL
{
    public interface IBllRenter
    {
        #region functionToUser
        //get
        public List<DTORenter> GetAllRenters();
        public DTORenter GetRenterById(int id);

        public List<DTORenter> GetRentersByOfficeId(string OfficeId);
        public DTORenter GetRenterByNameAndPassword(string name, string password);
        public DTORenter GetRenterByMail(string mail);
        public DTORenter GetRenterByPhone(string mail);
        //delete
        public List<DTORenter> DeleteRenter(DTORenter renter);
        public List<DTORenter> DeleteRenterById(int renterId);

        //update
        public List<DTORenter> UpdateRenterById(int RenterId, DTORenter Renter);

        //add

        public List<DTORenter> AddRenter(DTORenter renter);

        #endregion

        #region functionToadditiveDetails
        //get

        public List<DTOAdditiveForRenter> GetAllAdditiveByRenter(int RenterId);
        public DTOAdditiveForRenter GetAdditiveDetailsById(int UserId, int additiveDetailsId);

        public DTOAdditiveForRenter GetAdditiveDetailsByName(int RenterId, string additiveDetailsName);

        //delete

        public List<DTOAdditiveForRenter> DeleteAdditiveDetails(int UserId, DTOAdditiveForRenter additiveDetails);

        //update

        public List<DTOAdditiveForRenter> UpdateAdditiveDetails(int RenterId, int additiveDetailsId, DTOAdditiveForRenter additiveDetails);

        //add

        public List<DTOAdditiveForRenter> AddAdditiveDetails(int UserId, DTOAdditiveForRenter additiveDetails);
        #endregion
    }
}
