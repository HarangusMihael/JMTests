using System;
using Xunit;

namespace PascalTriangle
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 1, 1 }, 2)]
        [InlineData(new int[] { 1, 2, 1 }, 3)]
        [InlineData(new int[] { 1, 3, 3, 1 }, 4)]
        [InlineData(new int[] { 1, 4, 6, 4, 1 }, 5)]
        [InlineData(new int[] { 1, 5, 10, 10, 5, 1 }, 6)]
        public void Test1(int[] expected, int n)
        {
            Assert.Equal(expected, TriangleNumbers(n));
        }

        int[] TriangleNumbers(int row)
        {
            if (row == 0)
                return new int[] { };          
            var previous = TriangleNumbers(row - 1);

            return Sum(previous, row, new int[row]);         
        }

        int[] Sum(int[] previous, int row, int[] result)
        {
            result[0] = 1;
            result[previous.Length] = 1;
            if (row == 1 || row == 2) 
                return result;
            else
                result[row - 2] = previous[row - 3] + previous[row - 2];
            return Sum(previous, row - 1, result);
        }
    }
}
