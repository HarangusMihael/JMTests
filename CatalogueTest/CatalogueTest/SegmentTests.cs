using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CatalogueTest
{
    public class SegmentTests
    {
        Student c = new Student("c", new Subject[] { new Subject("", new double[] { }) });
        Student a = new Student("a", new Subject[] { new Subject("", new double[] { }) });
        Student d = new Student("d", new Subject[] { new Subject("", new double[] { }) });
        Student f = new Student("f", new Subject[] { new Subject("", new double[] { }) });
        Student b = new Student("b", new Subject[] { new Subject("", new double[] { }) });

        [Fact]
        public void SegmentTest()
        {
            var students = new Student[] { a, b, c, f};

            var segment = new Segment<Student>(students, 0, 2);
            Assert.Equal(a, segment.Get(0));
        }

        [Fact]
        public void ReturnOneElementTest()
        {
            var students = new Student[] { a, b, c, f };

            var segment = new Segment<Student>(students, 2, 3);
            Assert.Equal(c, segment.Get(0));
            Assert.Equal(f, segment.Get(1));
        }

        [Fact]
        public void InvalidElementTest()
        {
            var students = new Student[] { a, b, c, f };

            var segment = new Segment<Student>(students, 2, 3);
            Assert.Equal(c, segment.Get(0));
            Assert.Throws<IndexOutOfRangeException>(() => segment.Get(2));
        }

        [Fact]
        public void ReturnSegmentOf()
        {
            var students = new Student[] { a, b, c, f };

            var result = new Student[] { b, c };

            var segment = new Segment<Student>(students, 1, 2);
            var subSegment = segment.SubSegment(0, 0);
            Assert.Equal(b, subSegment.Get(0));
            Assert.Throws<IndexOutOfRangeException>(() => subSegment.Get(1));
        }

        [Fact]
        public void SegmentLength()
        {
            var students = new Student[] { a, b, c, f };

            var result = new Student[] { b, c };
            var segment = new Segment<Student>(students, 1, 2);
            
            Assert.Throws<IndexOutOfRangeException>(() => segment.SubSegment(0, 2));
        }

        [Fact]
        public void SwapTest()
        {
            var students = new Student[] { a, b };
            var segment = new Segment<Student>(students, 0, 1);
            segment.Swap(0, 1);
            var result = new Student[] { b, a };
            Assert.Equal(result, students);
        }
    }
}
