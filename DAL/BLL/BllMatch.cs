using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using DAL;
using DTO;

namespace BLL
{
    public class BllMatch : IBllMatch
    {
        IBllOffice bllOffice;
        IMapper imapper;

        public BllMatch(IBllOffice bllOffice)
        {
            this.bllOffice = bllOffice;
            var config = new MapperConfiguration(cnf => cnf.AddProfile<Auto>());
            //משתנה זה זמין לשימוש לביצוע ההמרות בפועל
            imapper = config.CreateMapper();
        }


        List<Office> OfficesByCity = new List<Office>();

        List<Office> officeByNecessaryCriterions = new List<Office>();

        List<Office> OfficeByPriorityLevelSort = new List<Office>();

        //פונקציה למיון ע"פ כתובת
        public List<Office> AddressSort(List<Office> offices, Renter renter)
        {

            //מעבר על המשרדים לחיפוש כתובת תואמת והכנסה לרשימה חדשה במקרה וכן
            foreach (var of in offices)
            {
                if (of.Address.City == renter.Address.City)
                    OfficesByCity.Add(of);
            }
            return OfficesByCity;
        }


        //פונקצית למיון ע"פ קריטריוניים הכרחיים ללקוח
        public List<Office> NecessaryCriterionsSort(List<Office> offices, Renter renter)
        {

            List<Office> tempOffices = OfficesByCity;
            //מעבר על כל העדפות של השוכר
            foreach (var renterAdditive in renter.additives)
            {
                //בדיקה רק במידה וההעדפה היא הכרחית
                if (renterAdditive.Necessary)
                {
                    AdditiveForOffice afo = null;
                    //מעבר על כל המשרדים
                    //foreach (var of in OfficesByCity)
                    //{
                    //    afo = of.additives.Find(a => a.Id == renterAdditive.Id && a.Value.Equals(renterAdditive.Value));
                    //    if (afo == null)
                    //    {
                    //        tempOffices.Remove(of);
                    //    }
                    //}
                    if (renterAdditive.Id == 1100)
                    {
                        for (var i = 0; i < OfficesByCity.Count; i++)
                        {
                            int price = int.Parse(renterAdditive.Value);
                            if (OfficesByCity[i].Payment > price)
                            {
                                OfficesByCity.Remove(OfficesByCity[i]);
                                i--;
                            }
                        }
                    }
                    else if (renterAdditive.Id == 2000)
                    {
                        for (var i = 0; i < OfficesByCity.Count; i++)
                        {
                            int size = int.Parse(renterAdditive.Value);
                            if (OfficesByCity[i].Size < size)
                            {
                                OfficesByCity.Remove(OfficesByCity[i]);
                                i--;
                            }
                        }
                    }
                    else
                    {
                        for (var i = 0; i < OfficesByCity.Count; i++)
                        {
                            afo = OfficesByCity[i].Additives.Find(a => a.Id == renterAdditive.Id && a.Value.Equals(renterAdditive.Value));
                            if (afo == null)
                            {
                                OfficesByCity.Remove(OfficesByCity[i]);
                                i--;
                            }
                        }
                    }
                }
            }
            return OfficesByCity;
        }

        //פונקצית דירוג ע"פ דרישות לקוח
        //מה הפונקציה עושה:
        //הפונקציה מגדירה שני מערכים
        //אחד למשרדים ומקביל אליו כמות ההעדפות התואמות לדרישת השוכר של אותו משרד
        //ולאחר מכן מיון מקבילי של שני המערכים
        public List<Office> PriorityLevelSort(List<Office> offices, Renter renter)
        {
            //הגדרת מערך ובו כמות ההתאמות לכל משרד

            int[] countMatchArray = new int[offices.Count];
            //הכנסת המשרדים למערך לצורך המיון
            //הגדרה
            Office[] SortOfficesByPriority = new Office[offices.Count];
            //הכנסה
            int g = 0;
            foreach (var item in offices)
            {
                SortOfficesByPriority[g] = item;
                g++;
            }
            int i = 0;
            //מעבר ובדיקה של כמות ההתאמות בכל משרד והכנסה למקום המקביל אליו במערך
            foreach (var of in offices)
            {
                int count = 0;
                //מעבר על ההעדפות של הלקוח
                foreach (var add in renter.additives)
                {
                    //בדיקת ההעדפה וההתאמה
                    if (of.Additives.Find(a => a.Id == add.Id && a.Value.Equals(add.Value)) != null)
                    {
                        count++;
                    }
                }
                //הכנסת כמות ההתאמות
                countMatchArray[i] = count;
                count = 0;
                i++;
            }
            //מיון שני המערכים במקביל
            int temp;
            Office office;
            for (int i2 = 0; i2 < countMatchArray.Length - 1; i2++)
            {
                for (int j = 0; j < countMatchArray.Length - i2 - 1; j++)
                {
                    if (countMatchArray[j] < countMatchArray[j + 1])
                    {
                        //החלפה במערך הכמויות
                        temp = countMatchArray[i2];
                        countMatchArray[i2] = countMatchArray[i2 + 1];
                        countMatchArray[i2 + 1] = temp;
                        //החלפה בהתאמה במערך המשרדים
                        office = SortOfficesByPriority[i2];
                        SortOfficesByPriority[i2] = SortOfficesByPriority[i2 + 1];
                        SortOfficesByPriority[i2 + 1] = office;
                    }
                }
            }
            return SortOfficesByPriority.ToList();

        }
        //פונקציה ראשית
        public List<DTOOffice> matchingOfficeToRenter(DTORenter renter2)
        {
            Renter renter = imapper.Map<DTORenter, Renter>(renter2);
            List<Office> offices = imapper.Map<List<DTOOffice>, List<Office>>(bllOffice.GetAllOffices());
            //מיון ע"פ כתובת הדבר ההכרחי הראשון
            OfficesByCity = AddressSort(offices, renter);
            //מיון ע"פ הקריטריונים ההכרחיים לשוכר
            officeByNecessaryCriterions = NecessaryCriterionsSort(OfficesByCity, renter);
            //דירוג הרשימה ע"פ  העדפות לקוח
            OfficeByPriorityLevelSort = PriorityLevelSort(officeByNecessaryCriterions, renter);
            Console.WriteLine(OfficeByPriorityLevelSort.ToString());
            return imapper.Map<List<Office>, List<DTOOffice>>(OfficeByPriorityLevelSort);
        }
    }
}
