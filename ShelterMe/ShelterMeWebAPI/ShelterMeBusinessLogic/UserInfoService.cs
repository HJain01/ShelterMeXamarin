using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShelterMeDataAccess;

namespace ShelterMeBusinessLogic {
    public class UserInfoService {
        public bool ContainsUsernameAndPassword(string username, string password) {
            UserInfoData userInfo = new UserInfoData();
            if (userInfo.getUsernameAndPassword().ContainsKey(username) && userInfo.getUsernameAndPassword()[username].Equals(password)) {
                return true;
            }
            return false;
        }

        public bool ContainsPassword(string password) {
            UserInfoData userInfo = new UserInfoData();
            if (userInfo.getPassword().Contains(password)) {
                return true;
            }
            return false;
        }

        public void EnterData(string firstName, string lastName, string email, string password, string userType) {
            UserInfoData userInfo = new UserInfoData();
            userInfo.EnterUserData(firstName, lastName, email, password, userType);
        }
    }
}
