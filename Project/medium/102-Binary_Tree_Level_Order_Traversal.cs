using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using NUnit.Framework;

namespace Project.medium
{
    public class Binary_Tree_Level_Order_Traversal
    {
        [TestCase("3,9 20,15 7", 3, 9, 20, null, null, 15, 7)]
        [TestCase("1,2,3,4,5", 1, 2, null, 3, null, 4, null, 5)]
        public void Test(string exp, params int?[] arr)
        {
            var root = new TreeNode(arr);
            var res = LevelOrder(root);
            var act = string.Join(',', res.Select(list => string.Join(' ', list)));
            Assert.AreEqual(exp, act);
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var output = new List<IList<int>>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var nextQueue = new Queue<TreeNode>();
                var localOutput = new List<int>();

                while (queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    if (node == null)
                    {
                        continue;
                    }

                    localOutput.Add(node.val);

                    nextQueue.Enqueue(node.left);
                    nextQueue.Enqueue(node.right);
                }

                queue = nextQueue;
                if (localOutput.Any())
                    output.Add(localOutput);
            }

            return output;
        }
    }
}