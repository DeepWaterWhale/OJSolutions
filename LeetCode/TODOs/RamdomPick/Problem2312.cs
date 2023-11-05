namespace LeetCode.TODOs.RamdomPick
{
    internal class Problem2312
    {
        public class Solution
        {
            public long SellingWood(int m, int n, int[][] prices)
            {
                long[,] dp = new long[m + 1, n + 1];
                foreach (var price in prices)
                {
                    dp[price[0], price[1]] = price[2];
                }

                for (int i = 1; i <= m; i++)
                {
                    for (int j = 1; j <= n; ++j)
                    {
                        long ans = dp[i, j];

                        // Cut horizontal
                        for (int k = 1; k <= i / 2; ++k)
                        {
                            dp[i, j] = Math.Max(dp[i, j], dp[k, j] + dp[i - k, j]);
                        }

                        // Cut vertical
                        for (int k = 1; k <= j / 2; ++k)
                        {
                            dp[i, j] = Math.Max(dp[i, j], dp[i, k] + dp[i, j - k]);
                        }
                    }
                }

                return dp[m, n];
            }
        }
    }
}
