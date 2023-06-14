using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Employment
    {

     /*** DATA MEMBERS FOR CLASS  ***/

        private SupervisoryLevel _Level;
        private string _Title; // Sometimes it shows green Line under string because eventually
                               // we have to define whether it is nullable or non-nullable string 
                               // string? means it  is a nullable string.
                               // now default of string is null.
        private double _Years;


        /***  PROPERTIES  ***/

        // Properties are asscociated with a single piece of data.

        // Properties can be implemented by:
        //  a) fully implemented properties
        //  b) auto implemented properties

            // Fully implemented property usually has additional logic to execute for
            //     the control over the data; such as validation
            // Fully implemented properties will have a declared data member to store the data 
         
            // Auto implemented properties do not have additional logic
            // Auto implemented properties do not have a declared data member to
            //     store the data instead the o/s will create on the property's behave a
            //     storage area that is accessable ONLY by using the property

        // a property will always have an accessor (get)
        // a property may or may not have a mutator
        //     no mutator the property is consider "read-only" and is usually
        //         returning a computed value:
        //         example a FullName  made up of 2 pieces of data FirstName and Lastname
        //      in this it is just concatenating the data

        //     has a mutator the property will at some point save the data to storage
        //     the mutator may be public (default) or private
        //          public: accessable by outside users of the class
        //          private: accessable ONLY within the class
        //  a property DOES NOT have ANY declare incoming parameter list!!!!!

        // Property: Title
        // Validation : there must be a character string
        public string Title
        {
            //referred to as the accessor
            //returns the string associated with this property
            get { return _Title; }

            //referred to as the mutator
            //it is within the set that the validation of the data
            //  is done to determine if the data is acceptable
            //by default set is public
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is required");
                }
                //else
                //{
                        _Title = value;
                // }
            }
        }

        public SupervisoryLevel Level
        {
            get { return _Level; }

            private set
            {
                //  A private set means that the property can only be set by code 
                //   within the class definition (outside user cannot do this)        

                // An advantage of doing this is increasing security on the field
                //     as any change is under the control of the class definition  

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
                    throw new ArgumentOutOfRangeException(value.ToString());
                }
                _Years = value; // it is not preffered to write it as value = _Years;
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
        // in a known state.

        // does  a class definition need a constructor? No

        // if a class definition does not have a constructor then the system
        // will create the instance and assign the system default value to the data member
        // and / or implemented property

        // if you have no constructor the common phrase is "using a system constructor"

        // IF YOU CODE A CONSTRUCTOR  IN Y0UR CLASS YOU ARE RESPONSIBLE FOR ANY AND ALL CONSTRUCTIONS 
        //                                  FOR THE CLASS!!!

        // DEFAULT CONSTRUCTOR:
        // you can apply your own literal values for your data members and/or auto-implemented properties
        // that diifer from the system default values
        // why? you may have data that is validated and using the system default values would cause an
        // exception

        public Employment()
        {
            //this constructor will be used on creating an instance using
            //Employment myInstance = new Employment();
            //A practice that I Personally use is to avoid referring my data members directly
            //specially if the property contains validation

            Title = "Unknown";
            Level = SupervisoryLevel.TeamMember;
            StartDate = DateTime.Today;
            // optionally one could set years to zero, but that is the system default
            // value for a numeric, therefore one does not need to assign a value
            //unless you wish to do
        }
        // GREEDY CONSTRUCTOR
        // a greedy constructor is one that accepts a parameter list of values to
        // assign to your instance data on creation of the instance
        // generally your greedy constructor contains a parameter on the signature
        // for each data member you have in your class defintion

        // all default parameters must appear after non-default parameters in your parameter list
        // in this example, we will use Years as an default parameters

        [JsonConstructor]
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
            if (years > 0.0)
            {
                Years = (double)years;
            }
            else
            {
                TimeSpan span = DateTime.Now - StartDate;
                Years = Math.Round((span.Days / 365.25), 1);
            }
        }

        //Behaviours (a.k.a. methods)
        //a method consists of a header (accesslevel, rdt(return data type), methodname, ([list of parameters])
        //                     a coding block     { ....... }

        public void SetEmploymentResponsiblityLevel(SupervisoryLevel level)
        {
            //the property has a private set
            //therefore the only ways to assign a value to the Property
            //   is either: via the constructor are creation time
            //          or: via a public method within the class
            
            //What about validation the value?
            //Validation can be done in multiple places
            //   a) can it be done in this method: Yes
            //   b) can it be done in the property: Yes if property is  fully implemented
            Level = level;
        }

        public void CorrectStartDate(DateTime startdate)
        {
            //the StartDate property is an auto implemented property
            //The StartDate property has NO validation code
            //You need to do any validation on the incoming value
            //  wherever you plan to alter the existing value in the class
            if (startdate >= DateTime.Today.AddDays(1))
            {
                throw new ArgumentException($"The start date {startdate} is in the future");
            }
            StartDate = startdate;
        }

        public double UpdateCurrentEmploymentYearsExperince()
        {
            TimeSpan span = DateTime.Now - StartDate;
            Years = Math.Round((span.Days / 365.25), 1);
            return Years;
        }

        public override string ToString()
        {
            return $"{Title},{Level},{StartDate.ToString("MMM dd, yyyy")},{Years}";
        }

        public static Employment Parse(string str)
        {
            //Parsing attempts to change the contents of a string into another datatype
            // example:   string 55  --> int x = int.Parse(string); success
            //            string bob --> int x = int.Parse(string); failed with an exception message

            //text is a string of csv values (comma separate values)
            //separate the string of values into individual strings
            //  using .Split(delimiter)
            //a delimiter is normally some type of character
            //for a csv, the delimiter is a comma (',')
            //the .Split() method returns an array of strings
            //test the array size to determine if sufficient "parts" have be supplied
            //if not, throw a FormatException
            //if sufficient parts have been supplied you can continue your logic in 
            //  creating the instance of intent

            string[] pieces = str.Split(',');
            if (pieces.Length != 4)
            {
                throw new FormatException($"Record {str} not in the expected format.");
            }

            //if sufficient parts have been supplied you can continue your logic in 
            //  creating the instance of intent

            //create a new instance using the greedy constructor

            return new Employment(pieces[0],
                                  (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), pieces[1]),
                                  DateTime.Parse(pieces[2]),
                                  double.Parse(pieces[3])
                                  );
        }

        public static bool TryParse(string str, out Employment employment)
        {
            //use this method to check to see if the parse could actually be done
            //the result of the attempt is
            //  a) true and the converted string value is placed into the out going variable
            //  b) false and no conversion of the string is done
            //     (optional,
            //          you can include a try/catch within the method to capture (error handling) the 
            //          Parse error so that it does not return to the program
            //          and your false value will have a meaning)

            //example   if (xxxx.TryParse(string, out myNumericvalue)) { ..... } else { .... }

            bool result = true; //assume success
            employment = null;
            try
            {
                employment = Parse(str);
            }
            catch (FormatException ex)
            {
                result = false; //indicates failure
            }
            return result;

            //alternative
            //if you wish to have the FormatException passed on to the calling coding
            //  the DO NOT include the try/catch within your TryParse method

            //result = false;
            //if (string.IsNullOrWhiteSpace(str))
            //{
            //    throw new ArgumentNullException("No value was supplied for parsing");
            //}
            //employment = null;
            //employment = Parse(str);
            //return true;

        }
    }
}
      