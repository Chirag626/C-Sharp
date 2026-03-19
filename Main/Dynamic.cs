// Dynamic return type ka matlab hai ki method alag alag types return kar sakta hai based on the input parameters. 
// Iska use tab hota hai jab hume ek hi method se different types of data return karna hota hai without creating multiple overloaded methods.

class Dynamic 
{


    // -------------------------------------------------------
    // dynamic return type + params
    // - dynamic matlab compiler TYPE CHECK nahi karta compile time pe
    // - Runtime pe decide hota hai actual type kya hai
    // - Java mein 'Object' return karte the — yeh us jaisa hai
    // - less usage in development, but useful in certain scenarios like when working with JSON, XML, or when you want a method to be flexible with return types based on input.
    // -------------------------------------------------------
    public static dynamic GetValue(params dynamic[] values)
    {
        // Sabse pehle check karo — sab ek hi type ke hain?
        bool allSameType = values.All(v => v.GetType() == values[0].GetType());

        if (!allSameType)
        {
            return "Error: Mixed types pass kiye hain!";
        }

        // Pehla value dekho — uske type ke hisaab se kaam karo
        if (values[0] is int)
        {
            int sum = 0;
            foreach (var v in values) sum += v;
            return sum;  // int return karega
        }
        else if (values[0] is string)
        {
            return string.Join(" ", values);  // string return karega
        }
        else if (values[0] is double)
        {
            double sum = 0;
            foreach (var v in values) sum += v;
            return sum;  // double return karega
        }
        else if (values[0] is bool)
        {
            bool result = true;
            foreach (var v in values) result = result && v;
            return result; // bool return karega
        }
        else if (values[0] is char)
        {
            return new string(values.Select(v => (char)v).ToArray()); // char array ko string mein convert karke return karega
        }
        else if (values[0] is decimal)
        {
            decimal sum = 0;
            foreach (var v in values) sum += v;
            return sum; // decimal return karega
        }
        else
        {
            return "Unsupported type"; // agar type match nahi karta toh ek message return karega
        }

    }

}