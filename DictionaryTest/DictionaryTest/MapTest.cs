using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DictionaryTest
{
    public class MapTest
    {
        [Fact]
        public void AddTest()
        {
            Map<int, int> dictionary = new Map<int, int>();

            dictionary.Add(1, 10);

            Assert.Equal(new Map<int, int> { { 1, 10 } }, dictionary);
        }

        [Fact]
        public void Test()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10},
                { 2, 20}
            };

            Assert.Equal(new Map<int, int> { { 1, 10 }, { 2, 20 } }, dictionary);
        }

        [Fact]
        public void ContainsKeyTest()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10},
                { 2, 20}
            };

            Assert.True(dictionary.ContainsKey(1));
            Assert.True(dictionary.ContainsKey(1));
        }

        [Fact]
        public void ContainsKeyValuePairTest()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10},
                { 2, 20}
            };

            Assert.True(dictionary.Contains(new System.Collections.Generic.KeyValuePair<int, int>(2, 20)));
        }

        [Fact]
        public void RemoveTest()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10},
                { 2, 20}
            };

            dictionary.Remove(2);

            Assert.Equal(new Map<int, int> { { 1, 10 } }, dictionary);
        }

        [Fact]
        public void AddPairExceptionTest()
        {
            Map<int, int> dictionary = new Map<int, int>();

            dictionary.Add(1, 10);

            Assert.Throws<ArgumentException>(() =>
             dictionary.Add(new System.Collections.Generic.KeyValuePair<int, int>(1, 10)));
        }


        [Fact]
        public void AddPairTest()
        {
            Map<int, int> dictionary = new Map<int, int>();

            dictionary.Add(1, 10);
            dictionary.Add(new KeyValuePair<int, int>(2, 20));

            Assert.Equal(new Map<int, int> { { 1, 10 }, { 2, 20 } }, dictionary);
        }

        [Fact]
        public void ClearTest()
        {
            Map<int, int> dictionary = new Map<int, int>();

            dictionary.Add(1, 10);
            dictionary.Add(2, 20);
            dictionary.Add(3, 30);
            dictionary.Clear();

            Assert.Equal(new Map<int, int> { }, dictionary);
        }

        [Fact]
        public void ClearTest2()
        {
            Map<int, int> dictionary = new Map<int, int>();

            dictionary.Add(1, 10);
            dictionary.Add(2, 20);
            dictionary.Add(3, 30);
            dictionary.Clear();
            dictionary.Add(3, 30);

            Assert.Equal(new Map<int, int> { { 3, 30 } }, dictionary);
        }

        [Fact]
        public void CopyToTest()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10 },
                { 2, 20 }
            };
            KeyValuePair<int, int>[] array = new KeyValuePair<int, int>[2];

            dictionary.CopyTo(array, 0);

            Assert.Equal(new[] { new KeyValuePair<int, int>(1, 10), new KeyValuePair<int, int>(2, 20) }, array);
        }

        [Fact]
        public void CopyToExceptionTest()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10 },
                { 2, 20 }
            };
            KeyValuePair<int, int>[] array = new KeyValuePair<int, int>[1];

            Assert.Throws<ArgumentException>(() => dictionary.CopyTo(array, 0));
        }

        [Fact]
        public void CopyToIndexExceptionTest()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10 },
                { 2, 20 }
            };
            KeyValuePair<int, int>[] array = new KeyValuePair<int, int>[1];

            Assert.Throws<ArgumentOutOfRangeException>(() => dictionary.CopyTo(array, -1));
        }

        [Fact]
        public void CopyToArrayIndexExceptionTest()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10 },
                { 2, 20 }
            };
            KeyValuePair<int, int>[] array = new KeyValuePair<int, int>[2];

            Assert.Throws<ArgumentException>(() => dictionary.CopyTo(array, 1));
        }

        [Fact]
        public void GetValueTest()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10 },
                { 2, 20 }
            };

            Assert.True(dictionary.TryGetValue(2, out int item));
        }

        [Fact]
        public void GetByKeyTest()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10 },
                { 2, 20 }
            };

            Assert.Equal(20, dictionary[2]);
        }

        [Fact]
        public void RemovePairTest()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10},
                { 2, 20}
            };

            dictionary.Remove(new KeyValuePair<int, int>(2, 20));

            Assert.Equal(new Map<int, int> { { 1, 10 } }, dictionary);
        }

        [Fact]
        public void KeysTest()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10},
                { 2, 20}
            };

            Assert.Equal(new int[] { 1, 2}, dictionary.Keys);
        }

        [Fact]
        public void ValuesTest()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10},
                { 2, 20}
            };

            Assert.Equal(new int[] { 10, 20 }, dictionary.Values);
        }

        [Fact]
        public void ChangeByKeyTest()
        {
            Map<int, int> dictionary = new Map<int, int>
            {
                { 1, 10 },
                { 2, 20 }
            };
            dictionary[2] = 30;
            Assert.Equal(30, dictionary[2]);
        }
    }
}
