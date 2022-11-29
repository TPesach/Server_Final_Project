using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Hirer : User
    {
        public List<Int32> OfficesList { get; set; }
    }
}
