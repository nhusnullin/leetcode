using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using NUnit.Framework;

namespace Project.medium
{
    public class Populating_Next_Right_Pointers_in_Each_Node
    {
        [TestCase("-1,#,0,1,#,2,3,4,5,#,6,7,8,9,10,11,12,13,#,", -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13)]
        public void Test(string exp, params int?[] arr)
        {
            Assert.AreEqual(exp, Connect(new Node(arr)).ToString());
            Assert.AreEqual(exp, ConnectMyVersion(new Node(arr)).ToString());
        }

        // Approach 2: Using previously established next pointers
        public Node Connect(Node root)
        {
            if (root == null)
            {
                return null;
            }

            var leftNode = root;

            while (leftNode.left != null)
            {
                var head = leftNode;
                while (head != null)
                {
                    // connection 1
                    head.left.next = head.right;

                    // connection 2
                    if (head.next != null)
                    {
                        head.right.next = head.next.left;
                    }

                    head = head.next;
                }

                leftNode = leftNode.left;
            }

            return root;
        }


        public Node ConnectMyVersion(Node root)
        {
            var queue = new Queue<Node>();
            if (root?.left != null) queue.Enqueue(root.left);
            if (root?.right != null) queue.Enqueue(root.right);
            var levelLenght = 1;
            while (queue.Any())
            {
                levelLenght *= 2;

                var prev = queue.Dequeue();
                if (prev.left != null) queue.Enqueue(prev.left);
                if (prev.right != null) queue.Enqueue(prev.right);

                for (var i = 1; i < levelLenght && queue.Any(); i++)
                {
                    var node = queue.Dequeue();
                    prev.next = node;
                    prev = node;

                    if (prev.left != null) queue.Enqueue(prev.left);
                    if (prev.right != null) queue.Enqueue(prev.right);
                }
            }

            return root;
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node()
            {
            }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }

            public Node(params int?[] arr)
            {
                if (arr == null || arr.Length == 0 || arr[0] == null)
                {
                    return;
                }

                var index = 0;
                var root = this;
                root.val = arr[index++].Value;
                var queue = new Queue<Node>();
                queue.Enqueue(root);

                while (index < arr.Length)
                {
                    var node = queue.Dequeue();
                    var value = arr[index++];
                    if (value != null)
                    {
                        node.left = new Node(value.Value);
                        queue.Enqueue(node.left);
                    }

                    if (index >= arr.Length) continue;

                    value = arr[index++];
                    if (value == null) continue;

                    node.right = new Node(value.Value);
                    queue.Enqueue(node.right);
                }
            }

            public override string ToString()
            {
                var root = this;
                var sb = new StringBuilder();
                
                
                while (root != null)
                {
                    var head = root;
                    while (head!= null)
                    {
                        sb.Append($"{head.val},");
                        head = head.next;
                    }

                    sb.Append("#,");
                    while (root!= null)
                    {
                        var nextRoot = root.left ?? root.right;
                        if (nextRoot != null)
                        {
                            root = nextRoot;
                            break;
                        }

                        root = root.next;
                    }
                    
                }

                return sb.ToString();
            }
        }
    }
}