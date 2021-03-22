using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace Project.easy
{
    public class Squares_of_a_Sorted_Array
    {
        [TestCase(new[] {-2, 1, 3}, new[] {1, 4, 9})]
        [TestCase(new[] {-4, -1, 0, 3, 10}, new[] {0, 1, 9, 16, 100})]
        public void Test(int[] nums, int[] expected)
        {
            var sortedSquares = SortedSquares(nums);
            Assert.AreEqual(expected, sortedSquares);
        }


        public int[] SortedSquares(int[] nums)
        {
            var l = nums.Length;
            var i = 0;
            var j = l - 1;
            var res = new int[l];
            var k = 0;

            for (k = l - 1; k >= 0; k--)
            {
                var s = 0;
                if (Math.Abs(nums[i]) < Math.Abs(nums[j]))
                {
                    s = nums[j--];
                }
                else
                {
                    s = nums[i++];
                }

                res[k] = s * s;
            }

            return res;
        }

        public int[] SortedSquares2(int[] nums)
        {
            var res = new int[nums.Length];

            var j = 0;
            for (j = 0; j < nums.Length; j++)
            {
                if (nums[j] >= 0)
                {
                    break;
                }

                nums[j] = Math.Abs(nums[j]);
            }

            var i = j - 1;
            var l = nums.Length;
            for (int k = 0; k < res.Length; k++)
            {
                var left = i >= 0 ? nums[i] : Int32.MaxValue;
                var right = j < l ? nums[j] : Int32.MaxValue;

                if (left < right)
                {
                    res[k] = left * left;
                    i--;
                }
                else
                {
                    res[k] = right * right;
                    j++;
                }
            }

            return res;
        }
    }
}