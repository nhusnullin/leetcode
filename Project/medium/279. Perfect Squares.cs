using System;
using System.Linq;
using NUnit.Framework;

namespace Project.medium
{
    public class Perfect_Squares {
        private int[] _squares;

        [TestCase(1,4)]
        [TestCase(3,12)]
        [TestCase(2,13)]
        public void Test(int exp, int n)
        {
            Assert.AreEqual(exp, NumSquares(n));
        }

        public int NumSquares(int n)
        {
            _squares = new int[(int)Math.Sqrt(n) + 1];
            for (int i = 0; i < _squares.Length; i++) _squares[i] = i * i;

            var count = 1;

            Bfs(n, ++count);
            
            return count;
        }

        public bool Bfs(int n, int count)
        {
            if(count == 1)
            {
                return _squares.Any(x => x == n);
            }

            for (int i = 1; i < n; i++)
            {
                for (int k = 1; k <= Math.Min(i, Math.Sqrt(n)); k++)
                {
                    if (Bfs(n - k * k, count -1))
                    {
                        break;
                    }
                }
                
            }


            return false;

        }
        
        public int NumSquaresDP(int n)
        {
            var sqrtN = (int) Math.Sqrt(n);
            if (n == sqrtN * sqrtN) return 1;

            var dp = new int[Math.Max(n + 1, 4)];
            for (var i = 0; i < dp.Length; i++) dp[i] = int.MaxValue;

            dp[0] = 0;
            dp[1] = 1;

            for (var i = 2; i < dp.Length; i++)
            {
                for (var k = 1; k <= Math.Sqrt(i); k++)
                {
                    dp[i] = Math.Min(dp[i], dp[i - k * k] + 1);
                }
            }

            return dp[n];
        }
    }
}