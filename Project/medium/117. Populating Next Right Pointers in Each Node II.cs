using NUnit.Framework;
using Node = Project.medium.Populating_Next_Right_Pointers_in_Each_Node.Node;

namespace Project.medium
{
    public class Populating_Next_Right_Pointers_in_Each_Node_II
    {
        [TestCase("-1,#,0,1,#,2,3,4,5,#,6,7,8,9,10,11,12,13,#,", -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13)]
        [TestCase("1,#,2,3,#,4,5,7,#,", 1, 2, 3, 4, 5, null, 7)]
        [TestCase("3,#,9,20,#,15,7,#,", 3, 9, 20, null, null, 15, 7)]
        [TestCase("-1,#,-7,9,#,-1,-7,#,8,-9,#,", -1, -7, 9, null, null, -1, -7, null, 8, -9)]
        public void Test(string exp, params int?[] arr)
        {
            Assert.AreEqual(exp, Connect(new Node(arr)).ToString());
        }

        public Node Connect(Node root)
        {
            if (root == null)
            {
                return root;
            }

            var leftMost = root;
            while (leftMost != null)
            {
                var head = leftMost;
                while (head != null)
                {
                    // connect 1
                    if (head.left != null)
                    {
                        head.left.next = head.right;
                    }

                    // connect 2
                    var node = head.right ?? head.left;
                    if (node != null)
                    {
                        while (head.next != null)
                        {
                            var next = head.next.left ?? head.next.right;
                            if (next != null)
                            {
                                node.next = next;
                                break;
                            }
                            head = head.next;
                        }
                    }

                    head = head?.next;
                }

                while (leftMost != null)
                {
                    var node = leftMost.left ?? leftMost.right;

                    if (node != null)
                    {
                        leftMost = node;
                        break;
                    }

                    leftMost = leftMost.next;
                }
            }

            return root;
        }
    }
}