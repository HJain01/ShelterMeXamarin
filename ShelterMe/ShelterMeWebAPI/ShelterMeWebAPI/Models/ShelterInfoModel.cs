using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShelterMeWebAPI.Models {
    public class ShelterInfoModel {
        public string ShelterName { get; set; }
        public int Capacity { get; set; }
        public string Gender { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
