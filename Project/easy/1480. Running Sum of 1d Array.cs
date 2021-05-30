using System.Diagnostics;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace Project.easy
{
    public class Running_Sum_of_1d_Array
    {
        [TestCase(new[] {1, 3, 6, 10}, new[] {1, 2, 3, 4})]
        public void Test(int[] exp, int[] act)
        {
            Assert.AreEqual(exp, RunningSum(act));
        }

        public int[] RunningSum(int[] nums)
        {
            for (int i = 1; i < nums.Length; i++)
            {
                nums[i] = nums[i] + nums[i - 1];
            }

            return nums;
        }
    }
}