using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShelterMeDataAccess;
using ShelterMeObjects;

namespace ShelterMeBusinessLogic {
    public class ShelterInfoService {
        public ShelterInfo getShelterInformation(string shelterName) {
            ShelterInfoData shelterInfo = new ShelterInfoData();
            ShelterInfo shelterData = new ShelterInfo();
            shelterData = shelterInfo.getShelterInformation(shelterName);
            return shelterData;
        }
        public List<ShelterInfo> getShelterInformation() {
            ShelterInfoData shelterInfoData = new ShelterInfoData();
            List<ShelterInfo> shelterList = new List<ShelterInfo>();
            shelterList = shelterInfoData.getShelterInformation();
            return shelterList;
        }
        public ShelterInfo getFilteredSheltersByName(string shelterName) {
            ShelterInfoData filteredSheltersByName = new ShelterInfoData();
            ShelterInfo filteredShelterByNameList = new ShelterInfo();
            filteredShelterByNameList = filteredSheltersByName.getShelterInformation(shelterName);
            return filteredShelterByNameList;
        }
        public List<ShelterInfo> getFilteredSheltersByRestrictions(string genderOrAgeRange) {
            ShelterInfoData filteredSheltersByRestrictions = new ShelterInfoData();
            List<ShelterInfo> filteredSheltersByRestrictionsList = new List<ShelterInfo>();
            filteredSheltersByRestrictionsList = filteredSheltersByRestrictions.getShelterInformationByRestrictions(genderOrAgeRange);
            return filteredSheltersByRestrictionsList;
        }
        public void EnterShelterData(int id, string shelterName, int capacity, string restrictions, float longitude, float latitude, string address, string phoneNumber) {
            ShelterInfoData enterShelterData = new ShelterInfoData();
            enterShelterData.EnterShelterData(getLastID() + 1, shelterName, capacity, restrictions, longitude, latitude, address, phoneNumber);
        }
        public int getLastID() {
            ShelterInfoData lastID = new ShelterInfoData();
            int id = 0;
            id = lastID.GetLastShelterID();
            return id;
        }
        public List<string> getShelterNames() {
            ShelterInfoData shelterInfo = new ShelterInfoData();
            List<string> returnList = new List<string>();
            returnList = shelterInfo.getShelterNames();
            return returnList;
        }
        public int getCapacity(string shelterName) {
            ShelterInfoData shelterInfo = new ShelterInfoData();
            return shelterInfo.getCapacity(shelterName);
        }
        public void reduceCapacity(int idIn, string shelterNameIn, int capacityIn, string restrictionsIn, float longitudeIn, float latitudeIn, string addressIn, string phoneNumberIn) {
            ShelterInfoData shelterInfo = new ShelterInfoData();
            shelterInfo.reduceCapacity(idIn, shelterNameIn, capacityIn, restrictionsIn, longitudeIn, latitudeIn, addressIn, phoneNumberIn);
        }
        public void increaseCapacity(int idIn, string shelterNameIn, int capacityIn, string restrictionsIn, float longitudeIn, float latitudeIn, string addressIn, string phoneNumberIn) {
            ShelterInfoData shelterInfo = new ShelterInfoData();
            shelterInfo.increaseCapacity(idIn, shelterNameIn, capacityIn, restrictionsIn, longitudeIn, latitudeIn, addressIn, phoneNumberIn);
        }
    }
}
