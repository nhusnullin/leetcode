using NUnit.Framework;

namespace Project
{
    [TestFixture]
    public class Kth_Missing_Positive_Number
    {
        [TestCase(new int[]{2,3,4,7,11}, 5, 9)]
        [TestCase(new int[]{1,2,3,4}, 2, 6)]
        [TestCase(new int[]{1,2,3,4}, 1, 5)]
        public void Test(int[] arr, int k, int expected)
        {
            Assert.AreEqual(expected, FindKthPositive(arr, k));
        }
            
        public int FindKthPositive(int[] arr, int k)
        {

            var k_th = 0;
            var arr_i = 0;
            int i;
            
            for (i = 1; i <= arr[^1]; i++)
            {
                if (arr_i < arr.Length && i == arr[arr_i])
                {
                    arr_i++;
                    continue;
                }

                k_th++;

                if (k_th == k)
                {
                    return i;
                }
            }

            i += k - k_th - 1;
            
            return i;
        }
    }
}