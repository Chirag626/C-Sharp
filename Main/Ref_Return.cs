class Ref_Return
{
      /*
    ref return example
    A method can return a reference to a variable instead of returning a copy.
    This allows the caller to directly modify the original variable.
    */

    static int data = 50; // variable whose reference we will return

    public static ref int GetReference()
    {
        return ref data; // returning reference of data
    }

    public static void Run2()
    {
        // ref local receiving reference returned from method
        ref int value = ref GetReference();

        Console.WriteLine("Before modification: " + data);

        value = 999; // modifies original variable because it points to same memory

        Console.WriteLine("After modification: " + data);
    }
}
