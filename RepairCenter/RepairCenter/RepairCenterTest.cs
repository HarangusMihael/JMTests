using System;
using Xunit;

namespace RepairCenter
{
    public class RepairCenter
    {
        public enum Priority
        {
            High = 3,
            Medium = 2,
            Low = 1
        }

        Case aLow = new Case("a", Priority.Low);
        Case bHigh = new Case("b", Priority.High);
        Case cMedium = new Case("c", Priority.Medium);

        [Fact]
        public void Test1()
        {
            var aHigh = new Case("a", Priority.High);
            var cases = new Case[] { aHigh };
            Assert.Equal(new Case[] { aHigh }, QuickSort(cases, 0, cases.Length));

        }
        [Fact]
        public void Test2()
        {
            var cases = new Case[] { aLow, bHigh };
            Assert.Equal(new Case[] { bHigh, aLow }, QuickSort(cases, 0, cases.Length));
        }

        [Fact]
        public void Test3()
        {
            var cases = new Case[] { aLow, bHigh, cMedium };
            var actual = QuickSort(cases, 0, cases.Length);
            Assert.Equal(new Case[] { bHigh, cMedium, aLow }, actual);

        }

        [Fact]
        public void Test4()
        {
            Case cLow = new Case("c", Priority.Low);
            Case[] cases = new Case[] { aLow, bHigh, cLow };
            Assert.Equal(new Case[] { bHigh, aLow, cLow }, QuickSort(cases, 0, cases.Length));
        }

        [Fact]
        public void Test5()
        {
            Case dHigh = new Case("d", Priority.High);
            Case[] cases = new Case[] { cMedium, aLow, bHigh, cMedium, dHigh};
            Case[] actual = QuickSort(cases, 0, cases.Length);
            Assert.Equal(new Case[] { bHigh, dHigh, cMedium, cMedium, aLow }, actual);

        }

        [Fact]
        public void Test6()
        {
            Case dHigh = new Case("d", Priority.High);
            Case eMedium = new Case("e", Priority.Medium);
            Case[] cases = new Case[] { aLow, cMedium, bHigh, cMedium, dHigh, eMedium, bHigh, dHigh, aLow, aLow };
            Case[] actual = QuickSort(cases, 0, cases.Length);
            Assert.Equal(new Case[] { bHigh, dHigh, bHigh, dHigh, eMedium, cMedium, cMedium, aLow, aLow, aLow }, actual);

        }

        Case[] QuickSort(Case[] cases, int start, int end)
        {
            if (cases.Length <= 1)
                return cases;
            if (start < end)
            {
                var (pivotStart, pivotEnd) = Partition3(cases, start, end);                
                QuickSort(cases, pivotEnd + 1, end);
                QuickSort(cases, 0, pivotStart - 1);
            }

            return cases;
        }

        int Partition(Case[] array, int start, int end)
        {
            int j = start;
            Case pivot = array[start];
            for (int i = j + 1; i < end; i++)
            {
                if (array[i].priority > pivot.priority)
                {
                    Swap(ref array[i], ref array[j]);
                    j += 1;
                }
            }
                      
            return j;
        }

        (int, int) Partition3(Case[] array, int start, int end)
        {
            int j = start;
            int i = start + 1;
            int k = 0;
            Case pivot = array[start];
            while (i < end)
            {
                if (array[i].priority > pivot.priority)
                {
                    Swap(ref array[i], ref array[j]);
                    j += 1;
                }
                else if(array[i].priority==pivot.priority)
                {
                    k++;
                }
                i++;
            }

            return (end - k, j + k);
        }

        static void Swap(ref Case first, ref Case second)
        {
            Case temp = first;
            first = second;
            second = temp;
        }

        public struct Case
        {
            public string reparation;
            public Priority priority;
            public Case(string reparation, Priority priority)
            {
                this.reparation = reparation;
                this.priority = priority;
            }
            public override string ToString()
            {
                return $"{reparation}-{priority}";
            }
        }

    }
}
