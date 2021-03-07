using System.Text;

namespace Project
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode()
        {
            val = -1;
        }

        public ListNode AddNext(ListNode node)
        {
            next = node;
            return node;
        }
            
        
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public ListNode(int[] values):this()
        {
            var prev = this;
            for (int i = 0; i < values.Length; i++)
            {
                if (i == 0)
                {
                    prev.val = values[0];
                    continue;
                }

                var node = new ListNode(values[i]);
                prev.next = node;
                prev = node;
            }
        }

        public override string ToString()
        {
            return ToString(this, new StringBuilder()).ToString().Trim();
        }

        private StringBuilder ToString(ListNode node, StringBuilder builder)
        {
            if (node != null)
            {
                builder.Append($" {node.val}");
                ToString(node.next, builder);
            }

            return builder;
        }
    }
}