using NUnit.Framework;

namespace Project.medium
{
    public class Swap_Nodes_in_Pairs {

        [TestCase("2 1 4 3", 1,2,3,4)]
        [TestCase("2 1", 1,2)]
        [TestCase("1",1)]
        public void Test(string exp, params int[] val)
        {
            var head = new ListNode(val);
            var act = SwapPairs(head);
            Assert.AreEqual(exp, act.ToString());
        }

        // Implementation without dummy nodes
        public ListNode SwapPairs(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var first = head;
            var second = head.next;

            first.next = SwapPairs(second.next);
            second.next = first;
            return second;
        }

        public ListNode SwapPairs_II(ListNode head)
        {
            var dummy = new ListNode(0,head);
            Swap(dummy);
            return dummy.next;
        }

        private ListNode Swap(ListNode head)
        {
            if (head == null || head.next == null || head.next.next == null)
            {
                return head;
            }

            var first = head.next;
            var second = first.next;
            var third = second.next;

            head.next = second;
            second.next = first;
            first.next = third;

            Swap(first);
            return head;
        }
    }
}