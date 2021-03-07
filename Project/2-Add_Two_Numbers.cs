using NUnit.Framework;

namespace Project
{
    [TestFixture]
    public class Add_Two_Numbers
    {
        [TestCase(new int[]{2,4,3}, new int[]{5,6,4}, "7 0 8")]
        [TestCase(new int[]{9,9,9,9,9,9,9}, new int[]{9,9,9,9}, "8 9 9 9 0 0 0 1")]
        public void Test(int[] arr1, int[] arr2, string expected)
        {
            var l1 = new ListNode(arr1);
            var l2 = new ListNode(arr2);

            var actualHead = AddTwoNumbers(l1, l2);
            Assert.AreEqual(expected, actualHead.ToString());
        }
        
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var r = new ListNode();
            var d = new ListNode(-1, r);
            var a = 0;
            while (true)
            {
                var val = (l1?.val ?? 0) + (l2?.val ?? 0) + a;
                r.val = val % 10;
                a = val / 10;

                l1 = l1?.next;
                l2 = l2?.next;
                
                if (l1 == null && l2 == null)
                {
                    if (a > 0)
                    {
                        r.next = new ListNode(a);
                    }
                    break;
                }
                
                r.next = new ListNode();
                r = r.next;
            }

            return d.next;
        }
    }
}