using System;
using NUnit.Framework;

namespace Project.easy
{
    public class Reverse_Linked_List_recursively
    {
        [TestCase(new[] {1, 2, 3, 4, 5}, new[] {5, 4, 3, 2, 1})]
        [TestCase(new[] {1, 2}, new[] {2, 1})]
        public void Test(int[] act, int[] exp)
        {
            Assert.AreEqual(new ListNode(exp).ToString(), ReverseList(new ListNode(act)).ToString());
        }

        [Test]
        public void TestNull()
        {
            Assert.AreEqual(null, ReverseList(null));
        }

        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            if (head.next == null)
            {
                return head;
            }

            var next = head.next;
            head.next = null;
            var newHead = ReverseList(next);
            next.next = head;

            return newHead;
        }
    }
}