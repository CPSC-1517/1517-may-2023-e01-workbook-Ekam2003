using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        //form control properties
        public double Num { get; set; }
        public string MassText { get; set; }

        public int FavouriteCourse { get; set; } //using integer value from select
        public void OnGet()
        {
        }
    }
}
