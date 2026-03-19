using System;

class Student2
{
    // Private field (data hidden)
    private int age;

    //Public property to access private field
    public int Age
    {
        get { return age; }     // read value
        set
        {
            // validation
            if (value > 0 && value < 110)
            {
                age = value;
            }
            else
            {
                Console.WriteLine("Invalid Age : " + value);
            }
        }    // update value
    }

    // public uint Age // another way to write property using expression-bodied members (introduced in C# 7.0)
    // {
    //     get => age;             // read value (expression-bodied)
    //     set => age = value;     // update value (expression-bodied)
    // }


    // public uint Age // here we are using auto-implemented property, which is a shorthand syntax for properties in C#. The compiler automatically creates a private, anonymous backing field that can only be accessed through the property's get and set accessors.
    // {
    //     get; set;
    // }

    // Method
    public void Display()
    {
        Console.WriteLine("Age is: " + age); // print 0 if age is invalid otherwise print the valid age. This is because in the set accessor of the Age property, we are checking if the value is greater than 0 and less than 110, if it is valid then we are assigning it to the age field, otherwise we are printing an error message and not updating the age field, so it will remain 0 (the default value for int) if an invalid age is provided.
    }
}


public class BankAccount
{
    // Private — bahar se directly access nahi ho sakta
    private decimal _balance;
    private string _pin;

    public string OwnerName { get; set; }

    public BankAccount(string owner, string pin, decimal initialBalance)
    {
        OwnerName = owner;
        _pin = pin;
        _balance = initialBalance;
    }

    // Public methods — yahi sirf bahar se accessible hain
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Amount positive hona chahiye!");
        _balance += amount;
        Console.WriteLine($"Deposited: {amount}, New Balance: {_balance}");
    }

    public void Withdraw(string pin, decimal amount)
    {
        if (pin != _pin)
            throw new UnauthorizedAccessException("Wrong PIN!");
        if (amount > _balance)
            throw new InvalidOperationException("Insufficient balance!");
        _balance -= amount;
        Console.WriteLine($"Withdrawn: {amount}, Remaining: {_balance}");
    }

    // Read only — balance dekh sakte ho, directly change nahi
    public decimal GetBalance(string pin)
    {
        if (pin != _pin)
            throw new UnauthorizedAccessException("Wrong PIN!");
        return _balance;
    }
}

class Encapsulation
{
    public static void Run()
    {
        Student2 s = new Student2();

        s.Age = 21;      // set value
        s.Display();     // print value

        Console.WriteLine("Bank Account Example : ");
        var account = new BankAccount("Rohan", "1234", 5000);
        account.Deposit(1000);                    // ✅
        account.Withdraw("1234", 2000);           // ✅
        // account._balance = 99999;             // ❌ Private hai — direct access nahi!
        // account.Withdraw("0000", 1000);       // ❌ Wrong PIN — Exception!
    }
}