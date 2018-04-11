using System;
using System.Linq;
using Xunit;

namespace ChainList
{
    public class ChainListTest
    {
        [Fact]
        public void AddOneElementTest()
        {
            var List = new ChainList<int> { 1};

            Assert.Equal(new int[] { 1}, List);
        }

        [Fact]
        public void AddOneElement2Test()
        {
            var List = new ChainList<int> { 1, 2 };

            Assert.Equal(new int[] { 1, 2 }, List);
        }

        [Fact]
        public void AddOneElement3Test()
        {
            var List = new ChainList<int> { 1, 2, 3, 4, 5 };

            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, List);
        }

        [Fact]
        public void AddOneElement4Test()
        {
            var List = new ChainList<int> { 1, 2, 3, 4, 5 };

            Assert.Equal(new int[] { 5, 4, 3, 2, 1}, List.GetReverseEnumerator());
        }

        [Fact]
        public void AddFirstTest()
        {
            var List = new ChainList<int> { 1, 2, 3 };

            List.AddFirst(8);

            Assert.Equal(new int[] { 8, 1, 2, 3}, List);
        }

        [Fact]
        public void InsertAtTest()
        {
            var List = new ChainList<int> { 1, 2, 3 };

            List.InsertAt(0, 8);

            Assert.Equal(new int[] { 1, 8, 2, 3 }, List);
        }

        [Fact]
        public void DeleteTest()
        {
            var List = new ChainList<int> { 1, 2, 3, 4 };

            List.Delete(3);

            Assert.Equal(new int[] { 1, 2, 4 }, List);
        }

        [Fact]
        public void InsertAtExceptionTest()
        {
            var List = new ChainList<int> { 1, 2, 3 };

            Assert.Throws<ArgumentOutOfRangeException>(() => List.InsertAt(4, 8));
        }

        [Fact]
        public void DeleteExceptionTest()
        {
            var List = new ChainList<int> { 1, 2, 3, 4 };
            List.Delete(10);
            Assert.Equal(new int[] { 1, 2, 3, 4 }, List);
        }

        [Fact]
        public void FindFromBegginingTest()
        {
            var List = new ChainList<int> { 1, 2, 3, 4 };

            Node<int> result = new Node<int>(3);
            Node<int> expected = List.FindFromBeggining(3);

            Assert.Equal(result.Value, expected.Value);
        }

        [Fact]
        public void FindFromEndTest()
        {
            var List = new ChainList<int> { 1, 2, 3, 4 };

            Node<int> result = new Node<int>(2);
            Node<int> expected = List.FindFromEnd(2);

            Assert.Equal(result.Value, expected.Value);
        }
    }
}
