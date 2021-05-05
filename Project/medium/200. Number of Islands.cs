using NUnit.Framework;

namespace Project.medium
{
    public class TestNumber_of_Islands
    {
        [Test]
        public void Test()
        {
            var grid = new char[][]
            {
                new char[] {'1', '1', '1', '1', '0'},
                new char[] {'1', '1', '0', '1', '0'},
                new char[] {'1', '1', '0', '0', '0'},
                new char[] {'0', '0', '0', '0', '0'}
            };

            var calc = new Number_of_Islands();
            Assert.AreEqual(1, calc.NumIslands(grid));
        }
        
        [Test]
        public void Test2()
        {
            var grid = new char[][]
            {
                new char[] {'1','1','0','0','0'},
                new char[] {'1','1','0','0','0'},
                new char[] {'0','0','1','0','0'},
                new char[] {'0','0','0','1','1'}
            };

            var calc = new Number_of_Islands();
            Assert.AreEqual(3, calc.NumIslands(grid));
        }
    }

    public class Number_of_Islands
    {
        private readonly int[][] _directions = {
            new[] {1, 0},
            new[] {0, 1},
            new[] {0, -1},
            new[] {-1, 0},
        };

        private int _m;
        private int _n;
        private char[][] _grid;

        private const char Water = '0';
        private const char Land = '1';

        public int NumIslands(char[][] grid)
        {
            _grid = grid;
            _m = grid.Length;
            _n = grid[0].Length;

            var count = 0;

            for (var r = 0; r < _m; r++)
            {
                for (var c = 0; c < _n; c++)
                {
                    if (grid[r][c] != Land) continue;
                    
                    count++;
                    MarkIsland(r, c);
                }
            }

            return count;
        }

        private void MarkIsland(params int[] start)
        {
            foreach (var direction in _directions)
            {
                var r = start[0] + direction[0];
                var c = start[1] + direction[1];

                if (r < 0 || c < 0 || r >= _m || c >= _n || _grid[r][c] == Water)
                {
                    continue;
                }

                _grid[r][c] = Water;
                MarkIsland(r, c);
            }
        }
    }
}