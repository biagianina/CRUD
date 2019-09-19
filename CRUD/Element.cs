using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class Element<TKey, TValue>
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public int Next { get; set; }

        public Element(TKey key, TValue value, int next = -1)
        {
            Key = key;
            Value = value;
            Next = next;
        }
    }
}
