using System;
using NUnit.Framework;

namespace Project
{
    [TestFixture]
    public class Create_Sorted_Array_through_Instructions
    {
        [TestCase(new []{1,5,6,2}, 1)]
        [TestCase(new []{1,2,3,6,5,4}, 3)]
        [TestCase(new []{1,3,3,3,2,4,2,1,2}, 4)]
        public void Test(int[] instructions, int expected)
        {
            Assert.AreEqual(expected, CreateSortedArray(instructions));
        }
        
        public int CreateSortedArray(int[] instructions)
        {

            var ans = 0;
            for (int i = 0; i < instructions.Length; i++)
            {
                var less = 0;
                var greather = 0;

                for (int j = 0; j < i; j++)
                {
                    if (instructions[i] > instructions[j]) less++;
                    if (instructions[i] < instructions[j]) greather++;
                }
                ans += Math.Min(less, greather);

            }

            return ans;
        }
    }
}