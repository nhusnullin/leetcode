using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Project.easy
{
    public class Path_Sum
    {
        [TestCase(true, 22, 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, null, 1)]
        [TestCase(false, 5, 1, 2, 3)]
        [TestCase(true, -1, 1, -2, -3, 1, 3, -2, null, -1)]
        public void Test(bool exp, int targetSum, params int?[] arr)
        {
            Assert.AreEqual(exp, HasPathSum(new medium.TreeNode(arr), targetSum));
        }

        public bool HasPathSum(medium.TreeNode root, int targetSum)
        {
            var stack = new Stack<medium.TreeNode>();
            var stackSum = new Stack<int>();

            stack.Push(root);
            stackSum.Push(root.val);

            while (stack.Any())
            {
                var node = stack.Pop();
                var remain = stackSum.Pop();

                if (node.left == null && node.right == null && remain == targetSum)
                {
                    return true;
                }

                if (node.left != null)
                {
                    stack.Push(node.left);
                    stackSum.Push(remain + node.left.val);
                }

                if (node.right != null)
                {
                    stack.Push(node.right);
                    stackSum.Push(remain + node.right.val);
                }
            }

            return false;
        }

        public bool HasPathSumRecursively(medium.TreeNode root, int targetSum)
        {
            if (root == null)
            {
                return false;
            }

            if (root.left == null && root.right == null)
            {
                return root.val == targetSum;
            }

            var left = HasPathSum(root.left, targetSum - root.val);
            var right = HasPathSum(root.right, targetSum - root.val);

            return left || right;
        }
    }
}