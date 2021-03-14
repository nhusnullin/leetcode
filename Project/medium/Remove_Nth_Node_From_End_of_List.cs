using NUnit.Framework;

namespace Project.medium
{
    class Remove_Nth_Node_From_End_of_List
    {
        [TestCase(new[] {1, 2, 3, 4, 5}, 2, new[] {1, 2, 3, 5})]
        [TestCase(new[] {1, 2}, 1, new[] {1})]
        [TestCase(new[] {1, 2}, 2, new[] {2})]
//        [TestCase(new[] {1}, 1, new int[] { })]
        public void Test(int[] arr, int n, int[] exp)
        {
            var head = new ListNode(arr);
            var actual = RemoveNthFromEnd(head, n);
            Assert.AreEqual(new ListNode(exp).ToString(), actual.ToString());
        }


        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var dummy = new ListNode(0, head);
            var first = dummy;
            var second = dummy;

            for (int i = 1; i <= n+1; i++)
            {
                first = first.next;
            }

            while (first!=null)
            {
                first = first.next;
                second = second.next;
            }

            second.next = second.next.next;
            
            return dummy.next;
        }

        public ListNode RemoveNthFromEnd_TwoPointers(ListNode head, int n)
        {
            var p1 = head;

            while (--n > 0)
            {
                p1 = p1.next;
            }

            if (p1.next == null)
            {
                return head.next;
            }

            var p2 = head;
            p1 = p1.next;

            while (p1.next != null)
            {
                p2 = p2.next;
                p1 = p1.next;
            }

            p2.next = p2.next.next;

            return head;
        }

        public ListNode RemoveNthFromEnd_TwoPassAlg(ListNode head, int n)
        {
            var length = 0;
            var node = head;
            while (node != null)
            {
                length++;
                node = node.next;
            }

            var delta = length - n;

            if (delta == 0)
            {
                return head?.next;
            }

            node = head;
            for (; delta > 1; --delta)
            {
                node = node.next;
            }

            node.next = node.next?.next;
            return head;
        }
    }
}