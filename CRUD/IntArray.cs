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
            intArray = new int[4];
        }

        public void Add(int element)
        {
            Insert(Count, element);
        }

        public int Count { get; private set; }

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
            return IndexOf(element)!= -1;
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
            ResizeArray();

            ShiftRight(index);

            intArray[index] = element;

            Count++;
        }
        
        public void Clear()
        {
            Array.Resize(ref intArray, 0);
            Count = 0;
        }

        public void Remove(int element)
        {
            if (IndexOf(element) != -1)
            {
                RemoveAt(IndexOf(element));
            }
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        private void ResizeArray()
        {
            if (Count == intArray.Length)
            {
                Array.Resize(ref intArray, intArray.Length * 2);
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < intArray.Length - 1; i++)
            {
                intArray[i] = intArray[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = intArray.Length - 1; i > index; i--)
            {
                intArray[i] = intArray[i - 1];
            }
        }

    }
}
