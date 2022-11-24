using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DisasterAlleviation.Pages
{
    public class ActiveDisasterModel : PageModel
    {
        public List<ActiveDisaster> disasterList = new List<ActiveDisaster>();
        ActiveDisaster activeDisaster = new ActiveDisaster();
        String ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\IRA\\OneDrive\\Documents\\DisasterDB.mdf;Integrated Security=True;Connect Timeout=30";
        String error;
        public void OnGet()
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                //retrieving amount from MonetaryDonate table
                String query = "Select amount from MonetaryDonate";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@amount", activeDisaster.amount);
                command.ExecuteNonQuery();

                //retrieving good name from GOODS_DONATE table
                String query2 = "Select goodName from GOODS_DONATE";
                SqlCommand com = new SqlCommand(query2, con);
                com.Parameters.AddWithValue("@goodName", activeDisaster.goodsAllocated);
                com.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            


        }
    }

    public class ActiveDisaster
    {
        public string amount;
        public string goodsAllocated;
    }
}
