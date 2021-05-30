namespace Project.medium
{
    public class Search_a_2D_Matrix_II
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            if (matrix[0][0] > target || matrix[^1][^1] < target) return false;

            return FindColumn(matrix, target, 0, matrix.Length - 1, 0, matrix[0].Length - 1);
        }

        private bool FindColumn(int[][] m, int target, int i1, int i2, int j1, int j2)
        {
            if (m[i1][j1] == target) return true;

            if (i1 == i2 && j1 == j2) return false;

            int mid = 0;
            
            mid = i1 + (i2 - i1) / 2;
            if (m[mid][j1] > target) i2 = mid;
            
            mid = j1 + (j2 - j1) / 2;
            if (m[i1][mid] > target) j2 = mid;

            return false;
        }


        /*
            Input [
            [1,2,3,4,5],
            [6,7,8,9,10],
            [11,12,13,14,15],
            [16,17,18,19,20],
            [21,22,23,24,25]]
            19
            Output false
            Expected true
         */
    }
}