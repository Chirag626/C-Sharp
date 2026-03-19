using System;
using System.Threading;
using System.Threading.Tasks;

/*
❌ Problem Without Async (Real World Thinking)
Imagine you have a DataService class that calls DB + API.
👉 If you write synchronous code, each request:
DB call (3 sec) → wait
API call (2 sec) → wait

If 100 users hit your API:
100 threads get blocked 😵
Server becomes slow / crashes
✅ What Async Solves
Instead of blocking thread → free it while waiting
👉 Same thread can now handle more requests.
*/
class AsyncAwait_1
{
    public static async Task Run()
    {
        DataService service = new DataService();

        Console.WriteLine("Request started...\n");

        // ------------------------------------------
        // ❌ Synchronous call (blocking)
        // ------------------------------------------
        // string data1 = service.GetData();
        // string data2 = service.GetApiData();

        // Console.WriteLine(data1);
        // Console.WriteLine(data2);


        // ------------------------------------------
        // ✅ Async call (non-blocking)
        // ------------------------------------------
        Task<string> dbTask = service.GetDataAsync();
        Task<string> apiTask = service.GetApiDataAsync();

        Console.WriteLine("Doing other work while waiting...\n");

        // await both results
        string dbResult = await dbTask;
        string apiResult = await apiTask;

        Console.WriteLine(dbResult);
        Console.WriteLine(apiResult);

        Console.WriteLine("\nRequest finished.");
    }
}


// --------------------------------------------------
// Separate Class (Real Backend Style)
// --------------------------------------------------
class DataService
{
    // ------------------------------------------
    // ❌ Synchronous method (blocks thread)
    // ------------------------------------------
    public string GetData()
    {
        Console.WriteLine("Fetching data from DB...");

        // Thread is BLOCKED here
        Thread.Sleep(3000);

        return "DB Data received";
    }


    // ------------------------------------------
    // ❌ Synchronous API call
    // ------------------------------------------
    public string GetApiData()
    {
        Console.WriteLine("Calling external API...");

        Thread.Sleep(2000);

        return "API Data received";
    }


    // ------------------------------------------
    // ✅ Async DB call
    // ------------------------------------------
    public async Task<string> GetDataAsync()
    {
        Console.WriteLine("Fetching data from DB...");

        // ------------------------------------------
        // 👉 Behind the scenes:
        // - No thread blocking
        // - Timer starts
        // - Thread is FREE to serve other requests
        // ------------------------------------------
        await Task.Delay(3000);

        return "DB Data received";
    }


    // ------------------------------------------
    // ✅ Async API call
    // ------------------------------------------
    public async Task<string> GetApiDataAsync()
    {
        Console.WriteLine("Calling external API...");

        await Task.Delay(2000);

        return "API Data received";
    }
}