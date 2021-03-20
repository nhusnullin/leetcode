using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Project.medium
{
    public class Node
    {
        public int val;
        public Node prev;
        public Node next;
        public Node child;

        public Node(params int[] val)
        {
            this.val = val[0];
            var prev = this;
            for (var i = 1; i < val.Length; i++)
            {
                var node = new Node(val[i]);
                prev.next = node;
                node.prev = prev;
                prev = node;
            }
        }

        public Node(int val)
        {
            this.val = val;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            var node = this;
            while (node != null)
            {
                str.Append($"{node.val} ");
                node = node.next;
            }

            return str.ToString().TrimEnd();
        }

        public string ToStringFromTail()
        {
            var tail = this;
            while (tail.next != null)
            {
                tail = tail.next;
            }

            var str = new StringBuilder();
            while (tail != null)
            {
                str.Append($"{tail.val} ");
                tail = tail.prev;
            }

            return str.ToString().Trim();
        }
    }

    public class Flatten_a_Multilevel_Doubly_Linked_List
    {
        [Test]
        public void Test()
        {
            var childHead = new Node(4, 5);
            var st = childHead.ToString();

            var head = new Node(1, 2, 3);
            head.next.child = childHead;

            var actual = Flatten(head);
            Assert.AreEqual("1 2 4 5 3", actual.ToString());
            Assert.AreEqual("3 5 4 2 1", actual.ToStringFromTail());
        }

        [Test]
        public void Test2()
        {
            var childHead = new Node(3);
            var st = childHead.ToString();

            var head = new Node(1, 2);
            head.next.child = childHead;

            var actual = Flatten(head);
            Assert.AreEqual("1 2 3", actual.ToString());
            Assert.AreEqual("3 2 1", actual.ToStringFromTail());
        }


        public Node Flatten(Node head)
        {
            if (head == null)
            {
                return null;
            }

            Recursively(head);
            return head;
        }


        public Node Recursively(Node childHead)
        {
            var tail = childHead;
            while (childHead != null)
            {
                if (childHead.child != null)
                {
                    tail = Recursively(childHead.child);
                    InsertInto(childHead, childHead.child, tail);
                    childHead.child = null;
                }

                tail = childHead;
                childHead = childHead.next;
            } 

            return tail;
        }

        public Node InsertInto(Node node, Node head, Node tail)
        {
            var next = node.next;
            node.next = head;
            head.prev = node;
            tail.next = next;
            if (next != null) next.prev = tail;
            return tail;
        }
    }
}