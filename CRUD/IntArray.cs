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

        public void SetElement(int index, int element)
        {
            intArray[index] = element;
        }

        public bool Contains(int element)
        {
            bool contains = false;

            for (int i = 0; i < intArray.Length; i++)
            {
                if (element == intArray[i])
                {
                    contains = true;
                }
            }

            return contains;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < intArray.Length; i++)
            {
                if (element == intArray[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            Array.Resize(ref intArray, intArray.Length + 1);
            for (int i = 0; i < index; i++)
            {
               intArray[i] = intArray[i];
            }

            for (int i = intArray.Length - 1; i > index; i--)
            {
                intArray[i] = intArray[i - 1];
            }

            intArray[index] = element;
        }

        public void Clear()
        {
            Array.Resize(ref intArray, 0);
        }

        public void Remove(int element)
        {
            int removedIndex = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (element == intArray[i])
                {
                    removedIndex = i;
                }
            }
            for (int i = removedIndex; i < intArray.Length - 1; i++)
            {
                intArray[i] = intArray[i + 1];
            }

            Array.Resize(ref intArray, intArray.Length - 1);
        }
    }
}
