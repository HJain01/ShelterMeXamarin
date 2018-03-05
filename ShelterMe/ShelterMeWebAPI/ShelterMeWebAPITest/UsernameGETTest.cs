using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShelterMeBusinessLogic;

namespace ShelterMeWebAPITest {
    [TestClass]
    public class UsernameGETTest {
        [TestMethod]
        public void TestGET() {
            UserInfoService userInfo = new UserInfoService();
            userInfo.ContainsUsername("jainh9999@gmail.com");
        }
    }
}
