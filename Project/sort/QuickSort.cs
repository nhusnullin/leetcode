using NUnit.Framework;

namespace Project.sort
{
    public class QuickSort
    {
        [TestCase(new[] {1, 2, 3, 5}, new[] {5, 2, 3, 1})]
        [TestCase(new[] {0, 0, 1, 1, 2, 5}, new[] {5, 1, 1, 2, 0, 0})]
        public void Test(int[] exp, int[] act)
        {
            Assert.AreEqual(exp, SortArray(act));
        }

        public int[] SortArray(int[] nums)
        {
            Sort(nums, 0, nums.Length - 1);
            return nums;
        }


        public void Sort(int[] nums, int lo, int hi)
        {
            if (lo >= hi) return;

            int p = Partitioning(nums, lo, hi);
            Sort(nums, lo, p - 1);
            Sort(nums, p + 1, hi);
        }

        public int Partitioning(int[] nums, int lo, int hi)
        {
            int i = lo;
            int j = hi + 1;

            while (true)
            {
                while (nums[lo] > nums[++i])
                {
                    if (i == hi) break;
                }

                while (nums[lo] < nums[--j])
                {
                    if (j == lo) break;
                }

                if (i >= j) break;

                Exch(nums, i, j);
            }

            Exch(nums, lo, j);

            return j;
        }

        public void Exch(int[] nums, int i, int j)
        {
            var tmp = nums[i];
            nums[i] = nums[j];
            nums[j] = tmp;
        }
    }
}