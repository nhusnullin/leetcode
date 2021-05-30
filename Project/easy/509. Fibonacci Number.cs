using NUnit.Framework;

namespace Project.easy
{
    public class Fibonacci_Number
    {
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        public void Test(int exp, int act)
        {
            Assert.AreEqual(exp, Fib(act));
        }

        private int[] _cache;
        public int Fib(int n)
        {
            if (n <= 0) return 0;
            
            _cache = new int[n+1];
            _cache[0] = 0;
            _cache[1] = 1;

            return F(n);
        }

        public int F(int n)
        {
            if (n == 0) return 0;
            if (_cache[n] != 0) return _cache[n];

            return F(n - 1) + F(n - 2);
        }
    }
}