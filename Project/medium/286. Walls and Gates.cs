using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Project.medium
{
    public class Walls_and_Gates
    {
        public const int Gate = 0;
        public const int Wall = -1;
        public const int Empty = Int32.MaxValue;

        public int[][] Directions = new[]
        {
            new[] {0, -1},
            new[] {-1, 0},
            new[] {1, 0},
            new[] {0, 1},
        };

        public void WallsAndGates(int[][] space)
        {
            var rooms = new Queue<Tuple<int, int>>();
            int m = space.Length;
            int n = space[0].Length;

            // find all gates
            for (int i = 0; i < space.Length; i++)
            {
                for (int j = 0; j < space[i].Length; j++)
                {
                    if (space[i][j] == Gate)
                    {
                        rooms.Enqueue(new Tuple<int, int>(i, j));
                    }
                }
            }

            while (rooms.Any())
            {
                var room = rooms.Dequeue();

                foreach (var direction in Directions)
                {
                    var r = room.Item1 + direction[0];
                    var c = room.Item2 + direction[1];

                    if (r < 0 || c < 0 || r >= m || c >= n || space[r][c] != Empty)
                    {
                        continue;
                    }

                    space[r][c] = space[room.Item1][room.Item2] + 1;
                    rooms.Enqueue(new Tuple<int, int>(r, c));
                }
            }
        }
    }
}