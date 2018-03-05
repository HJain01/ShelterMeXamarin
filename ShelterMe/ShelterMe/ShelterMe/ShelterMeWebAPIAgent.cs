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

                var uri = new Uri($"http://localhost:53281/api/values/usernameAndPassword?username={usernameIn}&password={passwordIn}");
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

        public async void EnterData(string firstNameIn, string lastNameIn, string emailIn, string passwordIn, string userTypeIn) {
            try {
                HttpClient client = new HttpClient();

                var uri = new Uri($"http://localhost:53281/api/values/EnterData?firstName={firstNameIn}&lastName={lastNameIn}&email={emailIn}&password={passwordIn}&userType={userTypeIn}");
                HttpResponseMessage response = await client.GetAsync(uri);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public async Task<List<string>> getShelterInformation(string shelterName) {
            try {
                string listString = "";
                HttpClient client = new HttpClient();
                var uri = new Uri($"http://localhost:53281/api/values/shelterInformation?shelterName={shelterName}");
                HttpResponseMessage response = await client.GetAsync(uri);
                listString = await response.Content.ReadAsStringAsync();
                var t = JsonConvert.DeserializeObject<List<string>>(listString);
                return t;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
