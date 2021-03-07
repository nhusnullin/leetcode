using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using NUnit.Framework;

namespace Project
{
    [TestFixture]
    public class Max_Number_of_K_Sum_Pairs
    {
        [TestCase(new[]{1,2,3,4}, 5,2)]
        [TestCase(new[]{3,1,3,4,3}, 6,1)]
        [TestCase(new[]{3,1,5,1,1,1,1,1,2,2,3,2,2}, 1,0)]
        [TestCase(new[]{4,4,1,3,1,3,2,2,5,5,1,5,2,1,2,3,5,4}, 2,2)]
        [TestCase(new[]{2,2,2,3,1,1,4,1}, 4,2)]
        public void test(int[] nums, int k, int expected)
        {
            Assert.AreEqual(expected,MaxOperations4(nums,k));
        }

        public int MaxOperations4(int[] nums, int k)
        {
            if (nums.Length < 1)
            {
                return 0;
            }
            
            Array.Sort(nums);
            var ans = 0;
            var i = 0;
            var j = nums.Length-1;
            
            var numsi = nums[i];
            var numsj = nums[j];
            
            while (i < j)
            {
                var sum = numsi + numsj;

                if (sum > k)
                {
                    numsj = nums[--j];
                    continue;
                }
                if (sum < k)
                {
                    numsi = nums[++i];
                    continue;
                }

                ans++;
                numsj = nums[--j];
                numsi = nums[++i];
            }

            return ans;
        }
        

        public int MaxOperations3(int[] nums, int k)
        {
            var ans = 0;
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                var complement = k - nums[i];

                if (dic.TryGetValue(complement, out var val) && val > 0)
                {
                    ans++;
                    dic[complement]--;
                }
                else if(dic.ContainsKey(nums[i]))
                {
                    dic[nums[i]]++;
                }
                else
                {
                    dic[nums[i]] = 1;
                }
            }

            return ans;
        }
        
        

        public int MaxOperations(int[] nums, int k)
        {
            var ans = 0;
            var dic = NumsToDic(nums, k);


            foreach (var num in nums)
            {
                if (!dic.ContainsKey(num) || dic[num] == 0)
                {
                    continue;
                }

                dic[num]--;

                var key = k - num;
                if (dic.ContainsKey(key) && dic[key] > 0)
                {
                    dic[key]--;

                    ans++;
                }
            }

            return ans;
        }

        public int MaxOperations2(int[] nums, int k)
        {
            var ans = 0;
            var ans2 = 0;
            var dic = NumsToDic(nums, k);


            foreach (var i in dic)
            {
                if (k % 2 == 0 && i.Key == k / 2)
                {
                    ans2 += i.Value / 2;
                    continue;
                }

                var key = k - i.Key;
                if (!dic.ContainsKey(key)) continue;

                ans += Math.Min(i.Value, dic[key]);
            }

            ans = (ans > 1 ? ans / 2 : ans) + ans2;

            return ans;
        }

        private static Dictionary<int, int> NumsToDic(int[] nums, int k)
        {
            var dic = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (num > k)
                {
                    continue;
                }

                if (dic.ContainsKey(num))
                {
                    dic[num]++;
                }
                else
                {
                    dic[num] = 1;
                }
            }

            return dic;
        }
    }
}