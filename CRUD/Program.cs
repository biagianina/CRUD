using System;
using System.Collections;

namespace CRUD
{
    class Program
    {
        static void Main()
        {
            var test = new List<string>();
            Console.WriteLine("Populate the List");
            test.Add("one");
            test.Add("two");
            test.Add("three");
            test.Add("four");
            test.Add("five");
            test.Add("six");
            test.Add("seven");
            test.Add("eight");

            foreach (var obj in test)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("Remove elements from the list");
            test.Remove("six");
            test.Remove("eight");

            foreach (var obj in test)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("Add an element to the end of the list");
            test.Add("nine");

            foreach (var obj in test)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("Insert an element into the middle of the list");
            test.Insert(4, "number");

            foreach (var obj in test)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("Check for specific elements in the list");
            Console.WriteLine($"List contains \"three\": {test.Contains("three")}");
            Console.WriteLine($"List contains \"ten\": {test.Contains("ten")}");
        }

    }
}
