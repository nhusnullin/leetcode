using NUnit.Framework;

namespace Project.easy
{
    public class Palindrome_Linked_List
    {
        [TestCase(new[] {1, 2, 2, 1}, true)]
        [TestCase(new[] {1, 2, 1}, true)]
        [TestCase(new[] {1, 2}, false)]
        public void Test(int[] list, bool result)
        {
            // Assert.AreEqual(result, IsPalindrome(new ListNode(list)));
            Assert.AreEqual(result, IsPalindrome(new ListNode(list)));
        }

        [Test]
        public void TestOnNUll()
        {
            Assert.AreEqual(false, IsPalindrome(null));
        }
        
        ListNode curHead;

        public bool IsPalindrome(ListNode head)
        {
            if(head == null)
            {
                return false;
            }
            curHead = new ListNode(0,head);
            return IsPalindromeDeep(head);
        }

        public bool IsPalindromeDeep(ListNode head)
        {
            if (head == null) return true;

            if (!IsPalindromeDeep(head.next)) return false;

            curHead = curHead.next;
            return curHead.val == head.val;
        }


        public bool IsPalindromeIterate(ListNode head)
        {
            if (head == null)
            {
                return false;
            }

            var slow = head;
            var fast = head;
            while (fast.next != null && fast.next.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            var reverseHead = slow.next;
            slow.next = null;

            reverseHead = Reverse(reverseHead);

            while (reverseHead != null && head != null)
            {
                if (reverseHead.val != head.val)
                {
                    return false;
                }

                reverseHead = reverseHead.next;
                head = head.next;
            }

            return true;
        }


        private ListNode Reverse(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var currentHead = head;
            while (head.next != null)
            {
                var p = head.next;
                head.next = p.next;
                p.next = currentHead;
                currentHead = p;
            }

            return currentHead;
        }
    }
}