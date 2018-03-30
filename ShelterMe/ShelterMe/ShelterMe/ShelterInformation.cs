using System;
using System.Collections.Generic;
using System.Text;

namespace ShelterMe {
    public class ShelterInformation {
        public int uniqueKey { get; set; }
        public string shelterName { get; set; }
        public int capacity { get; set; }
        public string restrictions { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
    }
}
