using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Project.medium
{
    public class Validate_Binary_Search_Tree
    {
        [TestCase(true, 2, 1, 3)]
        [TestCase(false, 5, 1, 4, null, null, 3, 6)]
        [TestCase(false, 1, 1)]
        [TestCase(false, 1, null, 1)]
        [TestCase(false, 5, 4, 6, null, null, 3, 7)]
        public void Test(bool exp, params int?[] values)
        {
            var root = new TreeNode(values);
            Assert.AreEqual(exp, IsValidBST(root));
        }

        public bool IsValidBST(TreeNode root)
        {
            return false;
        }
        
        // recursively 
        public bool IsValidBSTRec(TreeNode root, int? lo = null, int? hi = null)
        {
            if (root == null) return true;

            if (lo != null && root.val <= lo ||
                hi != null && root.val >= hi)
                return false;

            return IsValidBSTRec(root.right, root.val, hi) && IsValidBSTRec(root.left, lo, root.val);
        }
    }
}