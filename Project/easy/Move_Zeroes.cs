using NUnit.Framework;

namespace Project.easy
{
    class Move_Zeroes
    {
        [TestCase(new[] {0, 1, 0, 3, 12}, new[] {1, 3, 12, 0, 0})]
        [TestCase(new[]{4,2,4,0,0,3,0,5,1,0}, new[]{4,2,4,3,5,1,0,0,0,0})]
        public void Test(int[] nums, int[] exp)
        {
            MoveZeroes(nums);
            Assert.AreEqual(exp, nums);
        }


        public void MoveZeroes(int[] nums)
        {

            var lastNonZero = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[lastNonZero++] = nums[i];
                }
            }

            for (int i = lastNonZero; i < nums.Length; i++)
            {
                nums[i] = 0;
            }

        }

        public void MoveZeroes3(int[] nums)
        {
            if (nums.Length < 2)
            {
                return;
            }
            
            var left = 0;
            var right = 1;

            while (left < nums.Length)
            {
                if (nums[left] != 0)
                {
                    left++;
                    continue;
                }

                if (right < left)
                {
                    right = left + 1;
                }
                
                while (right < nums.Length)
                {
                    if (nums[right] == 0)
                    {
                        right++;
                        continue;
                    }

                    nums[left++] = nums[right];
                    nums[right++] = 0;
                    break;
                }

                if (right == nums.Length)
                {
                    break;
                }
            }

        }

        public void MoveZeroes2(int[] nums)
        {
            var left = 0;
            var right = nums.Length - 1;

            while (left < right)
            {
                if (nums[left] != 0)
                {
                    left++;
                    continue;
                }

                if (nums[right] == 0)
                {
                    right--;
                    continue;
                }

                nums[left++] = nums[right];
                nums[right--] = 0;
            }
        }
    }
}