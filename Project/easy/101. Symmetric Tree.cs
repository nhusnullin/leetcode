using NUnit.Framework;

namespace Project.easy
{
    public class Symmetric_Tree
    {
        [TestCase(true, 1, 2, 2, 3, 4, 4, 3)]
        [TestCase(false, 1, 2, 2, 3, 5, 4, 3)]
        [TestCase(false, 1, 2, 2, null, 3, null, 3)]
        public void Test(bool exp, params int?[] arr)
        {
            Assert.AreEqual(exp, IsSymmetric(new medium.TreeNode(arr)));
        }

        public bool IsSymmetric(medium.TreeNode root)
        {
            if (root == null)
            {
                return false;
            }

            return IsSymmetric(root.left, root.right);
        }

        public bool IsSymmetric(medium.TreeNode lefTreeNode, medium.TreeNode rightTreeNode)
        {
            if (lefTreeNode == null || rightTreeNode == null)
            {
                return lefTreeNode == rightTreeNode;
            }

            var left = IsSymmetric(lefTreeNode.left, rightTreeNode.right);
            var right = IsSymmetric(lefTreeNode.right, rightTreeNode.left);

            return left && right & lefTreeNode.val == rightTreeNode.val;
        }
    }
}