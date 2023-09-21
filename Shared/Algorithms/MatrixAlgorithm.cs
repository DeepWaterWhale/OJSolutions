namespace Shared.Algorithms
{
    public static class MatrixAlgorithm
    {
        public static long[,] MakeMatrix(int height, int width, long[] nums)
        {
            var matrix = new long[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = nums[(i * width) + j];
                }
            }

            return matrix;
        }

        public static long[,] Multiple(long[,] m1, long[,] m2, long MOD = -1)
        {
            int len1 = m1.GetLength(0), len2 = m1.GetLength(1), len3 = m2.GetLength(0), len4 = m2.GetLength(1);
            long[,] ans = new long[len1, len4];
            for (int i = 0; i < len1; i++)
            {
                for (int j = 0; j < len4; j++)
                {
                    ans[i, j] = 0;
                    for (int k = 0; k < len3; k++)
                    {
                        ans[i, j] += m1[i, k] * m2[k, j];
                        if (MOD != -1)
                        {
                            ans[i, j] = ans[i, j] % MOD;
                        }
                    }
                }
            }

            return ans;
        }

        public static long[,] FastExponential(long[,] matrix, long exp, long MOD = -1)
        {
            int height = matrix.GetLength(0), width = matrix.GetLength(1);
            long[,] ans = new long[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    ans[i, j] = 0;
                }

                ans[i, i] = 1;
            }

            while (exp > 0)
            {
                if (exp % 2 == 1)
                {
                    ans = Multiple(ans, matrix, MOD);
                }

                matrix = Multiple(matrix, matrix, MOD);
                exp /= 2;
            }

            return ans;
        }
    }
}
