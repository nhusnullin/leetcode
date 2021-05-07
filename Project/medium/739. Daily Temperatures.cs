using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Project.medium
{
    public class Daily_Temperatures
    {
        [TestCase(new[] {1, 1, 4, 2, 1, 1, 0, 0}, new[] {73, 74, 75, 71, 69, 72, 76, 73})]
        [TestCase(new[] {8, 1, 5, 4, 3, 2, 1, 1, 0, 0}, new[] {89, 62, 70, 58, 47, 47, 46, 76, 100, 70})]
        [TestCase(new[] {1, 0, 0, 2, 1, 0, 0, 0, 0, 0}, new[] {34, 80, 80, 34, 34, 80, 80, 80, 80, 34})]
        public void Test(int[] exp, int[] T)
        {
            Assert.AreEqual(exp, DailyTemperatures(T));
        }

        public int[] DailyTemperatures(int[] T)
        {
            if (T.Length < 2) return new[] {0};
            var res = new int[T.Length];
            var stack = new Stack<int>();
            for (int j = 1; j < T.Length; j++)
            {
                stack.Push(j - 1);

                if (T[j - 1] >= T[j])
                {
                    continue;
                }

                while (stack.Any())
                {
                    var peek = stack.Peek();
                    var delta = T[j] - T[peek];

                    if (delta <= 0) break;

                    res[peek] = j - peek;
                    stack.Pop();
                }
            }

            return res;
        }
    }
}