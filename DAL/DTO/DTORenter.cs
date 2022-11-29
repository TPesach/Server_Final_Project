using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace DTO
{
    public class DTORenter : DTOUser
    {
        public Kind Kind { get; set; }

        public Int32 OfficeId { get; set; }

        public List<DTOAdditiveForRenter> additives { get; set; }
    }
}
