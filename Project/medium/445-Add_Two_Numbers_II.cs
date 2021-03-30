using NUnit.Framework;

namespace Project.medium
{
    public class Add_Two_Numbers_II
    {
        [TestCase(new[] {7, 2, 4, 3}, new[] {5, 6, 4}, new[] {7, 8, 0, 7})]
        [TestCase(new[]{0}, new []{1}, new []{1})]
        [TestCase(new[]{5},new[]{5}, new []{1,0})]
        public void Test(int[] arr1, int[] arr2, int[] exp)
        {
            var r = Reverse(new ListNode(arr1));
            Assert.AreEqual(new ListNode(exp).ToString(), AddTwoNumbers(new ListNode(arr1), new ListNode(arr2)).ToString());
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var revL1 = Reverse(l1);
            var revL2 = Reverse(l2);

            var newHead = new ListNode(0);
            var node = newHead;
            bool tensPosition=false;
            while (revL1 != null || revL2!= null)
            {
                var sum = Norm(revL1?.val) + Norm(revL2?.val);

                if (revL1 != null) revL1 = revL1.next;
                if (revL2 != null) revL2 = revL2.next;
                
                sum += node.val;
                if (sum / 10 > 0)
                {
                    node.val = sum % 10;
                    node.next = new ListNode(sum / 10);
                    tensPosition = true;
                }
                else
                {
                    node.val = sum;
                    node.next = new ListNode(0);
                    tensPosition = false;
                }
                node = node.next;

            }

            newHead = Reverse(newHead);
            return tensPosition ? newHead : newHead.next;
        }

        public int Norm(int? val)
        {
            return val ?? 0;
        }
        
        public ListNode Reverse(ListNode head)
        {
            var curHead = head;
            while (head.next != null)
            {
                var p = head.next;
                head.next = p.next;
                p.next = curHead;
                curHead = p;
            }

            return curHead;
        }
    }
}