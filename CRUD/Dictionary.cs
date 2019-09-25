using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        readonly Element<TKey, TValue>[] elements;
        readonly int[] buckets;
        readonly int size;
        int freeIndex = -1;

        public Dictionary(int size)
        {
            this.elements = new Element<TKey, TValue>[size];
            this.buckets = new int[size];
            Array.Fill(buckets, -1);
            this.size = size;
        }
        public TValue this[TKey key]
        {
            get
            {
                if (TryGetIndexOfKey(key, out int index))
                {
                    return elements[index].Value;
                }
                else
                {
                    throw new KeyNotFoundException("Key not in the dictionary");
                }
            }
            set
            {
                if (TryGetIndexOfKey(key, out int index))
                {
                    elements[index].Value = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                TKey[] keys = new TKey[Count];
                int keysCounter = 0;
                foreach (var current in this)
                {
                    keys[keysCounter++] = current.Key;
                }
                return keys;
            }
        }
        public ICollection<TValue> Values
        {
            get
            {
                TValue[] values = new TValue[Count];
                int valueCount = 0;
                foreach (var current in this)
                {
                    values[valueCount++] = current.Value;
                }
                return values;
            }
        }

        public int Count { get; set; }

        public bool IsReadOnly { get; }

        public void Add(TKey key, TValue value)
        {
           CheckKeyDuplicate(key);
           int bucketNumber = GetBucket(key);
           int elementIndex = CheckFreePosition();
           if (elements[elementIndex] != null)
           {
                freeIndex = elements[elementIndex].Next;
           }
           elements[elementIndex] = new Element<TKey, TValue>(key, value, buckets[bucketNumber]);
           buckets[bucketNumber] = elementIndex;
           Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Count = 0;
            Array.Fill(buckets, -1);
            Array.Fill(elements, default);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            if (TryGetIndexOfKey(item.Key, out int index))
            {
                return elements[index].Value.Equals(item.Value);
            }

            return false;
        }

        public bool ContainsKey(TKey key)
        {
            return TryGetIndexOfKey(key, out _);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (Count > array.Length)
            {
                throw new ArgumentException("Array is smaller than dictionary");
            }

            foreach (var current in this)
            {
                array.SetValue(current, arrayIndex++);
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            int freeElements = 0;
            for(int i = 0; i < Count + freeElements; i++)
            {
                if (HasValue(i))
                {
                    yield return new KeyValuePair<TKey, TValue>(elements[i].Key, elements[i].Value);
                }
                else
                {
                    freeElements++;
                }
            }
        }

        private bool HasValue(int index)
        {
            for (int i = freeIndex; i != -1; i = elements[i].Next)
            {
                if (index == i)
                {
                    return false;
                }
            }

            return true;
        }

        public bool Remove(TKey key)
        {
            if (TryGetIndexOfKey(key, out int index))
            {
                if (HasValue(index))
                {
                    Delete(elements[index]);
                    freeIndex = index;
                    Count--;
                    return true;
                }
            }
           
            return false;
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            if (TryGetIndexOfKey(key, out int index))
            {
                value = elements[index].Value;
                return true;
            }

            value = default;
            return false;
        }

        public bool TryGetIndexOfKey(TKey key, out int index)
        {
            int bucketNumber = GetBucket(key);
            for (index = buckets[bucketNumber]; index > -1; index = elements[index].Next)
            {
                if (elements[index].Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        private int GetBucket(TKey key)
        {
            int bucketNumber = Math.Abs(key.GetHashCode());
            if (bucketNumber > size - 1)
            {
                bucketNumber %= size;
            }

            return bucketNumber;
        }

        private void Delete(Element<TKey, TValue> element)
        {
            element.Key = default;
            element.Value = default;
            element.Next = freeIndex;
        }

        private void CheckKeyDuplicate(TKey key)
        {
            if (ContainsKey(key))
            {
                throw new ArgumentException("Key already exists");
            }
        }

        private int CheckFreePosition()
        {
            if (freeIndex != -1)
            {
                return freeIndex;
            }

            if (Count == size)
            {
                throw new InvalidOperationException("Dictionary is full!");
            }

            return Count;
        }
    }
}
