using System;
using NUnit.Framework;

namespace Project
{
    [TestFixture]
    public class Minimum_Operations_to_Reduce_X_to_Zero
    {
        [TestCase(new[]{1,1,4,2,3}, 5,2)]
        [TestCase(new[]{1,1}, 3,-1)]
        [TestCase(new[]{3,2,20,1,1,3}, 10,5)]
        public void Test(int[] nums, int x, int expected)
        {
            Assert.AreEqual(expected, MinOperations(nums, x));
        }
        
        public int MinOperations(int[] nums, int x)
        {
            var i = 0;
            var j = nums.Length-1;

            var ans1 = 0;
            var tmp = x;
            while (i <= j)
            {
                if (nums[i] <= tmp)
                {
                    tmp -= nums[i++];
                    ans1++;
                }
                else
                {
                    tmp -= nums[j--];
                    ans1++;
                }

                if (tmp < 0)
                {
                    ans1 = -1;
                    break;
                }

                if (tmp == 0)
                {
                    break;
                }
            }

            if (tmp > 0)
            {
                ans1 = -1;
            }
            
            i = 0;
            j = nums.Length-1;
            var ans2 = 0;
            tmp = x;
            while (i <= j)
            {
                if (nums[j] <= tmp)
                {
                    tmp -= nums[j--];
                    ans2++;
                }
                else
                {
                    tmp -= nums[i++];
                    ans2++;
                }

                if (tmp < 0)
                {
                    ans2 = -1;
                    break;
                }

                if (tmp == 0)
                {
                    break;
                }
            }
            
            if (tmp > 0)
            {
                ans2 = -1;
            }

            return Math.Min(ans1, ans2);

        }
    }
}