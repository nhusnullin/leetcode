using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Project.medium
{
    public class Coin_Change
    {
        [TestCase(3, 11, 5, 2, 1)]
        [TestCase(3, 11, 1,2,5)]
        [TestCase(-1, 3, 2)]
        [TestCase(1, 1, 1)]
        [TestCase(20, 100, 5, 2, 1)]
        public void Test(int exp, int amount, params int[] coins)
        {
            // Assert.AreEqual(exp, CoinChange(coins, amount, new Dictionary<int, int>()));
            //Assert.AreEqual(exp, CoinChange(coins, amount));

            var memo = new int[amount + 1];
            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = Int32.MaxValue;
            }
            
            Assert.AreEqual(exp, CoinChangeBF(coins, amount, memo));
        }

        // brute force + dp
        public int CoinChangeBF(int[] coins, int remain, int[] memo)
        {
            if (remain < 0) return -1;
            if (remain == 0) return 0;

            if (memo[remain] != int.MaxValue) return memo[remain];

            int min = int.MaxValue;
            foreach (var coin in coins)
            {
                int cn = CoinChangeBF(coins, remain - coin, memo);
                if (cn == -1) continue;
                min = Math.Min(min, cn + 1);
            }

            memo[remain] = min == int.MaxValue ? -1 : min;
            return memo[remain];
        }


        // top bottom approach
        public int CoinChange(int[] coins, int amount, Dictionary<int, int> cache, int count = 0)
        {
            if (amount == 0) return count;
            if (cache.ContainsKey(amount)) return cache[amount];

            var cn = int.MaxValue;

            foreach (var coin in coins)
            {
                var newAmount = amount - coin;
                if (newAmount >= 0)
                {
                    cn = Math.Min(cn, CoinChange(coins, newAmount, cache, count + 1));
                }
            }

            cache[amount] = cn;

            return cn == int.MaxValue ? -1 : cn;
        }

        public int CoinChange(int[] coins, int amount)
        {
            var res = new int[amount + 1];
            for (int i = 1; i < res.Length; i++)
            {
                res[i] = -1;
            }

            for (var value = 1; value <= amount; value++)
            {
                foreach (var coin in coins)
                {
                    var newValue = value - coin;
                    if (newValue < 0 || res[newValue] == -1) continue;

                    if (res[value] == -1)
                    {
                        res[value] = res[newValue] + 1;
                    }
                    else
                    {
                        res[value] = Math.Min(res[value], res[newValue] + 1);
                    }
                }
            }

            return res[amount] == -1 ? -1 : res[amount];
        }
    }
}