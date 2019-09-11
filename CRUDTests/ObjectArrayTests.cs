using System;
using Xunit;

namespace CRUD
{
    public class ObjectArrayTests
    {
        [Fact]
        public void AddAndSetElements()
        {
            var objectArray = new List<int>
            {
                2,
                1,
                4,
                5,
                6
            };
            
            Assert.Equal(2, objectArray[0]);
            Assert.Equal(1, objectArray[1]);
            Assert.Equal(4, objectArray[2]);
            Assert.Equal(5, objectArray[3]);
            Assert.Equal(6, objectArray[4]);
            Assert.Equal(5, objectArray.Count);
        }

        [Fact]
        public void InsertElement()
        {
            var objectArray = new List<char>
            {
                'a',
                'b',
                'c'
            };
            objectArray.Insert(1, 'd');
            Assert.Equal('a', objectArray[0]);
            Assert.Equal('d', objectArray[1]);
            Assert.Equal('b', objectArray[2]);
            Assert.Equal('c', objectArray[3]);
        }

        [Fact]
        public void IndexOFElements()
        {
            var objectArray = new List<string>
            {
                "abcd"
            };
            Assert.Equal(0, objectArray.IndexOf("abcd"));
            objectArray.Add("1");
            Assert.Equal(1, objectArray.IndexOf("1"));

        }
   
        [Fact]
        public void ClearElements()
        {
            var objectArray = new List<int>
            {
                1
            };
            objectArray[1] = 1;
            objectArray[2] = 2;
            objectArray[3] = 3;
            objectArray.Add(4);
            objectArray.Clear();
            Assert.Equal(0, objectArray.Count);
        }

        [Fact]
        public void RemoveElementAt()
        {
            var objectArray = new List<int>
            {
                1
            };
            Assert.Equal(0, objectArray.IndexOf(1));
            objectArray.Add(2);
            objectArray.RemoveAt(0);
            Assert.Equal(2, objectArray[0]);

        }

        [Fact]
        public void RemoveElement()
        {
            var objectArray = new List<string>
            {
                "abcd"
            };
            Assert.Equal(0, objectArray.IndexOf("abcd"));
            objectArray.Add("test");
            objectArray.Remove("abcd");
            Assert.Equal("test", objectArray[0]);

        }

    }
}
