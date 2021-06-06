using System;
using NUnit.Framework;

namespace Project.easy
{
    public class Maximum_Subarray
    {
        [TestCase(6, -2, 1, -3, 4, -1, 2, 1, -5, 4)]
        public void Test(int exp, params int[] nums)
        {
            Assert.AreEqual(exp, MaxSubArray(nums));
        }

        public int MaxSubArray(int[] nums)
        {
            var max = int.MinValue;
            for (var i = 1; i < nums.Length; i++)
            {
                if (i > i + nums[i - 1]) continue;
                nums[i] += nums[i - 1];
            }

            var m = int.MinValue;
            foreach (var num in nums)
            {
                m = Math.Max(m, num);
            }

            return m;
        }
    }
}