namespace OOPsReview
{
    public class Employment
    {
        private SupervisoryLevel _Level;
        private string _Title;
        private double _Years;

        public string Title
        {
            get { return _Title; }
            set {
                if (string.IsNullOrWhiteSpace(value)) 
                { 
                    throw new ArgumentNullException("Title is required");
                }
                
                _Title = value;
            }
        }

        public SupervisoryLevel Level
        {
            get { return _Level; }

            private set
            {
                // a private set means that the property can only be set
                // by code within the class definition
                // an advantage of doing this is increasing security on the field
                //as any change is under the control of the class definition

                //validate the value given as an enum is actually defined

                // a user of this class could send in an integer value that was
                // type casted as this enum datatype but have a non-defined value
                

                //to test for a defined enum value use Enum.IsDEfined(typeof(xxx),
                //where xxx is the name of the enum datatype

                if(!Enum.IsDefined(typeof(SupervisoryLevel),value))
                {
                    throw new ArgumentNullException($"Supervisory level is invalid:{value}");
                }
                _Level = value;
            }
        }
        // validate the years of the service in the employee position as a positive value.

        public double Years
        {
            get { return _Years; } // used on the right side of an assignment statement or in an expression
            set                    // used on th left side of an assignment statement
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _Years = value;
            }
        }

        //this property is an example of an auto-implemented property
        //there is no validation within the property
        //there is no private data member for this property
        // the system will generate an interal storage area for the data 
        // and handle the setting and getting from that storage area 
        // the private set means that the property will only be able to be 
        // set via a constructor or method
        // auto-implemented properties can have either a public or private set
        //using a public or private set is a design decision 

        public DateTime StartDate { get; private set; }

    }
}