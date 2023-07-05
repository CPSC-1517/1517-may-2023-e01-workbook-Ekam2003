using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            //the student mark report will be loaded as the page comes up for the
            // first time.
            //therefore, all code will be in OnGet() event

            //get the path to your web app root

            //use relative addressing to access the data file within your web site
            //using this technique will allow us to skip the injection dependency of IWebHostEnvironment
            // it is important that your practice good addressing by including the .(dot) indicaitng
            //the current folder which in case is the top of the website.
           

            string filePathName = @".\Data\StudentMarks.txt";

            //userdata will contain all of the data file records in an array
            Array userdata = null;

            //to Parse the csv record into an instance of our class, I have setup
            // a reusable variable of hold an instance of the class.
            StudentMarks markRecord = null;
            try
            {
                // There is a file class in PageModel
                // to use the File class of System.IO you MUST fully qualify your
                // reference to the class when coding the read method.
                userdata = System.IO.File.ReadAllLines(filePathName);

                //process each record in the record array
                // each record could possibly throw an exception while Parsing
                // you should process all possible records while reporting records
                // that could not ne parsed

                foreach(string line in userdata)
                {
                    try
                    {
                        markRecord = StudentMarks.Parse(line);
                        if(markRecord != null)
                        {
                            studentMarks.Add(markRecord);
                        }
                    }
                    catch(FormatException ex)
                    {
                        ModelState.AddModelError("Record Format ", $"{GetInnerException(ex).Message}:record{line}");
                    }

                    catch (Exception ex)
                    {
                        ModelState.AddModelError("System Error", $"{GetInnerException(ex).Message}:record{line}");
                    }
                }

                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("File Data Error", $"{GetInnerException(ex).Message}");
            }

        }
        public Exception GetInnerException(Exception ex)
        {
            while(ex.InnerException !=null)
            {
                ex = ex.InnerException;
            }

            return ex;
        }
    
}
}
