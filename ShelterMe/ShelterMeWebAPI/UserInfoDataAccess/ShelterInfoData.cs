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
        public List<string> getShelterInformation(string shelterName) {
            try {
                List<string> shelterInformation = new List<string>();
                using (SqlConnection conn = new SqlConnection(
                    "Data Source=DESKTOP-STK0G8E\\SQLEXPRESS;Initial Catalog=ShelterMe;Integrated Security=SSPI")) {
                    SqlDataReader rdr = null;
                    conn.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM SHELTER_INFO WHERE SHELTER_NAME='{shelterName}'", conn);
                    rdr = command.ExecuteReader();
                    while (rdr.Read()) {
                        shelterInformation.Add(rdr[0].ToString());
                        shelterInformation.Add(rdr[1].ToString());
                        shelterInformation.Add(rdr[2].ToString());
                        shelterInformation.Add(rdr[3].ToString());
                        shelterInformation.Add(rdr[4].ToString());
                        shelterInformation.Add(rdr[5].ToString());
                        shelterInformation.Add(rdr[6].ToString());
                        shelterInformation.Add(rdr[7].ToString());
                    }
                }
                return shelterInformation;
            } catch (Exception) {
                /*return new List<string>() { "This shelter does not exist" };*/
                throw;
            }
        }
    }
}
