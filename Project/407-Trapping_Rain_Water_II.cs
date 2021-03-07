using System;
using NUnit.Framework;

namespace Project
{
    [TestFixture]
    public class Trapping_Rain_Water_II
    {
        private static object[][] _combinationTests = new[]
        {
            new object[] {new[] {new[]{ 1,4,3,1,3,2} , new []{3,2,1,3,2,4}, new []{2,3,3,2,3,1}}, 4},
        };
            
        [Test]
        [TestCaseSource(nameof(_combinationTests))]
        public void Test(int[][] heightMap, int expected)
        {
            Assert.AreEqual(expected, TrapRainWater(heightMap));
        } 
        
        public int TrapRainWater(int[][] heightMap)
        {

            var leftMax = new int [heightMap[1].Length];
            leftMax[0] = heightMap[0][1];
            for (int i = 0; i < heightMap[1].Length; i++)
            {
                // leftMax[i] = Math.Max()
            }

            return -1;
        }
    }
}