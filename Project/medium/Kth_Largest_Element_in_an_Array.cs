using System;
using NUnit.Framework;

namespace Project.medium
{
    class Kth_Largest_Element_in_an_Array
    {
        [TestCase(new[] {3, 2, 1, 5, 6, 4}, 2, 5)]
        [TestCase(new[] {3, 2, 3, 1, 2, 4, 5, 5, 6}, 4, 4)]
        public void Test(int[] nums, int k, int exp)
        {
            Assert.AreEqual(exp, FindKthLargest(nums, k));
        }


        public int FindKthLargest(int[] nums, int k)
        {
            return Select(nums, 0, nums.Length - 1, k);
        }

        public int Select(int[] A, int p, int r, int k)
        {
            if (p == r)
            {
                return A[p];
            }

            int pivot = Partition(A, p, r);
            if (A.Length - pivot == k)
            {
                return A[pivot];
            }

            if (A.Length - pivot < k)
            {
                return Select(A, p, pivot-1, k);
            }

            return Select(A, pivot, r, k);
        }

        int Partition(int[] A, int l, int r)
        {
            var pivot = A[r];

            var i = l - 1;

            for (var j = l; j < r; j++)
            {
                if (A[j] <= pivot)
                {
                    i++;
                    Swap(A, i, j);
                }
            }

            Swap(A, ++i, r);
            return i;
        }

        public static void  Swap(int[] A, int i, int j)
        {
            if (i == j)
            {
                return;
            }

            var tmp = A[i];
            A[i] = A[j];
            A[j] = tmp;
        }

        public int FindKthLargest2(int[] nums, int k)
        {
            Array.Sort(nums);

            return nums[nums.Length - k];
        }
    }
}