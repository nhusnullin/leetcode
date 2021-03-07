using System.Collections.Generic;
using NUnit.Framework;

namespace Project.easy
{
    public class Remove_Element
    {
        [TestCase(new[] {1, 2, 2, 3}, 2, new[] {1, 3, 2, 2}, 2)]
        [TestCase(new[] {0, 1, 2, 2, 3, 0, 4, 2}, 2, new[] {0, 1, 4, 0, 3, 2, 2, 2}, 5)]
        public void Test(int[] nums, int val, int[] exp, int expCount)
        {
            var actual = RemoveElement(nums, val);
            Assert.AreEqual(exp, nums);
            Assert.AreEqual(expCount, actual);
        }

        public int RemoveElement(int[] nums, int val)
        {
            var res = 0;
            var left = 0;
            var right = nums.Length - 1;

            while (left <= right)
            {
                if (nums[left] != val)
                {
                    res++;
                    left++;
                    continue;
                }

                if (nums[right] == val)
                {
                    right--;
                    continue;
                }

                nums[left] = nums[right];
                nums[right] = val;
                res++;
                left++;
                right--;
            }

            return res;
        }
    }

    public class Duplicate_Zeros
    {
        [TestCase(new[] {1, 0, 3}, new[] {1, 0, 0})]
        [TestCase(new[] {8, 4, 5, 0, 0, 0, 0, 7}, new[] {8, 4, 5, 0, 0, 0, 0, 0})]
        [TestCase(new[] {1, 0, 2, 3, 0, 4, 5, 0}, new[] {1, 0, 0, 2, 3, 0, 0, 4})]
        public void Test(int[] arr, int[] exp)
        {
            DuplicateZeros(arr);
            Assert.AreEqual(exp, arr);
        }

        public void DuplicateZeros(int[] arr)
        {
            var zCount = 0;
            var length = arr.Length;
            for (var i = 0; i < length - zCount; i++)
            {
                var num = arr[i];
                if (num == 0)
                {
                    // edge case
                    if (i == length - 1 - zCount)
                    {
                        arr[length - 1] = 0;
                        length -= 1;
                        break;
                    }

                    zCount++;
                }
            }

            var j = length - 1 - zCount;
            for (int i = length - 1; i >= 0; i--)
            {
                var num = arr[j--];
                arr[i] = num;
                if (num == 0 && i - 1 >= 0)
                {
                    arr[--i] = 0;
                }
            }
        }

        public void DuplicateZeros2(int[] arr)
        {
            var queue = new Queue<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                queue.Enqueue(arr[i]);

                var num = queue.Dequeue();
                arr[i] = num;
                if (num == 0 && i + 1 < arr.Length)
                {
                    queue.Enqueue(arr[++i]);
                    arr[i] = 0;
                }
            }
        }
    }
}