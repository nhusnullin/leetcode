using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Project.medium
{
    public class Maximal_Square
    {
        [TestCase(4, 5, '1', '0', '1', '0', '0', '1', '0', '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', '0', '1', '0')]
        [TestCase(4, 2, '1', '1', '1', '1')]
        public void Test(int exp, int size, params char[] arr)
        {
            var matrix = new char[arr.Length / size][];
            for (int i = 0; i < arr.Length; i++)
            {
                var row = i / size;
                var col = i % size;
                if (matrix[row] == null) matrix[row] = new char[size];
                matrix[row][col] = arr[i];
            }

            Assert.AreEqual(exp, MaximalSquare(matrix));
        }

        
        public int MaximalSquare(char[][] matrix)
        {
            var res = 0;
            var memo = new Dictionary<Tuple<int, int>, int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    res = Math.Max(res, MaximalSquare(matrix, i, j, memo));
                }
            }

            return res * res;
        }

        public int MaximalSquare(char[][] matrix, int i, int j, Dictionary<Tuple<int, int>, int> memo)
        {
            if (i >= matrix.Length || j >= matrix[i].Length || matrix[i][j] == '0') return 0;

            var point = new Tuple<int, int>(i, j);
            if (memo.ContainsKey(point)) return memo[point];
            
            
            memo[point] = Math.Min(
                Math.Min(MaximalSquare(matrix, i + 1, j, memo), MaximalSquare(matrix, i, j + 1, memo)),
                MaximalSquare(matrix, i + 1, j + 1, memo)) + 1;

            return memo[point];
        }
    }
}