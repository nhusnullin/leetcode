using System;
using NUnit.Framework;

namespace Project.medium
{
    public class Lowest_Common_Ancestor_of_a_Binary_Tree
    {
        [TestCase(5, 5, 4, 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4)]
        [TestCase(3, 5, 1, 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4)]
        public void Test(int exp, int p, int q, params int?[] arr)
        {
            var root = new TreeNode(arr);
            var pNode = new TreeNode(p);
            var qNode = new TreeNode(q);

        }

        // 1. Recursive Approach
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            LowestCommonAncestorRecursive(root, p, q);
            return _node;
        }

        private TreeNode _node;

        public bool LowestCommonAncestorRecursive(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return false;

            var l = LowestCommonAncestorRecursive(root.left, p, q);
            var r = LowestCommonAncestorRecursive(root.right, p, q);

            if (l && r ||
                (l || r) && (root.val == p.val || root.val == q.val))
            {
                _node = root;
            }

            return l || r || root.val == p.val || root.val == q.val;
        }
    }
}