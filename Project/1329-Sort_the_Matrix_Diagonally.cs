using System;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NUnit.Framework;

namespace Project
{
    [TestFixture]
    public class Sort_the_Matrix_Diagonally
    {
        private static object[][] _combinationTests = new[]
        {
            new object[]
            {
                new[] {new[] {3, 3, 1, 1}, new[] {2, 2, 1, 2}, new[] {1, 1, 1, 2}},
                new[] {new[] {1, 1, 1, 1}, new[] {1, 2, 2, 2}, new[] {1, 2, 3, 3}}
            },
        };

        [Test]
        [TestCaseSource(nameof(_combinationTests))]
        public void Test(int[][] mat, int[][] expected)
        {
            Assert.AreEqual(expected, DiagonalSort2(mat));
        }

        public void CountingSort()
        {
            
        }

        public void SortDiagonal(int[][] mat, int i, int j)
        {
            var n = mat.Length;
            var m = mat[0].Length;
            
            var array = new int[Math.Min(n - i, m - j )];
            var index = 0;
            while (i<n && j < m)
            {
                array[index++] = mat[i][j];
                i++;
                j++;
            }
            Array.Sort(array);

            var ar_i = array.Length - 1;
            while (i>0 && j >0)
            {
                --i;
                --j;
                mat[i][j] = array[ar_i--];
            }
        }


        public int[][] DiagonalSort2(int[][] mat)
        {
            for (int i = 0; i < mat.Length; i++)
            {
                SortDiagonal(mat, i,0);
            }

            for (int j = 0; j < mat[0].Length; j++)
            {
                SortDiagonal(mat, 0, j);
            }

            return mat;
        }

        public int[][] DiagonalSort(int[][] mat)
        {
            bool isOk;
            var ii = new bool[mat.Length];
            do
            {
                isOk = true;
                for (var i = 0; i < mat.Length; i++)
                {
                    // if(ii[i]) continue;

                    for (var j = 0; j < mat[0].Length; j++)
                    {
                        var d = Math.Min(i + j + 1, mat[0].Length);
                        if(j>d) continue;
                        
                        isOk &= !Swap(mat, i, j);
                    }

                    // ii[i] |= isOk;
                }
            } while (!isOk);
                

            return mat;
        }

        public bool Swap(int[][] mat, int i, int j)
        {
            if (i + 1 >= mat.Length ||
                j + 1 >= mat[0].Length)
            {
                return false;
            }

            if (mat[i][j] > mat[i + 1][j + 1])
            {
                var tmp = mat[i][j];
                mat[i][j] = mat[i + 1][j + 1];
                mat[i + 1][j + 1] = tmp;
                return true;
            }

            return false;
        }


    }
}