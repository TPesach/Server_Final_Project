using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using DAL;
using DTO;

namespace BLL
{
    public class BllHirer: IBllHirer
    {
        IDalHirer DalHirer;
        IMapper imapper;

        public BllHirer(IDalHirer _DalHirer)
        {
            this.DalHirer = _DalHirer;
            //הגדרה זו מאפשרת לבצע את ההמרות בין המחלקות לפי המחלקה שמגדירה אותן
            //המחלקה שמגדירה אותן נמצאת בשכבת ה dto
            //וקראנו לה Auto
            var config = new MapperConfiguration(cnf => cnf.AddProfile<Auto>());
            //משתנה זה זמין לשימוש לביצוע ההמרות בפועל
            imapper = config.CreateMapper();
        }

        #region functions


        #region add

        public List<DTOHirer> AddHirer(DTOHirer hirer)
        {
            Hirer newHirer = imapper.Map<DTOHirer, Hirer>(hirer);
            List<Hirer> hireres = DalHirer.AddHirer(newHirer);
            return imapper.Map<List<Hirer>, List<DTOHirer>>(hireres);
        }
        public List<DTOHirer> AddOfficeToHirer(int hirerId, int officeId)
        {

            List<Hirer> hireres = DalHirer.AddOfficeToHirer(hirerId, officeId);
            return imapper.Map<List<Hirer>, List<DTOHirer>>(hireres);
        }

        #endregion

        #region delete

        public List<DTOHirer> DeleteHirer(DTOHirer hirer)
        {
            Hirer newHirer = imapper.Map<DTOHirer, Hirer>(hirer);
            List<Hirer> hireres = DalHirer.DeleteHirer(newHirer);
            return imapper.Map<List<Hirer>, List<DTOHirer>>(hireres);
        }

        public List<DTOHirer> DeleteHirerById(string hirerId)
        {
            List<Hirer> hireres = DalHirer.DeleteHirerById(hirerId);
            return imapper.Map<List<Hirer>, List<DTOHirer>>(hireres);
        }
        #endregion

        //I fix the bag:)
        #region get

        public List<DTOHirer> GetAllHirer()
        {
            List<Hirer> hireres = DalHirer.GetAllHirer();
            return imapper.Map<List<Hirer>, List<DTOHirer>>(hireres);
        }

        public DTOHirer GetHirerById(string id)
        {
            Hirer hirer = DalHirer.GetHirerById(id);
            return imapper.Map<Hirer, DTOHirer>(hirer);
        }

        public DTOHirer GetHirerByMail(string mail)
        {
            Hirer hirer = DalHirer.GetHirerByMail(mail);
            return imapper.Map<Hirer, DTOHirer>(hirer);
        }

        public DTOHirer GetHirerByNameAndPassword(string name, string password)
        {
            Hirer hirer = DalHirer.GetHirerByNameAndPassword(name, password);
            return imapper.Map<Hirer, DTOHirer>(hirer);
        }

        public DTOHirer GetHirerByOffice(string officeId)
        {

            return imapper.Map<Hirer, DTOHirer>(DalHirer.GetHirerByOffice(officeId));
        }

        public DTOHirer GetHirerByPhone(string phone)
        {
            Hirer hirer = DalHirer.GetHirerByPhone(phone);
            return imapper.Map<Hirer, DTOHirer>(hirer);
        }
        #endregion

        #region update

        public List<DTOHirer> UpdateHirerById(string hirerId, DTOHirer hirer)
        {
            Hirer newHirer = imapper.Map<DTOHirer, Hirer>(hirer);
            List<Hirer> hireres = DalHirer.UpdateHirerById(hirerId, newHirer);
            return imapper.Map<List<Hirer>, List<DTOHirer>>(hireres);
        }
        #endregion

        #endregion
    }
}
