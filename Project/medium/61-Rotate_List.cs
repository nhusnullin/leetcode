using NUnit.Framework;

namespace Project.medium
{
    public class Rotate_List
    {
        [TestCase(new[] {0, 1, 2}, 1, "2 0 1")]
        [TestCase(new[] {0, 1, 2}, 2, "1 2 0")]
        [TestCase(new[] {0, 1, 2}, 4, "2 0 1")]
        [TestCase(new[] {1,2}, 2, "1 2")]
        public void Test(int[] val, int k, string exp)
        {
            Assert.AreEqual(exp, RotateRight(new ListNode(val), k).ToString());
        }

        public ListNode RotateRight(ListNode head, int k)
        {
            int l = 1;
            var tail = head;
            while (tail.next != null)
            {
                l++;
                tail = tail.next;
            }

            if (l == k)
            {
                return head;
            }
            
            tail.next = head;

            if (l > k)
            {
                l -= k;
            }
            else
            {
                var n = k % l;
                l -= n;
            }

            while (l > 1)
            {
                head = head.next;
                l--;
            }

            var newHead = head.next;
            head.next = null;
            return newHead;
        }
    }
}