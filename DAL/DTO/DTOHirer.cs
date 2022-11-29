using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOHirer : DTOUser
    {
        public List<Int32> OfficesList { get; set; }
    }
}
