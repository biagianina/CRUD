using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class IntArray
    {
        protected int[] array;

        public IntArray()
        {
            array = new int[4];
        }

        public void Add(int element)
        {
            Insert(Count, element);
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }
        
        public bool Contains(int element)
        {
            return IndexOf(element)!= -1;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (element == array[i])
                {
                    return i;
                }
            }

            return -1;
        }

        public virtual void Insert(int index, int element)
        {
            ResizeArray();

            ShiftRight(index);

            array[index] = element;

            Count++;
        }
        
        public void Clear()
        {
            Array.Resize(ref array, 0);
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
            if (Count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
        }

    }
}
