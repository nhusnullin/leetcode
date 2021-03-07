using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using NUnit.Framework;

namespace Project
{
    [TestFixture]
    public class Boats_to_Save_People
    {
        [TestCase(new[]{1,2}, 3, 1)]
        [TestCase(new[]{3,2,2,1}, 3, 3)]
        [TestCase(new[]{3,5,3,4}, 5, 4)]
        public void Test(int[] people, int limit, int expected)
        {
            Assert.AreEqual(expected, NumRescueBoats(people, limit));
        }
        
        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);

            var i = 0;
            var j = people.Length - 1;
            var ans = 0;
            
            while (i <= j)
            {
                if (people[i] + people[j] <= limit)
                {
                    ans++;
                    i++;
                    j--;
                }
                else
                {
                    j--;
                    ans++;
                }
            }

            return ans;
        }
    }
}