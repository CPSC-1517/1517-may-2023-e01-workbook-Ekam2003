using OOPsReview;
using System.Linq;

Console.WriteLine("Hello, World!");

Residence myHome = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
Console.WriteLine(myHome.ToString());

//can I change a value in the record instance? NO!
//myHome.Number = 321;

//to alter a value in the record instance you MUST craete a new instance
myHome = new Residence(321, "Maple St.", "Edmonton", "AB", "T6Y7U8");
Console.WriteLine(myHome.ToString());

//example of refactoring
// Refactoring is the process of restructing code, while not
// changing it original functionality. The goal of refactoring
// is to improve internal code by making small changes without altering
// the code external behaviour

//original code

bool flag = false;
if (myHome.Province.ToLower() =="ab")
{
    flag = true;
}
if (myHome.Province.ToLower() == "bc")
{
    flag = true;
}
if (myHome.Province.ToLower() == "sk")
{
    flag = true;
}
if (myHome.Province.ToLower() == "mn")
{
    flag = true;
}

if (myHome.Province.ToLower() == "ab" ||
    myHome.Province.ToLower() == "bc"

// refactor using a switch statement
switch (myHome.Province.ToLower())
{
    case "ab":
    case "bc":
    case "sk":
    case "mn":
        {
            flag = "true";
            break;
        }
    default:
        {
            flag=false;
        }

}
