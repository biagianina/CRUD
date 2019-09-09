using System;
using Xunit;

namespace CRUD
{
    public class ObjectArrayTests
    {
        [Fact]
        public void AddAndSetElements()
        {
            var objectArray = new ObjectArray();
            objectArray.Add("abcd");
            objectArray[1] = 1;
            objectArray[2] = 1.39;
            objectArray[3] = 'a';
            objectArray.Add("test");
            Assert.Equal("abcd", objectArray[0]);
            Assert.Equal(1, objectArray[1]);
            Assert.Equal(1.39, objectArray[2]);
            Assert.Equal('a', objectArray[3]);
            Assert.Equal("test", objectArray[4]);
            Assert.Equal(5, objectArray.Count);
        }

        [Fact]
        public void InsertElement()
        {
            var objectArray = new ObjectArray();
            objectArray.Add('a');
            objectArray.Add('b');
            objectArray.Add('c');
            objectArray.Insert(1, 'd');
            Assert.Equal('a', objectArray[0]);
            Assert.Equal('d', objectArray[1]);
            Assert.Equal('b', objectArray[2]);
            Assert.Equal('c', objectArray[3]);
        }

        [Fact]
        public void IndexOFElements()
        {
            var objectArray = new ObjectArray();
            objectArray.Add("abcd");
            Assert.Equal(0, objectArray.IndexOf("abcd"));
            objectArray.Add("test");
            Assert.Equal(1, objectArray.IndexOf("test"));

        }
   
        [Fact]
        public void ClearElements()
        {
            var objectArray = new ObjectArray();
            objectArray.Add("abcd");
            objectArray[1] = 1;
            objectArray[2] = 1.39;
            objectArray[3] = 'a';
            objectArray.Add("test");
            objectArray.Clear();
            Assert.Equal(0, objectArray.Count);
        }

        [Fact]
        public void RemoveElementAt()
        {
            var objectArray = new ObjectArray();
            objectArray.Add("abcd");
            Assert.Equal(0, objectArray.IndexOf("abcd"));
            objectArray.Add("test");
            objectArray.RemoveAt(0);
            Assert.Equal("test", objectArray[0]);

        }

        [Fact]
        public void RemoveElement()
        {
            var objectArray = new ObjectArray();
            objectArray.Add("abcd");
            Assert.Equal(0, objectArray.IndexOf("abcd"));
            objectArray.Add("test");
            objectArray.Remove("abcd");
            Assert.Equal("test", objectArray[0]);

        }

    }
}
