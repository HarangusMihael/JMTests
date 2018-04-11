using System;
using Xunit;

namespace CatalogueTest
{
    public class CatalogueTest
    {
        [Fact]
        public void OrderAlphabeticalTest()
        {
            Student b = new Student("b", new Subject[] { new Subject("Mathematics",new double[] { 5, 8, 9 }),
                                                       new Subject("Literature",new double[] { 7, 7, 7 })});

            Student a = new Student("a", new Subject[] { new Subject("Literature",new double[] { 6, 8, 7}),
                                                       new Subject("Mathematics",new double[] { 7, 9, 9 })});
            var students = new Student[] { b, a };

            var result = new Student[] { a, b };
            Assert.Equal(result, OrderAlphabeticallyShellSort(students));

        }
        [Fact]
        public void Test2()
        {
            Student c = new Student("c", new Subject[] { new Subject("", new double[] { }) });
            Student a = new Student("a", new Subject[] { new Subject("", new double[] { }) });
            Student d = new Student("d", new Subject[] { new Subject("", new double[] { }) });
            Student f = new Student("f", new Subject[] { new Subject("", new double[] { }) });
            Student b = new Student("b", new Subject[] { new Subject("", new double[] { }) });

            var actual = new Student[] { c, a, d, f, b };
            var expected = new Student[] { a, b, c, d, f };

            Assert.Equal(expected, OrderAlphabeticallyShellSort(actual));
        }

        [Fact]
        public void OrderByOverallGradesTest()
        {
            Student b = new Student("b", new Subject[] {
                                            new Subject("Mathematics",new double[] { 5, 5 }),
                                            new Subject("Literature",new double[] { 5 })});

            Student a = new Student("a", new Subject[] {
                                            new Subject("Literature",new double[] { 6, 8, 6}),
                                            new Subject("Mathematics",new double[] { 10})});
            var students = new Student[] { b, a};

            var result = new Student[] { a, b};

            QuickSortByOverallGrades(students);
            Assert.Equal(result, students);
        }

        [Fact]
        public void FindSpecificOverallGradesTest()
        {
            Student b = new Student("b", new Subject[] {
                                            new Subject("Mathematics",new double[] { 5, 5 }),
                                            new Subject("Literature",new double[] { 5 })});

            Student a = new Student("a", new Subject[] {
                                            new Subject("Literature",new double[] { 6, 8, 6}),
                                            new Subject("Mathematics",new double[] { 10})});
            var students = new Student[] { a, b };

            Segment<Student> input = new Segment<Student>(students);
            QuickSortByOverallGrades(input);
            Assert.Equal(b, FindSpecificOverall(students, 5));
        }


        [Fact]
        public void FindMostGradesOfTen()
        {
            Student b = new Student("b", new Subject[] {
                                            new Subject("Mathematics",new double[] { 5, 5 }),
                                            new Subject("Literature",new double[] { 5 })});

            Student a = new Student("a", new Subject[] {
                                            new Subject("Literature",new double[] { 6, 8, 6}),
                                            new Subject("Mathematics",new double[] { 10})});

            Student c = new Student("c", new Subject[] {
                                            new Subject("Literature",new double[] { 10, 8, 6}),
                                            new Subject("Mathematics",new double[] { 10})});
            var students = new Student[] { a, b, c };

            Assert.Equal(c, FindGradesOfTen(students));
        }

        [Fact]
        public void SmallestOverallGrades()
        {
            Student b = new Student("b", new Subject[] {
                                            new Subject("Mathematics",new double[] { 5, 5 }),
                                            new Subject("Literature",new double[] { 6 })});

            Student a = new Student("a", new Subject[] {
                                            new Subject("Literature",new double[] { 6, 8, 6}),
                                            new Subject("Mathematics",new double[] { 10})});

            Student c = new Student("c", new Subject[] {
                                            new Subject("Literature",new double[] { 5, 5, 5}),
                                            new Subject("Mathematics",new double[] { 5})});

            Student d = new Student("d", new Subject[] {
                                            new Subject("Literature",new double[] { 10, 8, 6}),
                                            new Subject("Mathematics",new double[] { 10})});

            var students = new Student[] { a, b, c };

            Assert.Equal(c, SmallestOverall(students));
        }

        Student[] OrderAlphabeticallyShellSort(Student[] input)
        {
            Student temp;
            int gap = input.Length / 2;

            while (gap > 0)
            {
                for (int i = gap; i < input.Length; i++)
                {
                    for (int j = i - gap; j >= 0; j -= gap)
                    {
                        if (input[j].CompareByName(input[j + gap]) == 1)
                        {
                            temp = input[j + gap];
                            input[j + gap] = input[j];
                            input[j] = temp;
                        }
                    }
                }
                gap /= 2;
            }
            return input;
        }
        Student[] QuickSortByOverallGrades(Student[] input)
        {
            QuickSortByOverallGrades(new Segment<Student>(input));
            return input;
        }

        void QuickSortByOverallGrades(Segment<Student> input)
        {
            if (input.Length <= 1)
                return;
            
            int pivot = Partition(input);
            if (pivot > 0)
            {
                QuickSortByOverallGrades(input.SubSegment(0, pivot - 1));
                QuickSortByOverallGrades(input.SubSegment(pivot + 1, input.Length));
            }
        }

        int Partition(Segment<Student> input)
        {
            int j = 0;
            Student pivot = input.Get(0);
            for (int i = 1; i < input.Length; i++)
            {
                if (input.Get(i).OverallGrades() > pivot.OverallGrades())
                {
                    input.Swap(i, j);
                    j += 1;
                }
            }
            return j;
        }

        Student FindGradesOfTen(Student[] student)
        {
            Student result = student[0];
            for (int i = 1; i < student.Length; i++)
            {
                if (student[i].StudentOfTen() > student[i - 1].StudentOfTen())
                    result = student[i];
            }
            return result; 
        }

        Student FindSpecificOverall(Student[] student, double specific)
        {
            int i = student.Length / 2;
            Student[] newStudent = new Student[i + 1];
            if (student[i].OverallGrades() == specific)
                return student[i];

            if (specific > student[i].OverallGrades())
            {
                Array.Copy(student, i + 1, newStudent, 0, i);
            }
            if (specific < student[i].OverallGrades())
            {
                Array.Copy(student, 0, newStudent, 0, i - 1);
            }
            return FindSpecificOverall(newStudent, specific);

        }

        Student SmallestOverall(Student[] student)
        {
            Segment<Student> input = new Segment<Student>(student);
            QuickSortByOverallGrades(input);

            return student[student.Length - 1];
        }
    }
}
