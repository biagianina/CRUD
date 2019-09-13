using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class List<T> : IList<T>
    {
        T[] array;

        public List()
        {
            this.array = new T[4];
        }

        public void Add(T element)
        {
            CheckReadOnly();
            ResizeArray();
            array[Count] = element;
            Count++;
        }

        public int Count {get; private set;}

        public bool IsReadOnly { get; }

        public bool IsFixedSize { get; }

        public T this[int index]
        {
            get
            {
                CheckIndexOutOfRange(index);
                return array[index];
            }
            set
            {
                CheckReadOnly();
                CheckIndexOutOfRange(index);
                array[index] = value;
            }
        }

       
        public void Insert(int index, T element)
        {
            CheckReadOnly();

            CheckIndexOutOfRange(index);

            ResizeArray();

            ShiftRight(index);

            array[index] = element;

            Count++;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (element.Equals(array[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public void Clear()
        {
            CheckReadOnly();
            Array.Resize(ref array, 0);
            Count = 0;
        }

        public void RemoveAt(int index)
        {
            CheckReadOnly(); 
            CheckIndexOutOfRange(index);
            ShiftLeft(index);
            Count--;
        }

        public bool Remove(T element)
        {
            int index = IndexOf(element);
            if (index == -1)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        public void CopyTo(T[] targetArray, int arrayIndex)
        {
            CheckIndexOutOfRange(arrayIndex);

            if (Count > targetArray.Length)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < Count; i++)
            {
                targetArray.SetValue(array[i], arrayIndex++);
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        private void ResizeArray()
        {
            if (Count == array.Length)
            {
                Array.Resize(ref array, Count * 2);
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
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

        private void CheckIndexOutOfRange(int index)
        {
            if (index >= 0 && index < Count)
            {
                return;
            }

            throw new ArgumentOutOfRangeException("Index is not in the ranges of the array");
        }

        private void CheckReadOnly()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Array is readonly");
            }
        }
    }
}
