using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using NUnit.Framework;
using Project.easy;

namespace Project.medium
{
    public class Binary_Tree_Preorder_Traversal
    {
        [TestCase("1 2 3", 1, null, 2, 3)]
        [TestCase("1", 1)]
        [TestCase("3 1 2", 3, 1, 2)]
        public void Test(string exp, params int?[] arr)
        {
            Assert.AreEqual(exp, string.Join(' ', PreorderTraversal(new TreeNode(arr))));
        }

        public IList<int> PreorderTraversal(TreeNode root)
        {
            return PreorderTraversalIteratively(root);
            // return PreorderTraversalRecursively(root, new List<int>());
        }

        public IList<int> PreorderTraversalIteratively(TreeNode root)
        {
            var result = new List<int>();

            if (root == null)
            {
                return result;
            }

            var left = root;
            var stack = new Stack<TreeNode>();
            while (left != null)
            {
                result.Add(left.val);
                if (left.right != null)
                {
                    stack.Push(left.right);
                }

                left = left.left;
                if (left == null && stack.Count > 0)
                {
                    left = stack.Pop();
                }
            }

            return result;
        }

        public IList<int> PreorderTraversalRecursively(TreeNode root, List<int> result)
        {
            if (root == null)
            {
                return result;
            }

            result.Add(root.val);
            PreorderTraversalRecursively(root.left, result);
            PreorderTraversalRecursively(root.right, result);

            return result;
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            var node = obj as TreeNode;
            if (node == null)
            {
                return false;
            }

            return this.val == node.val;
        }

        public override string ToString()
        {
            var root = this;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var builder = new StringBuilder();
            while (queue.Any())
            {
                var node = queue.Dequeue();
                if (node == null)
                {
                    continue;
                }
                builder.Append($"{node.val},");
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }

            return builder.ToString();
        }

        public TreeNode(params int?[] arr)
        {
            if (arr == null || arr.Length == 0 || arr[0] == null)
            {
                return;
            }

            var index = 0;
            var root = this;
            root.val = arr[index++].Value;
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (index < arr.Length)
            {
                var node = queue.Dequeue();
                var value = arr[index++];
                if (value != null)
                {
                    node.left = new TreeNode(value.Value);
                    queue.Enqueue(node.left);
                }

                if (index >= arr.Length) continue;

                value = arr[index++];
                if (value == null) continue;

                node.right = new TreeNode(value.Value);
                queue.Enqueue(node.right);
            }
        }
    }
}