using System;
using System.Collections;

namespace CRUD
{
    class Program
    {
        static void Main()
        {
            var objectArray = new List<int>{ 12, 3 };
            foreach(var obj in objectArray)
            {
                Console.WriteLine(obj);
            }
        }

    }
}
