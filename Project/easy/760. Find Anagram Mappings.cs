using System.Collections.Generic;
using NUnit.Framework;

namespace Project.easy
{
    public class Find_Anagram_Mappings
    {
        [TestCase(new[] {1, 4, 3, 2, 0}, new[] {12, 28, 46, 32, 50}, new[] {50, 12, 32, 46, 28})]
        public void Test(int[] exp, int[] nums1, int[] nums2)
        {
            Assert.AreEqual(exp, AnagramMappings(nums1, nums2));
        }


        public int[] AnagramMappings(int[] nums1, int[] nums2)
        {
            var map = new Dictionary<int, Queue<int>>();
            for (var i = 0; i < nums2.Length; i++)
            {
                var e = nums2[i];
                if (map.ContainsKey(e))
                {
                    map[e].Enqueue(i);
                    continue;
                }

                map.Add(e, new Queue<int>(new[] {i}));
            }

            var o = new int[nums1.Length];
            for (var i = 0; i < nums1.Length; i++)
            {
                o[i] = map[nums1[i]].Dequeue();
            }

            return o;
        }
    }
}