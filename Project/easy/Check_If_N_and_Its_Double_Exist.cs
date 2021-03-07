using System.Collections.Generic;
using NUnit.Framework;

namespace Project.easy
{
    class Check_If_N_and_Its_Double_Exist
    {
        [TestCase(new[]{10,2,5,3}, true)]
        [TestCase(new[]{7,1,14,11}, true)]
        [TestCase(new[]{-2,0,10,-19,4,6,-8}, false)]
        [TestCase(new[]{4,-7,11,4,18}, false)]
        public void Test(int[] arr, bool exp)
        {
            Assert.AreEqual(exp, CheckIfExist(arr));
        }

        public bool CheckIfExist(int[] arr)
        {
            var map = new Dictionary<int,int>();

            for (var i = 0; i < arr.Length; i++)
            {
                var num = arr[i];
                if (!map.ContainsKey(num))
                {
                    map.Add(num, i);
                }

                if (map.ContainsKey(num * 2) && map[num*2] != i)
                {
                    return true;
                }

                if (num % 2 == 0 && map.ContainsKey(num / 2) && map[num / 2] != i)
                {
                    return true;
                }
            }

            return false;
        }
    }
}