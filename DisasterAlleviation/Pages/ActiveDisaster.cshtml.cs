using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DisasterAlleviation.Pages
{
    public class ActiveDisasterModel : PageModel
    {
        public void OnGet()
        {
        }
    }

    public class ActiveDisaster
    {
        public string disasterName;
        public string amount;
        public string goodsAllocated;
    }
}
