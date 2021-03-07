using NUnit.Framework;

namespace Project.easy
{
    public class Linked_List_Cycle
    {
        [Test, Timeout(2000)]
        public void Test()
        {
            var n1 = new ListNode(3);
            var n2 = new ListNode(2);
            var n3 = new ListNode(0);
            var n4 = new ListNode(-4);

            n1.AddNext(n2).AddNext(n3).AddNext(n4).AddNext(n2)
                                                  ;
            
            Assert.AreEqual(true, HasCycle(n1));
        }

        [TestCase(new[] {1, 2})]
        public void Test2(int[] arr)
        {
            Assert.AreEqual(false, HasCycle(new ListNode(arr)));
        }
        
        
        public bool HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }
            
            var p1 = head;
            var p2 = head.next;

            while (p2?.next != null &&  p1 != p2)
            {
                p1 = p1?.next;
                p2 = p2?.next?.next;
            }

            return p2?.next != null;
        }
    }
}