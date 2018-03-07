using System;
using Xunit;

namespace PocketComputer
{
    public class PocketComputerTest
    {
        [Fact]
        public void ComputeNumbersTest()
        {
            string input = "+ * * 5 5 10 1";
            Assert.Equal(251, CalculateNumbers(input,0));

        }

        float CalculateNumbers(string input, float result)
        {
            string Operands = null;
            string[] Numbers = new string[(input.Length+1)/2];
            if (input == "")
                return result;
            else
                 Operands = StringOperands(input, "");
                 Numbers = input.Substring(StringOperands(input, "").Length * 2).Split();
            return CalculateNumbers((input.Substring((Operands.Length + Numbers.Length)*2)), ComputeNumbers(Numbers, Operands, Convert.ToSingle(Numbers[0]), 1));

        }

        string StringOperands(string input,string result)
        {
            if (int.TryParse(Convert.ToString(input[0]), out int i))
                return result;
            else if (!int.TryParse(Convert.ToString(input[0]), out int n) && Convert.ToString(input[0]) != " ")
                return StringOperands(input.Substring(1), result + input[0]);
            else
                return StringOperands(input.Substring(1), result);
        }


        float ComputeNumbers(string[] input, string operand, float result,int i)
        {
            if (operand == "")
                return result;
            else
                return ComputeNumbers(input, operand.Substring(0, operand.Length - 1), Calculate(operand[operand.Length - 1], result, Convert.ToSingle(input[i])),i+=1);
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
