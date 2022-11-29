using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL;
using DTO;

namespace BLL
{
    public class BllManager : IBllManager
    {
        IDalManager DalManager;
        IMapper imapper;

        public BllManager(IDalManager _DalManager)
        {
            this.DalManager = _DalManager;
            //הגדרה זו מאפשרת לבצע את ההמרות בין המחלקות לפי המחלקה שמגדירה אותן
            //המחלקה שמגדירה אותן נמצאת בשכבת ה dto
            //וקראנו לה Auto
            var config = new MapperConfiguration(cnf => cnf.AddProfile<Auto>());
            //משתנה זה זמין לשימוש לביצוע ההמרות בפועל
            imapper = config.CreateMapper();
        }


        #region functions

        #region add

        public List<DTOManager> AddManager(DTOManager manager)
        {
            Manager newManager = imapper.Map<DTOManager, Manager>(manager);
            List<Manager> managers = DalManager.AddManager(newManager);
            return imapper.Map<List<Manager>, List<DTOManager>>(managers);
        }
        #endregion

        #region delete

        public List<DTOManager> DeleteManager(DTOManager manager)
        {
            Manager newManager = imapper.Map<DTOManager, Manager>(manager);
            List<Manager> managers = DalManager.DeleteManager(newManager);
            return imapper.Map<List<Manager>, List<DTOManager>>(managers);
        }

        public List<DTOManager> DeleteManagerById(int managerId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region get
        //public List<DTOHirer> GetAllHirer()
        //{
        //    List<Hirer> hireres = DalHirer.GetAllHirer();
        //    return imapper.Map<List<Hirer>, List<DTOHirer>>(hireres);
        //}

        //public DTOHirer GetHirerById(string id)
        //{
        //    Hirer hirer = DalHirer.GetHirerById(id);
        //    return imapper.Map<Hirer, DTOHirer>(hirer);
        //}

        //public DTOHirer GetHirerByMail(string mail)
        //{
        //    Hirer hirer = DalHirer.GetHirerByMail(mail);
        //    return imapper.Map<Hirer, DTOHirer>(hirer);
        //}

        //public DTOHirer GetHirerByNameAndPassword(string name, string password)
        //{
        //    Hirer hirer = DalHirer.GetHirerByNameAndPassword(name, password);
        //    return imapper.Map<Hirer, DTOHirer>(hirer);
        //}

        //public DTOHirer GetHirerByOffice(string officeId)
        //{

        //    return imapper.Map<Hirer, DTOHirer>(DalHirer.GetHirerByOffice(officeId));
        //}

        //public DTOHirer GetHirerByPhone(string phone)
        //{
        //    Hirer hirer = DalHirer.GetHirerByPhone(phone);
        //    return imapper.Map<Hirer, DTOHirer>(hirer);
        //}


        public List<DTOManager> GetAllManager()
        {
            List<Manager> managers = DalManager.GetAllManager();
            return imapper.Map<List<Manager>, List<DTOManager>>(managers);
        }

        public DTOManager GetManagerById(int id)
        {
            Manager manager = DalManager.GetManagerById(id);
            return imapper.Map<Manager, DTOManager>(manager);
        }

        public DTOManager GetManagerByMail(string mail)
        {
            Manager manager = DalManager.GetManagerByMail(mail);
            return imapper.Map<Manager, DTOManager>(manager);
        }

        public DTOManager GetManagerByNameAndPassword(string name, string password)
        {
            throw new NotImplementedException();
        }

        public DTOManager GetManagerByPhone(string phone)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region update

        public List<DTOManager> UpdateManagerById(int managerId, DTOManager manager)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion
    }
}
