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
        public void ComputeNumbersTest(double expected, string expression)
        {
            Assert.Equal(expected, Calculate(expression,0));
        }

        double Calculate(string input,double result)
        {
            int index = 0;
            return Calculate(input.Split(" ".ToCharArray()), ref index,result);

        }

        double Calculate(string[] input, ref int index, double result)
        {
            string secondString = null;
            string newString = null;
            if (input.Length == 1)
                return Convert.ToDouble(input[0]);
            else if (input.Length == 3)
                return CalculateNumbers(Convert.ToChar(input[0]), Convert.ToDouble(input[1]), Convert.ToDouble(input[2]));
            else if (double.TryParse(input[input.Length / 2 - 1], out double n) && !double.TryParse(input[input.Length / 2], out double m))
            {
                newString = string.Join(" ", input);
                string[] temporary = new string[2];

                Array.Copy(input, 0, temporary, 0, index+2);
                secondString = string.Join(" ", temporary);
                index = input.Length / 2 - 1;
                result = CalculateNumbers(Convert.ToChar(input[index + 1]), Convert.ToDouble(input[index + 2]), Convert.ToDouble(input[index + 3]));
                return Calculate(secondString + " " + Convert.ToString(result), result);
            }
            else if (input.Length == 5 )
            {
                newString = string.Join(" ", input);
                index = input.Length / 2 - 1;
                result = CalculateNumbers(Convert.ToChar(input[index]), Convert.ToDouble(input[index + 1]), Convert.ToDouble(input[index + 2]));
                return Calculate(newString.Substring(0, 1) + " " + Convert.ToString(result) + newString.Substring(newString.Length - 2), result);
            }
            
            else
            {

                index = input.Length / 2 - 1;
                string[] temporary = new string[input.Length / 2 - 1];
                Array.Copy(input, index + 3, temporary, 0, index);
                newString = string.Join(" ", input);
                secondString = string.Join(" ", temporary);
                result = CalculateNumbers(Convert.ToChar(input[index]), Convert.ToDouble(input[index + 1]), Convert.ToDouble(input[index + 2]));

                return Calculate(newString.Substring(0, index * 2 - 1) + " " + Convert.ToString(result) + " " + secondString, result);
            }

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
