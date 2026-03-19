#pragma warning disable
using System;

// ============================================================
//       EXCEPTION HANDLING - COMPLETE REVISION FILE
//       For: Java Developer learning C#
// ============================================================

// ---------------------------------------------------
// CUSTOM EXCEPTIONS 
// Same as Java — Exception class se inherit karo
// ---------------------------------------------------

class InvalidAgeException : Exception
{
    public int Age { get; }

    public InvalidAgeException(int age)
        : base($"Invalid age: {age}. Age must be between 0 and 150.")
    {
        Age = age;
    }
}

class InsufficientBalanceException : Exception
{
    public decimal Balance { get; }
    public decimal Amount { get; }

    public InsufficientBalanceException(decimal balance, decimal amount)
        : base($"Insufficient balance. Available: {balance}, Requested: {amount}")
    {
        Balance = balance;
        Amount  = amount;
    }
}


class ExceptionHandling
{
    public static void Run()
    {
        // ---------------------------------------------------
        // 1. BASIC TRY-CATCH-FINALLY
        // Same as Java
        // ---------------------------------------------------
        Console.WriteLine("===== 1. Basic Try-Catch-Finally =====");
        try
        {
            int a = 10;
            int b = 0;
            int result = a / b;             // DivideByZeroException aayegi
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
        }
        finally
        {
            // Finally hamesha chalta hai — exception aaye ya na aaye
            // Same as Java
            Console.WriteLine("Finally block — Always runs \n");
        }


        // ---------------------------------------------------
        // 2. MULTIPLE CATCH BLOCKS
        // Same as Java — specific se generic ki taraf
        // ---------------------------------------------------
        Console.WriteLine("===== 2. Multiple Catch Blocks =====");
        try
        {
            string str = null;
            Console.WriteLine(str.Length);  // NullReferenceException
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine($"Null Error: {ex.Message}");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine($"Index Error: {ex.Message}");
        }
        catch (Exception ex)                // Sabse last mein — generic catch
        {
            Console.WriteLine($"General Error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Cleanup done\n");
        }


        // ---------------------------------------------------
        // 3. THROW
        // Same as Java — exception manually throw karo
        // ---------------------------------------------------
        Console.WriteLine("===== 3. Throw =====");
        try
        {
            ValidateAge(-5);
        }
        catch (InvalidAgeException ex) // this is a custom exception we created above.
        {
            Console.WriteLine($"Caught Custom Exception: {ex.Message}");
            Console.WriteLine($"Invalid Age was: {ex.Age}\n");
        }


        // ---------------------------------------------------
        // 4. RETHROW — ex vs throw
        // Java mein sirf 'throw ex' tha
        // C# mein 'throw' alag hai — stack trace preserve hoti hai
        // ---------------------------------------------------
        Console.WriteLine("===== 4. Rethrow =====");
        try
        {
            RethrowExample();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Rethrown Exception: {ex.Message}\n");
        }


        // ---------------------------------------------------
        // 5. WHEN KEYWORD (Java mein nahi hota!)
        // Catch block pe condition laga sakte ho
        // ---------------------------------------------------
        Console.WriteLine("===== 5. When Keyword =====");
        try
        {
            throw new ArgumentException("Value is negative");
        }
        catch (ArgumentException ex) when (ex.Message.Contains("negative"))
        {
            Console.WriteLine($"Specifically negative error: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Some other ArgumentException: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("When example done\n");
        }


        // ---------------------------------------------------
        // 6. CUSTOM EXCEPTION
        // Same as Java — apni exception class banao
        // ---------------------------------------------------
        Console.WriteLine("===== 6. Custom Exception =====");
        try
        {
            Withdraw(1000, 5000);
        }
        catch (InsufficientBalanceException ex)
        {
            Console.WriteLine($"Caught: {ex.Message}");
            Console.WriteLine($"Available: {ex.Balance}, Requested: {ex.Amount}\n");
        }


        // ---------------------------------------------------
        // 7. NESTED TRY-CATCH
        // Same as Java
        // ---------------------------------------------------
        Console.WriteLine("===== 7. Nested Try-Catch =====");
        try
        {
            try
            {
                int[] arr = new int[3];
                arr[10] = 5;                // IndexOutOfRangeException
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Inner Catch: {ex.Message}");
                throw new Exception("Wrapped Exception", ex);  // Inner exception wrap karo
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Outer Catch: {ex.Message}");
            Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}\n");  // ?. — null safe
        }


        // ---------------------------------------------------
        // 8. EXCEPTION FILTERS — Real world use
        // when keyword ka practical example
        // ---------------------------------------------------
        Console.WriteLine("===== 8. Exception Filters =====");
        int[] statusCodes = { 404, 500, 403 };

        foreach (var code in statusCodes)
        {
            try
            {
                HandleStatusCode(code);
            }
            catch (Exception ex) when (ex.Message.Contains("404"))
            {
                Console.WriteLine($"Not Found Error: {ex.Message}");
            }
            catch (Exception ex) when (ex.Message.Contains("500"))
            {
                Console.WriteLine($"Server Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Other Error: {ex.Message}");
            }
        }
    }


    // ---------------------------------------------------
    // HELPER METHODS
    // ---------------------------------------------------

    // throw — Custom exception throw karna
    static void ValidateAge(int age)
    {
        if (age < 0 || age > 150)
            throw new InvalidAgeException(age);

        Console.WriteLine($"Valid age: {age}");
    }

    // Rethrow — 2 tarike
    static void RethrowExample()
    {
        try
        {
            throw new Exception("Original Exception");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Logging: {ex.Message}");

            // throw ex;  // ❌ Stack trace reset ho jaati hai — Java mein yahi tha
            throw;        // ✅ Stack trace preserve hoti hai — C# ka better way
        }
    }

    // Custom exception throw karna
    static void Withdraw(decimal balance, decimal amount)
    {
        if (amount > balance)
            throw new InsufficientBalanceException(balance, amount);

        Console.WriteLine($"Withdrawn: {amount} Rs");
    }

    // Status code handler
    static void HandleStatusCode(int code)
    {
        if (code != 200)
            throw new Exception($"{code} Error occurred");
    }
}

// -------------------------------------------------------
// QUICK JAVA vs C# COMPARISON
// -------------------------------------------------------
// Java                              C#
// ----------------------------------|-------------------
// try/catch/finally                 | Same ✅
// throw new Exception()             | Same ✅
// throws keyword in method          | ❌ Nahi hota C# mein
// No 'when' keyword                 | when ✅
// throw ex — stack trace reset      | throw — stack trace preserve ✅
// Checked + Unchecked exceptions    | Sirf Unchecked ✅
// -------------------------------------------------------