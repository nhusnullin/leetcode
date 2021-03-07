using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Project.easy
{
    class Find_All_Numbers_Disappeared_in_an_Array
    {
        [TestCase(new[] {1, 2, 4, 4}, new[] {3})]
        [TestCase(new[] {4, 3, 2, 7, 8, 2, 3, 1}, new[] {5, 6})]
        public void Test(int[] nums, int[] exp)
        {
            Assert.AreEqual(exp, FindDisappearedNumbers(nums).ToArray());
        }


        public IList<int> FindDisappearedNumbers(int[] nums)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                while (nums[i] != 0 && nums[i] != i+1)
                {
                    Swap(nums, i, nums[i]-1);
                }
            }

            var list = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    list.Add(i+1);
                }
            }

            return list;
        }

        public void Swap(int[] A, int i, int j)
        {
            if (i == j)
            {
                return;
            }

            int tmp = 0;
            if (A[i] != A[j])
            {
                tmp = A[i];
            }
            A[i] = A[j];
            A[j] = tmp;
        }
    }
}