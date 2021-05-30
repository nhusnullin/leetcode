using NUnit.Framework;

namespace Project.sort
{
    public class MergeSort
    {
        [TestCase(new[] {1, 2, 3, 5}, new[] {5, 2, 3, 1})]
        [TestCase(new[] {0, 0, 1, 1, 2, 5}, new[] {5, 1, 1, 2, 0, 0})]
        public void Test(int[] exp, int[] act)
        {
            Assert.AreEqual(exp, SortArray(act));
        }

        public int[] SortArray(int[] nums)
        {
            var aux = new int[nums.Length];
            Sort(nums, aux, 0, nums.Length - 1);
            return nums;
        }

        public void Sort(int[] a, int[] aux, int lo, int hi)
        {
            if (lo >= hi) return;

            var mid = lo + (hi - lo) / 2;
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);

            Merge(a, aux, lo, mid, hi);
        }

        public void Merge(int[] a, int[] aux, int lo, int mid, int hi)
        {
            for (int k = lo; k <= hi; k++) aux[k] = a[k];

            var i = lo;
            var j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) a[k] = aux[j++];
                else if (j > hi) a[k] = aux[i++];
                else if (aux[i] < aux[j]) a[k] = aux[i++];
                else a[k] = aux[j++];
            }
        }
    }
}