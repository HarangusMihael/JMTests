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

        [Fact]
        public void Test1()
        {
            Case[] cases= new Case[] { new Case("a", Priority.High), new Case("b", Priority.Low), new Case("c", Priority.Medium) };
            Assert.Equal("acb", QuickSort(cases));        
        }
        [Fact]
        public void SecondTest()
        {
            Case[] secondCases = new Case[] { new Case("a", Priority.High), new Case("b", Priority.Low),
                                       new Case("c", Priority.Medium), new Case("d", Priority.Low), new Case("e",Priority.Medium) };
            Assert.Equal("acebd", QuickSort(secondCases));
        }

        string QuickSort(Case[] cases)
        {
            Case[] bigger = new Case[1]; 
            Case[] equal = new Case[1];
            Case[] smaller = new Case[1]; 
            string result = null;
            Case pivot = cases[1];
            for (int i = 0; i < cases.Length; i++) 
            {
                if (pivot.priority < cases[i].priority)
                {
                    if (bigger[0].reparation == null)
                    {
                        bigger[0] = cases[i];
                    }
                    else
                    {
                        Array.Resize(ref bigger, bigger.Length + 1);
                        bigger[bigger.Length - 1] = cases[i];
                    }
                }
                if (pivot.priority > cases[i].priority)
                {
                    Array.Resize(ref smaller, smaller.Length + 1);
                    smaller[smaller.Length - 1] = cases[i];
                }
                if (pivot.priority == cases[i].priority)
                {
                    Array.Resize(ref equal, equal.Length + 1);
                    equal[equal.Length - 1] = cases[i];
                    //ArraySegment<Case> equal = new ArraySegment<Case>(temp, 0, i);
                }
            }
            result += ArrayConcat(bigger) + ArrayConcat(equal) + ArrayConcat(smaller);

            return result;
        }

        string ArrayConcat(Case[] array)
        {
            string result = null;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i].reparation;
            }
            return result;
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
        }

    }
}
