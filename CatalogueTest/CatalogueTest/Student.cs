using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogueTest
{
    struct Student
    {
        private string name;
        private Subject[] subjects;

        public Student(string name, Subject[] grades)
        {
            this.name = name;
            this.subjects = grades;
        }

        public double OverallGrades()
        {
            double result = 0;
            foreach (var subject in subjects)
            {
                result += subject.Average();
            }
            return result / subjects.Length;
        }
      
        public int CompareByName(Student other)
        {
            return string.Compare(name, other.name, true);
        }

        public int StudentOfTen()
        {
            int numberOfGrades = 0;
            foreach (var subject in subjects)
            {
                numberOfGrades += subject.CountGradesOf(10);
            }
            return numberOfGrades;
        }

    }
}
