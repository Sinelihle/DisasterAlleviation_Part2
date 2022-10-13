using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterAlleviation.Pages
{
    [Authorize("administrator")]
    public class AllocateModel : PageModel
    {
        public void OnGet()
        {
           
        }
        
        public void OnPost()
        {
           
        }
    }
}
