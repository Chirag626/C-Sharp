// ============================================================
//       C# LINQ - COMPLETE REVISION FILE
//       For: Java Developer learning C#
//       Java Stream vs C# LINQ comparison
// ============================================================

using System;
using System.Collections.Generic;
using System.Linq;

class LINQ
{
    public static void Run()
    {
        var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var students = new List<Student_>
        {
            new Student_("Chirag", 85, "CSE"),
            new Student_("Amit",  92, "ECE"),
            new Student_("Sara",  78, "CSE"),
            new Student_("Raj",   95, "ECE"),
            new Student_("Priya", 60, "CSE"),
        };


        // ---------------------------------------------------
        // 1. WHERE — Filter karo
        // Java : .filter(n -> n % 2 == 0)
        // C#   : .Where(n => n % 2 == 0)
        // ---------------------------------------------------
        Console.WriteLine("===== 1. Where (Filter) =====");
        var evens       = numbers.Where(n => n % 2 == 0);
        var topStudents = students.Where(s => s._Marks > 80);

        Console.WriteLine(string.Join(", ", evens));                           // 2,4,6,8,10
        foreach (var s in topStudents) Console.WriteLine($"{s._Name}: {s._Marks}"); // Chirag, Amit, Raj
        Console.WriteLine();


        // ---------------------------------------------------
        // 2. SELECT — Transform karo
        // Java : .map(n -> n * 2)
        // C#   : .Select(n => n * 2)
        // ---------------------------------------------------
        Console.WriteLine("===== 2. Select (Map/Transform) =====");
        var doubled   = numbers.Select(n => n * 2);
        var names     = students.Select(s => s._Name);
        var name_Marks = students.Select(s => $"{s._Name}: {s._Marks}");

        Console.WriteLine(string.Join(", ", doubled));    // 2,4,6,8,10,12,14,16,18,20
        Console.WriteLine(string.Join(", ", names));      // Chirag,Amit,Sara,Raj,Priya
        foreach (var nm in name_Marks) Console.WriteLine(nm);
        Console.WriteLine();


        // ---------------------------------------------------
        // 3. ORDERBY / ORDERBYDESCENDING — Sort karo
        // Java : .sorted() / .sorted(Comparator.reverseOrder())
        // C#   : .OrderBy() / .OrderByDescending()
        // ---------------------------------------------------
        Console.WriteLine("===== 3. OrderBy (Sort) =====");
        var ascending  = numbers.OrderBy(n => n);
        var descending = numbers.OrderByDescending(n => n);
        var by_Marks    = students.OrderByDescending(s => s._Marks);

        Console.WriteLine(string.Join(", ", ascending));   // 1,2,3...10
        Console.WriteLine(string.Join(", ", descending));  // 10,9,8...1
        foreach (var s in by_Marks) Console.WriteLine($"{s._Name}: {s._Marks}");
        Console.WriteLine();


        // ---------------------------------------------------
        // 4. FIRST / FIRSTORDEFAULT — Pehla element lo
        // Java : .findFirst().get()
        // C#   : .First() / .FirstOrDefault()
        // FirstOrDefault — null return karta hai agar nahi mila
        // ---------------------------------------------------
        Console.WriteLine("===== 4. First / FirstOrDefault ====="); // first element ya default value (null) return karta hai. Agar condition match nahi karti toh First() exception throw karega, jabki FirstOrDefault() null return karega.
        var firstEven   = numbers.First(n => n % 2 == 0);           // 2
        var firstTopper = students.FirstOrDefault(s => s._Marks > 90); // Amit
        var notFound    = students.FirstOrDefault(s => s._Marks > 99); // null

        Console.WriteLine(firstEven);
        Console.WriteLine(firstTopper?._Name ?? "Not found");   // Amit
        Console.WriteLine(notFound?._Name    ?? "Not found");   // Not found
        Console.WriteLine();


        // ---------------------------------------------------
        // 5. COUNT — Count karo
        // Java : .count()
        // C#   : .Count()
        // ---------------------------------------------------
        Console.WriteLine("===== 5. Count =====");
        var totalStudents = students.Count();
        var cseStudents   = students.Count(s => s._Branch == "CSE");

        Console.WriteLine($"Total   : {totalStudents}");  // 5
        Console.WriteLine($"CSE     : {cseStudents}");    // 3
        Console.WriteLine();


        // ---------------------------------------------------
        // 6. SUM / MIN / MAX / AVERAGE — Aggregate karo
        // Java : .reduce() — manually karna padta tha
        // C#   : Direct methods available hain!
        // ---------------------------------------------------
        Console.WriteLine("===== 6. Sum / Min / Max / Average =====");
        var sum     = numbers.Sum();
        var min     = numbers.Min();
        var max     = numbers.Max();
        var average = numbers.Average();
        var total_Marks = students.Sum(s => s._Marks);
        var avg_Marks   = students.Average(s => s._Marks);

        Console.WriteLine($"Sum    : {sum}");          // 55
        Console.WriteLine($"Min    : {min}");          // 1
        Console.WriteLine($"Max    : {max}");          // 10
        Console.WriteLine($"Avg    : {average}");      // 5.5
        Console.WriteLine($"Total _Marks : {total_Marks}");
        Console.WriteLine($"Avg _Marks   : {avg_Marks}");
        Console.WriteLine();


        // ---------------------------------------------------
        // 7. ANY / ALL — Condition check karo
        // Java : .anyMatch() / .allMatch()
        // C#   : .Any() / .All()
        // ---------------------------------------------------
        Console.WriteLine("===== 7. Any / All =====");
        var anyPassed  = students.Any(s => s._Marks > 90);   // Koi ek bhi pass?
        var allPassed  = students.All(s => s._Marks > 50);   // Sab pass?
        var noneBelow  = !students.Any(s => s._Marks < 50);  // Koi fail nahi?

        Console.WriteLine($"Any above 90 : {anyPassed}");  // True
        Console.WriteLine($"All above 50 : {allPassed}");  // True
        Console.WriteLine($"None below 50: {noneBelow}");  // True
        Console.WriteLine();


        // ---------------------------------------------------
        // 8. GROUPBY — Group karo
        // Java : .collect(Collectors.groupingBy())
        // C#   : .GroupBy() — bahut simple!
        // ---------------------------------------------------
        Console.WriteLine("===== 8. GroupBy =====");
        var byBranch = students.GroupBy(s => s._Branch);

        foreach (var group in byBranch)
        {
            Console.WriteLine($"Branch: {group.Key}");
            foreach (var s in group)
                Console.WriteLine($"  {s._Name}: {s._Marks}");
        }
        Console.WriteLine();


        // ---------------------------------------------------
        // 9. SELECTMANY — Nested list ko flat karo
        // Java : .flatMap()
        // C#   : .SelectMany()
        // ---------------------------------------------------
        Console.WriteLine("===== 9. SelectMany (FlatMap) =====");
        var classes = new List<List<string>> // these are the lists of list.
        {
            new List<string> { "Chirag", "Amit" },
            new List<string> { "Sara", "Raj"   },
            new List<string> { "Priya"          }
        };

// SelectMany nested list ko ek flat list mein convert karta hai — jaise saari classes ke students ko ek hi register mein likhna!
        var allStudents = classes.SelectMany(c => c);
        Console.WriteLine(string.Join(", ", allStudents));  // Chirag,Amit,Sara,Raj,Priya
        Console.WriteLine();


        // ---------------------------------------------------
        // 10. CHAINING — Multiple operations ek saath
        // Java : stream().filter().map().sorted().collect()
        // C#   : .Where().Select().OrderBy().ToList()
        // ---------------------------------------------------
        Console.WriteLine("===== 10. Chaining =====");
        var result = students
            .Where(s => s._Branch == "CSE")          // CSE students
            .Where(s => s._Marks > 70)               // 70 se zyada _Marks
            .OrderByDescending(s => s._Marks)        // _Marks se sort
            .Select(s => $"{s._Name}: {s._Marks}")    // Name: _Marks format
            .ToList();                               // List mein convert

        foreach (var r in result) Console.WriteLine(r);
        Console.WriteLine();


        // ---------------------------------------------------
        // 11. QUERY SYNTAX — SQL jaisa (Java mein nahi hota!)
        // C# mein dono ways valid hain
        // APIs mein Method Syntax zyada use hota hai
        // ---------------------------------------------------
        Console.WriteLine("===== 11. Query Syntax (SQL Style) =====");

        // Method Syntax
        var methodSyntax = students
            .Where(s => s._Marks > 80)
            .OrderBy(s => s._Name);

        // Query Syntax — same result!
        var querySyntax = from s in students
                          where s._Marks > 80
                          orderby s._Name
                          select s;

        foreach (var s in querySyntax)
            Console.WriteLine($"{s._Name}: {s._Marks}");
        Console.WriteLine();


        // ---------------------------------------------------
        // 12. TOLIST / TOARRAY / TODICTIONARY — Convert karo
        // Java : .collect(Collectors.toList())
        // C#   : .ToList() / .ToArray() / .ToDictionary()
        // ---------------------------------------------------
        Console.WriteLine("===== 12. ToList / ToArray / ToDictionary =====");
        var list   = numbers.Where(n => n > 5).ToList();
        var array  = numbers.Where(n => n > 5).ToArray();
        var dict   = students.ToDictionary(s => s._Name, s => s._Marks);

        Console.WriteLine(string.Join(", ", list));   // 6,7,8,9,10
        Console.WriteLine(string.Join(", ", array));  // 6,7,8,9,10
        foreach (var kvp in dict)
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
    }
}


// Student model
class Student_
{
    public string _Name   { get; set; }
    public int    _Marks  { get; set; }
    public string _Branch { get; set; }

    public Student_(string name, int marks, string branch)
    {
        _Name   = name;
        _Marks  = marks;
        _Branch = branch;
    }
}

// -------------------------------------------------------
// JAVA STREAM vs C# LINQ
// -------------------------------------------------------
// Java                              | C#
// ----------------------------------|--------------------
// .filter(n -> n > 5)               | .Where(n => n > 5)
// .map(n -> n * 2)                  | .Select(n => n * 2)
// .sorted()                         | .OrderBy(n => n)
// .findFirst().get()                | .First()
// .count()                          | .Count()
// .reduce(0, Integer::sum)          | .Sum()
// .anyMatch()                       | .Any()
// .allMatch()                       | .All()
// .flatMap()                        | .SelectMany()
// .collect(Collectors.groupingBy()) | .GroupBy()
// .collect(Collectors.toList())     | .ToList()
// No SQL style                      | Query syntax ✅
// Stream ek baar use hoti hai       | LINQ reusable ✅
// -------------------------------------------------------