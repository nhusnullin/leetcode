using NUnit.Framework;

namespace Project.medium
{
    public class Count_Univalue_Subtrees
    {
        [TestCase(4, 5, 1, 5, 5, 5, null, 5)]
        [TestCase(6, 5, 5, 5, 5, 5, null, 5)]
        public void Test(int exp, params int?[] arr)
        {
            Assert.AreEqual(exp, CountUnivalSubtrees(new TreeNode(arr)));
        }


        public int count = 0;
        public int CountUnivalSubtrees(TreeNode root)
        {
            count = 0;
            if (root == null)
            {
                return 0;
            }
            
            IsUnivalSubtree(root);
            return count;
        }

        public bool IsUnivalSubtree(TreeNode root)
        {
            if (root == null)
                return true;

            var res = true;

            if (root.left != null)
            {
                res &= IsUnivalSubtree(root.left);
                res &= root.left.val == root.val;
            }

            if (root.right != null)
            {
                res &= IsUnivalSubtree(root.right);
                res &= root.right.val == root.val;
            }

            if (res)
            {
                count++;
            }

            return res;
        }
    }
}