using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DisasterAlleviation.Pages
{
    public class totalMonetaryModel : PageModel
    {
        public TotalDonate totalDon = new TotalDonate();

        public void OnGet()
        {
            String ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\IRA\\OneDrive\\Documents\\DisasterDB.mdf;Integrated Security=True;Connect Timeout=30";


            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                con.Open();
                String query = "SELECT SUM(amount) FROM MonetaryDonate";

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@donDate", totalDon.Amount);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception " + ex.ToString());
            }
        }
    }

    public class TotalDonate
    {
        public int Amount;
    }
}
