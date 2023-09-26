namespace LeetCode.WeeklyContest.WC345
{
    using System;

    internal class Problem2684
    {
        public class Solution
        {
            public int MaxMoves(int[][] grid)
            {
                int cols = grid[0].Length;
                int rows = grid.Length;
                int[,] max = new int[rows, cols];
                for (int row = 0; row < rows; ++row)
                {
                    max[row, cols - 1] = 0;
                }

                for (int col = cols - 2; col >= 0; --col)
                {
                    for (int row = 0; row < rows; ++row)
                    {
                        max[row, col] = 0;
                        if (row > 0 && grid[row][col] < grid[row - 1][col + 1])
                        {
                            max[row, col] = Math.Max(max[row, col], max[row - 1, col + 1] + 1);
                        }

                        if (grid[row][col] < grid[row][col + 1])
                        {
                            max[row, col] = Math.Max(max[row, col], max[row, col + 1] + 1);
                        }

                        if (row < rows - 1 && grid[row][col] < grid[row + 1][col + 1])
                        {
                            max[row, col] = Math.Max(max[row, col], max[row + 1, col + 1] + 1);
                        }
                    }
                }

                int ans = 0;
                for (int row = 0; row < rows; ++row)
                {
                    ans = Math.Max(ans, max[row, 0]);
                }

                return ans;
            }
        }
    }
}
