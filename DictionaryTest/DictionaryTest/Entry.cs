using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryTest
{
    class Entry<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;

        public Entry(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
