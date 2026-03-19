// Abstract Class — Common data aur behavior sabko milega
abstract class Payment
{
    // State — data store ho raha hai
    public string CustomerName { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }

    // Constructor — state initialize ho rahi hai
    public Payment(string customerName, decimal amount)
    {
        CustomerName = customerName;
        Amount = amount;
        PaymentDate = DateTime.Now;
    }

    // Abstract — har payment ka apna process hoga
    public abstract bool ProcessPayment();

    // Common method — sabke liye same logic
    public void PrintReceipt()
    {
        Console.WriteLine("==================");
        Console.WriteLine("   PAYMENT RECEIPT");
        Console.WriteLine("==================");
        Console.WriteLine($"Customer : {CustomerName}");
        Console.WriteLine($"Amount   : {Amount} Rs");
        Console.WriteLine($"Date     : {PaymentDate}");
        Console.WriteLine($"Status   : {(ProcessPayment() ? "Success" : "Failed")}");
        Console.WriteLine("==================");
    }
}

// Child 1 — CreditCard ka apna ProcessPayment
class CreditCard : Payment
{
    public string CardNumber { get; set; }

    public CreditCard(string customerName, decimal amount, string cardNumber)
        : base(customerName, amount)
    {
        CardNumber = cardNumber;
    }

    public override bool ProcessPayment()
    {
        Console.WriteLine($"Processing Credit Card ending {CardNumber[^4..]}...");
        return true;
    }
}

// Child 2 — UPI ka apna ProcessPayment
class UPI : Payment
{
    public string UpiId { get; set; }

    public UPI(string customerName, decimal amount, string upiId)
        : base(customerName, amount)
    {
        UpiId = upiId;
    }

    public override bool ProcessPayment()
    {
        Console.WriteLine($"Processing UPI payment via {UpiId}...");
        return true;
    }
}




// Interface — sirf contract, koi state nahi
interface IRefundable
{
    bool ProcessRefund(decimal amount);
    void SendRefundNotification();
}

interface ISchedulable
{
    void SchedulePayment(DateTime scheduleDate);
}

// CreditCard refund bhi kar sakta hai aur schedule bhi
class CreditCardPro : Payment, IRefundable, ISchedulable
{
    public string CardNumber { get; set; }

    public CreditCardPro(string customerName, decimal amount, string cardNumber)
        : base(customerName, amount)
    {
        CardNumber = cardNumber;
    }

    // Abstract class ka method implement kiya
    public override bool ProcessPayment()
    {
        Console.WriteLine($"Processing Credit Card ending {CardNumber[^4..]}...");
        return true;
    }

    // IRefundable ka contract implement kiya
    public bool ProcessRefund(decimal amount)
    {
        Console.WriteLine($"Refunding {amount} Rs to card ending {CardNumber[^4..]}");
        return true;
    }

    public void SendRefundNotification()
    {
        Console.WriteLine($"Refund notification sent to {CustomerName}");
    }

    // ISchedulable ka contract implement kiya
    public void SchedulePayment(DateTime scheduleDate)
    {
        Console.WriteLine($"Payment of {Amount} Rs scheduled for {scheduleDate.ToShortDateString()}");
    }
}

// UPI sirf refund kar sakta hai, schedule nahi
class UPIPro : Payment, IRefundable
{
    public string UpiId { get; set; }

    public UPIPro(string customerName, decimal amount, string upiId)
        : base(customerName, amount)
    {
        UpiId = upiId;
    }

    public override bool ProcessPayment()
    {
        Console.WriteLine($"Processing UPI payment via {UpiId}...");
        return true;
    }

    public bool ProcessRefund(decimal amount)
    {
        Console.WriteLine($"Refunding {amount} Rs to {UpiId}");
        return true;
    }

    public void SendRefundNotification()
    {
        Console.WriteLine($"Refund notification sent to {CustomerName}");
    }
}

class Abstraction
{
    public static void Run()
    {
        Console.WriteLine("===== Abstract Class =====");
        var cc = new CreditCard("Chirag", 5000, "1234567890123456");
        var upi = new UPI("Sumit", 2000, "sumit@upi");

        cc.PrintReceipt();
        Console.WriteLine();
        upi.PrintReceipt();


         Console.WriteLine("\n---- Interface  -----");
        var ccPro  = new CreditCardPro("Chirag", 5000, "1234567890123456");
        var upiPro = new UPIPro("Sumit", 2000, "sumit@upi");

        // Refund — dono kar sakte hain
        ccPro.ProcessRefund(500);
        ccPro.SendRefundNotification();
        Console.WriteLine();
        upiPro.ProcessRefund(200);
        upiPro.SendRefundNotification();

        // Schedule — sirf CreditCardPro kar sakta hai
        Console.WriteLine();
        ccPro.SchedulePayment(DateTime.Now.AddDays(7));
        // upiPro.SchedulePayment(DateTime.Now.AddDays(7)); // Error: UPIPro does not implement ISchedulable

    }
}