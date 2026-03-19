using System;
using System.Threading.Tasks;

class AsyncAwait_HouseHold
{
    public static async Task Run()
    {
        Console.WriteLine("Start Cooking...");

        // --------------------------------------------------
        // 👉 Behind the scenes:
        // - MakeMaggi() starts executing immediately
        // - It runs until FIRST await
        // - Then returns a Task (promise of completion)
        // --------------------------------------------------
        Task maggiTask = MakeMaggi();

        // Same for Tea
        Task teaTask = MakeTea();

        // --------------------------------------------------
        // 👉 Now both tasks are RUNNING (not waiting here)
        // Main method continues execution
        // --------------------------------------------------

        // --------------------------------------------------
        // 👉 await:
        // - Does NOT block thread
        // - It registers a "callback"
        // - When task finishes → execution resumes from here
        // --------------------------------------------------
        await maggiTask;
        await teaTask;

        Console.WriteLine("Everything is ready!");
    }


    static async Task MakeMaggi()
    {
        Console.WriteLine("Boiling water for Maggi...");

        // --------------------------------------------------
        // 👉 Behind the scenes:
        // - Task.Delay creates a timer (not thread sleep)
        // - Method pauses here and RETURNS control to caller
        // - Thread becomes FREE to do other work
        // --------------------------------------------------
        await Task.Delay(3000);

        Console.WriteLine("Cooking Maggi...");

        await Task.Delay(2000);

        Console.WriteLine("Maggi Ready!");
    }


    static async Task MakeTea()
    {
        Console.WriteLine("Boiling water for Tea...");

        await Task.Delay(2000);

        Console.WriteLine("Making Tea...");

        await Task.Delay(2000);

        Console.WriteLine("Tea Ready!");
    }
}