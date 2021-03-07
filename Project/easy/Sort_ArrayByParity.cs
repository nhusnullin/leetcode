using NUnit.Framework;

namespace Project.easy
{
    class Sort_ArrayByParity
    {
        [TestCase(new[]{3,1,2,4}, new[]{2,4,3,1})]
        public void Test(int[] A, int[] exp)
        {
            Assert.AreEqual(exp, SortArrayByParity(A));
        }
        
        public int[] SortArrayByParity(int[] A)
        {

            var p1 = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] % 2 == 0)
                {
                    var tmp = A[p1];
                    A[p1++] = A[i];
                    A[i] = tmp;
                }
            }

            return A;
        }
    }
}