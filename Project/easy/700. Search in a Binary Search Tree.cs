using Project.medium;

namespace Project.easy
{
    public class Search_in_a_Binary_Search_Tree
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
                if (root == null || root.val == val)
                {
                    return root;
                }


                if (val > root.val)
                {
                    return SearchBST(root.right, val);
                }

                return SearchBST(root.left, val);
        }
    }
}