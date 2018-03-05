using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterMeObjects {
    public class ShelterInfo {
        public string UniqueKey { get; set; }
        public string ShelterName { get; set; }
        public string Capacity { get; set; }
        public string Restrictions { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string SpecialNotes { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
