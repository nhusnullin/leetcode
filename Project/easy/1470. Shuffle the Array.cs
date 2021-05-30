using System.Linq;
using NUnit.Framework;

namespace Project.easy
{
    public class Shuffle_the_Array
    {
        [TestCase(new[] {2, 3, 5, 4, 1, 7}, new[] {2, 5, 1, 3, 4, 7}, 3)]
        public void Test(int[] exp, int[] act, int n)
        {
            Assert.AreEqual(exp, Shuffle(act, n));
        }

        public int[] Shuffle(int[] nums, int n)
        {
            var res = new int[nums.Length];
            var i = 0;
            var j = n;
            var k = 0;

            while (i < n)
            {
                res[k++] = nums[i++];
                res[k++] = nums[j++];
            }

            return res;
        }
    }
}