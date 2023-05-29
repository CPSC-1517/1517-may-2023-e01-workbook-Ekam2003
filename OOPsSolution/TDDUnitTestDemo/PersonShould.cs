using FluentAssertions;
using OOPsReview;
namespace TDDUnitTestDemo
{
    public class Person_Should
    {
        //Atribute title 
        //Fact which does one test and is usually setup and coded within the test
        // Theory which allow for multiple test data stream applied to the same test
        [Fact]
        public void Create_an_Instance_with_First_Last_Name()
        {
            //Arrange (setup)
            string firstname = "Ekamjot";
            string lastname = "Kaur";

            Residence address = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
            string expectedaddress = "123,Maple St.,Edmonton,AB,T6Y7U8";
            Person me = new Person(firstname, lastname, address, null);

            string expectedfirstname = "bob";

            //Act (execution) (sut subject under test)
            me.FirstName = expectedfirstname;

            //Assert(testing of the action)
            me.FirstName.Should().Be(expectedfirstname);

        }
    }