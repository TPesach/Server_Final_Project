using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BLL
{
    public interface IBllHirer
    {
        //get
        public List<DTOHirer> GetAllHirer();
        public DTOHirer GetHirerById(string id);
        public DTOHirer GetHirerByOffice(string officeId);
        public DTOHirer GetHirerByNameAndPassword(string name, string password);
        public DTOHirer GetHirerByMail(string mail);
        public DTOHirer GetHirerByPhone(string phone);

        //delete
        public List<DTOHirer> DeleteHirer(DTOHirer hirer);
        public List<DTOHirer> DeleteHirerById(string hirerId);

        //update
        public List<DTOHirer> UpdateHirerById(string hirerId, DTOHirer hirer);

        //add
        public List<DTOHirer> AddHirer(DTOHirer hirer);
        public List<DTOHirer> AddOfficeToHirer(int hirerId, int officeId);
    }
}
