namespace LeetCode.ByWeeklyContest.BWC105
{
    internal class Problem2707
    {
        public class Solution
        {
            public int MinExtraChar(string s, string[] dictionary)
            {
                int[] dp = new int[s.Length + 1];
                dp[s.Length] = 0;
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    dp[i] = s.Length;
                    for (int j = 1; i + j <= s.Length; j++)
                    {
                        string s2 = s.Substring(i, j);
                        dp[i] = Math.Min(dp[i], this.MinExtraCharNoSplit(s2, dictionary) + dp[i + j]);
                    }
                }

                Console.WriteLine(string.Join(", ", dp));
                return dp[0];
            }

            private int MinExtraCharNoSplit(string s, string[] dictionary)
            {
                int ans = s.Length;
                foreach (string s2 in dictionary)
                {
                    if (s.IndexOf(s2) != -1)
                    {
                        ans = Math.Min(ans, s.Length - s2.Length);
                    }
                }

                return ans;
            }
        }
    }
}
