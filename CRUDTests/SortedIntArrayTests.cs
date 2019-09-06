using System;
using Xunit;

namespace CRUD
{
    public class SortedIntArrayTests
    {
        [Fact]
        public void AddElements()
        {
            var array = new SortedIntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void SortedArray()
        {
            var array = new SortedIntArray();
            array.Add(1);
            array.Add(3);
            array.Add(2);
            array.Add(4);
            array.Sort();
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
            Assert.Equal(4, array[3]);
        }
    }
}
