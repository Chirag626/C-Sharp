// ============================================================
//       C# COLLECTIONS - COMPLETE REVISION FILE
//       For: Java Developer learning C#
// ============================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

class Collections
{
    public static void Run()
    {
        ListExample();
        DictionaryExample();
        HashSetExample();
        StackExample();
        QueueExample();
        LinkedListExample();
        SortedDictionaryExample();
        ObservableCollectionExample();
    }


    // ---------------------------------------------------
    // 1. LIST<T> — Java ka ArrayList
    // Java  : ArrayList<String> list = new ArrayList<>();
    // C#    : var list = new List<string>();
    // ---------------------------------------------------
    static void ListExample()
    {
        Console.WriteLine("===== 1. List<T> =====");

          var l1 = new List<(int Id, string Name)>
        {
            (1, "Aman"),
            (2, "Bobby"),
            (3, "Chirag")
        };
         foreach (var data in l1)
        {
            Console.WriteLine($"{data.Id} - {data.Name}");
        }

        var list = new List<string>();

        // Add — Java mein .add() tha
        list.Add("Chirag");
        list.Add("Amit");
        list.Add("Sara");

        // Index se access — Same as Java
        Console.WriteLine(list[0]);              // Chirag

        // Remove
        list.Remove("Amit");                     // Value se remove
        list.RemoveAt(0);                        // Index se remove

        // Check
        Console.WriteLine(list.Contains("Sara")); // True
        Console.WriteLine($"Count: {list.Count}"); // Java mein .size() tha

        // Loop
        var names = new List<string> { "Chirag", "Amit", "Sara" };
        foreach (var name in names)
            Console.WriteLine(name);

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 2. DICTIONARY<K,V> — Java ka HashMap
    // Java  : HashMap<String, Integer> map = new HashMap<>();
    // C#    : var dict = new Dictionary<string, int>();
    // ---------------------------------------------------
    static void DictionaryExample()
    {
        Console.WriteLine("===== 2. Dictionary<K,V> =====");

        var dict = new Dictionary<string, int>();

        // Add — Java mein .put() tha
        dict.Add("Chirag", 21);
        dict["Amit"] = 22;                       // Yeh bhi valid hai
        dict.Add("Sumit", 23);

        // Access — Java mein .get() tha returns null if key not found, C# mein throws exception
        Console.WriteLine(dict["Chirag"]);        // 21

        // Safe access — KeyNotFoundException se bachne ke liye
        if (dict.ContainsKey("Amit"))
            Console.WriteLine(dict["Amit"]);     // 22 return value if key exists

// TryGetValue — Best practice. Prints "key : value" if found
        if (dict.TryGetValue("Sara", out int age)) // TryGetValue returns false if key not found, true if found and assigns value to 'age'
            Console.WriteLine($"Sara : {age}"); 
        else
            Console.WriteLine("Sara nahi mili!");

        // Loop
        foreach (var kvp in dict)
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");

        // Remove — Same as Java
        dict.Remove("Chirag");
        Console.WriteLine($"Count after remove: {dict.Count}");

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 3. HASHSET<T> — C# Specific ⭐
    // Java mein tha but C# wala zyada powerful hai
    // Set Operations directly available hain
    // ---------------------------------------------------
    static void HashSetExample()
    {
        Console.WriteLine("===== 3. HashSet<T> =====");

        var set1 = new HashSet<int> { 1, 2, 3, 4, 5 };
        var set2 = new HashSet<int> { 3, 4, 5, 6, 7 };

        // Duplicate automatically remove hota hai
        set1.Add(1);                             // Already hai — add nahi hoga
        set1.Add(6);                             // Naya — add hoga
        Console.WriteLine($"Initial Count: {set1.Count}"); // 6
        Console.Write("After Adding elements SET 1 : ");
        foreach (var n in set1) Console.Write($"{n} ");
        Console.Write("\nAfter Adding elements SET 2 : ");
        foreach (var n in set2) Console.Write($"{n} ");

        // Set Operations — Java mein manually karne padte the!
        var union  = new HashSet<int>(set1);
        union.UnionWith(set2);                   // set1 | set2
        Console.Write("\nUnion: ");
        foreach (var n in union) Console.Write($"{n} ");

        var intersect = new HashSet<int>(set1);
        intersect.IntersectWith(set2);           // set1 & set2 — common elements
        Console.Write("\nIntersect: ");
        foreach (var n in intersect) Console.Write($"{n} ");

        var except = new HashSet<int>(set1);
        except.ExceptWith(set2);                 // set1 - set2
        Console.Write("\nExcept: ");
        foreach (var n in except) Console.Write($"{n} ");

        Console.WriteLine($"\nContains 3: {set1.Contains(3)}");

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 4. STACK<T> — Same as Java
    // LIFO — Last In First Out
    // ---------------------------------------------------
    static void StackExample()
    {
        Console.WriteLine("===== 4. Stack<T> =====");

        var stack = new Stack<string>();

        // Push — Same as Java
        stack.Push("First");
        stack.Push("Second");
        stack.Push("Third");

        // Pop — LIFO — Same as Java
        Console.WriteLine(stack.Pop());          // Third

        // Peek — Remove nahi hoga — Same as Java
        Console.WriteLine(stack.Peek());         // Second

        Console.WriteLine($"Count: {stack.Count}"); // 2

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 5. QUEUE<T> — Same as Java
    // FIFO — First In First Out
    // Java mein .add() tha, C# mein .Enqueue()
    // ---------------------------------------------------
    static void QueueExample()
    {
        Console.WriteLine("===== 5. Queue<T> =====");

        var queue = new Queue<string>();

        // Enqueue — Java mein .add() tha
        queue.Enqueue("First");
        queue.Enqueue("Second");
        queue.Enqueue("Third");

        // Dequeue — FIFO
        Console.WriteLine(queue.Dequeue());      // First

        // Peek
        Console.WriteLine(queue.Peek());         // Second

        Console.WriteLine($"Count: {queue.Count}"); // 2

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 6. LINKEDLIST<T> — Same concept, alag syntax
    // Java mein .addFirst()/.addLast() tha — Same in C#
    // ---------------------------------------------------
    static void LinkedListExample()
    {
        Console.WriteLine("===== 6. LinkedList<T> =====");

        var linkedList = new LinkedList<string>();

        // Add
        linkedList.AddFirst("First");
        linkedList.AddLast("Last");
#pragma warning disable CS8604 // Possible null reference argument.
        linkedList.AddAfter(linkedList.First, "Middle");
#pragma warning restore CS8604 // Possible null reference argument.

        // Loop
        foreach (var item in linkedList)
            Console.WriteLine(item);             // First, Middle, Last

        // Remove
        linkedList.Remove("Middle");
        linkedList.RemoveFirst();
        linkedList.RemoveLast();

        Console.WriteLine($"Count after removes: {linkedList.Count}"); // 0

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 7. SORTEDDICTIONARY<K,V> — C# Specific ⭐
    // Java mein TreeMap tha
    // Keys automatically sort hoti hain
    // ---------------------------------------------------
    static void SortedDictionaryExample()
    {
        Console.WriteLine("===== 7. SortedDictionary<K,V> =====");

        var sorted = new SortedDictionary<string, int>();
        sorted.Add("Zebra", 1);
        sorted.Add("Apple", 2);
        sorted.Add("Mango", 3);

        // Automatically alphabetically sorted output
        foreach (var kvp in sorted)
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        // Apple: 2
        // Mango: 3
        // Zebra: 1

        Console.WriteLine();
    }


    // ---------------------------------------------------
    // 8. OBSERVABLECOLLECTION<T> — C# Only ⭐
    // Java mein bilkul nahi tha!
    // Jab collection change ho — automatically notify kare
    // Real-time UI updates ke liye use hota hai
    // ---------------------------------------------------
    static void ObservableCollectionExample()
    {
        Console.WriteLine("===== 8. ObservableCollection<T> =====");

        var oc = new ObservableCollection<string>();

        // Event — jab bhi collection change ho tab trigger hoga
        oc.CollectionChanged += (sender, e) =>
        {
            Console.WriteLine($"Collection changed! Action: {e.Action}");
        };

        oc.Add("Chirag");     // Collection changed! Action: Add
        oc.Add("Sumit");      // Collection changed! Action: Add
        oc.Remove("Chirag");  // Collection changed! Action: Remove
        oc.Clear();          // Collection changed! Action: Reset

        Console.WriteLine($"Count: {oc.Count}");

        oc.Add("Sakshi");      // Collection changed! Action: Add 
        Console.WriteLine($"Now Count: {oc.Count}");

        Console.WriteLine();
    }
}

// -------------------------------------------------------
// QUICK JAVA vs C# COMPARISON
// -------------------------------------------------------
// Java                   | C#                          | Extra?
// -----------------------|-----------------------------|------------------
// ArrayList<T>           | List<T>                     | Same
// HashMap<K,V>           | Dictionary<K,V>             | TryGetValue ✅
// HashSet<T>             | HashSet<T>                  | Set Operations ✅
// Stack<T>               | Stack<T>                    | Same
// Queue<T>               | Queue<T>                    | Same
// LinkedList<T>          | LinkedList<T>               | Same
// TreeMap<K,V>           | SortedDictionary<K,V>       | Same concept
// ❌                     | ObservableCollection<T>     | C# Only ⭐
// -------------------------------------------------------