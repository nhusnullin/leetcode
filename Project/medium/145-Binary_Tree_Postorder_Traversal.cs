using System.Collections.Generic;
using System.Xml.Schema;
using NUnit.Framework;

namespace Project.medium
{
    public class Binary_Tree_Postorder_Traversal
    {
        [TestCase("3 2 1", 1, null, 2, 3)]
        [TestCase("2 1", 1, 2)]
        [TestCase("2 1", 1, null, 2)]
        public void Test(string exp, params int?[] arr)
        {
            Assert.AreEqual(exp, string.Join(' ', PostorderTraversal(new TreeNode(arr))));
        }

        public IList<int> PostorderTraversal(TreeNode root)
        {
            // return PostorderTraversalRecursively(root, new List<int>());
            return PostorderTraversalIteratively(root);
        }

        public IList<int> PostorderTraversalIteratively(TreeNode root)
        {
            var result = new List<int>();
            var stack = new Stack<TreeNode>();

            while (root!= null || stack.Count > 0)
            {
                while (root!= null)
                {
                    if(root.right!= null) stack.Push(root.right);
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();

                if (stack.Count > 0 && root.right == stack.Peek())
                {
                    stack.Pop();
                    stack.Push(root);
                    root = root.right;
                }
                else
                {
                    result.Add(root.val);
                    root = null;
                }

            }
            
            
            return result;
        }
        
        public IList<int> PostorderTraversalRecursively(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return result;
            }

            PostorderTraversalRecursively(root.left, result);
            PostorderTraversalRecursively(root.right, result);

            result.Add(root.val);
            return result;
        }
    }
}