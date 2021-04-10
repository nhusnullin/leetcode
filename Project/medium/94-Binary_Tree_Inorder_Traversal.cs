using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using NUnit.Framework;
using TreeNode = Project.medium.TreeNode;

namespace Project.medium
{
    public class Binary_Tree_Inorder_Traversal
    {
        [TestCase("1 3 2", 1, null, 2, 3)]
        [TestCase("1 2", 1, null, 2)]
        public void Test(string exp, params int?[] arr)
        {
            Assert.AreEqual(exp, string.Join(' ', InorderTraversal(new TreeNode(arr))));
        }


        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            //return InorderTraversalRecursively(root, result);
            return InorderTraversalIteratively(root);
        }

        public IList<int> InorderTraversalIteratively(TreeNode root)
        {
            var dic = new HashSet<TreeNode>();
            var result = new List<int>();
            var stack = new Stack<TreeNode>();
            var node = root;
            stack.Push(null);
            stack.Push(node);
            while (node != null)
            {
                if (node.left != null && !dic.Contains(node.left))
                {
                    node = node.left;
                    stack.Push(node);
                    continue;
                }

                if (!dic.Contains(node))
                {
                    result.Add(node.val);
                    dic.Add(node);
                }

                if (node.right != null && !dic.Contains(node.right))
                {
                    node = node.right;
                    stack.Push(node);
                    continue;
                }

                node = stack.Pop();
            }


            return result;
        }

        public IList<int> InorderTraversalRecursively(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return result;
            }

            InorderTraversalRecursively(root.left, result);

            result.Add(root.val);

            InorderTraversalRecursively(root.right, result);

            return result;
        }
    }
}