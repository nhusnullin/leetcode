using System;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace Project
{
    [TestFixture]
    public class Merge_k__Sorted_Lists
    {

        private static object[][] _combinationTests = new[]
        {
            new object[]
            {
                new[] {new[] {1, 4, 5}, new[] {1, 3, 4}, new[] {2, 6}},
                new[] {1, 1, 2, 3, 4, 4, 5, 6}
            },
        };

        [Test]
        [TestCaseSource(nameof(_combinationTests))]
        public void Test(int[][] lists, int[] expected)
        {
          Assert.AreEqual(new ListNode(expected).ToString(), MergeKLists(lists.Select(x=>new ListNode(x)).ToArray()).ToString());  
        }
        
        public ListNode MergeKLists(ListNode[] lists)
        {
            var root = new ListNode(new int[2]);
            var current = root.next;
            
            for(int i=0;i<lists.Length;i++)
            {
                var dummy = new ListNode();
                dummy.next = lists[i];
                lists[i] = dummy;
            }

            var min = new ListNode(new[]{0, Int32.MaxValue});
            bool isOver = false;
            while (!isOver)
            {
                isOver = true;
                for (var i = 0; i < lists.Length; i++)
                {
                    if (lists[i].next != null && lists[i].next.val <= min.next?.val)
                    {
                        isOver = false;
                        min = lists[i];
                    }

                    current.next = min.next;
                    min.next = min.next?.next;

                    if (current.next == null)
                    {
                        Debugger.Break();
                            
                    }
                    current = current.next;
                }
            }

            return root;

        }
    }


}