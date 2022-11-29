using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public enum Kind
    {
        זכר, נקבה
    }
    public class Renter : User
    {
        //arr of criterion
        public Kind Kind { get; set; }

        public Int32 OfficeId { get; set; }

        public List<AdditiveForRenter> additives { get; set; }

        //public List<AdditiveForRenter> Additives
        //{
        //    get { return additives; }
        //}

        #region functions

        //public void addAdditive(AdditiveDetails additiveDetails)
        //{
        //    additives.Add(additiveDetails);
        //}
        //public void DeleteAdditive(AdditiveDetails additiveDetails)
        //{
        //    additives.Add(additiveDetails);
        //}
        #endregion
    }
}
