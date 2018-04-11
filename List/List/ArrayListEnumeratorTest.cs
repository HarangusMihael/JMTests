using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace List
{
    public class ArrayListEnumeratorTest
    {
        [Fact]
        public void CurrentIndexTest()
        {
            var enumerator = new ArrayListEnumerator<string>(new string [] { "a"}, 1);
            enumerator.MoveNext();
            Assert.Equal("a", enumerator.Current);
        }

        [Fact]
        public void MoveNextTest()
        {
            var enumerator = new ArrayListEnumerator<string>(new string[] { "a","b" }, 2);
            enumerator.MoveNext();
            enumerator.MoveNext();
            Assert.Equal("b", enumerator.Current);
        }

        [Fact]
        public void MoveNextExceptionTest()
        {
            var enumerator = new ArrayListEnumerator<string>(new string[] { "a", "b" }, 2);
            enumerator.MoveNext();
            enumerator.MoveNext();
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void ResetTest()
        {
            var enumerator = new ArrayListEnumerator<string>(new string[] { "a", "b" }, 2);
            enumerator.MoveNext();
            enumerator.MoveNext();
            enumerator.MoveNext();
            enumerator.Reset();
            enumerator.MoveNext();
            Assert.Equal("a", enumerator.Current);
        }

        [Fact]
        public void MoveNextInvalidOperationExceptionTest()
        {
            var enumerator = new ArrayListEnumerator<string>(new string[] { "a","b","c" }, 3);

            Assert.Throws<IndexOutOfRangeException>(() => enumerator.Current);
        }
    }
}
