using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace Project.hard
{
    public class Sudoku_Solver
    {
        [TestCase(new char[]
        {
            '5', '3', '.', '.', '7', '.', '.', '.', '.',
            '6', '.', '.', '1', '9', '5', '.', '.', '.',
            '.', '9', '8', '.', '.', '.', '.', '6', '.',
            '8', '.', '.', '.', '6', '.', '.', '.', '3',
            '4', '.', '.', '8', '.', '3', '.', '.', '1',
            '7', '.', '.', '.', '2', '.', '.', '.', '6',
            '.', '6', '.', '.', '.', '.', '2', '8', '.',
            '.', '.', '.', '4', '1', '9', '.', '.', '5',
            '.', '.', '.', '.', '8', '.', '.', '7', '9'
        }, 9)]
        public void Test(char[] arr, int size)
        {
            var board = ConvertFrom(arr, size);

            SolveSudoku(board);
        }

        private static char[][] ConvertFrom(char[] arr, int size)
        {
            char[][] board = new char[size][];
            for (int i = 0; i < arr.Length; i++)
            {
                var row = i / size;
                if (board[row] == null) board[row] = new char[size];
                board[row][i % size] = arr[i];
            }

            return board;
        }


        [TestCase(true, '2', 0, 2)]
        [TestCase(false, '3', 1, 2)]
        public void TestIsValid(bool exp, char ch, int i, int j)
        {
            var arr = new char[]
            {
                '5', '3', '.', '.', '7', '.', '.', '.', '.',
                '6', '.', '.', '1', '9', '5', '.', '.', '.',
                '.', '9', '8', '.', '.', '.', '.', '6', '.',
                '8', '.', '.', '.', '6', '.', '.', '.', '3',
                '4', '.', '.', '8', '.', '3', '.', '.', '1',
                '7', '.', '.', '.', '2', '.', '.', '.', '6',
                '.', '6', '.', '.', '.', '.', '2', '8', '.',
                '.', '.', '.', '4', '1', '9', '.', '.', '5',
                '.', '.', '.', '.', '8', '.', '.', '7', '9'
            };
            var board = ConvertFrom(arr, 9);
            Assert.AreEqual(exp, IsValid(board, ch, i, j));
        }

        // -----

        private const char Empty = '.';
        private const int Zero = (int) '0';

        public void SolveSudoku(char[][] board)
        {
            SolveSudoku(board, 0, 0);
        }

        public void SolveSudoku(char[][] board, int i, int j)
        {
            Visualize(board);
            if (IsOptimal(board)) throw new NotImplementedException();

            for (; i < board.Length; i++)
            {
                for (; j < board[i].Length; j++)
                {
                    if (!IsEmpty(board, i, j)) continue;

                    for (var n = 1; n < 10; n++)
                    {
                        if (!IsValid(board, (char) (Zero + n), i, j)) continue;

                        Place(board, i, j, n);
                        SolveSudoku(board, i, j);
                        Remove(board, i, j);
                    }

                    // if (IsEmpty(board, i, j)) return;
                }
            }
        }

        private static void Visualize(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    Trace.Write($"{board[i][j]} ");
                }

                Trace.WriteLine(" ");
            }

            Trace.WriteLine("------------------------");
        }

        public static bool IsOptimal(char[][] board)
        {
            for (var i = 0; i < board.Length; i++)
            {
                for (var j = 0; j < board[i].Length; j++)
                {
                    if (board[i][j] == Empty)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool IsEmpty(char[][] board, int i, int j)
        {
            return board[i][j] == Empty;
        }

        public static bool IsValid(char[][] board, char val, int i, int j)
        {
            for (var k = 0; k < board.Length; k++)
            {
                if (board[k][j] == val ||
                    board[i][k] == val ||
                    board[i / 3 * 3 + k / 3][j / 3 * 3 + k % 3] == val
                ) return false;
            }

            return true;
        }

        private static bool IsValid(char[][] board, int i, int j)
        {
            return IsValidRow(board, i) && IsValidColumn(board, j) && IsValidBox(board, i, j);
        }

        private static bool IsValidRow(char[][] board, int i)
        {
            var arr = new HashSet<char>(10);
            for (int j = 0; j < board[i].Length; j++)
            {
                var ch = board[i][j];
                if (ch == Empty) continue;
                if (arr.Contains(ch)) return false;
                arr.Add(ch);
            }

            return true;
        }

        private static bool IsValidColumn(char[][] board, int j)
        {
            var arr = new HashSet<char>(10);
            for (int i = 0; i < board.Length; i++)
            {
                var ch = board[i][j];
                if (ch == Empty) continue;
                if (arr.Contains(ch)) return false;
                arr.Add(ch);
            }

            return true;
        }

        private static bool IsValidBox(char[][] board, int i, int j)
        {
            var box_i = i / 3;
            var box_j = j / 3;

            var arr = new HashSet<char>(10);

            for (i = box_i * 3; i < box_i * 3 + 3; i++)
            {
                for (j = box_j * 3; j < box_j * 3 + 3; j++)
                {
                    var ch = board[i][j];
                    if (ch == Empty) continue;
                    if (arr.Contains(ch)) return false;
                    arr.Add(ch);
                }
            }

            return true;
        }

        private static void Remove(char[][] board, int i, int j)
        {
            board[i][j] = Empty;
        }

        private static void Place(char[][] board, int i, int j, int n)
        {
            board[i][j] = (char) (Zero + n);
        }
    }
}