using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShelterMeObjects;
using System.Data.SqlClient;

namespace ShelterMeDataAccess {
    public class ShelterInfoData {
        ShelterInfo shelterInfo = new ShelterInfo();
        public ShelterInfo getShelterInformation(string shelterName) {
            try {
                ShelterInfo shelterInformation = new ShelterInfo();
                using (SqlConnection conn = new SqlConnection(
                    "Data Source=tcp:shelterme.database.windows.net,1433;Initial Catalog=ShelterMe;User ID=Harsh_Jain;Password=Nadiad1998")) {
                    SqlDataReader rdr = null;
                    conn.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM SHELTER_INFORMATION WHERE SHELTER_NAME='{shelterName}'", conn);
                    rdr = command.ExecuteReader();
                    while (rdr.Read()) {
                        shelterInformation.UniqueKey = Convert.ToInt32(rdr[0]);
                        shelterInformation.ShelterName = (rdr[1].ToString());
                        shelterInformation.Capacity = Convert.ToInt32(rdr[2]);
                        shelterInformation.Restrictions = (rdr[3].ToString());
                        shelterInformation.Longitude = (float) Convert.ToDouble(rdr[4]);
                        shelterInformation.Latitude = (float) Convert.ToDouble(rdr[5]);
                        shelterInformation.Address = (rdr[6].ToString());
                        shelterInformation.PhoneNumber = (rdr[7].ToString());
                    }
                    conn.Close();
                }
                return shelterInformation;
            } catch (Exception) {
                return null;
            }
        }
        public List<ShelterInfo> getShelterInformationByRestrictions(string genderOrAgeRange) {
            try {
                List<ShelterInfo> shelterInformation = new List<ShelterInfo>();
                ShelterInfo subList = new ShelterInfo();
                using (SqlConnection conn = new SqlConnection(
                    "Data Source=tcp:shelterme.database.windows.net,1433;Initial Catalog=ShelterMe;User ID=Harsh_Jain;Password=Nadiad1998")) {
                    SqlDataReader rdr = null;
                    conn.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM SHELTER_INFORMATION WHERE RESTRICTIONS LIKE '%{genderOrAgeRange}%'", conn);
                    rdr = command.ExecuteReader();
                    while (rdr.Read()) {
                        subList = new ShelterInfo();
                        subList.UniqueKey = Convert.ToInt32(rdr[0]);
                        subList.ShelterName = (rdr[1].ToString());
                        subList.Capacity = Convert.ToInt32(rdr[2]);
                        subList.Restrictions = (rdr[3].ToString());
                        subList.Longitude = (float) Convert.ToDouble(rdr[4]);
                        subList.Latitude = (float) Convert.ToDouble(rdr[5]);
                        subList.Address = (rdr[6].ToString());
                        subList.PhoneNumber = (rdr[7].ToString());
                        shelterInformation.Add(subList);
                    }
                    conn.Close();
                }
                return shelterInformation;
            } catch (Exception) {
                return null;
            }
        }
        public void EnterShelterData(int id, string shelterName, int capacity, string restrictions, float longitude, float latitude, string address, string phoneNumber) {
            using (SqlConnection conn = new SqlConnection(
                "Data Source=tcp:shelterme.database.windows.net,1433;Initial Catalog=ShelterMe;User ID=Harsh_Jain;Password=Nadiad1998")) {
                conn.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO SHELTER_INFORMATION VALUES({id}, '{shelterName}', {capacity}, '{restrictions}', {longitude}, {latitude}, '{address}', '{phoneNumber}')", conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        public int GetLastShelterID() {
            try {
                int uniqueKey = 0;
                using (SqlConnection conn = new SqlConnection(
                    "Data Source=tcp:shelterme.database.windows.net,1433;Initial Catalog=ShelterMe;User ID=Harsh_Jain;Password=Nadiad1998")) {
                    SqlDataReader rdr = null;
                    conn.Open();
                    SqlCommand command = new SqlCommand($"SELECT TOP 1 UNIQUE_KEY FROM SHELTER_INFORMATION ORDER BY UNIQUE_KEY DESC", conn);
                    rdr = command.ExecuteReader();
                    while (rdr.Read()) {
                        uniqueKey = Convert.ToInt32(rdr[0]);
                    }
                    conn.Close();
                }
                return uniqueKey;
            } catch (Exception) {
                return 0;
            }
        }
        public List<string> getShelterNames() {
            try {
                List<string> shelterNameList = new List<string>();
                using (SqlConnection conn = new SqlConnection(
                    "Data Source=tcp:shelterme.database.windows.net,1433;Initial Catalog=ShelterMe;User ID=Harsh_Jain;Password=Nadiad1998")) {
                    SqlDataReader rdr = null;
                    conn.Open();
                    SqlCommand command = new SqlCommand("SELECT SHELTER_NAME FROM SHELTER_INFORMATION", conn);
                    rdr = command.ExecuteReader();
                    while (rdr.Read()) {
                        shelterNameList.Add(rdr[0].ToString());
                    }
                    conn.Close();
                }
                return shelterNameList;
            } catch (Exception ex) {
                return null;
            }
        }
        public int getCapacity(string shelterName) {
            using (SqlConnection conn = new SqlConnection(
                "Data Source=tcp:shelterme.database.windows.net,1433;Initial Catalog=ShelterMe;User ID=Harsh_Jain;Password=Nadiad1998")) {
                SqlDataReader rdr = null;
                conn.Open();
                SqlCommand command = new SqlCommand($"SELECT CAPACITY FROM SHELTER_INFORMATION WHERE SHELTER_NAME='{shelterName}'", conn);
                rdr = command.ExecuteReader();
                while (rdr.Read()) {
                    shelterInfo.Capacity = Convert.ToInt32(rdr[0]);
                }
                conn.Close();
            }
            return shelterInfo.Capacity;
        }
        public void reduceCapacity(int idIn, string shelterNameIn, int capacityIn, string restrictionsIn, float longitudeIn, float latitudeIn, string addressIn, string phoneNumberIn) {
            using (SqlConnection conn = new SqlConnection(
                "Data Source=tcp:shelterme.database.windows.net,1433;Initial Catalog=ShelterMe;User ID=Harsh_Jain;Password=Nadiad1998")) {
                conn.Open();
                SqlCommand command = new SqlCommand($"UPDATE SHELTER_INFORMATION SET CAPACITY=CAPACITY-1 WHERE SHELTER_NAME='{shelterNameIn}'", conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
        public void increaseCapacity(int idIn, string shelterNameIn, int capacityIn, string restrictionsIn, float longitudeIn, float latitudeIn, string addressIn, string phoneNumberIn) {
            using (SqlConnection conn = new SqlConnection(
                "Data Source=tcp:shelterme.database.windows.net,1433;Initial Catalog=ShelterMe;User ID=Harsh_Jain;Password=Nadiad1998")) {
                conn.Open();
                SqlCommand command = new SqlCommand($"UPDATE SHELTER_INFORMATION SET CAPACITY=CAPACITY+1 WHERE SHELTER_NAME='{shelterNameIn}'", conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
