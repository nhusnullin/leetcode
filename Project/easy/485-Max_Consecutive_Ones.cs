using System;

namespace Project.easy
{
    public class Max_Consecutive_Ones
    {
        public class Solution
        {
            public int FindMaxConsecutiveOnes(int[] nums)
            {
                int max = Int32.MaxValue;

                int local_max = 0;

                foreach (var num in nums)
                {
                    if (num == 1)
                    {
                        local_max++;
                    }
                    else
                    {
                        max = Math.Max(max, local_max);
                        local_max = 0;
                    }
                }

                return max;
            }
        }
    }
}