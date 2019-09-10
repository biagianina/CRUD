using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class ObjectEnumerator : IEnumerator
    {
        public readonly object[] objectArray;
        int position = -1;

        public ObjectEnumerator(object[] objectArray)
        {
            this.objectArray = objectArray;
        }
        public object Current
        {
            get
            {
                if (position < 0)
                {
                    return null;
                }

                return objectArray [position];
            }
                
        }
        public bool MoveNext()
        {
            position++;
            
            return position < objectArray.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
