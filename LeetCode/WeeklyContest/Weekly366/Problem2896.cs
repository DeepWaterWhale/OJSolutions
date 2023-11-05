namespace LeetCode.TODOs.Weekly366
{
    using Shared.Utils;

    internal class Problem2896
    {
        public class Solution
        {
            public int MinOperations(string s1, string s2, int x)
            {
                // -2 means not initialized, -1 means not possible
                var dp = ArrayUtils.Make2DArray(s1.Length, 4, -2);
                int length = s1.Length;
                if (s1[length - 1] == s2[length - 1])
                {
                    dp[length - 1, 0] = 0;
                    dp[length - 1, 1] = 250000;
                    dp[length - 1, 2] = 250000;
                    dp[length - 1, 3] = 0;
                }
                else
                {
                    dp[length - 1, 0] = 250000;
                    dp[length - 1, 1] = 0;
                    dp[length - 1, 2] = 0;
                    dp[length - 1, 3] = 250000;
                }

                int ans = this.Solve(s1, s2, x, dp, 0, 0);
                if (ans >= 250000)
                {
                    return -1;
                }

                return ans;
            }

            // dp status including:
            //     1. Has unpaired FlipAny
            //     1. Current char is flipped or not by FlipNext
            // dp[k][0] = Not Flipped by FlipNext   &&   No unpaired FlipAny
            // dp[k][1] = Not Flipped by FlipNext   &&   Has unpaired FlipAny
            // dp[k][2] = Flipped by FlipNext       &&   No unpaired FlipAny
            // dp[k][3] = Flipped by FlipNext       &&   Has unpaired FlipAny
            // Need to calculate dp[0][0]
            private int Solve(string s1, string s2, int x, int[,] dp, int index, int status)
            {
                if (dp[index, status] != -2)
                {
                    return dp[index, status];
                }

                int ans = 250000;
                if ((s1[index] == s2[index]) == (status < 2))
                {
                    // Current s1[index] == s2[index], can not 
                    // Case 1: Do nothing:
                    ans = Math.Min(ans, this.Solve(s1, s2, x, dp, index + 1, status % 2));
                }
                else
                {
                    // Case 2: flip current with flip any
                    if (status % 2 == 0)
                    {
                        // No unpaired flip any
                        ans = Math.Min(ans, this.Solve(s1, s2, x, dp, index + 1, 1) + x);
                    }
                    else
                    {
                        // Has unpaired flip any
                        ans = Math.Min(ans, this.Solve(s1, s2, x, dp, index + 1, 0));
                    }

                    // Case 3: flip current with next
                    ans = Math.Min(ans, this.Solve(s1, s2, x, dp, index + 1, 2 + status % 2) + 1);
                }

                dp[index, status] = ans;
                return ans;
            }
        }
    }
}
