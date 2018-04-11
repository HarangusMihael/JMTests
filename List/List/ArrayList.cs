using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace List
{
    class ArrayList<T> : IList<T>
    {
        private int counter = 0;
        private T[] array;

        public ArrayList(int initialCapacity = 8)
        {
            array = new T[initialCapacity];
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return array[index];
            }
            set
            {
                ValidateIndex(index);
                array[index] = value;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index >= counter || index < 0)
                throw new ArgumentOutOfRangeException();
        }

        public int Count => counter;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            EnsureCapacity();
            array[counter++] = item;
        }

        private void EnsureCapacity()
        {
            if (array.Length == counter)
            {
                Array.Resize(ref array, counter * 2);
            }
        }

        public void Clear()
        {
            counter = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < counter; i++)
                if (array[i].Equals(item))
                    return true;
            return false;
        }

        public void CopyTo(T[] newArray, int arrayIndex)
        {
            if (counter > newArray.Length - arrayIndex)
               throw new ArgumentException();

            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();

            int k = 0;
            for (int i = arrayIndex; k < counter; i++)
            {
                newArray[i] = array[k];
                k++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayListEnumerator<T>(array, counter);
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == null)
                {
                    return -1;
                }
                else if (array[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);

            EnsureCapacity();
            counter++;
            for (int i = array.Length - 1; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = item;
        }

        public bool Remove(T item)
        {
            if (IndexOf(item) == -1)
                return false;
            RemoveAt(IndexOf(item));
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);

            counter--;
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
