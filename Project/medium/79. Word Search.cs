using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Project.medium
{
    public class Word_Search_Test
    {
        [TestCase(true, "ABCCED", 4, 'A', 'B', 'C', 'E', 'S', 'F', 'C', 'S', 'A', 'D', 'E', 'E')]
        [TestCase(true, "SEE", 4, 'A','B','C','E','S','F','C','S','A','D','E','E')]
        [TestCase(false, "AAAAAAAAAAAAAAB", 6, 'A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A','A')]
        public void Test(bool exp, string word, int size, params char[] arr)
        {
            var board = new char[arr.Length / size][];
            for (int i = 0; i < arr.Length; i++)
            {
                int row = i / size;
                if (board[row] == null) board[row] = new char[size];
                board[row][i % size] = arr[i];
            }

            Assert.AreEqual(exp, new Word_Search().Exist(board, word));
        }
    }

    public class Word_Search
    {
        private string _word;

        private const char Used = '#';

        public bool Exist(char[][] board, string word)
        {
            _board = board;
            _word = word;
            for (int i = -1; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    if (BackTrack(i, j, 0)) return true;
                }
            }
            
            return false;
        }

        private readonly int[][] _directions = new[] { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { -1, 0 } };
        private char[][] _board;

        private bool BackTrack(int i, int j, int index)
        {
            if (index >= _word.Length) return true;

            foreach (var direction in _directions)
            {
                int row = i + direction[0];
                int col = j + direction[1];

                if (row < 0 || col < 0 ||
                    row >= _board.Length || col >= _board[0].Length ||
                    _word[index] != _board[row][col]
                    )
                {
                    continue;
                }

                _board[row][col] = Used;
                if (BackTrack(row, col, index+1)) return true;
                _board[row][col] = _word[index];
            }

            return false;
        }
        
    }
}