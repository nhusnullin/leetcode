using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Project.medium
{
    public class Copy_List_with_Random_Pointer {

        [Test]
        public void Test()
        {
            var head = new Node(1,2,3);
            head.random = head.next;

            var newHead = CopyRandomList(head);
        }
        
        public Node CopyRandomList(Node head)
        {

            if (head == null)
            {
                return null;
            }
            
            var store = new Dictionary<Node, Node>();

            var clonedHead = new Node(head.val);
            store.Add(head, clonedHead);

            var node = head.next;
            var clonedNode = clonedHead;

            while (node != null)
            {
                clonedNode.next = new Node(node.val);
                clonedNode = clonedNode.next;

                if (!store.ContainsKey(node))
                {
                    store.Add(node, clonedNode);
                }

                node = node.next;
            }

            node = head;
            while (node != null)
            {
                if (node.random != null)
                {
                    store[node].random = store[node.random];
                }
                else
                {
                    store[node].random = null;
                }

                node = node.next;
            }

            return clonedHead;
        }

        public class Node
        {
            public int val;
            public Node random;
            public Node next;

            public Node(int _val, Node _next)
            {
                val = _val;
                next = _next;
            }

            public Node(params int[] val)
            {
                this.val = val[0];
                var prev = this;
                for (var i = 1; i < val.Length; i++)
                {
                    var node = new Node(val[i]);
                    prev.next = node;
                    prev = node;
                }
            }

            public Node(int val)
            {
                this.val = val;
                this.next = null;
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
        }
    }
}