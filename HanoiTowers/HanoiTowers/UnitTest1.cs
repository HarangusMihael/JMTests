using System;
using Xunit;

namespace HanoiTowers
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("AC",1)]
        [InlineData("AB AC BC",2)]
        [InlineData("AC AB CB AC BA BC AC",3)]
        public void Test1(string expected,int n)
        {
            Assert.Equal(expected, MoveTowers(n,'A','B','C'));
        }

        string MoveTowers(int NumberOfDisks, char source, char aux, char destination)
        {
            if (NumberOfDisks == 1)
                return Convert.ToString(source) + Convert.ToString(destination);

                return MoveTowers(NumberOfDisks - 1, source, destination, aux) + " " +
                       Convert.ToString(source) + Convert.ToString(destination) +" "+
                       MoveTowers(NumberOfDisks - 1, aux, source, destination);
        }

    }
}
