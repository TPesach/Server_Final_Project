using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BLL
{
    public interface IBllManager
    {
        //get
        public List<DTOManager> GetAllManager();
        public DTOManager GetManagerById(int id);
        public DTOManager GetManagerByNameAndPassword(string name, string password);
        public DTOManager GetManagerByMail(string mail);
        public DTOManager GetManagerByPhone(string phone);


        //delete
        public List<DTOManager> DeleteManager(DTOManager manager);
        public List<DTOManager> DeleteManagerById(int managerId);


        //update
        public List<DTOManager> UpdateManagerById(int managerId, DTOManager manager);


        //add
        public List<DTOManager> AddManager(DTOManager manager);
    }
}
