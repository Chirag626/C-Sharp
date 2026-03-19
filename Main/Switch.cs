class Switch
{
    public static void Run()
    {
        string day = "Monday";
        // switch statement  : one of the most common control flow statements in programming languages, including C#. It allows you to execute different blocks of code based on the value of a variable or expression. The switch statement is often used as an alternative to multiple if-else statements when you have a variable that can take on multiple discrete values.
        switch (day)
        {
            case "Monday":
                Console.WriteLine($"Normal Way : Start of week , day : {day}");
                break;
        }


        // another way in C# 8.0 and later : switch expression
        string day1 = "Tuesday";
        string message = day1 switch 
        {
            "Monday" => "Start of week",
            "Tuesday" => "Second day",
            "Wednesday" => "Midweek",
            "Thursday" => "Almost weekend",
            "Friday" => "Last day of work",
            _ => "Weekend"
        };
        Console.WriteLine($"new way : {message}, day : {day1}");
    }
}