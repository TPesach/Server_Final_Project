using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class User
    {
        #region fields


        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        #endregion
    }
}
