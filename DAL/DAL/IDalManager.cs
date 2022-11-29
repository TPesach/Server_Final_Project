using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDalManager
    {
        //get
        public List<Manager> GetAllManager();
        public Manager GetManagerById(int id);
        public Manager GetManagerByNameAndPassword(string name, string password);
        public Manager GetManagerByMail(string mail);
        public Manager GetManagerByPhone(string phone);


        //delete
        public List<Manager> DeleteManager(Manager manager);
        public List<Manager> DeleteManagerById(int managerId);


        //update
        public List<Manager> UpdateManagerById(int managerId, Manager manager);


        //add
        public List<Manager> AddManager(Manager manager);
    }
}
