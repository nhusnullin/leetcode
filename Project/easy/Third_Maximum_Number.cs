using System;
using NUnit.Framework;

namespace Project.easy
{
    class Third_Maximum_Number
    {
        [TestCase(new[] {3, 2, 1}, 1)]
        [TestCase(new[] {2, 2, 3, 1}, 1)]
        [TestCase(new[] {1, 1, 2}, 2)]
        [TestCase(new[] {2, 1, 1}, 2)]
        public void Test(int[] nums, int exp)
        {
            Assert.AreEqual(exp, ThirdMax(nums));
        }

        public int ThirdMax(int[] nums)
        {
            var max = new int[3]{Int32.MinValue, Int32.MinValue, Int32.MinValue};

            max[0] = Max(nums, Int32.MaxValue).Value;
            int length = 1;
            
            for (int i = 1; i < max.Length; i++)
            {
                var val = Max(nums, max[i - 1]);
                if (val.HasValue && val < max[i - 1])
                {
                    max[i] = val.Value;
                    length++;
                }
            }

            return length < 3 ? max[0] : max[2];

        }

        public int? Max(int[] nums, int upperBound)
        {
            int? max = null;
            foreach (var num in nums)
            {
                if ((!max.HasValue || num > max ) && num < upperBound)
                {
                    max = num;
                }
            }

            return max;
        }
    }
}