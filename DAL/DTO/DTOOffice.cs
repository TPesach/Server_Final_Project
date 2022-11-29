using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace DTO
{
    public class DTOOffice
    {
        public Int32 Id { get; set; }
        public Address Address { get; set; }
        public int HirerId { get; set; }
        public int Size { get; set; }
        public int NumOfRoom { get; set; }
        public int Payment { get; set; }
        public int Floor { get; set; }

        public List<Renter> RenterList { get; set; }

        public List<DTOAdditiveForOffice> Additives { get; set; }
    }
}
