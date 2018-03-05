using System;
using Xunit;

namespace PocketComputer
{
    public class PocketComputerTest
    {
        [Fact]
        public void ComputeNumbersTest()
        {
            Assert.Equal(11, ComputeNumbers("+-*3421"," ",1));

        }

        float ComputeNumbers(string input, string operand, float result)
        {
            if (input == "")
                return result;
            else if (!int.TryParse(Convert.ToString(input[0]), out int n))
                return ComputeNumbers(input.Substring(1), operand + input[0], result);
            else
                 if (operand.Length == input.Length - 1 / 2)
                 {
                   operand += operand[operand.Length - 1];
                 }
            return ComputeNumbers(input.Substring(1), operand.Substring(0, operand.Length-1), Calculate(operand[operand.Length-1],result,(float)char.GetNumericValue(input[0])));
          
        }

        float Calculate(char Operand,float Result,float Number)
        {
            float result = 0;
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
