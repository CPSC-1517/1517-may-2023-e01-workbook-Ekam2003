using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models; // the namespace of your source code (namespace is WebApp.Models)
                        // i am telling where to find student model


namespace WebApp.Pages.Samples
{
    public class StudentMarkReportModel : PageModel
    {
        public string Feedback { get; set; }
        public bool HasFeedback { get { return !string.IsNullOrWhiteSpace(Feedback); }}

        // to detrmine if we have data coming in 
        public List<StudentMarks> studentMarks { get; set; } = new List<StudentMarks>();
    
        public void OnGet()
        {

        }
    }
}
