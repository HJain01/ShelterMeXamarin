using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShelterMe {
    public class ShelterMeWebAPIAgent
    {
        public async Task<bool> ContainsUsernameAndPassword(string usernameIn, string passwordIn) {
            try {
                string booleanString = "";
                HttpClient client = new HttpClient();

                var uri = new Uri($"https://sheltermewebapi.azurewebsites.net/api/usernameAndPassword?username={usernameIn}&password={passwordIn}");
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode) {
                    booleanString = await response.Content.ReadAsStringAsync();
                    var t = JsonConvert.DeserializeObject<bool>(booleanString);
                    return t;
                }
                return false;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<UserInformation> getUserData(string usernameIn) {
            string userString = "";
            HttpClient client = new HttpClient();
            var uri = new Uri($"https://sheltermewebapi.azurewebsites.net/api/userData?username={usernameIn}");
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode) {
                userString = await response.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<UserInformation>(userString);
                return t;
            }
            return null;
        }

        public async void EnterData(string firstNameIn, string lastNameIn, string emailIn, string passwordIn, string userTypeIn) {
            try {
                UserInformation userInformation = new UserInformation();
                userInformation.firstName = firstNameIn;
                userInformation.lastName = lastNameIn;
                userInformation.email = emailIn;
                userInformation.password = passwordIn;
                userInformation.userType = userTypeIn;
                var stringContent = new StringContent(JsonConvert.SerializeObject(userInformation));
                HttpClient client = new HttpClient();
                string uri = $"https://sheltermewebapi.azurewebsites.net/api/enterUserData?firstName={firstNameIn}&lastName={lastNameIn}&email={emailIn}&password={passwordIn}&userType={userTypeIn}";
                HttpResponseMessage response = await client.PostAsync(uri, stringContent);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<ShelterInformation> getShelterInformation(string shelterName) {
            try {
                if (shelterName.Contains("'")) {
                    shelterName = shelterName.Replace("'", "''");
                }
                string listString = "";
                HttpClient client = new HttpClient();
                var uri = new Uri($"https://sheltermewebapi.azurewebsites.net/api/shelterInformation?shelterName={shelterName}");
                HttpResponseMessage response = await client.GetAsync(uri);
                listString = await response.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<ShelterInformation>(listString);
                return t;
            } catch (Exception ex) {
                return null;
            }
        }

        public async Task<List<ShelterInformation>> GetShelterInformation() {
            string listString = "";
            HttpClient client = new HttpClient();
            var uri = new Uri($"http://sheltermewebapi.azurewebsites.net/api/allShelters");
            HttpResponseMessage response = await client.GetAsync(uri);
            listString = await response.Content.ReadAsStringAsync();
            var t = JsonConvert.DeserializeObject<List<ShelterInformation>>(listString);
            return t;
        }

        public async Task<List<ShelterInformation>> getFilteredSheltersByRestrictions(string genderOrAgeRange) {
            try {
                string listString = "";
                HttpClient client = new HttpClient();
                var uri = new Uri($"http://sheltermewebapi.azurewebsites.net/api/shelterInformationRestrictions?genderOrAgeRange={genderOrAgeRange}");
                HttpResponseMessage response = await client.GetAsync(uri);
                listString = await response.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<List<ShelterInformation>>(listString);
                return t;
            } catch(Exception ex) {
                throw ex;
            }
        }
        public async void EnterShelterData(int idIn, string shelterNameIn, int capacityIn, string restrictionsIn, float longitudeIn, float latitudeIn, string addressIn, string phoneNumberIn) {
            try {
                ShelterInformation shelterInformation = new ShelterInformation();
                shelterInformation.uniqueKey = idIn;
                shelterInformation.shelterName = shelterNameIn;
                shelterInformation.capacity = capacityIn;
                shelterInformation.restrictions = restrictionsIn;
                shelterInformation.longitude = longitudeIn;
                shelterInformation.latitude = latitudeIn;
                shelterInformation.address = addressIn;
                shelterInformation.phoneNumber = phoneNumberIn;
                var stringContent = new StringContent(JsonConvert.SerializeObject(shelterInformation));
                HttpClient client = new HttpClient();
                string uri = $"https://sheltermewebapi.azurewebsites.net/api/enterShelterData?id={idIn}&shelterName={shelterNameIn}&capacity={capacityIn}&restrictions={restrictionsIn}&longitude={longitudeIn}&latitude={latitudeIn}&address={addressIn}&phoneNumber={phoneNumberIn}";
                HttpResponseMessage response = await client.PostAsync(uri, stringContent);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public async Task<int> getLastID() {
            try {
                string intString = "";
                HttpClient client = new HttpClient();
                var uri = new Uri($"https://sheltermewebapi.azurewebsites.net/api/lastID");
                HttpResponseMessage response = await client.GetAsync(uri);
                intString = await response.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<int>(intString);
                return t;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public async Task<List<string>> getShelterNames() {
            try {
                string nameString = "";
                HttpClient client = new HttpClient();
                var uri = new Uri($"https://sheltermewebapi.azurewebsites.net/api/shelterNames");
                HttpResponseMessage response = await client.GetAsync(uri);
                nameString = await response.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<List<string>>(nameString);
                return t;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public async Task<int> getCapacity(string shelterName) {
            try {
                string intString = "";
                HttpClient client = new HttpClient();
                var uri = new Uri($"https://sheltermewebapi.azurewebsites.net/api/capacity/shelterName={shelterName}");
                HttpResponseMessage response = await client.GetAsync(uri);
                intString = await response.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<int>(intString);
                return t;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public async void reduceCapacity(int idIn, string shelterNameIn, int capacityIn, string restrictionsIn, float longitudeIn, float latitudeIn, string addressIn, string phoneNumberIn) {
            try {
                ShelterInformation shelterInformation = new ShelterInformation();
                shelterInformation.uniqueKey = idIn;
                shelterInformation.shelterName = shelterNameIn;
                shelterInformation.capacity = capacityIn;
                shelterInformation.restrictions = restrictionsIn;
                shelterInformation.longitude = longitudeIn;
                shelterInformation.latitude = latitudeIn;
                shelterInformation.address = addressIn;
                shelterInformation.phoneNumber = phoneNumberIn;
                var stringContent = new StringContent(JsonConvert.SerializeObject(shelterInformation));
                HttpClient client = new HttpClient();
                var uri = $"https://sheltermewebapi.azurewebsites.net/api/reduceCapacity?id={idIn}&shelterName={shelterNameIn}&capacity={capacityIn}&restrictions={restrictionsIn}&longitude={longitudeIn}&latitude={latitudeIn}&address={addressIn}&phoneNumber={phoneNumberIn}";
                HttpResponseMessage response = await client.PutAsync(uri, stringContent);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public async void increaseCapacity(int idIn, string shelterNameIn, int capacityIn, string restrictionsIn, float longitudeIn, float latitudeIn, string addressIn, string phoneNumberIn) {
            try {
                ShelterInformation shelterInformation = new ShelterInformation();
                shelterInformation.uniqueKey = idIn;
                shelterInformation.shelterName = shelterNameIn;
                shelterInformation.capacity = capacityIn;
                shelterInformation.restrictions = restrictionsIn;
                shelterInformation.longitude = longitudeIn;
                shelterInformation.latitude = latitudeIn;
                shelterInformation.address = addressIn;
                shelterInformation.phoneNumber = phoneNumberIn;
                var stringContent = new StringContent(JsonConvert.SerializeObject(shelterInformation));
                HttpClient client = new HttpClient();
                var uri = $"https://sheltermewebapi.azurewebsites.net/api/increaseCapacity?id={idIn}&shelterName={shelterNameIn}&capacity={capacityIn}&restrictions={restrictionsIn}&longitude={longitudeIn}&latitude={latitudeIn}&address={addressIn}&phoneNumber={phoneNumberIn}";
                HttpResponseMessage response = await client.PutAsync(uri, stringContent);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
