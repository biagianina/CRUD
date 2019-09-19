using System;
using System.Collections;
using System.Collections.Generic;

namespace CRUD
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, int> customersAge = new Dictionary<string, int>(4)
            {
                {"Ana", 46 },
                {"Bianca", 24 },
                {"Vasile", 56 },
                {"Casian",6 }
            };

            foreach (var customer in customersAge)
            {
                Console.WriteLine("{0} is {1} years old.\n", customer.Key, customer.Value);
            }
            Console.WriteLine("Number of elements in dictionary = {0}\n", customersAge.Count);

            Console.WriteLine("Does dictionary contain 'Ana'? {0}\n", customersAge.ContainsKey("Ana"));

            Console.WriteLine("Ana's age is {0}\n", customersAge["Ana"]);

            customersAge.Remove("Ana");

            Console.WriteLine("Does dictionary contain 'Ion'? {0}\n", customersAge.ContainsKey("Ion"));


            foreach (var customer in customersAge)
            {
                Console.WriteLine("{0} is {1} years old.\n", customer.Key, customer.Value);
            }

            foreach (var value in customersAge.Values)
            {
                Console.Write(value + " ");
                
                
            }

            Console.WriteLine();
            Console.WriteLine();

            foreach (var value in customersAge.Keys)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();
            Console.WriteLine();

            customersAge.Add("Gianina", 20);

            foreach (var customer in customersAge)
            {
                Console.WriteLine("{0} is {1} years old.\n", customer.Key, customer.Value);
            }
        }
    }  

}

