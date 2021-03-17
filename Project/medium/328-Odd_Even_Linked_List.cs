using System.Xml;
using NUnit.Framework;

namespace Project.medium
{
    public class Odd_Even_Linked_List
    {
        [TestCase(new[] {1, 2, 3, 4, 5}, new[] {1, 3, 5, 2, 4})]
        [TestCase(new[] {2, 1, 3, 5, 6, 4, 7}, new[] {2, 3, 6, 7, 1, 5, 4})]
        public void Test(int[] act, int[] exp)
        {
            Assert.AreEqual(new ListNode(exp).ToString(), OddEvenList(new ListNode(act)).ToString());
        }

        [Test]
        public void Test()
        {
            Assert.AreEqual(null, OddEvenList(null));
        }

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            
            var odd = head;
            var evenHead = head?.next;
            var even = evenHead;

            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenHead;

            return head;
        }
        
        public ListNode OddEvenList_My(ListNode head)
        {

            if (head == null)
            {
                return null;
            }
            
            var oddTail = head;
            var evenHead = head?.next;
            var evenTail = head?.next;
            var cur = evenTail?.next;

            while (cur!= null)
            {
                evenTail.next = cur.next;
                cur.next = evenTail;
                oddTail.next = cur;

                evenTail = evenTail.next;
                oddTail = oddTail.next;

                cur = evenTail?.next;
            }

            oddTail.next = evenHead;
            
            return head;
        }
    }
}