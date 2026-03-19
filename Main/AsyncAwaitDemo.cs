// ============================================================
//       C# ASYNC/AWAIT - COMPLETE REVISION FILE
// ============================================================

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

class AsyncAwaitDemo
{
    public static async Task Run()
    {
        await BasicAsyncExample();
        await MultipleTasksExample();
        await TaskWhenAllExample();
        await TaskWhenAnyExample();
        await AsyncWithReturnValue();
        await AsyncExceptionHandling();
        await RealWorldExample();
    }


    // ---------------------------------------------------
    // 1. BASIC ASYNC/AWAIT
    // Java mein: CompletableFuture, ExecutorService
    // C# mein: async/await — bahut simple aur clean!
    // Rule:
    //   - async method mein await use karo
    //   - await lagane se thread block nahi hota
    //   - Return type Task (void) ya Task<T> (value)
    // ---------------------------------------------------
    static async Task BasicAsyncExample()
    {
        Console.WriteLine("===== 1. Basic Async/Await =====");

        Console.WriteLine("Task start...");
        await Task.Delay(1000);              // 1 second wait — thread block nahi hoga!
        Console.WriteLine("Task done after 1 sec!\n");
    }


    // ---------------------------------------------------
    // 2. ASYNC METHOD WITH RETURN VALUE
    // Java mein: CompletableFuture<Integer>
    // C# mein: Task<int>
    // ---------------------------------------------------
    static async Task AsyncWithReturnValue()
    {
        Console.WriteLine("===== 2. Async Return Value =====");

        int result = await GetSquareAsync(5);
        Console.WriteLine($"Square of 5: {result}");   // 25

        string data = await FetchDataAsync("Rohan");
        Console.WriteLine($"Data: {data}\n");
    }

    // Task<int> — async method jo int return karta hai
    static async Task<int> GetSquareAsync(int n)
    {
        await Task.Delay(500);   // Simulate async work
        return n * n;
    }

    // Task<string> — async method jo string return karta hai
    static async Task<string> FetchDataAsync(string name)
    {
        await Task.Delay(500);   // Simulate DB/API call
        return $"Hello, {name}!";
    }


    // ---------------------------------------------------
    // 3. MULTIPLE TASKS — Sequential vs Parallel
    // Sequential — ek ke baad ek (slow)
    // Parallel   — sab ek saath (fast)
    // ---------------------------------------------------
    static async Task MultipleTasksExample()
    {
        Console.WriteLine("===== 3. Sequential vs Parallel =====");

        // Sequential — 3 seconds total
        Console.WriteLine("Sequential start...");
        var r1 = await DelayAndReturn("Task 1", 1000);
        var r2 = await DelayAndReturn("Task 2", 1000);
        var r3 = await DelayAndReturn("Task 3", 1000);
        Console.WriteLine($"Sequential done: {r1}, {r2}, {r3}\n");
    }

    static async Task<string> DelayAndReturn(string name, int ms)
    {
        await Task.Delay(ms);
        return name;
    }


    // ---------------------------------------------------
    // 4. TASK.WHENALL — Sab tasks parallel chalao
    // Java mein: CompletableFuture.allOf()
    // C# mein: Task.WhenAll() — bahut simple!
    // ---------------------------------------------------
    static async Task TaskWhenAllExample()
    {
        Console.WriteLine("===== 4. Task.WhenAll (Parallel) =====");

        // Sab tasks ek saath start honge — ~1 second total (3 nahi!)
        var task1 = DelayAndReturn("Task 1", 1000);
        var task2 = DelayAndReturn("Task 2", 1000);
        var task3 = DelayAndReturn("Task 3", 1000);

        var results = await Task.WhenAll(task1, task2, task3);
        Console.WriteLine($"All done: {string.Join(", ", results)}\n");
    }


    // ---------------------------------------------------
    // 5. TASK.WHENANY — Jo pehle complete ho uska result lo
    // Java mein: CompletableFuture.anyOf()
    // C# mein: Task.WhenAny()
    // ---------------------------------------------------
    static async Task TaskWhenAnyExample()
    {
        Console.WriteLine("===== 5. Task.WhenAny =====");

        var task1 = DelayAndReturn("Slow Task",  3000);
        var task2 = DelayAndReturn("Fast Task",  500);
        var task3 = DelayAndReturn("Medium Task",1500);

        // Jo pehle complete ho
        var firstDone = await Task.WhenAny(task1, task2, task3);
        Console.WriteLine($"First done: {await firstDone}\n");  // Fast Task
    }


    // ---------------------------------------------------
    // 6. EXCEPTION HANDLING IN ASYNC
    // Same as normal try/catch — bas await ke saath
    // ---------------------------------------------------
    static async Task AsyncExceptionHandling()
    {
        Console.WriteLine("===== 6. Async Exception Handling =====");

        try
        {
            await FailingTaskAsync();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Caught: {ex.Message}\n");
        }
    }

    static async Task FailingTaskAsync()
    {
        await Task.Delay(500);
        throw new InvalidOperationException("Something went wrong!");
    }


    // ---------------------------------------------------
    // 7. REAL WORLD — ASP.NET API jaisa example
    // Har API endpoint async hoti hai
    // Database calls, HTTP calls sab async hote hain
    // ---------------------------------------------------
    static async Task RealWorldExample()
    {
        Console.WriteLine("===== 7. Real World — API Style =====");

        // Simulate API endpoints
        var user    = await GetUserAsync(1);
        var orders  = await GetOrdersAsync(1);

        Console.WriteLine($"User  : {user}");
        Console.WriteLine($"Orders: {string.Join(", ", orders)}\n");

        // Parallel DB calls — faster!
        var (u, o) = await GetUserAndOrdersAsync(2);
        Console.WriteLine($"User  : {u}");
        Console.WriteLine($"Orders: {string.Join(", ", o)}");
    }

    // Simulate DB calls
    static async Task<string> GetUserAsync(int id)
    {
        await Task.Delay(500);   // Simulate DB query
        return $"User_{id}";
    }

    static async Task<List<string>> GetOrdersAsync(int userId)
    {
        await Task.Delay(500);   // Simulate DB query
        return new List<string> { $"Order_1", $"Order_2", $"Order_3" };
    }

    // Parallel calls — dono ek saath
    static async Task<(string, List<string>)> GetUserAndOrdersAsync(int id)
    {
        var userTask   = GetUserAsync(id);
        var ordersTask = GetOrdersAsync(id);

        await Task.WhenAll(userTask, ordersTask);  // Parallel!

        return (userTask.Result, ordersTask.Result);
    }
}

// -------------------------------------------------------
// QUICK SUMMARY
// -------------------------------------------------------
// async        →  Method ko async banao
// await        →  Async operation ka wait karo — thread block nahi hoga
// Task         →  async void — kuch return nahi
// Task<T>      →  async method jo T return karta hai
// Task.WhenAll →  Sab tasks parallel chalao
// Task.WhenAny →  Jo pehle complete ho uska result lo
// -------------------------------------------------------
// JAVA vs C#
// -------------------------------------------------------
// Java                          | C#
// ------------------------------|-------------------------
// CompletableFuture<T>          | Task<T>
// .thenApply()                  | await
// CompletableFuture.allOf()     | Task.WhenAll()
// CompletableFuture.anyOf()     | Task.WhenAny()
// ExecutorService               | Task.Run()
// Checked exceptions            | try/catch same ✅
// -------------------------------------------------------
// ASP.NET mein:
// public async Task<IActionResult> GetUsers()
// {
//     var users = await _db.Users.ToListAsync();
//     return Ok(users);
// }
// -------------------------------------------------------