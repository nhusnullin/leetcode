using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Project.medium
{
    public class Linked_List_Cycle_II
    {
        [Test, Timeout(2000)]
        public void IntersectionTest()
        {
            var n1 = new ListNode(3);
            var n2 = new ListNode(2);
            var n3 = new ListNode(0);
            var n4 = new ListNode(-4);

            n1.AddNext(n2).AddNext(n3).AddNext(n4).AddNext(n2)
                ;

            Assert.AreEqual(n4, Intersection(n1));
            Assert.AreEqual(n2, DetectCycle(n1));
        }

        [TestCase(new[] {1, 2})]
        public void IntersectionTest2(int[] arr)
        {
            Assert.AreEqual(null, Intersection(new ListNode(arr)));
        }

        
        private ListNode Intersection(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var hare = head;
            var tortoise = head;

            while (hare?.next != null)
            {
                hare = hare.next.next;
                tortoise = tortoise.next;

                if (hare == tortoise)
                {
                    return tortoise;
                }
            }

            return null;
        }


        public ListNode DetectCycle(ListNode head)
        {
            var intersection = Intersection(head);
            if (intersection == null)
            {
                return null;
            }

            while (head != intersection)
            {
                head = head.next;
                intersection = intersection.next;
            }

            return head;
        }
    }
}