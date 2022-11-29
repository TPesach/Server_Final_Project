using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDalHirer
    {
        #region functions
        //get
        public List<Hirer> GetAllHirer();
        public Hirer GetHirerById(string id);
        public Hirer GetHirerByOffice(string officeId);
        public Hirer GetHirerByNameAndPassword(string name, string password);
        public Hirer GetHirerByMail(string mail);
        public Hirer GetHirerByPhone(string phone);


        //delete


        public List<Hirer> DeleteHirer(Hirer hirer);
        public List<Hirer> DeleteHirerById(string hirerId);


        //update

        public List<Hirer> UpdateHirerById(string hirerId, Hirer hirer);

        //add

        public List<Hirer> AddHirer(Hirer hirer);
        public List<Hirer> AddOfficeToHirer(int hirerId, int officeId); 

        #endregion
    }
}
