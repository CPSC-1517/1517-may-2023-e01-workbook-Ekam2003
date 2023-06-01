using FluentAssertions;
using OOPsReview;
namespace TDDUnitTestDemo
{
    public class Person_Should
    {
        public Person Make_SUT_Instance()
        {
            string firstname = "ekamjot";
            string lastname = "kaur";
            Residence address = new Residence(123, "Maple St.", "AB", "T6Y7U8");
            Person me = new Person(firstname,lastname,null);
            return me;

        }
        #region Valid Data
        //Atribute title 
        //Fact which does one test and is usually setup and coded within the test
        // Theory which allow for multiple test data stream applied to the same test
        [Fact]
        public void Create_an_Instance_Using_Default_Constructor()
        {
            //Arrange (setup)
            string expectedfirstname = "unknown";
            string expectedlastname = "unknown";

            //Act (execution) (sut subject under test)
            Person sut = new Person();

            //Assert (testing of the action)
            sut.FirstName.Should().Be(expectedfirstname);
            sut.LastName.Should().Be(expectedlastname);
            sut.Address.Should().BeNull();
            sut.EmploymentPositions.Count().Should().Be(0);
        }

        [Fact]
        public void Create_an_Instance_With_First_And_Last_Name_Residence_With_NO__List_Of_Employment()
        {
            //Arrange (setup)
            string firstname = "Don";
            string lastname = "Welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";


            //Act (execution) (sut subject under test)
            Person sut = new Person(firstname, lastname, address, null);

            //Assert (testing of the action)
            sut.FirstName.Should().Be(firstname);
            sut.LastName.Should().Be(lastname);
            sut.Address.ToString().Should().Be(expectedaddress);
            sut.EmploymentPositions.Count().Should().Be(0);
        }


        [Fact]
        public void Change_FirstName_To_New_Name()
        {
            //Arrange (setup)
            Person me = Make_SUT_Instance();
            string firstname = "don";
            string lastname = "welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstname, lastname, address, null);

            string expectedfirstname = "bob";

            // Act
            me.FirstName = expectedfirstname;

            // Assert
            me.FirstName.Should().Be(expectedfirstname);

        }

        [Fact]
        public void Change_LastName_To_New_Name()
        {
            //Arrange (setup)
            string firstname = "don";
            string lastname = "welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstname, lastname, address, null);

            string expectedlastname = "smith";

            // Act
            me.LastName = expectedlastname;

            // Assert
            me.LastName.Should().Be(expectedlastname);

        }

        [Fact]
        public void Change_Both_First_And_Last_Name_To_New_Name()
        {
            //Arrange (setup)
            string firstname = "don";
            string lastname = "welch";
            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            Person me = new Person(firstname, lastname, address, null);
            string expectedfirstname = "pat";
            string expectedlastname = "smith";

            // Act
            me.ChangeName(expectedfirstname, expectedlastname);

            // Assert
            me.FirstName.Should().Be(expectedfirstname);
            me.LastName.Should().Be(expectedlastname);

        }
        [Fact]

        public void Return_The_Number_Of_Employment_Instance_For_New_Person()
        {
            //Arange (set uo)
            //no emloyment instances
            Person sut = Make_SUT_Instance();

            //Act (excution)
            int actual = sut.NumberOfEmployment;

            //Assert (testing of the action)
            actual.Should().Be(0);
        }

        [Fact]

        public void Add_First_Employment_Instance()
        {
            //Arange (set uo)
            //no emloyment instances
            Person sut = Make_SUT_Instance();
            int expectednumberofemployment = 1;
            Employment employment = new Employment("TDD member", SupervisoryLevel.TeamMember, new DateTime(2018, 03, 10));

            //Act (excution)
            sut.AddEmployment(employment);



            //Assert (testing of the action)
            sut.NumberOfEmployment.Should().Be(expectednumberofemployment);

        }

        public void Add_Another_Employment_Instance()
        {
            //Arange (set uo)
            //no emloyment instances
            Person sut = Make_SUT_Instance();
            int expectednumberofemployment = 1;
            Employment employment = new Employment("TDD member", SupervisoryLevel.TeamMember, new DateTime(2018, 03, 10));
            
            //Act (excution)
            sut.AddEmployment(employment);



            //Assert (testing of the action)
            sut.NumberOfEmployment.Should().Be(expectednumberofemployment);

        }
        #endregion



    }
}