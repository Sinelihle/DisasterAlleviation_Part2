using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DisasterAlleviation.Pages
{
    public class DonateModel : PageModel
    {
        public List<DonationInfo> userInfo = new List<DonationInfo>();
        public DonationInfo loginInfo = new DonationInfo();
        public string errorMessage = "";
        public void OnGet()
        {
            String ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\IRA\\OneDrive\\Documents\\DisasterDB.mdf;Integrated Security=True;Connect Timeout=30";


            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                con.Open();

                String query = "Select * from GOODS_DONATE";

                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LoginInfo info = new LoginInfo();

                        info.ID = "" + reader.GetInt32(0);
                        info.Password = reader.GetString(2);
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception " + ex.ToString());
            }
        }

        public void OnPost()
        {
            string goodCate = "";
            loginInfo.DonDate = Request.Form["donDate"];
            loginInfo.NumOfGoods = Request.Form["goodNum"];
            loginInfo.GoodName = Request.Form["goodName"];
            loginInfo.GoodCatergory = Request.Form["goodsCategory"];
            loginInfo.UserName = Request.Form["userName"];
            loginInfo.GoodDescription = Request.Form["GoodDescription"];


            if (loginInfo.GoodCatergory.ToString().Equals("Clothes"))
            {
                goodCate = "Clothes";
            }
            else if(loginInfo.GoodCatergory.ToString().Equals("Non-Perishable Food"))
            {
                goodCate = "Non-Perishable Food";
            }

            loginInfo.GoodCatergory = Request.Form[goodCate];




            try
            {
                String ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\IRA\\OneDrive\\Documents\\DisasterDB.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                String query = "insert into GOODS_DONATE (goodName, donaDate, numGoods, goodsCategory, goodDescription, donorName) values " + "(@goodName, @donaDate, @numGoods, @goodsCategory, @goodDescription, @donorName)";

                SqlCommand command = new SqlCommand(query, con);

                command.Parameters.AddWithValue("@donDate", loginInfo.DonDate);
                command.Parameters.AddWithValue("@numGoods", loginInfo.NumOfGoods);
                command.Parameters.AddWithValue("@goodName", loginInfo.GoodName);
                command.Parameters.AddWithValue("@goodsCategory", loginInfo.GoodCatergory);
                command.Parameters.AddWithValue("@donorName", loginInfo.UserName);
                command.Parameters.AddWithValue("@goodDescription", loginInfo.GoodDescription);



                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
        }
    }

    public class DonationInfo
    {
        public string GoodID;
        public string GoodName;
        public string UserName;
        public string DonDate;
        public string NumOfGoods;
        public string GoodCatergory;
        public string GoodDescription;


    }
}

/*
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

 */