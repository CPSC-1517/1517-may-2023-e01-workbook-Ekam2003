using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicEventsModel : PageModel  //can not change the :PageModel becuse it is Inherited Parent class.
    {
        //page properties
        public string Feedback { get; set; }

        /*************************************************
         * 
         * OnGet is a method that is call each and every time
         * this page is created
         * this page is called first when the page is retrieved
         * 
         * REMEMBER that the internet is a state-less environment 
         * That means the any web page is requested exists in the memory for as long as the page is executing code
         * After the page is sent to the user's brower, the system 
         * does NOT know about the page 
         * 
         ************************************************
         */
        public void OnGet()
        {
            Feedback = "in OnGet";
        }
    }
}
