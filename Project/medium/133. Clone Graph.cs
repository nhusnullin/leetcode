using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Project.medium
{
    public class Clone_Graph
    {
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        [Test]
        public void Test()
        {
            var nodes = new Node[] {new Node(0), new Node(1), new Node(2), new Node(3), new Node(4)};
            var root = nodes[1];

            nodes[1].neighbors.Add(nodes[2]);
            nodes[1].neighbors.Add(nodes[4]);

            nodes[2].neighbors.Add(nodes[1]);
            nodes[2].neighbors.Add(nodes[3]);

            nodes[3].neighbors.Add(nodes[2]);
            nodes[3].neighbors.Add(nodes[4]);

            nodes[4].neighbors.Add(nodes[1]);
            nodes[4].neighbors.Add(nodes[3]);

            var res = CloneGraph(root);
        }

        private Dictionary<int, Node> _cache = new Dictionary<int, Node>();

        public Node CloneGraph(Node node)
        {
            var root = new Node() {val = node.val};
            _cache.Add(node.val, node);
            CloneGraph(node, root);
            return root;
        }

        public void CloneGraph(Node source, Node destination)
        {
            if (source.neighbors == null || !source.neighbors.Any())
            {
                return;
            }

            foreach (var neighbor in source.neighbors)
            {
                var isExist = destination.neighbors.Any(x => x.val == neighbor.val);
                if (!isExist)
                {
                    Node node;
                    if (_cache.ContainsKey(neighbor.val))
                    {
                        node = _cache[neighbor.val];
                    }
                    else
                    {
                        node = new Node()
                        {
                            val = neighbor.val
                        };
                    }

                    destination.neighbors.Add(node);
                    CloneGraph(neighbor, node);
                }
            }
        }
    }
}