namespace LeetCode.TODOs.RamdomPick
{
    using System;

    internal class Problem0329
    {
        public class Solution
        {
            // dp[i][j] is the max length when starting at i,j
            private int[][] dp;
            private int height;
            private int width;
            public int LongestIncreasingPath(int[][] matrix)
            {
                height = matrix.Length;
                width = matrix[0].Length;
                dp = new int[height][];
                for (int i = 0; i < height; ++i)
                {
                    dp[i] = new int[width];
                    for (int j = 0; j < width; ++j)
                    {
                        dp[i][j] = -1;
                    }
                }

                int ans = 1;
                for (int i = 0; i < height; ++i)
                {
                    for (int j = 0; j < width; ++j)
                    {
                        ans = Math.Max(ans, Solve(matrix, i, j));
                    }
                }

                return ans;
            }

            private int Solve(int[][] matrix, int i, int j)
            {
                if (dp[i][j] != -1)
                {
                    return dp[i][j];
                }

                dp[i][j] = 1;
                if (i > 0 && matrix[i][j] < matrix[i - 1][j])
                {
                    dp[i][j] = Math.Max(dp[i][j], Solve(matrix, i - 1, j) + 1);
                }

                if (i < height - 1 && matrix[i][j] < matrix[i + 1][j])
                {
                    dp[i][j] = Math.Max(dp[i][j], Solve(matrix, i + 1, j) + 1);
                }

                if (j > 0 && matrix[i][j] < matrix[i][j - 1])
                {
                    dp[i][j] = Math.Max(dp[i][j], Solve(matrix, i, j - 1) + 1);
                }

                if (j < width - 1 && matrix[i][j] < matrix[i][j + 1])
                {
                    dp[i][j] = Math.Max(dp[i][j], Solve(matrix, i, j + 1) + 1);
                }

                return dp[i][j];
            }
        }
    }
}
