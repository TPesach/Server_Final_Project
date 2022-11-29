using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace DTO
{
    public class DTOUser
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
    }
}
