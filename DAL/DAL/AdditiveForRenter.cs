using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class AdditiveForRenter : AdditiveForOffice
    {
        public Boolean Necessary { get; set; }
        public int PriorityLevel { get; set; }
    }
}
