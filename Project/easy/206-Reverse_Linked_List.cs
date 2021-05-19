using NUnit.Framework;

namespace Project.easy
{
    public class Reverse_Linked_List
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

        // 2021 06 19
        // recursively
        public ListNode ReverseList(ListNode head) {

            if (head == null || head.next == null)
            {
                return head;
            }

            var newHead = ReverseList(head.next);

            var next = head.next;
            head.next = null;
            next.next = head; 

            return newHead;
        }
        
        
        public ListNode ReverseList_1(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var curHead = head;
            while (head.next !=null)
            {
                var p = head.next;
                head.next = p.next;
                p.next = curHead;
                curHead = p;
            }

            return curHead;
        }
        
        public ListNode ReverseList_2(ListNode head)
        {
            if (head == null)
            {
                return null;
            }
            var node = head?.next;
            head.next = null;
            while (node != null)
            {
                var next = node.next;
                node.next = head;
                head = node;
                node = next;
            }

            return head;
        }
    }
}