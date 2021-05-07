using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.easy
{
    public class MinStack
    {
        class Node
        {
            public int val;
            public int min;
        }

        private List<Node> _array;

        public MinStack()
        {
            _array = new List<Node>();
        }

        public void Push(int val)
        {
            var min = _array.Any() ? Math.Min(_array[^1].min, val) : val;
            
            _array.Add(new Node()
            {
                val = val,
                min = min
            });
        }

        public void Pop()
        {
            _array.RemoveAt(_array.Count-1);
        }

        public int Top()
        {
            return _array[^1].val;
        }

        public int GetMin()
        {
            return _array[^1].min;
        }
    }
}