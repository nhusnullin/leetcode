using System.Xml.Schema;
using NUnit.Framework;

namespace Project.medium
{
    public class MyLinkedList
    {
        public ListNode Head => head;
        public ListNode Tail => GetTail();
        
        private ListNode head;

        /** Initialize your data structure here. */
        public MyLinkedList()
        {
            head = null;
        }

        public MyLinkedList(ListNode root)
        {
            head = null;

            if (root.val != -1)
            {
                head = root;
            }
        }

        private ListNode GetTail()
        {
            var cur = head;

            while (cur!= null && cur.next != null)
            {
                cur = cur.next;
            }
            
            return cur;
        }

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
        {
            var cur = GetNode(index);
            return cur?.val ?? -1;
        }

        private ListNode GetNode(int index)
        {
            var cur = head;
            for (int i = 0; i < index && cur != null; i++)
            {
                cur = cur.next;
            }

            return cur;
        }

        

        /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
        public void AddAtHead(int val)
        {
            var cur = new ListNode(val);
            cur.next = head;
            head = cur;
        }
        
        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            if (head == null)
            {
                AddAtHead(val);
                return;
            }

            var cur = GetTail();
            cur.next = new ListNode(val);
        }
        
        /**
         * Add a node of value val before the index-th node in the linked list.
         * If index equals to the length of linked list, the node will be appended to the end of linked list.
         * If index is greater than the length, the node will not be inserted.
         */
        public void AddAtIndex(int index, int val)
        {
            if (index == 0)
            {
                AddAtHead(val);
                return;
            }

            var prev = GetNode(index - 1);
            if (prev == null)
            {
                return;
            }

            var cur = new ListNode(val);
            var next = prev.next;

            prev.next = cur;
            cur.next = next;

        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
        {
            var cur = GetNode(index);
            if (cur == null)
            {
                return;
            }

            var prev = GetNode(index - 1);
            var next = cur.next;

            if (prev != null)
            {
                prev.next = next;
            }
            else
            {
                head = next;
            }
        }

        [TestCase(new[]{1,2},3, new []{1,2,3})]
        [TestCase(new int []{}, 1, new[]{1})]
        public void TestAddAtTail(int[] list, int val, int[] exp)
        {
            var ll = new MyLinkedList(new ListNode(list));
            ll.AddAtTail(val);
            Assert.AreEqual(new ListNode(exp).ToString(), ll.Head.ToString());
            Assert.AreEqual(exp[^1], ll.Tail.val);
        }
        
        [TestCase(new[] {2, 3, 4}, 1, 1, new[] {1, 2, 3, 4})]
        [TestCase(new[] {1, 3, 4}, 2, 2, new[] {1, 2, 3, 4,})]
        [TestCase(new[] {1, 2, 3}, 4, 4, new[] {1, 2, 3, 4,})]
        public void TestAddAtIndex(int[] list, int index, int val, int[] exp)
        {
            var ll = new MyLinkedList(new ListNode(list));
            ll.AddAtIndex(index, val);
            Assert.AreEqual(new ListNode(exp).ToString(), ll.Head.ToString());
            Assert.AreEqual(exp[0], ll.Head.val);
            Assert.AreEqual(exp[^1], ll.Tail.val);
        }
        
        [TestCase(new int[]{}, 1,new[]{1})]
        [TestCase(new[]{2}, 1,new[]{1,2})]
        public void TestAddAtHead(int[] list, int val, int[] exp)
        {
            var ll = new MyLinkedList(new ListNode(list));
            ll.AddAtHead(val);
            Assert.AreEqual(new ListNode(exp).ToString(), ll.Head.ToString());
            Assert.AreEqual(exp[0], ll.Head.val);
            Assert.AreEqual(exp[^1], ll.Tail.val);
            Assert.AreEqual(exp[^1], ll.Tail.val);
        }
        
        [TestCase(new[] {1, 2, 3}, 1, new[] {2, 3})]
        [TestCase(new[] {1, 2, 3}, 2, new[] {1, 3})]
        [TestCase(new[] {1, 2, 3}, 3, new[] {1, 2})]
        [TestCase(new[] {1, 2, 3}, 5, new[] {1, 2, 3})]
        [TestCase(new[] {1, 2, 3}, 6, new[] {1, 2, 3})]
        public void TestDeleteAtIndex(int[] list, int index, int[] exp)
        {
            var root = new ListNode(list);
            var ll = new MyLinkedList(root);
            ll.DeleteAtIndex(index);
            Assert.AreEqual(new ListNode(exp).ToString(), ll.Head.ToString());
            Assert.AreEqual(exp[0], ll.Head.val);
            Assert.AreEqual(exp[^1], ll.Tail.val);
        }

        [Test]
        public void Test1()
        {
            var ll = new MyLinkedList();
            ll.AddAtHead(2);
            ll.DeleteAtIndex(1);
            ll.AddAtHead(2);
            ll.AddAtHead(7);
            ll.AddAtHead(3);
            ll.AddAtHead(2);
            ll.AddAtHead(5);
            ll.AddAtTail(5);
            ll.Get(5);
            ll.DeleteAtIndex(6);
            ll.DeleteAtIndex(4);
        }

        [Test]
        public void Test2()
        {
            var ll = new MyLinkedList();
            ll.AddAtHead(1);
            ll.AddAtTail(3);
            ll.AddAtIndex(1,2);
            Assert.AreEqual(2,ll.Get(1));
            ll.DeleteAtIndex(1);
            Assert.AreEqual(3, ll.Get(1));

        }
    }
}