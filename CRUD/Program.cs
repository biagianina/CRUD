using System;

namespace CRUD
{
    class Program
    {
        static void Main()
        {
            var array = new ObjectArray { 1, "abcd", 'a', 1.52 };
            foreach(var i in array)
            {
                Console.WriteLine(i);
            }
            Console.Read();
        }
    }
}
