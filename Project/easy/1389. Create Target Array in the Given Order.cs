using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Project.easy
{
    public class Create_Target_Array_in_the_Given_Order {

        [TestCase(new[]{0,4,1,3,2}, new []{0,1,2,3,4}, new []{0,1,2,2,1})]
        public void Test(int[] exp, int[] nums, int[] index)
        {
            Assert.AreEqual(exp, CreateTargetArray(nums,index));
        }
        
        public int[] CreateTargetArray(int[] nums, int[] index)
        {
            var list = new ArrayList();
            for (int i = 0; i < index.Length; i++)
            {
                list.Insert(index[i], nums[i]);
            }

            var target = new int[nums.Length];
            for (int i = 0; i < list.Count; i++)
            {
                target[i] = (int)list[i];
            }
            
            return target;

        }
    }
}