namespace LeetCode.TODOs.WC362
{
    using Shared;
    using Shared.Algorithms;

    internal class Problem2851
    {
        public class Solution
        {
            public int NumberOfWays(string s, string t, long k)
            {
                string str = t + s + s;
                var zarr = ZAlgorithm.ZFunc(str);

                var trans = MatrixAlgorithm.MakeMatrix(2, 2, new long[] { 0, t.Length - 1, 1, t.Length - 2 });
                trans = MatrixAlgorithm.FastExponential(trans, k, Constants.MOD);

                long ans = 0;
                for (int i = t.Length; i < t.Length * 2; ++i)
                {
                    if (zarr[i] >= t.Length)
                    {
                        // Shift right (i - t.Length) can make s to t
                        // Then we need to find the numbers of k shifts make
                        // The (total shifts chars) % t.Length == i % t.Length

                        // dp[k][0] = after k shifts, (total shifts chars) % t.Length == i % t.Length
                        // dp[k][1] = after k shifts, (total shifts chars) % t.Length != i % t.Length
                        // dp[k + 1][0] = dp[k][1]
                        // dp[k + 1][1] = dp[k][0] * (t.Length - 1) + dp[k][1] * (t.Length - 2)
                        // dp[k + 1] (1 * 2) = dp[k] (1 * 2) * [[0 , t.Length - 1], [1, t.Length - 2]]
                        var dp = new long[1, 2];
                        if (i % t.Length == 0)
                        {
                            dp[0, 0] = 1;
                            dp[0, 1] = 0;
                        }
                        else
                        {
                            dp[0, 0] = 0;
                            dp[0, 1] = 1;
                        }

                        var final = MatrixAlgorithm.Multiple(dp, trans, Constants.MOD);
                        ans += final[0, 0];
                    }
                }

                return (int)(ans % Constants.MOD);
            }
        }
    }
}
