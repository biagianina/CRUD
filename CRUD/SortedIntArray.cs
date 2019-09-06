using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD
{
    public class SortedIntArray : IntArray
    {
        private void Sort()
        {
            Sort(array, 0, Count - 1); 
        }

        public override void Insert(int index, int element)
        {
            base.Insert(index, element);
            Sort();
        }

        public int[] Sort(int[] array, int start, int end)
        {
            int i = start;
            int j = end;
            var pivot = array[(i + j) / 2];

            if (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (pivot < array[j])
                {
                    j--;
                }

                if (i <= j)
                {
                    var temp = array[j];
                    array[j] = array[i];
                    array[i] = temp;

                    i++;
                    j--;
                }

                if (start < j)
                {
                    Sort(array, start, j);
                }

                if (i < end)
                {
                    Sort(array, i, end);
                }
            }

            return array;
        }
    }
}
