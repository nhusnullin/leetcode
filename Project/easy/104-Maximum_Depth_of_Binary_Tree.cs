using System;
using Project.medium;

namespace Project.easy
{
    public class Maximum_Depth_of_Binary_Tree {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            var left = MaxDepth(root.left);
            var right = MaxDepth(root.right);

            return Math.Max(left, right) + 1;

        }

        private int _answer = 0;
        public int MaxDepthTopDown(TreeNode root)
        {
            MaxDepthTopDown(root, 1);
            return _answer;
        }
        
        public void MaxDepthTopDown(TreeNode root, int depth)
        {
            if (root == null)
            {
                return;
            }

            if (root.left == null && root.right == null)
            {
                _answer = Math.Max(_answer, depth);
            }
            
            MaxDepthTopDown(root.left, depth + 1);
            MaxDepthTopDown(root.right, depth + 1);
            
            
        }
    }
}