using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DisasterAlleviation.Pages
{
   
    public class monetaryDonateModel : PageModel
    {
        public List<MonetaryDon> moneyInfo = new List<MonetaryDon>();
        public MonetaryDon loginInfo = new MonetaryDon();
        public string errorMessage;
        public void OnGet()
        {
        }

        public void OnPost()
        {
            loginInfo.Date = Request.Form["donDate"];
            loginInfo.amount = Request.Form["amount"];

            try
            {
                String ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\IRA\\OneDrive\\Documents\\DisasterDB.mdf;Integrated Security=True;Connect Timeout=30";
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                String query = "Insert into MonetaryDonate (donDate, amount) values " + "(@donDate,@amount)";

                SqlCommand command = new SqlCommand(query, con);

                command.Parameters.AddWithValue("@donDate", loginInfo.Date);
                command.Parameters.AddWithValue("@amount", loginInfo.amount);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
    }

    public class MonetaryDon
    {
        public string Date;
        public string amount;


    }


}
