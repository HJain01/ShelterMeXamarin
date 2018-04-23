using System;
using System.Collections.Generic;
using System.Text;

namespace ShelterMe {
    public class UserInformation {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string userType { get; set; }
        public bool claimedARoom { get; set; }
        public int size { get; set; }
    }
}
