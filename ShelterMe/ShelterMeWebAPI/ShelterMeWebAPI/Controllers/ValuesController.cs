using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShelterMeBusinessLogic;
using ShelterMeObjects;

namespace ShelterMeWebAPI.Controllers {
    [Route("api")]
    public class ValuesController : Controller {
        // GET api/usernameAndPassword
        [HttpGet("usernameAndPassword")]
        public bool ContainsUsernameAndPassword(string username, string password) {
            UserInfoService service = new UserInfoService();
            return service.ContainsUsernameAndPassword(username, password);
        }

        // GET api/userData
        [HttpGet("userData")]
        public UserInfo getUserData(string username) {
            UserInfoService service = new UserInfoService();
            return service.GetUserData(username);
        }

        //GET api/shelterInformation
        [HttpGet("shelterInformation")]
        public ShelterInfo getShelterInformation(string shelterName) {
            ShelterInfoService service = new ShelterInfoService();
            return service.getShelterInformation(shelterName);
        }
        
        //GET api/allShelters
        [HttpGet("allShelters")]
        public List<ShelterInfo> getShelterInformation() {
            ShelterInfoService service = new ShelterInfoService();
            return service.getShelterInformation();
        }

        //GET api/shelterInformationRestrictions
        [HttpGet("shelterInformationRestrictions")]
        public List<ShelterInfo> getShelterInformationByRestrictions(string genderOrAgeRange) {
            ShelterInfoService service = new ShelterInfoService();
            return service.getFilteredSheltersByRestrictions(genderOrAgeRange);
        }

        //GET api/lastUniqueKey
        [HttpGet("lastID")]
        public int getLastID() {
            ShelterInfoService service = new ShelterInfoService();
            return service.getLastID();
        }

        //GET api/shelterNames
        [HttpGet("shelterNames")]
        public List<string> getShelterNames() {
            ShelterInfoService service = new ShelterInfoService();
            return service.getShelterNames();
        }

        // GET api/capacity
        [HttpGet("capacity")]
        public int getCapacity(string shelterName) {
            ShelterInfoService service = new ShelterInfoService();
            return service.getCapacity(shelterName);
        }

        // POST api/enterUserData
        [HttpPost("enterUserData")]
        public void EnterUserData(string firstName, string lastName, string email, string password, string userType) {
            UserInfoService service = new UserInfoService();
            service.EnterData(firstName, lastName, email, password, userType);
        }

        // POST api/enterShelterData
        [HttpPost("enterShelterData")]
        public void EnterShelterData(int id, string shelterName, int capacity, string restrictions, float longitude, float latitude, string address, string phoneNumber) {
            ShelterInfoService service = new ShelterInfoService();
            service.EnterShelterData(id, shelterName, capacity, restrictions, longitude, latitude, address, phoneNumber);
        }

        // PUT api/reduceCapacity
        [HttpPut("reduceCapacity")]
        public void reduceCapacity(int idIn, string shelterNameIn, int capacityIn, string restrictionsIn, float longitudeIn, float latitudeIn, string addressIn, string phoneNumberIn) {
            ShelterInfoService service = new ShelterInfoService();
            service.reduceCapacity(idIn, shelterNameIn, capacityIn, restrictionsIn, longitudeIn, latitudeIn, addressIn, phoneNumberIn);
        }

        // PUT api/increaseCapacity
        [HttpPut("increaseCapacity")]
        public void increaseCapacity(int idIn, string shelterNameIn, int capacityIn, string restrictionsIn, float longitudeIn, float latitudeIn, string addressIn, string phoneNumberIn) {
            ShelterInfoService service = new ShelterInfoService();
            service.increaseCapacity(idIn, shelterNameIn, capacityIn, restrictionsIn, longitudeIn, latitudeIn, addressIn, phoneNumberIn);
        }

        // DELETE api/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
