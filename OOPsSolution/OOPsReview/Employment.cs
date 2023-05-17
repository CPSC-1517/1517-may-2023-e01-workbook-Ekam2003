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
                //if (value < 0) // using a utility generic method to do this test
                if(!Utilities.IsZeroOrPositive(value))
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

        // Constructor

        // the purpose of a constructor is to create an instance of your class
        //in a known state.
        //does  a class definition need a constructor? No
        // if a class definition does not have a constructor then the system
        //will create the instance and assign the system default value to the data member
        // and / or implemented property
        //if you have no constructor the common phrase is "using a system constructor"

        //IF YOU CODE A CONSTRUCTOR  IN YPUR CLASS YOU ARE RESPONSIBLE FOR ANY AND ALL CONSTRUCTIONS 
        //FOR THE CLASS!!!

        //default constructor
        // you can apply your own literal values for your data members and/or auto-implemented properties
        //that diifer from the system default values
        //why? you may have data that is validated and using the system default values would cause an
        //exception

        public Employment()
        {
            //this constructor will be used on creating an instance using
            //Employment myInstance = new Employment();
            //A practice that I Personally use is to avoid referring my data members directly
            //specially if the property contains validation

            Title = "Unknown";
            Level = SupervisoryLevel.TeamMwmber;
            StartDate = DateTime.Today;
            // optionally one could set years to zero, but that is the system default
            // value for a numeric, therefore one does not need to assign a value
            //unless you wish to do
        }
        //greedy constructor
        // a greedy constructor is one that accepts a parameter list of values to
        // assign to your instance data on creation of the instance
        //generally your greedy constructor contains a parameter on the signature
        //for each data member you have in your class defintion

        //all default paraameters must appear after non-default parametera in your parameter list
        // in this example, we will use Years as an optional parameters

    public Employment(string title, SupervisoryLevel level,
                        DateTime startdate, double years =0.0)
        {
            Title = title;
            Level = level;
            Years = years;
            //this example to demonstate where you can place validation for
            // properties have are auto-implemented
            //validation start date must not exist in the future
            // validation can be done anywhere in your class
            //since the property is auto-implemented and has a private set
            //validation can be done in the constructor or a method
            //that alters the property value
            //If the validation is done in the property, It would not be an 
            //auto-implemented property but a friendly - implemented property
            //.Today has a time of 00:00:00 AM
            //.Now has a specific time of day at execution 18:47:256 PM
            //by using the .Today.AddDAys(1) you cover all times on a specific date
            if(startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startdate} is in the future");

            }
            StartDate = startdate;
        }
    }
}