using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterMeObjects {
    public class ShelterInfo {
        public int UniqueKey { get; set; }
        public string ShelterName { get; set; }
        public int Capacity { get; set; }
        public string Restrictions { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string SpecialNotes { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
