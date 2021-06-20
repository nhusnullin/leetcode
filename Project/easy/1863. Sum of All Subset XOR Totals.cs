using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Project.easy
{
    public class Sum_of_All_Subset_XOR_Totals_LeetCode
    {
        [TestCase(new[] { 1, 3 }, 6)]
        public void Test(int[] nums, int exp)
        {
            Assert.AreEqual(exp, SubsetXORSumBinaryMask(nums));
        }

        public int SubsetXORSumBinaryMask(int[] nums)
        {
            acc = 0;

            for (int i = 1; i < (1 << nums.Length); i++)
            {
                var bits = i;
                int xor = 0;
                int pos = 0;
                while (bits > 0)
                {
                    if ((bits & 1) == 1)
                    {
                        xor ^= nums[pos];
                    }

                    bits >>= 1;
                    pos++;
                }

                acc += xor;
            }

            return acc;
        }

        private int acc = 0;

        public int SubsetXORSum(int[] nums)
        {
            acc = 0;
            Calc(nums, 0, 0);
            return acc;
        }

        private void Calc(int[] nums, int idx, int x0)
        {
            acc += x0;

            for (var i = idx; i < nums.Length; i++)
            {
                Calc(nums, i + 1, x0 ^ nums[i]);
            }
        }
    }

    public class Sum_of_All_Subset_XOR_Totals
    {
        [TestCase(new[] { 1, 3 })]
        public void Test(int[] nums)
        {
            SubsetXORSum(nums);
        }


        public int SubsetXORSum(int[] nums)
        {
            var coll = Subset(nums, "0", 0).ToList();
            return -1;
        }

        public IEnumerable<string> Subset(int[] nums, string acc, int idx)
        {
            for (int i = idx; i < nums.Length; i++)
            {
                var s = $"{acc} ^ {nums[i]}";
                yield return s;
                foreach (var s1 in Subset(nums, s, i + 1)) yield return s1;
            }
        }

        [TestCase(new[] { 'a', 'b', 'c' })]
        public void TestPermute(char[] str)
        {
            var coll = new List<string>();
            Permute(str, 0, str.Length - 1, coll);
            var hs = coll.ToHashSet();
        }

        public void Permute(char[] str, int l, int r, IList<string> acc)
        {
            if (l == r) return;

            for (var i = l; i <= r; i++)
            {
                (str[l], str[i]) = (str[i], str[l]);

                acc.Add(new string(str));

                Permute(str, l + 1, r, acc);

                (str[i], str[l]) = (str[l], str[i]);
            }
        }
    }
}