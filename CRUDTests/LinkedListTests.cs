using System;
using Xunit;

namespace CRUD
{
    public class LinkedListTests
    {
        [Fact]
        public void AddElement()
        {
            var ll = new LinkedList<string>
            {
                "test",
                "abc"
            };

            Assert.Equal("test", ll.First.Value);
            Assert.Equal("abc", ll.Last.Value);

        }

        [Fact]
        public void ClearElements()
        {
            var ll = new LinkedList<string>
            {
                "test",
                "abc",
                "tst",
                "ab"
            };
            ll.Clear();
            Assert.Null(ll.First);
            Assert.Null(ll.Last);
          
        }

        [Fact]
        public void ContainsElement()
        {
            var ll = new LinkedList<string>
            {
                "test",
                "abc",
                "tst",
                "ab"
            };

            Assert.Contains("test", ll);
            Assert.DoesNotContain("arterter", ll);
        }

        [Fact]
        public void FirstAndLastElement()
        {
            var ll = new LinkedList<string>
            {
                "test",
                "abc",
                "tst",
                "ab"
            };

            Assert.Equal("test", ll.First.Value);
            Assert.Equal("ab", ll.Last.Value);
        }

        [Fact]
        public void AddAfter()
        {
            var ll = new LinkedList<string>
            {
                "test",
                "abc",
                "tst",
                "ab"
            };

            ll.AddAfter(ll.Find("test"), "cdf");
            Assert.Equal("cdf", ll.Find("test").Next.Value);
        }

        [Fact]
        public void AddBefore()
        {
            var ll = new LinkedList<string>
            {
                "test",
                "abc",
                "tst",
                "ab"
            };

            ll.AddBefore(ll.Find("test"), "cdf");
            Assert.Equal("cdf", ll.Find("test").Previous.Value);
        }

        [Fact]
        public void AddFirst()
        {
            var ll = new LinkedList<string>
            {
                "test",
                "abc",
                "tst",
                "ab"
            };

            ll.AddFirst( "cdf");
            Assert.Equal("cdf", ll.First.Value);
        }

        [Fact]
        public void AddLast()
        {
            var ll = new LinkedList<string>
            {
                "test",
                "abc",
                "tst",
                "ab"
            };

            ll.AddLast("cdf");
            Assert.Equal("cdf", ll.Last.Value);
        }

        [Fact]
        public void Find()
        {
            var ll = new LinkedList<string>
            {
                "test",
                "abc",
                "tst",
                "ab"
            };

            Assert.Equal("test", ll.Find("test").Value);
            Assert.Null(ll.Find("cdf"));
        }

        [Fact]
        public void CopyTo()
        {
            
            var ll = new LinkedList<string>
            {
                "test",
                "abc",
                "tst",
                "ab"
            };

            string[] targetArray = new string[ll.Count];
            ll.CopyTo(targetArray, 0);
            Assert.Equal(ll, targetArray);
        }

        [Fact]
        public void Remove()
        {

            var ll = new LinkedList<string>
            {
                "test",
                "abc",
                "tst",
                "ab"
            };

            Assert.True(ll.Remove("test"));
            Assert.False(ll.Remove("a"));
        }

        [Fact]
        public void RemoveFirst()
        {

            var ll = new LinkedList<string>
            {
                "test",
                "abc",
                "tst",
                "ab"
            };

            ll.RemoveFirst();
            Assert.Equal("abc", ll.First.Value);
        }

        [Fact]
        public void RemoveLast()
        {

            var ll = new LinkedList<string>
            {
                "test",
                "abc",
                "tst",
                "ab"
            };

            ll.RemoveLast();
            Assert.Equal("tst", ll.Last.Value);
        }
       
    }
}
