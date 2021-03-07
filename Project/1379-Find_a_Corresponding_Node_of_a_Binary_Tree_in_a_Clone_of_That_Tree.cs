using System.Collections.Generic;
using NUnit.Framework;

namespace Project
{
    public class TreeNode
    {
        public int? val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode()
        {
            
        }
        
        public TreeNode(int x)
        {
            val = x;
        }
        
        public TreeNode(int?[] arr)
        {
            var queue = new Queue<TreeNode>(arr.Length);
            queue.Enqueue(new TreeNode());
            
            foreach (var item in arr)
            {
                var node = queue.Dequeue();
                node.val = item;
                node.left = new TreeNode();
                node.right = new TreeNode();
                
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
        }
    }

    

    [TestFixture]
    public class Find_a_Corresponding_Node_of_a_Binary_Tree_in_a_Clone_of_That_Tree
    {
        private static object[][] _combinationTests = new[]
        {
            new object[] {new int? [] {7,4,3,null,null,6,19}, new TreeNode(3), true},
            new object[] {new int? [] {8,null,6,null,5,null,4,null,3,null,2,null,1}, new TreeNode(1), true}
            
        };
        
        [Test]
        [TestCaseSource(nameof(_combinationTests))]
        public void Test(int?[] arr, TreeNode target, bool expected)
        {
            var cloned = new TreeNode(arr);
            Assert.AreEqual(expected, GetTargetCopy(null, target, target).val == target.val);
        }
        
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {

            return Search(cloned, target);

        }

        public TreeNode Search(TreeNode head, TreeNode target)
        {
            if (head == null)
            {
                return null;
            }
            
            if (head.val == target.val)
            {
                return head;
            }

            var node = Search(head.left, target);
            if (node != null)
            {
                return node;
            }
            
            node = Search(head.right, target);
            return node;
        }
    }
}