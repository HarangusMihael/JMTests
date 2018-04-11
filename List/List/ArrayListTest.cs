using System;
using Xunit;

namespace List
{
    public class ArrayListTest
    {
        [Fact]
        public void CountTest()
        {
            var array = new ArrayList<string>();
            array.Add("a");

            Assert.Equal("a", array[0]);
            Assert.Equal(1, array.Count);
        }

        [Fact]
        public void CountTest2()
        {
            var array = new ArrayList<string>(1) { "a", "b", "c", "d", "e" };
            Assert.Equal(5, array.Count);
        }

        [Fact]
        public void CountTest3()
        {
            var array = new ArrayList<string>(1) { "a", "b", "c", "d", "e" };
            Assert.Equal("c", array[2]);
        }

        [Fact]
        public void EnumerableTest()
        {
            var array = new ArrayList<int>() { 1, 2, 3 };
            Assert.Equal(new int[] { 1, 2, 3 }, array);
        }

        [Fact]
        public void OutOfRangeTestForGet()
        {
            var array = new ArrayList<string>();
            array.Add("a");

            Assert.Throws<ArgumentOutOfRangeException>(() => array[2]);
        }

        [Fact]
        public void OutOfRangeTestForGetMinus()
        {
            var array = new ArrayList<string>();
            array.Add("a");

            Assert.Throws<ArgumentOutOfRangeException>(() => array[-1]);
        }

        [Fact]
        public void OutOfRangeTestForSet()
        {
            var array = new ArrayList<string>(1);
            array.Add("a");
            array.Add("b");
            Assert.Throws<ArgumentOutOfRangeException>(() => array[2] = "b");
        }

        [Fact]
        public void OutOfRangeTestForSetMinus()
        {
            var array = new ArrayList<string>(1);
            array.Add("a");
            array.Add("b");
            Assert.Throws<ArgumentOutOfRangeException>(() => array[-1] = "b");
        }

        [Fact]
        public void ClearTest()
        {
            var array = new ArrayList<string>();
            array.Add("a");
            array.Add("b");
            array.Clear();
            Assert.Throws<ArgumentOutOfRangeException>(() => array[0]);
        }
        [Fact]
        public void ContainsTest()
        {
            var array = new ArrayList<string>(1) { "a", "b", "c", "d", "e" };

            Assert.Contains("c", array);
        }

        [Fact]
        public void CopyToTest()
        {
            var array = new ArrayList<string>(4) { "a", "b", "c", "d" };
            var newArray = new string[6];
            array.CopyTo(newArray, 1);

            var test = new ArrayList<string>() { null, "a", "b", "c", "d", null };

            Assert.Equal(test, newArray);
        }

        [Fact]
        public void CopyToArgumentExceptionTest()
        {
            var array = new ArrayList<string>() { "a", "b", "c", "d" };
            var newArray= new string[2];
            Assert.Throws<ArgumentException>(() => array.CopyTo(newArray, 1));
        }

        [Fact]
        public void CopyToExceptionTest()
        {
            var array = new ArrayList<string>() { "a","b"};
            var newArray = new string[2];

            Assert.Throws<ArgumentOutOfRangeException>(() => array.CopyTo(newArray, -1));
        }

       [Fact]
       public void IndexOfTest()
        {
            var array = new ArrayList<string>() { "a", "b" };

            int index = array.IndexOf("b");

            Assert.Equal(1, index);
        }

        [Fact]
        public void IndexOfExceptionTest()
        {
            var array = new ArrayList<string>() { "a", "b" };

            int index = array.IndexOf("0");

            Assert.Equal(-1, index);
        }

        [Fact]
        public void InsertItemTest()
        {
            var array = new ArrayList<int>() { 1, 3, 4 };

            array.Insert(1, 2);

            var result = new ArrayList<int>() { 1, 2, 3, 4 };

            Assert.Equal(result, array);
        }

        [Fact]
        public void InsertItemTest2()
        {
            var array = new ArrayList<int>(1) { 1 };

            array.Insert(0, 2);

            var result = new ArrayList<int>() {2, 1};

            Assert.Equal(result, array);
        }

        [Fact]
        public void InsertItemExceptionTest()
        {
            var array = new ArrayList<int>() { 1, 3, 4 };

            Assert.Throws<ArgumentOutOfRangeException>(() => array.Insert(3,2));
        }

        [Fact]
        public void RemoveAtTest()
        {
            var array = new ArrayList<int>() { 1, 2, 3, 4 };

            array.RemoveAt(1);

            var result = new ArrayList<int>() { 1, 3, 4 };

            Assert.Equal(result, array);
        }

        [Fact]
        public void RemoveTest()
        {
            var array = new ArrayList<int>() { 1, 2, 3, 4 };

            Assert.True(array.Remove(3));
        }


        [Fact]
        public void RemoveAtExceptionTest()
        {
            var array = new ArrayList<int>() { 1, 2, 3, 4 };

            Assert.Throws<ArgumentOutOfRangeException>(() => array.RemoveAt(4));
        }
    }
}
