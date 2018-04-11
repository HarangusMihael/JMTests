using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogueTest
{
    class Segment<T>
    {
        private T[] students;
        private int start;
        private int end;

        public Segment(T[] input)
            : this(input, 0, input.Length - 1)
        {
        }

        public Segment(T[] students, int start, int end)
        {
            this.students = students;
            this.start = start;
            this.end = end;
        }

        internal T Get(int index)
        {
            if (index + start > end)
             throw new IndexOutOfRangeException();

            return students[index + start];
        }

        internal Segment<T> SubSegment(int firstIndex, int secondIndex)
        {
            if (secondIndex - firstIndex > end - start)
                throw new IndexOutOfRangeException();

            return new Segment<T>(students, start + firstIndex, start + secondIndex);
        }

        internal int Length => end - start + 1;

        internal void Swap(int i, int j)
        {
            var temp = students[i];
            students[i] = students[j];
            students[j] = temp;
        }
    }
}

