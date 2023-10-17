namespace LeetCode.WeeklyContest.Weekly353
{
    internal class Problem2771
    {
        public class Solution
        {
            public int MaxNonDecreasingLength(int[] nums1, int[] nums2)
            {
                int[,] dp = new int[nums1.Length, 2];
                dp[nums1.Length - 1, 0] = 1;
                dp[nums1.Length - 1, 1] = 1;

                int ans = 1;
                for (int i = nums1.Length - 2; i >= 0; i--)
                {
                    dp[i, 0] = 1;
                    if (nums1[i] <= nums1[i + 1])
                    {
                        dp[i, 0] = Math.Max(dp[i, 0], dp[i + 1, 0] + 1);
                    }

                    if (nums1[i] <= nums2[i + 1])
                    {
                        dp[i, 0] = Math.Max(dp[i, 0], dp[i + 1, 1] + 1);
                    }

                    ans = Math.Max(ans, dp[i, 0]);

                    dp[i, 1] = 1;
                    if (nums2[i] <= nums1[i + 1])
                    {
                        dp[i, 1] = Math.Max(dp[i, 1], dp[i + 1, 0] + 1);
                    }

                    if (nums2[i] <= nums2[i + 1])
                    {
                        dp[i, 1] = Math.Max(dp[i, 1], dp[i + 1, 1] + 1);
                    }

                    ans = Math.Max(ans, dp[i, 1]);
                }

                return ans;
            }
        }
    }
}
