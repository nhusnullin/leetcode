using System.Collections.Generic;
using NUnit.Framework;

namespace Project.easy
{
    public class Pascal_s_Triangle_II
    {
        [TestCase(new[] {1, 3, 3, 1}, 3)]
        public void Test(int[] exp, int rowIndex)
        {
            Assert.AreEqual(new List<int>(exp), GetRow(rowIndex));
        }

        private int[,] _cache;

        public IList<int> GetRow(int rowIndex)
        {
            _cache = new int[rowIndex+1, rowIndex+1];
            var res = new List<int>();
            for (var i = 0; i <= rowIndex; i++)
            {
                res.Add(Calc(rowIndex, i));
            }

            return res;
        }

        public int Calc(int i, int j)
        {
            if (i < 0 || j < 0)
            {
                return 0;
            }

            if (i == 0 && j == 0 || i == 1 && j == 0 || i == 1 && j == 1)
            {
                return 1;
            }

            if (_cache[i, j] != 0)
            {
                return _cache[i, j];
            }
            
            _cache[i,j] = Calc(i - 1, j - 1) + Calc(i - 1, j);

            return _cache[i, j];
        }
    }
}