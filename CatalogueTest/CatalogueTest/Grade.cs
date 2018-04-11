using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogueTest
{
    struct Subject
    {
        private string name;
        private double[] grades;

        public Subject(string subject, double[] grades)
        {
            this.name = subject;
            this.grades = grades;
        }

        public double Average()
        {
            double result = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                result += grades[i];
            
            }
            return result / grades.Length;
        }

        public int CountGradesOf(double grade)
        {
            int count = 0;
            foreach (var item in grades)
            {
                if (item == grade)
                    count++;
            }
            return count;
        }
    }
}
