using Microsoft.VisualStudio.TestTools.UnitTesting;
using DisasterAlleviation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DisasterAlleviation.Pages.Tests
{
    [TestClass()]
    public class LogUserModelTests
    {
        [TestMethod()]
        public void OnGetTest()
        {

            String ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\IRA\\OneDrive\\Documents\\DisasterDB.mdf;Integrated Security=True;Connect Timeout=30";


            SqlConnection con = new SqlConnection(ConnectionString);

            con.Open();

            String query = "Select * from LOG_USER()";

            SqlCommand cmd = new SqlCommand(query, con);
            List<LoginInfo> userInfo = new List<LoginInfo>();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    LoginInfo info = new LoginInfo();

                    info.ID = "" + reader.GetInt32(0);
                    info.Password = reader.GetString(2);
                    userInfo.Add(info);
                }
            }

            Assert.AreEqual("Select * from LOG_USER()", cmd.ToString());
           
        }
    }
}