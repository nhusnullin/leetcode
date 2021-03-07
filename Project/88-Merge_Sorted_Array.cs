using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Project
{
    [TestFixture]
    public class Merge_Sorted_Array
    {
        [TestCase(new[] {1, 2, 3, 0, 0, 0}, 3, new[] {2, 5, 6}, 3, new[] {1, 2, 2, 3, 5, 6})]
        [TestCase(new[] {1}, 1, new int[0], 0, new[] {1})]
        [TestCase(new[] {2,0}, 1, new int[]{1}, 1, new[] {1,2})]
        public void Test(int[] nums1, int m, int[] nums2, int n, int[] expected)
        {
            Merge(nums1, m, nums2, n);
            Assert.AreEqual(expected, nums1);
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var i = 0;
            var j = 0;
            var ii = 0;

            var ans = new int[m + n];

            while (ii < m+n)
            {
                if (i < m && j < n && nums1[i] == nums2[j])
                {
                    ans[ii++] = nums1[i++];
                    ans[ii++] = nums2[j++];
                    continue;
                }

                if (i < m && j < n && nums1[i] < nums2[j])
                {
                    ans[ii++] = nums1[i++];
                    continue;
                }

                if (i < m && j < n && nums1[i] > nums2[j])
                {
                    ans[ii++] = nums2[j++];
                    continue;
                }

                if (i == m && j < n)
                {
                    ans[ii++] = nums2[j++];
                    continue;
                }

                if (i < m && j == n)
                {
                    ans[ii++] = nums1[i++];
                    continue;
                }

                throw new ApplicationException();
            }
            
            ans.CopyTo(nums1,0);

        }

        

    }
}