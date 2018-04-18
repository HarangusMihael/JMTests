using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryTest
{
    class Map<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private IList<Entry<TKey, TValue>>[] bucket;
        private int counter = 0;

        public Map(int capacity = 4)
        {
            bucket = new IList<Entry<TKey, TValue>>[capacity];
            for (int i = 0; i < capacity; i++)
                bucket[i] = new List<Entry<TKey, TValue>>();
        }

        public TValue this[TKey key]
        {
            get
            {
                if (!TryGetValue(key, out TValue value))
                    throw new KeyNotFoundException();

                return value;
            }
            set
            {
                TValue newValue = value;
                if (TryGetValue(key, out value))
                {
                    var index = key.GetHashCode();
                    foreach (var item in bucket[index])
                    {
                        if (!item.Value.Equals(newValue))
                            item.Value = newValue;
                    }
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                TKey[] array = new TKey[counter];
                int j = 0;

                foreach (var item in this)
                {
                    array[j] = item.Key;
                    j++;
                }

                return array;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                TValue[] array = new TValue[counter];
                int j = 0;

                foreach (var item in this)
                {
                    array[j] = item.Value;
                    j++;
                }

                return array;
            }
        }

        public int Count => counter;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(TKey key, TValue value)
        {
            var pos = GetPosition(key, bucket.Length);

            foreach (var item in bucket[pos])
            {
                if (item.Key.Equals(key))
                    throw new ArgumentException();
            }

            Entry<TKey, TValue> kvp = new Entry<TKey, TValue>(key, value);
            bucket[pos].Add(kvp);
            counter++;
        }

        private int GetPosition(TKey key, int length)
        {
            var hash = key.GetHashCode();
            return Math.Abs(hash % length);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            for (int i = 0; i < bucket.Length; i++)
                bucket[i].Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            var index = item.Key.GetHashCode();

            return ContainsFunction(index, item, default(TKey));
        }

        public bool ContainsKey(TKey key)
        {
            var index = key.GetHashCode();

            return ContainsFunction(index, default(KeyValuePair<TKey, TValue>), key);
        }

        public bool ContainsFunction(int index, KeyValuePair<TKey, TValue> item, TKey key)
        {
            foreach (var pair in bucket[index])
            {
                if (pair.Key.Equals(item.Key) && pair.Value.Equals(item.Value))
                    return true;
                if (pair.Key.Equals(key))
                    return true;
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex == -1)
                throw new ArgumentOutOfRangeException();
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException();

            for (int i = 0; i < bucket.Length; i++)
            {
                var current = bucket[i];
                foreach (var item in current)
                {
                    if (item != null)
                    {
                        array[arrayIndex] = new KeyValuePair<TKey, TValue>(item.Key, item.Value);
                        arrayIndex++;
                    }
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int index = 0; index < bucket.Length; index++)
            {
                var current = bucket[index];
                foreach (var item in current)
                {
                    yield return new KeyValuePair<TKey, TValue>(item.Key, item.Value);
                }
            }
        }

        public bool Remove(TKey key)
        {
            var index = key.GetHashCode();
            var current = bucket[index];
            foreach (var item in current)
            {
                if (item.Key.Equals(key))
                {
                    bucket[index].Remove(item);
                    counter--;
                    return true;
                }
            }
            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var index = key.GetHashCode();
            foreach (var item in bucket[index])
            {
                if (item.Key.Equals(key))
                {
                    value = item.Value;
                    return true;
                }
            }
            value = default(TValue);
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
