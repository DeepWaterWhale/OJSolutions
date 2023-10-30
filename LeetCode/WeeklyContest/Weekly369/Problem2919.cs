namespace LeetCode.WeeklyContest.Weekly369
{
    internal class Problem2919
    {
        public class Solution
        {
            public long MinIncrementOperations(int[] nums, int k)
            {
                // dp[i] = the minimal operations to make nums[i] >= k and nums[k: ] beautiful
                long[] dp = new long[nums.Length + 3];
                for (int i = 0; i < 3; i++)
                {
                    dp[nums.Length + i] = 0;
                }

                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    dp[i] = Math.Min(Math.Min(dp[i + 1], dp[i + 2]), dp[i + 3]) + Math.Max(0, k - nums[i]);
                }

                return Math.Min(Math.Min(dp[0], dp[1]), dp[2]);
            }
        }
    }
}
