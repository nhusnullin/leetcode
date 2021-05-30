using NUnit.Framework;

namespace Project.easy
{
    public class Climbing_Stairs
    {
        [TestCase(5,4)]
        [TestCase(8,5)]
        public void Test(int exp, int n)
        {
            Assert.AreEqual(exp, ClimbStairs(n));
        }
        
        private int[] _cache;
        public int ClimbStairs(int n)
        {
            if (n <= 2) return n;
            _cache = new int[n+1];
            _cache[0] = 0;
            _cache[1] = 1;
            _cache[2] = 2;
            return F(n);
        }

        public int F(int n)
        {
            if (n == 0) return 0;
            if (_cache[n] != 0) return _cache[n];

            _cache[n] = F(n - 1) + F(n - 2);
            return _cache[n];
        }
        
    }
}