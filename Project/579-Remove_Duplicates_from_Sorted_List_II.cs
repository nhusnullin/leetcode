using System.Linq;
using NUnit.Framework;

namespace Project
{
    public class Tests
    {
        [TestCase(new int[] {0, 1, 2}, "0 1 2")]
        [TestCase(new int[] {0, 1, 1, 2}, "0 2")]
        [TestCase(new int[] {1, 1, 1, 2, 3}, "2 3")]
        [TestCase(new int[] {1, 2, 3, 3}, "1 2")]
        [TestCase(new int[] {1, 1, 1, 1}, null)]
        [TestCase(new int[] {1, 1, 2, 2}, null)]
        [TestCase(new int[] {1, 2, 2, 2}, "1")]
        [TestCase(new int[] {1, 2, 2, 2, 3}, "1 3")]
        [TestCase(new int[]{}, null)]
        [TestCase(null, null)]
        public void Test1(int[] actual, string expected)
        {
            ListNode head = null;
            if (actual != null)
            {
                head = new ListNode(actual);
            }
            var actualHead = DeleteDuplicatesViaLoop(head);
            Assert.AreEqual(expected, actualHead?.ToString());
        }

        public ListNode DeleteDuplicatesViaLoop(ListNode head)
        {
            var sentinel = new ListNode();

            var p = sentinel;
            int? dup = null;
            while (head != null)
            {
                if (head?.val == head?.next?.val || dup.HasValue && dup == head.val)
                {
                    dup = head.val;
                    head = head.next;
                    continue;
                }

                p.next = head;
                head = head.next;
                p = p.next;
            }

            p.next = null;
            return sentinel.next;
        }
            

        public ListNode DeleteDuplicates(ListNode head)
        {
            head = GetHead(head);
            if (head == null)
            {
                return head;
            }

            DeleteDuplicates(head, head.next);
            
            return head;
        }

        public void DeleteDuplicates(ListNode head, ListNode node, int? val = null)
        {
            if (node == null)
            {
                head.next = null;
                return;
            }
            
            if (node.val == node.next?.val)
            {
                DeleteDuplicates(head, node.next?.next, node.val);
                return;
            }
            
            if (val.HasValue && node.val == val)
            {
                DeleteDuplicates(head, node.next, node.val);
                return;
            }

            head.next = node;
            DeleteDuplicates(head.next, node.next, node.val);

        }

        private ListNode GetHead(ListNode head, bool toDelete = false)
        {
            if (head == null)
            {
                return null;
            }
            
            if (head.val != head.next?.val)
            {
                return toDelete ? GetHead(head.next) : head;
            }

            return GetHead(head.next, true);
        }
    }
}