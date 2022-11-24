using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DisasterAlleviation.Pages
{
    public class LogUserModel : PageModel
    {

        public List<LoginInfo> userInfo = new List<LoginInfo>();
        public LoginInfo loginInfo = new LoginInfo();
        public string errorMessage = "";
        public string approvedMessage = "";
        public void OnGet()
        {
            //returns all the users information
            String ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\IRA\\OneDrive\\Documents\\DisasterDB.mdf;Integrated Security=True;Connect Timeout=30";


            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                con.Open();
                
                String query = "Select * from LOG_USER()";

                SqlCommand cmd = new SqlCommand(query,con);

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LoginInfo info = new LoginInfo();

                        info.ID = "" + reader.GetInt32(0);
                        info.Password = reader.GetString(2);
                        userInfo.Add(info);
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception "+ ex.ToString());
            }
        }
        public void OnPost()
        {
            loginInfo.Email = Request.Form["uEmail"];
            loginInfo.Password = Request.Form["uPass"];

            if(loginInfo.Password.Length == 0 || loginInfo.Email.Length == 0)
            {
                errorMessage = "All fields should be field";
                return;
            }

            //saving into database

            try
            {
                String ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\IRA\\OneDrive\\Documents\\DisasterDB.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                String query = "Insert into LOG_USER (email, userPassword) values " + "(@email, @password)";

                SqlCommand command = new SqlCommand(query, con);

                command.Parameters.AddWithValue("@email", loginInfo.Email);
                command.Parameters.AddWithValue("@password", loginInfo.Password);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            loginInfo.Email = "";
            loginInfo.Password = "";
            approvedMessage = "Login Successful";

            Response.Redirect("/Donate");

        }
    }


    public class LoginInfo
    {
        public string ID;
        public string Password;
        public string Email;


    }
}
