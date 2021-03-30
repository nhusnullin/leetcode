using NUnit.Framework;

namespace Project.easy
{
    public class Merge_Two_Sorted_Lists
    {
        [TestCase(new[] {1, 2}, new[] {3, 4}, "1 2 3 4")]
        public void Test(int[] arr1, int[] arr2, string exp)
        {
            Assert.AreEqual(exp, MergeTwoLists(new ListNode(arr1), new ListNode(arr2)).ToString());
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {

            var arr = new[] {l1, l2};
            var newHead = new ListNode();
            var node = newHead;
            while (TryGetNextMinIndexNode(arr, out var minIndex))
            {
                node.next = arr[minIndex];
                node = node.next;
                arr[minIndex] = arr[minIndex].next;
            }
            
            return newHead.next;
        }

        public bool TryGetNextMinIndexNode(ListNode[] arr, out int minIndex)
        {
            minIndex = -1;
            for(var i=0;i<arr.Length;i++)
            {
                var node = arr[i];
                if (node != null && (minIndex == -1 || node.val <= arr[minIndex].val))
                {
                    minIndex = i;
                }
            }

            return minIndex != -1;
        }

    }
}