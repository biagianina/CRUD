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
            for(int i = 0; i < intArray.Length; i++)
            {
                if(intArray[intArray.Length - 1] != 0)
                {
                    Array.Resize(ref intArray, intArray.Length * 2);
                }
                else if(intArray[i] == 0)
                {
                    intArray[i] = element;
                    break;
                }
            }
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
            return IndexOf(element)!= -1 ? true : false;
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
            if (intArray[intArray.Length - 1] != 0)
            {
                Array.Resize(ref intArray, intArray.Length * 2);
            }

            ShiftRight(index);

            intArray[index] = element;
        }

        public void Clear()
        {
            Array.Resize(ref intArray, 0);
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
