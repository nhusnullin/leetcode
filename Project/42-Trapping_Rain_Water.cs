using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using NUnit.Framework;

namespace Project
{
    [TestFixture]
    public class Trapping_Rain_Water
    {

        [TestCase(new int[]{4,2,0,3}, 4)]
        [TestCase(new int[]{1,7,8}, 0)]
        [TestCase(new int[]{5,4,1,2}, 1)]
        [TestCase(new int[]{4,2,0,3,2,5}, 9)]
        [TestCase(new int[]{0,1,0,2,1,0,1,3,2,1,2,1}, 6)]
        public void Test(int[] height, int expected)
        {
            Assert.AreEqual(expected, TrapStack(height));
        }

        public int TrapStack(int[] height)
        {
            if (height.Length <= 1)
            {
                return 0;
            }

            var trap = 0;
            var stack = new Stack<int>();
            var i = 0;
            while (i < height.Length)
            {
                while (stack.Count != 0 && height[i] > height[stack.Peek()])
                {
                    var top = stack.Pop();

                    if (stack.Count == 0)
                    {
                        break;
                    }
                    
                    var distance = i - stack.Peek() - 1;
                    var boundedHeight = Math.Min(height[i], height[stack.Peek()]) - height[top];
                    trap += distance * boundedHeight;
                }
                
                stack.Push(i++);
            }

            return trap;
        }
        
        public int TrapDynamic(int[] height)
        {
            if (height.Length <= 1)
            {
                return 0;
            }
            
            var left_max = new int[height.Length];
            var right_max = new int[height.Length];

            left_max[0] = height[0];
            for (var i = 1; i < height.Length; i++)
            {
                left_max[i] = Math.Max(height[i], left_max[i - 1]);
            }

            right_max[^1] = height[^1];
            for (int i = height.Length - 2; i >= 0; i--)
            {
                right_max[i] = Math.Max(height[i], right_max[i + 1]);
            }

            var trap = 0;
            for (int i = 1; i < height.Length - 1; i++)
            {
                trap += Math.Min(left_max[i], right_max[i]) - height[i];
            }

            return trap;
        }
        
        public int TrapBF(int[] height) {

            if (height.Length <= 1)
            {
                return 0;
            }

            var i = 1;
            var l = 0; // индекс левого максимум
            var r = 0; // индекс правого максимума
            var trap = 0;
            while (i < height.Length)
            {
                l = r;
                
                // ищем левый максимум в лесенке
                for (; i < height.Length; i++)
                {
                    if (height[l] <= height[i])
                    {
                        l = i;
                    }
                    else
                    {
                        r = i;
                        i++;
                        break;
                    }
                }

                // ищем след максимум
                for (; i < height.Length; i++)
                {
                    if (height[r] <= height[i])
                    {
                        r = i;
                    }

                    if (height[r] >= height[l])
                    {
                        break;
                    }
                }

                if (l == r || l == height.Length - 1)
                {
                    break;
                }
                
                // вернем i обратно ибо еще надо будет бегать 
                i = r;

                var limit = Math.Min(height[l], height[r]);
                
                for (var n = l + 1; n < r; n++)
                {
                    trap += limit - height[n];
                }

            }

            return trap;
        }
    }
}