// using System;

// class Students
// {
//     public string name;
//     public int rollno;
//     public decimal marks;

//     // Parameterized Constructor
//     public Students(string name, int rollno, decimal marks)
//     {
//         this.name = name;
//         this.rollno = rollno;
//         this.marks = marks;
//     }

//     // Default Constructor
//     public Students()
//     {
//     }
// }

// class Class_Objects
// {
//     public static void Main(string[] __)
//     {

//         // 1️. Object Initializer Syntax
//         Students std = new Students
//         {
//             name = "Rianchal",
//             rollno = 23,
//             marks = 99.99m
//         };

//         /* is internally similar to object initializer in C# :

//         Students std = new Students(); // 2. Normal Object Creation
//         std.name = "Rianchal";
//         std.rollno = 23;
//         std.marks = 99.99m;
//         */




//         // 3️. Using Parameterized Constructor
//         Students std3 = new Students("Rahul", 15, 88.8m);


//         // 4️. Anonymous Object (no class required)
//         var tempStudent = new
//         {
//             name = "Temporary",
//             rollno = 99,
//             marks = 50.0m
//         };


//         // 5️. Creating Object using Activator (Reflection way)
//         Students std4 = (Students)Activator.CreateInstance(typeof(Students));
//         std4.name = "Dynamic";
//         std4.rollno = 50;
//         std4.marks = 70.0m;


//         // Printing values to verify objects
//         Console.WriteLine(std.name + " " + std.rollno + " " + std.marks);
//         Console.WriteLine(std3.name + " " + std3.rollno + " " + std3.marks);
//         Console.WriteLine(tempStudent.name + " " + tempStudent.rollno + " " + tempStudent.marks);
//         Console.WriteLine(std4.name + " " + std4.rollno + " " + std4.marks);
//     }
// }