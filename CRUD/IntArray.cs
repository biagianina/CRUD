using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class IntArray
    {
        private int[] intArray;

        public IntArray()
        {
            intArray = new int[0];
        }

        public void Add(int element)
        {
            Array.Resize(ref intArray, intArray.Length + 1);
            intArray[intArray.Length - 1] = element;
        }

        public int[] GetArray()
        {
            return intArray;
        }

        public int Count()
        {
            return intArray.Length;
        }

        public int Element(int index)
        {
            return intArray[index];
        }
    }
}
