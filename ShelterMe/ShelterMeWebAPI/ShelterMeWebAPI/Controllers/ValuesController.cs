using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelterMeBusinessLogic;

namespace ShelterMeWebAPI.Controllers {
    [Route("api/[controller]")]
    public class ValuesController : Controller {
        // GET api/values/usernameAndPassword
        [HttpGet("usernameAndPassword")]
        public bool ContainsUsernameAndPassword(string username, string password) {
            UserInfoService service = new UserInfoService();
            return service.ContainsUsernameAndPassword(username, password);
        }

        //GET api/values/shelterInformation
        [HttpGet("shelterInformation")]
        public List<string> getShelterInformation(string shelterName) {
            ShelterInfoService service = new ShelterInfoService();
            return service.getShelterInformation(shelterName);
        }

        // POST api/values
        [HttpPost("EnterData")]
        public void PostData(string firstName, string lastName, string email, string password, string userType) {
            UserInfoService service = new UserInfoService();
            service.EnterData(firstName, lastName, email, password, userType);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
