using NUnit.Framework;

namespace Project.easy
{
    public class Find_Numbers_with_Even_Number_of_Digits
    {
        [TestCase(new[] {12, 123}, 1)]
        [TestCase(new[] {100000}, 1)]
        [TestCase(new[] {580, 317, 640, 957, 718, 764}, 0)]
        public void test(int[] nums, int expected)
        {
            Assert.AreEqual(expected, FindNumbers(nums));
        }

        public int FindNumbers(int[] nums)
        {
            var res = 0;

            for (var i = 0; i < nums.Length; i++)
            {
                int l = 0;
                var num = nums[i];
                while (num % 10 != 0 || num / 10 != 0)
                {
                    num = num / 10;
                    l++;
                }

                if (l != 0 && l % 2 == 0)
                {
                    res++;
                }
            }

            return res;
        }
    }
}