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
            array.Add(1);
            Assert.True(array.Contains(1));
        }

        [Fact]
        public void AddTwoElements()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            Assert.True(array.Contains(1));
            Assert.True(array.Contains(2));
        }

        [Fact]
        public void GetNumberOfElements()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            Assert.Equal(2, array.Count);
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

        [Fact]
        public void SetElementOfAnIndex()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            array.SetElement(2, 4);
            Assert.Equal(4, array.Element(2));
        }

        [Fact]
        public void ReturnsTrueIfElementIsContained()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            Assert.True(array.Contains(2));
        }

        [Fact]
        public void ReturnsFalseIfElementIsNotContained()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            Assert.False(array.Contains(11));
        }

        [Fact]
        public void IndexOfExistingElement()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            Assert.Equal(2, array.IndexOf(3));
        }

        [Fact]
        public void IndexOfNonExistingElement()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            Assert.Equal(-1, array.IndexOf(11));
        }

        [Fact]
        public void InsertElement()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            array.Insert(1, 7);
            Assert.True(array.Contains(7));
            Assert.Equal(1, array.IndexOf(7));
        }

        [Fact]
        public void InsertElementAtEnd()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            array.Add(4);
            array.Insert(3, 9);
            Assert.True(array.Contains(9));
            Assert.Equal(3, array.IndexOf(9));
            Assert.Equal(6, array.Count);
        }

        [Fact]
        public void ClearElements()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            array.Clear();
            Assert.Equal(0,array.Count);
        }

        [Fact]
        public void RemoveElement()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            array.Remove(2);
            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void RemoveLastElement()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            array.Remove(5);
            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void RemoveElementAtIndex()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            array.RemoveAt(2);
            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void RemoveElementAtLastIndex()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            array.RemoveAt(3);
            Assert.Equal(3, array.Count);
        }

        [Fact]
        public void LengthIsDoubleForFifthElement()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            array.Add(3);
            Assert.Equal(5, array.Count);
        }

        [Fact]
        public void LengthIsDoubledForInsertingElementInACompleteArray()
        {
            var array = new IntArray();
            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(5);
            array.Insert(3, 2);
            Assert.Equal(5, array.Count);
        }

    }
}
