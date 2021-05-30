using System.Collections.Generic;

namespace Project.easy
{
    public class Kids_With_the_Greatest_Number_of_Candies
    {
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var max = 0;
            foreach (var candy in candies)
            {
                if (candy > max) max = candy;
            }

            var res = new bool[candies.Length];
            for (int i = 0; i < candies.Length; i++)
            {
                res[i] = candies[i] + extraCandies >= max;
            }

            return res;
        }
    }
}