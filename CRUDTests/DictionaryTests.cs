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
            int[] expected = { 17, 2, 10, 18, 12 };
            string[] expectedValues = { "f", "b", "c", "g", "e" };
            Assert.True(dictionary.Remove(7));
            Assert.True(dictionary.Remove(1));
            dictionary.Add(new KeyValuePair<int, string>(17, "f"));
            dictionary.Add(new KeyValuePair<int, string>(18, "g"));
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

        [Fact]
        public void TryGetIndexOfKey()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5)
            {
                { 1, "a" },
                { 2, "b" },
                { 10, "c" },
                { 7, "d" },

            };

            dictionary.TryGetIndexOfKey(1, out int index);
            Assert.Equal(0, index);
            dictionary.TryGetIndexOfKey(2, out int index1);
            Assert.Equal(1, index1);
            dictionary.TryGetIndexOfKey(10, out int index2);
            Assert.Equal(2, index2);
            dictionary.TryGetIndexOfKey(7, out int index3);
            Assert.Equal(3, index3);
            Assert.False(dictionary.TryGetIndexOfKey(8, out _));
        }

        [Fact]
        public void CopyTo()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(5)
            {
                { 1, "a" },
                { 2, "b" },
                { 10, "c" },
                { 7, "d" },
            };

            KeyValuePair<int, string>[] expected = {
                new KeyValuePair<int, string>(1,"a"),
                 new KeyValuePair<int, string>(2,"b"),
                  new KeyValuePair<int, string>(10,"c"),
                   new KeyValuePair<int, string>(7,"d") };

            KeyValuePair<int, string>[] copiedArray = new KeyValuePair<int, string>[dictionary.Count];
            dictionary.CopyTo(copiedArray, 0);
            Assert.Equal(expected, copiedArray);
        }


        [Fact]
        public void MultipleRemoveAndAdd()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>(9)
            {
                { 1, "a" },
                { 2, "b" },
                { 3, "c" },
                { 4, "d" },
                { 5, "e" },
                { 6, "f" },
                { 7, "g" },
                { 8, "h" },
                { 9, "i" }
            };

            dictionary.Remove(5);
            int[] expected5 = { 1, 2, 3, 4, 6, 7, 8, 9 };
            Assert.Equal(expected5, dictionary.Keys);
            dictionary.Remove(2);
            int[] expected2 = { 1, 3, 4, 6, 7, 8, 9 };
            Assert.Equal(expected2, dictionary.Keys);
            dictionary.Remove(8);
            int[] expected8 = { 1, 3, 4, 6, 7, 9 };
            Assert.Equal(expected8, dictionary.Keys);
            dictionary.Add(10, "j");
            dictionary.Add(11, "k");
            dictionary.Add(12, "l");
            int[] expected = { 1, 11, 3, 4, 12, 6, 7, 10, 9 };
            string[] expectedS = { "a", "k", "c", "d", "l", "f" ,"g", "j","i"};
            Assert.Equal(expected, dictionary.Keys);
            Assert.Equal(expectedS, dictionary.Values);
        }
    }
}
