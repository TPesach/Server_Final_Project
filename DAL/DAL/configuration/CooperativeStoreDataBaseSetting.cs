using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.configuration
{
    public class CooperativeStoreDataBaseSetting
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string UsersCollectionName { get; set; } = null!;
        public string OfficesCollectionName { get; set; } = null;

        public string AdditivesCollectionName { get; set; } = null;
        public string AdditiveDetailsCollectionName { get; set; } = null;
    }
}
