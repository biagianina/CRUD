using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class SortedIntArray : IntArray
    {
        public override void Insert(int index, int element)
        {
            if (index > 0 && array[index - 1] > element
                || index < Count - 1  && array[index] < element)
            {
                return;
            }

            base.Insert(index, element);
        }

        public override int this[int index]
        {
            get => base[index];
            set
            {
                if (index > 0 && array[index - 1] > value
                    || index < Count - 1 && array[index + 1] < value)
                {
                    return;
                }

                base[index] = value;
            }
        }
        public override void Add(int element)
        {
            base.Add(element);
            Sort();
        }
        private void Sort()
        {
            Sort(array);
        }
        private void Sort(int[] array)
        {
            bool flag = true;
            int temp;
            int arrLength = Count;

            for (int i = 1; (i <= (arrLength - 1)) && flag; i++)
            {
                flag = false;
                for (int j = 0; j < (arrLength - 1); j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        flag = true;
                    }
                }
            }
        }
    }
}
