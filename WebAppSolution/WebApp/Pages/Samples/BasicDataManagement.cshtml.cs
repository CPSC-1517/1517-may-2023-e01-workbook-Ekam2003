using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Samples
{
    public class BasicDataManagementModel : PageModel
    {
        //form control properties
        // it is the asp-for that links the form control to the property
        // if a property does NOT have a [BindProperty] attribute,
        //      the value of the property is not updated when the form is submitted
        //      the property is considered as a read-only property (one way binding)
        //      the property value is "out going only" (from the server to the client)

        //[BindProperty] this attribute is not required
        //HOWEVER: if you wish to receive data from your client (form) into the server
        //            (PageModel) you MUST have the [BindProperty] attribute on the property
        //         the property will be a two-way binding
        //         the property values is BOTH "out going" and "in coming"

        [BindProperty]
        public double Num { get; set; }
        [BindProperty]
        public string? MassText { get; set; }
        [BindProperty]
        public int FavouriteCourse { get; set; } //using integer value from select

        public string FavouriteCourseNoValueOnOption { get; set; } //using string text from select

        public string FeedBack { get; set; } //one way property for messages , it has not incoming control

        // this is an example of you managing the collection on the form yourself
        //The list is a list of errors collected during your validation

        public List<string> ErrorList { get; set; } = new List<string>();
        public void OnGet()
        {
        }
        //the return datatype of void stays on the same page, no special action
        //at the end of the event method

        //public void OnPostControlProcessing()
        //{
        //    //FeedBack = $"Number value is {Num}"
        //    //    + $"  Mass text is {MassText}"
        //    //    + $"  Favourite course with value is {FavouriteCourse}"
        //    //    + $" Favourite course without value is {FavouriteCourseNoValueOnOption}";

        //    if (Num < 0)
        //    {
        //        // using ModelState
        //        ModelState.AddModelError("", $"Num value of {Num} cannot be negative");

        //        //managing your own errors
        //        ErrorList.Add($"Num value of {Num} cannot be negative");
        //    }



        //    if (string.IsNullOrWhiteSpace(MassText))
        //    {
        //        //using ModelState
        //        ModelState.AddModelError("", $"Comment not supplied");

        //        //managing your own errors
        //        ErrorList.Add($"Comment not supplied");
        //    }
        //    if (FavouriteCourse == 0)
        //    {
        //        //using ModelState
        //        ModelState.AddModelError("", $"You did not pick a favourite course");

        //        //managing your own errors
        //        ErrorList.Add($"You did not pick a favourite course");
        //    }
        //    //if (ErrorList.Count()==0)
        //    if (ModelState.IsValid)
        //    {
        //        FeedBack = "Your data was valid.";
        //    }
        //}
        public IActionResult OnPostRedirectPage()
        {
            //IActionResult requires the event to have a return statement with
            //some type of action
            // In this example the action is to redirect to the page supplied as the 
            //supllied parameter value
            //An alternative to using IActionresult to stay on the same page is to 
            //use return Page.
            return RedirectToPage("BasicEvents");
        }

        //Two returing 
        //void keeps you on the same page
        

        public IActionResult OnPostControlProcessing()
        {
            //FeedBack = $"Number value is {Num}"
            //    + $"  Mass text is {MassText}"
            //    + $"  Favourite course with value is {FavouriteCourse}"
            //    + $" Favourite course without value is {FavouriteCourseNoValueOnOption}";

            if (Num < 0)
            {
                // using ModelState
                ModelState.AddModelError("", $"Num value of {Num} cannot be negative");

                //managing your own errors
                ErrorList.Add($"Num value of {Num} cannot be negative");
            }

            

            if (string.IsNullOrWhiteSpace(MassText))
            {
                //using ModelState
                ModelState.AddModelError("", $"Comment not supplied");

                //managing your own errors
                ErrorList.Add($"Comment not supplied");
            }
            if (FavouriteCourse == 0)
            {
                //using ModelState
                ModelState.AddModelError("", $"You did not pick a favourite course");

                //managing your own errors
                ErrorList.Add($"You did not pick a favourite course");
            }
            //if (ErrorList.Count()==0)
            if (ModelState.IsValid)
            {
                FeedBack = "Your data was valid.";
            }
            return Page(); //this statement is require because we changed the return datatype
                           // from void to IActionResult
                           // the action is to stay on the same page 
        }
    }
}
