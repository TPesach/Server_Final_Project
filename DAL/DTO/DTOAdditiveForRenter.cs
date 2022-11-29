using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTOAdditiveForRenter : DTOAdditiveForOffice
    {
        public Boolean Necessary { get; set; }
        public Int32 PriorityLevel { get; set; }
    }
}
