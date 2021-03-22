using System.Text;
using NUnit.Framework;

namespace Project.medium
{
    public class Insert_into_a_Sorted_Circular_Linked_List
    {
        [TestCase(new[]{1,3,4}, 2, "1 2 3 4")]
        [TestCase(new[]{1,3,4}, 5, "1 3 4 5")]
        [TestCase(new[]{1,3,4}, 0, "1 3 4 0")]
        [TestCase(new[]{5,4}, 0, "5 0 4")]
        [TestCase(new[]{5,6}, 0, "5 6 0")]
        [TestCase(new[]{5,6}, 5, "5 5 6")]
        [TestCase(new[]{3,4,1}, 2, "3 4 1 2")]
        [TestCase(new []{3,5,1}, 0, "3 5 0 1")]
        [TestCase(new[]{1}, 2, "1 2")]
        public void Test(int[] val, int insertVal, string exp)
        {
            var head = new Node(val);
            Assert.AreEqual(exp, Insert(head, insertVal).ToString());
        }

        public Node Insert(Node head, int insertVal)
        {
            if (head == null)
            {
                head = new Node(insertVal);
                head.next = head;
                return head;
            }

            var prev = head;
            var curr = head.next;
            var insert = false;
            
            do
            {
                if (insertVal >= prev.val && insertVal <= curr.val)
                {
                    insert = true;
                }
                else if(prev.val > curr.val)
                {
                    if (insertVal >= prev.val || insertVal <= curr.val)
                    {
                        insert = true;
                    }
                }

                if (insert)
                {
                    InsertAfter(prev, insertVal);
                    return head;
                }

                prev = prev.next;
                curr = curr.next;
            } while (prev!= head);

            InsertAfter(prev, insertVal);
            return head;
        }

        public Node Insert_My(Node head, int insertVal)
        {
            if (head == null)
            {
                head = new Node(insertVal);
                head.next = head;
                return head;
            }

            if (head.next == null)
            {
                head.next = new Node(insertVal);
                head.next = head;
                return head;
            }

            var newHead = head;
            
            // find head with min val
            var node = head;
            do
            {
                if (node.val < head.val)
                {
                    head = node;
                }

                node = node.next;
            } while (node != head);
            
            node = head;
            do
            {
                if (node.next == head)
                {
                    InsertAfter(node, insertVal);
                    return newHead;
                }

                if (insertVal >= node.val && insertVal < node.next.val)
                {
                    InsertAfter(node, insertVal);
                    return newHead;
                }

                node = node.next;
            } while (node != head);


            return newHead;
        }


        public Node InsertAfter(Node node, int val)
        {
            var tmp = node.next;
            node.next = new Node(val, tmp);
            return node;
        }


        public class Node
        {
            public int val;
            public Node next;

            public Node()
            {
            }

            public Node(int _val)
            {
                val = _val;
                next = null;
            }

            public Node(int _val, Node _next)
            {
                val = _val;
                next = _next;
            }

            public Node(params int[] val)
            {
                this.val = val[0];
                var node = this;
                for (var i = 1; i < val.Length; i++)
                {
                    node.next = new Node(val[i]);
                    node = node.next;
                }

                node.next = this;
            }

            public override string ToString()
            {
                var head = this;
                var node = head;
                var str = new StringBuilder();
                do
                {
                    str.Append($"{node.val} ");
                    node = node.next;
                } while (node != head);

                return str.ToString().TrimEnd();
            }
        }
    }
}