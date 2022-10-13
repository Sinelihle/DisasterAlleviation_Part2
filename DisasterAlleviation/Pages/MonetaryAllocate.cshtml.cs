using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace DisasterAlleviation.Pages
{
    [Authorize]
    public class MonetaryAllocateModel : PageModel
    {
        String connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\IRA\\OneDrive\\Documents\\DisasterDB.mdf;Integrated Security=True;Connect Timeout=30";
        AllocateGood goodAllocate=new AllocateGood();
        public void OnGet()
        {

        }

        public void OnPost()
        {
            goodAllocate.goodName = Request.Form["goodName"];

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            String query = "insert into goodAllocate (goodName) values " + "(@goodName)";

            SqlCommand command = new SqlCommand(query, con);

            command.Parameters.AddWithValue("@Amount", goodAllocate.goodName);
        }
    }

    public class AllocateGood
    {
        public string goodName;
    }

}
