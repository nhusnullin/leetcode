using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Project.easy
{
    class Intersection_of_Two_Linked_Lists
    {
        [TestCase(new[] {4, 1}, new[] {5, 6, 1}, new[] {8, 4, 5}, 8)]
        [TestCase(new[] {1, 9, 1}, new[] {3}, new[] {2, 4}, 2)]
        [TestCase(new int[] {}, new int[] {}, new int[] { 1 }, 1)]
        public void Test1(int[] head1, int[] head2, int[] tail, int expected)
        {
            var n = tail.Length == 0 ? null : new ListNode(tail);

            var root1 = head1.Length == 0 ? new ListNode(new int[]{}, n) : new ListNode(head1, n); 
            var root2 = head2.Length == 0 ? new ListNode(new int[]{}, n) : new ListNode(head2, n); 

            Assert.AreEqual(expected, GetIntersectionNode(root1, root2)?.val);
        }

        [Test]
        public void TestNull()
        {
            Assert.AreEqual(null, GetIntersectionNode(null, null)?.val);
        }

        private ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var p1 = headA;
            var p2 = headB;

            while (p1 != p2)
            {
                p1 = p1 == null ? headB : p1 = p1.next;
                p2 = p2 == null ? headA : p2 = p2.next;
            }

            return p1;
        }

        private ListNode GetIntersectionNodeLength(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
            {
                return null;
            }

            var node = headA;
            var aCount = 0;
            do
            {
                node = node.next;
                aCount++;
            } while (node != null);

            node = headB;
            var bCount = 0;
            do
            {
                node = node.next;
                bCount++;
            } while (node != null);

            if (aCount == 1 && bCount == 1 && headA.val == headB.val)
            {
                return headA;
            }

            var delta = Math.Abs(bCount - aCount);

            if (aCount > bCount)
            {
                var tmp = headA;
                headA = headB;
                headB = tmp;
            }

            for (; delta > 0; delta--)
            {
                headB = headB.next;
            }

            do
            {
                if (headA == headB)
                {
                    return headA;
                }

                headA = headA.next;
                headB = headB.next;
            } while (headA != null);

            return null;
        }

        private ListNode GetIntersectionNodeDic(ListNode headA, ListNode headB)
        {
            if (headA == null || headB == null)
            {
                return null;
            }

            if (headA.next == null && headB.next == null)
            {
                return headA.val == headB.val ? headA : null;
            }

            var dic = new Dictionary<ListNode, int?>();
            var node = headA;
            do
            {
                dic.Add(node, null);
                node = node?.next;
            } while (node != null);

            node = headB;
            do
            {
                if (dic.ContainsKey(node))
                {
                    return node;
                }

                node = node?.next;
            } while (node != null);

            return null;
        }
    }
}