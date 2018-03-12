using System;
using Xunit;

namespace PocketComputer
{
    public class PocketComputerTest
    {
        [Theory]
        [InlineData(5,"5")]
        [InlineData(12,"* 3 4")]
        [InlineData(5,"+ 2.5 2.5")]
        [InlineData(14,"+ * 3 4 2")]
        [InlineData(20,"+ + + 5 5 5 5")]
        [InlineData(4,"+ / * + + 2 2 2 3 6 1")]
        [InlineData(21,"+ 20 - 3 2")]
        [InlineData(23.5,"+ + * 10 2 3 - 4 3.5")]
        public void ComputeNumbersTest(double expected, string expression)
        {
            Assert.Equal(expected, Calculate(expression));
        }

        double Calculate(string input)
        {
            int index = 0;
            return Calculate(input.Split(" ".ToCharArray()), ref index);

        }

        double Calculate(string[] input, ref int index)
        {
            if (double.TryParse(input[index++], out double n))
                return n;         

            var operatorString = input[index - 1];
            return CalculateNumbers(
                operatorString[0],
                Calculate(input, ref index), 
                Calculate(input, ref index));
        }

        double CalculateNumbers(char operatorChar, double first, double second)
        {
            double result = 0;
            char option = operatorChar;
            switch(option)
            {
                case '*':
                   result = first * second;
                    break;
                case '+':
                   result = first + second;
                    break;
                case '/':
                   result = first / second;
                    break;
                case '-':
                   result = first - second;
                    break;
            }
            return result;
        }

    }
}
