﻿using OOPsReview;

Console.WriteLine("Hello, World!");

Residence myHome = new Residence(123, "Maple St.", "Edmonton", "AB", "T6Y7U8");
Console.WriteLine(myHome.ToString());

//can I change a value in the record instance? NO!
//myHome.Number = 321;

//to alter a value in the record instance you MUST craete a new instance
myHome = new Residence(321, "Maple St.", "Edmonton", "AB", "T6Y7U8");
Console.WriteLine(myHome.ToString());
