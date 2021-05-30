using System;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;

namespace Project.hard
{
    public class N_Queens_II
    {
        [TestCase(2, 4)]
        [TestCase(1, 1)]
        //[TestCase(8,8)]
        public void Test(int exp, int n)
        {
            Assert.AreEqual(exp, TotalNQueens(n));
        }

        private bool[,] _board;
        private int _n;


        public int TotalNQueens(int n)
        {
            _n = n;
            _board = new bool[n, n];
            return BackTrack();
        }


        public int BackTrack(int row = 0, int cn = 0, int queens = 0)
        {
            for (var col = 0; col < _n; col++)
            {
                // is valid
                if (!IsValid(row, col)) continue;

                queens++;
                Place(row, col);

                if (row + 1 == _n && queens == _n)
                {
                    cn++;
                }
                else
                {
                    cn = BackTrack(row + 1, cn, queens);
                }

                queens--;
                Remove(row, col);
            }

            return cn;
        }

        private bool IsValid(int row, int col)
        {
            for (var i = 0; i < _n; i++)
            {
                if (_board[row, i] || _board[i, col] ||
                    (col - i >= 0 && row - i >= 0) && _board[row - i, col - i] ||
                    (col - i >= 0 && row + i < _n) && _board[row + i, col - i] ||
                    (col + i < _n && row + i < _n) && _board[row + i, col + i] ||
                    (col + i < _n && row - i >= 0) && _board[row - i, col + i]
                    
                    )
                    return false;
            }

            return true;
        }

        private void Remove(int row, int col)
        {
            Place(row, col, false);
        }

        private void Place(int row, int col, bool val = true)
        {
            _board[row, col] = val;

            //Visualize(_board);
        }

        private void Visualize(bool[,] a)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    var ch = a[i, j] ? 'x' : '.';
                    sb.Append($"{ch} ");
                }

                sb.AppendLine();
            }

            Trace.Write(sb.ToString());
        }
    }
}