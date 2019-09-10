using System;
using Xunit;

namespace CRUD
{
    public class ObjectEnumeratorTests
    {
        [Fact]
        public void Current()
        {
            var array = new object[4];
            array[0] = 1;
            array[1] = "abcd";
            array[2] = 'a';
            array[3] = 1.52;
            var objectEnum = new ObjectEnumerator(array);
            Assert.Null(objectEnum.Current);
            objectEnum.MoveNext();
            Assert.Equal(1, objectEnum.Current);
            objectEnum.MoveNext();
            Assert.Equal("abcd", objectEnum.Current);
            objectEnum.Reset();
            Assert.Null(objectEnum.Current);
        }
    }
}
