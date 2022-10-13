using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DisasterAlleviation.Pages
{
    [Authorize("administrator")]
    public class AllocateModel : PageModel
    {
        AllocateMoney money=new AllocateMoney();   
        List<AllocateMoney> moneyList=new List<AllocateMoney>();
        String connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\IRA\\OneDrive\\Documents\\DisasterDB.mdf;Integrated Security=True;Connect Timeout=30";
        public void OnGet()
        {
           
        }
        
        public void OnPost()
        {
            money.allocateAmount.ToString().Equals(Request.Form["amount"].ToString());

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            String query = "insert into MonetaryAllocate (amount) values " + "(@Amount)";

            SqlCommand command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@Amount", money.allocateAmount);
        }
    }

    public class AllocateMoney
    {
        public double allocateAmount;
    }

}
