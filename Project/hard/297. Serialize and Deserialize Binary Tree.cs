using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Project.medium;


namespace Project.hard
{
    public class Serialize_and_Deserialize_Binary_Tree
    {
        [TestCase(1, 2, 3)]
        [TestCase(1, null, 3, 4)]
        [TestCase(1, 2, 3, null, null, 4, 5)]
        [TestCase(1, 2, 3, null, null, 4, 5, 6, 7)]
        public void Test(params int?[] arr)
        {
            var initRoot = new TreeNode(arr);
            var str = serialize(initRoot);
            var actRoot = deserialize(str);
            Assert.AreEqual(initRoot.ToString(), actRoot.ToString());
        }


        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
            {
                return string.Empty;
            }

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            var builder = new StringBuilder();
            while (queue.Any())
            {
                var size = queue.Count;
                var levelIsExist = false;
                var levelBuilder = new StringBuilder();

                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    if (node == null)
                    {
                        levelBuilder.Append("null,");
                        // queue.Enqueue(null);
                        // queue.Enqueue(null);
                    }
                    else
                    {
                        levelBuilder.Append($"{node.val},");
                        queue.Enqueue(node.left);
                        queue.Enqueue(node.right);
                        levelIsExist = true;
                    }
                }

                if (levelIsExist)
                {
                    builder.Append(levelBuilder);
                }
                else
                {
                    break;
                }
            }

            return builder.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            var dataSplit = data.Split(",");
            if (!dataSplit.Any())
            {
                return null;
            }

            var arr = new int?[dataSplit.Length - 1];
            for (int i = 0; i < arr.Length; i++)
            {
                if (int.TryParse(dataSplit[i], out var val))
                {
                    arr[i] = val;
                }
                else
                {
                    arr[i] = null;
                }
            }

            var queue = new Queue<TreeNode>();
            var arrIndex = 0;
            var root = new TreeNode(arr[arrIndex++].Value);
            queue.Enqueue(root);
            while (arrIndex < arr.Length)
            {
                var node = queue.Dequeue();
                var leftVal = arr[arrIndex++];

                if (leftVal != null)
                {
                    node.left = new TreeNode(leftVal.Value);
                    queue.Enqueue(node.left);
                }

                if (arrIndex >= arr.Length)
                {
                    continue;
                }

                var rightVal = arr[arrIndex++];
                if (rightVal != null)
                {
                    node.right = new TreeNode(rightVal.Value);
                    queue.Enqueue(node.right);
                }
            }


            return root;
        }
    }
}