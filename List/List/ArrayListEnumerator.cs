using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace List
{
    class ArrayListEnumerator<T> : IEnumerator<T>
    {
        private T[] array;
        private int currentIndex;
        private int count;

        public ArrayListEnumerator(T[] originalArray, int counter)
        {
            array = originalArray;
            currentIndex = -1;
            count = counter;
        }

        public T Current
        {
            get
            {
                if (currentIndex == -1)
                    throw new IndexOutOfRangeException();
               return array[currentIndex];
            }
        }
  
        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (currentIndex + 1 >= count)
                return false;

            currentIndex++;
            return true;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}
