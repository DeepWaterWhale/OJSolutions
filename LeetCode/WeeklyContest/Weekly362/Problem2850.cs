namespace LeetCode.WeeklyContest.Weekly362
{
    internal class Problem2850
    {
        public class Solution
        {
            public int MinimumMoves(int[][] grid)
            {
                int zeroCellCount = grid.Sum(line => line.Count(x => x == 0));
                if (zeroCellCount == 0)
                {
                    return 0;
                }

                int ans = 9999;
                for (int i = 0; i < 3; ++i)
                {
                    for (int j = 0; j < 3; ++j)
                    {
                        if (grid[i][j] == 0)
                        {
                            for (int ni = 0; ni < 3; ++ni)
                            {
                                for (int nj = 0; nj < 3; ++nj)
                                {
                                    int d = Math.Abs(ni - i) + Math.Abs(nj - j);
                                    if (grid[ni][nj] > 1)
                                    {
                                        grid[ni][nj]--;
                                        grid[i][j]++;
                                        ans = Math.Min(ans, d + MinimumMoves(grid));
                                        grid[i][j]--;
                                        grid[ni][nj]++;
                                    }
                                }
                            }
                        }
                    }
                }

                return ans;
            }
        }
    }
}
