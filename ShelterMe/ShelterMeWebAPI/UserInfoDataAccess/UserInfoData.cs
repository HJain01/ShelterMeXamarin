using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShelterMeObjects;

namespace ShelterMeDataAccess {
    public class UserInfoData {
        UserInfo userInfo = new UserInfo();
        public Dictionary<string, string> getUsernameAndPassword() {
            Dictionary<string, string> user = new Dictionary<string, string>();
            using (SqlConnection conn = new SqlConnection(
                "Data Source=DESKTOP-STK0G8E\\SQLEXPRESS;Initial Catalog=ShelterMe;Integrated Security=SSPI")) {
                SqlDataReader rdr = null;
                conn.Open();
                SqlCommand command = new SqlCommand(@"SELECT EMAIL, PASSWORD FROM USER_INFORMATION", conn);
                rdr = command.ExecuteReader();
                while (rdr.Read()) {
                    userInfo.Email = rdr[0].ToString();
                    userInfo.Password = rdr[1].ToString();
                    user.Add(userInfo.Email, userInfo.Password);
                }
                conn.Close();
            }
            return user;
        }

        public List<string> getPassword() {
            List<string> password = new List<string>();
            using (SqlConnection conn = new SqlConnection(
                "Data Source=DESKTOP-STK0G8E\\SQLEXPRESS;Initial Catalog=ShelterMe;Integrated Security=SSPI")) {
                SqlDataReader rdr = null;
                conn.Open();
                SqlCommand command = new SqlCommand(@"SELECT PASSWORD FROM USER_INFORMATION", conn);
                rdr = command.ExecuteReader();
                while (rdr.Read()) {
                    userInfo.Password = rdr[0].ToString();
                    password.Add(userInfo.Password);
                }
                conn.Close();
            }
            return password;
        }
        public void EnterUserData(string firstName, string lastName, string email, string password, string userType) {
            using (SqlConnection conn = new SqlConnection(
                "Data Source=DESKTOP-STK0G8E\\SQLEXPRESS;Initial Catalog=ShelterMe;Integrated Security=SSPI")) {
                conn.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO USER_INFORMATION"
                    + "VALUES({firstName}, {lastName}, {email}, {password}, {userType})", conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
