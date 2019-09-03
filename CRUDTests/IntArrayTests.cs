using System;
using Xunit;


namespace CRUD
{
    public class IntArrayTests
    {
        [Fact]
        public void AddAnElement()
        {
            var array = new IntArray();
            int[] expected = { 1 };
            array.Add(1);

            Assert.Equal(expected, array.GetArray());
        }

        [Fact]
        public void AddTwoElements()
        {
            var array = new IntArray();
            int[] expected = { 1 , 2 };
            array.Add(1);
            array.Add(2);
            Assert.Equal(expected, array.GetArray());
        }

        [Fact]
        public void GetNumberOfElements()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            Assert.Equal(2, array.Count());
        }

        [Fact]
        public void GetElementOfAnIndex()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            Assert.Equal(3, array.Element(2));
        }
    }
}
