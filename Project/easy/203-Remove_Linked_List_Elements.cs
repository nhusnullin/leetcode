using NUnit.Framework;

namespace Project.easy
{
    public class Remove_Linked_List_Elements
    {
        [TestCase(new[] {1, 2, 6, 3, 4, 5, 6}, new[] {1, 2, 3, 4, 5}, 6)]
        public void Test(int[] act, int[] exp, int val)
        {
            Assert.AreEqual(new ListNode(exp).ToString(), RemoveElements(new ListNode(act), val).ToString());
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
            {
                return null;
            }
            var dummy = new ListNode(-1, head);
            head = dummy;
            while (head.next !=null)
            {
                if(head.next.val == val)
                {
                    head.next = head.next?.next;
                }
                else
                {
                    head = head.next;
                }
            }

            return dummy.next;
        }
    }
}