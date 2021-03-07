using System;
using NUnit.Framework;

namespace Project.easy
{
    class Remove_Duplicates_from_Sorted_Array
    {
        [TestCase(new []{1,1,2}, 2)]
        [TestCase(new []{0,0,1,1,1,2,2,3,3,4}, 5)]
        public void Test(int[] nums,int exp)
        {
            Assert.AreEqual(exp, RemoveDuplicates(nums));
        }
        
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return nums.Length;
            }
            
            var p1 = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[p1] == nums[i])
                {
                    continue;
                }

                nums[++p1] = nums[i];

            }

            return ++p1;
        }
    }
}