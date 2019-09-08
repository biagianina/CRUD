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
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
            Assert.Equal(4, array[3]);
        }

        [Fact]
        public void SortedArrayRemovedElement()
        {
            var array = new SortedIntArray();
            array.Add(1);
            array.Add(3);
            array.Add(2);
            array.Add(4);
            array.Remove(2);
            Assert.Equal(1, array[0]);
            Assert.Equal(3, array[1]);
            Assert.Equal(4, array[2]);
            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void SortedArrayInsertedElement()
        {
            var array = new SortedIntArray();
            array.Add(1);
            array.Add(3);
            array.Add(2);
            array.Add(4);
            array.Insert(2, 5);
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(3, array[2]);
            Assert.Equal(4, array[3]);
            Assert.Equal(4, array.Count);
            array[1] = 5;
            Assert.Equal(2, array[1]);
            Assert.Equal(4, array.Count);
        }

        [Fact]
        public void SortTwoElements()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(1);
            array[1] = 4;
            Assert.Equal(2, array.Count);
            Assert.Equal(3, array[1]);
        }

        [Fact]
        public void SortsSingleElement()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array[0] = 4;
            Assert.Equal(3, array[0]);
        }

        [Fact]
        public void InsertElementAtEnd()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(2);
            array.Add(5);
            array.Add(4);
            array.Insert(4,6);
            Assert.Equal(6, array[4]);
        }

        [Fact]
        public void InsertIncorrectElementAtEnd()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(2);
            array.Add(5);
            array.Add(4);
            array.Insert(4, 1);
            Assert.Equal(4, array.Count);
        }

        [Fact]
        public void InsertElementAtStart()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(2);
            array.Add(5);
            array.Add(4);
            array.Insert(0, 1);
            Assert.Equal(1, array[0]);
        }

        [Fact]
        public void InsertIncorrectElementAtStart()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(2);
            array.Add(5);
            array.Add(4);
            array.Insert(0, 6);
            Assert.Equal(2, array[0]);
        }

        [Fact]
        public void IncorrectElementAtStart()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(2);
            array.Add(5);
            array.Add(4);
            array[0] = 6;
            Assert.Equal(2, array[0]);
        }

        [Fact]
        public void CorrectElementAtStart()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(2);
            array.Add(5);
            array.Add(4);
            array[0] = 1;
            Assert.Equal(1, array[0]);
        }

        [Fact]
        public void InsertSmallerThanNextBiggerThanPrevious()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(1);
            array.Add(7);
            array.Insert(2, 2);
            Assert.Equal(1, array[0]);
            Assert.Equal(3, array[1]);
            Assert.Equal(7, array[2]);
        }

        [Fact]
        public void SetSmallerThanNextBiggerThanPrevious()
        {
            var array = new SortedIntArray();
            array.Add(3);
            array.Add(1);
            array.Add(7);
            array[2] = 2;
            Assert.Equal(1, array[0]);
            Assert.Equal(3, array[1]);
            Assert.Equal(7, array[2]);
        }
    }
}
