using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public interface IBllMatch
    {
        public List<Office> AddressSort(List<Office> offices, Renter renter);
        public List<Office> NecessaryCriterionsSort(List<Office> offices, Renter renter);
        public List<Office> PriorityLevelSort(List<Office> offices, Renter renter);
        public List<DTOOffice> matchingOfficeToRenter(DTORenter renter);
    }
}
