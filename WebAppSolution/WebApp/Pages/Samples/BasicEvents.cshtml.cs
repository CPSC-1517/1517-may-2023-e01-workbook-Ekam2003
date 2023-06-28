using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicEventsModel : PageModel  //can not change the :PageModel becuse it is Inherited Parent class.
    {
        //page properties
        public string Feedback { get; set; }// public property within the class
                                            // that can be used in the cshtml page
        private Random random = new Random(); //private field within the class

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

        /*************************************************
         * 
         * OnPost is a method that is call by default if the 
         *         submit button is clicked and there is no code for  specific
         *         event handler for the button
         * 
         * REMEMBER that the internet is a state-less environment 
         * That means the any web page is requested exists in the memory for as long as the page is executing code
         * After the page is sent to the user's brower, the system 
         * does NOT know about the page 
         * 
         ************************************************/

        //public void OnPost()
        public void OnPostFirstButton() 
        {
            int oddeven = random.Next(1, 101);
            if (oddeven % 2 ==0)
            {
                Feedback = $"Your value {oddeven} is even.";
            }
            else
                
            {
                Feedback = $"Your value {oddeven} is odd.";
            }
        }

        //this event will execute in response to a button on the 
        // form that has asp-page-handler parameter set to the 
        // appended name on OnPost
        public void OnPostSecondButton()
        {
            Feedback = "You clicked the second button and there is coded event for the button page handler";
        }
    }
}
