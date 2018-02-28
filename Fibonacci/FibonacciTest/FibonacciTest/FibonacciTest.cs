using System;
using Xunit;

namespace FibonacciTest
{
    public class FibonacciTest
    {
        [Fact]
        public void TestFibonacci()
        {       
            Assert.Equal(13, Fibonacci(7));
        }

        int Fibonacci(int n)
        {
            int previous = 0;
            return Fibonacci(n, ref previous);
        }

         int Fibonacci(int n,ref int previous)
        {
            if (n < 2) return n;
            int beforePrevious = 0;
            previous= Fibonacci(n - 1, ref beforePrevious);
            return previous + beforePrevious;
        }
    }
}
