using NUnit.Framework;

namespace Project.easy
{
    class Height_Checker
    {
        [TestCase(new[]{1,1,4,2,1,3}, 3)]
        [TestCase(new[]{31,81,41,78,48,2,83,48,21,20,43,15,26,78,96,55,5,46,35,89,85,54,76,64,71,36,98,94,100,7,88,92,80,43,24,89,50,61,59,20,94,57,99,62,82,46,28,57,66,62,56,15,12,63,19,35,12,26,15,59,8,44,46,45,33,20,27,31,85,15,92,63,63,40,35,95,91,1,4,57,55,68,53,28,15,94,74,89,77,7,25,63,77,24,76,44},2)]
        public void Test(int[] height, int exp)
        {
            Assert.AreEqual(exp, HeightChecker(height));
        }
        
        public int HeightChecker(int[] heights)
        {

            var countedHeights = new int[101];
            foreach (var height in heights)
            {
                countedHeights[height]++;
            }

            var sortedHeight = new int[heights.Length];
            int j = 0;
            for (int i = 0; i < countedHeights.Length; i++)
            {
                if (countedHeights[i] == 0) continue;
                for (int k = 0; k < countedHeights[i]; k++)
                {
                    sortedHeight[j++] = i;
                }
            }

            var res = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] != sortedHeight[i])
                {
                    res++;
                }
            }

            return res;
        }
    }
}