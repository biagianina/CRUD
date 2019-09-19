using System;
using System.Collections.Generic;
using Xunit;

namespace CRUD
{
    public class DictionaryTests
    {
        [Fact]
        public void AddElement()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5)
            {
                { 1, "a" },
                { 2, "b" }
            };
            Assert.True(dictionary.ContainsKey(2));
            dictionary.Add(6, "c");
            Assert.True(dictionary.ContainsKey(6));
            Assert.True(dictionary.ContainsKey(1));
            Assert.False(dictionary.ContainsKey(7));
            var item = new KeyValuePair<int, string>(7, "d");
            dictionary.Add(item);
            Assert.True(dictionary.ContainsKey(item.Key));
        }

        [Fact]
        public void This()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5)
            {
                { 1, "a" },
                { 2, "b" },
                { 6, "c" },
                { 7, "d" }
            };
            Assert.Equal("a", dictionary[1]);
            Assert.Equal("b", dictionary[2]);
            Assert.Equal("c", dictionary[6]);
            Assert.Equal("d", dictionary[7]);
            Assert.Null(dictionary[3]);
        }

        [Fact]
        public void Values()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5)
            {
                { 1, "a" },
                { 2, "b" },
                { 6, "c" },
                { 7, "d" }
            };
            string[] expected = { "a", "b", "c", "d" };
            Assert.Equal(expected, dictionary.Values);
        }

        [Fact]
        public void Keys()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5)
            {
                { 1, "a" },
                { 2, "b" },
                { 6, "c" },
                { 7, "d" }
            };
            int[] expected = { 1, 2, 6, 7 };
            Assert.Equal(expected, dictionary.Keys);
        }

        [Fact]
        public void RemoveFirstFromBucket()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5)
            {
                { 1, "a" },
                { 2, "b" },
                { 6, "c" },
                { 7, "d" }
            };
            int[] expected = { 1, 2, 6 };
            string[] expectedValues = { "a", "b", "c" };
            Assert.True(dictionary.Remove(7));
            Assert.Equal(expected, dictionary.Keys);
            Assert.Equal(expectedValues, dictionary.Values);
        }

        [Fact]
        public void RemoveFromBucket()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5)
            {
                { 1, "a" },
                { 2, "b" },
                { 10, "c" },
                { 7, "d" },
                { 12, "e" }
            };
            int[] expected = { 17, 2, 10, 12 };
            string[] expectedValues = { "f", "b", "c", "e" };
            Assert.True(dictionary.Remove(7));
            Assert.True(dictionary.Remove(1));
            dictionary.Add(new KeyValuePair<int, string>(17, "f"));
            Assert.Equal(expected, dictionary.Keys);
            Assert.Equal(expectedValues, dictionary.Values);
        }

        [Fact]
        public void TryGetValue()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5)
            {
                { 1, "a" },
                { 2, "b" },
                { 10, "c" },
                { 7, "d" },
                { 12, "e" }
            };
            Assert.True(dictionary.TryGetValue(1, out _));
        }

        [Fact]
        public void TryAddMoreThanAllowed()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5)
            {
                { 1, "a" },
                { 2, "b" },
                { 10, "c" },
                { 7, "d" },
                { 12, "e" }
            };
            Assert.Throws<InvalidOperationException>(() => dictionary.Add(new KeyValuePair<int, string>(15, "g")));
        }

        [Fact]
        public void TryAddKeyDuplicate()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5)
            {
                { 1, "a" },
                { 2, "b" },
                { 10, "c" },
                { 7, "d" },
                
            };
            Assert.Throws<ArgumentException>(() => dictionary.Add(new KeyValuePair<int, string>(2, "g")));
        }


    }
}
