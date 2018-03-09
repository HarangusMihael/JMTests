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
            if (input.Length-1 == index)
                return Convert.ToDouble(input[0]);
            else
                return CalculateNumbers(Convert.ToChar(input[0]),Convert.ToDouble(input[index+1]),Convert.ToDouble(input[index+2]));

        }

        double CalculateNumbers(char Operand,double Result,double Number)
        {
            double result = 0;
            char option = Operand;
            switch(option)
            {
                case '*':
                   result = Result * Number;
                    break;
                case '+':
                   result = Result + Number;
                    break;
                case '/':
                   result = Result / Number;
                    break;
                case '-':
                   result = Result - Number;
                    break;
            }
            return result;
        }

    }
}
