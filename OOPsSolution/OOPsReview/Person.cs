﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Person
    {
        private string _FirstName;
        private string _LastName;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Residence Address { get; set; }
        public List<Employment> EmploymentPositions { get; set; } = new List<Employment>();

        public Person(string firstname, string lastname, Residence address, List<Employment> employmentpositions)
        {
            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw new ArgumentNullException("first name is requried");
            }
            if (string.IsNullOrWhiteSpace(lastname))
            {
                throw new ArgumentNullException("last name is requried");
            }
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            if (employmentpositions != null)
            {
                EmploymentPositions = employmentpositions;  //store the supplied list of employments
            }

        }

        public Person()
        {
            FirstName = "unknown";
            LastName = "unknown";

        }
    }
}
