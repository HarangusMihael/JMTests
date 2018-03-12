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
            double first = 0;
            double second = 0;
            string operand = null;
            if (double.TryParse(input[index],out double n))
                return Convert.ToDouble(input[index]);         
            else
              operand += input[index];
            index++;
            first = Calculate(input, ref index);
            index++;
            second = Calculate(input, ref index);
            return CalculateNumbers(Convert.ToChar(operand), first, second);
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
