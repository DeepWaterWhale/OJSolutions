namespace LeetCode.ByweeklyContest.Biweekly114
{
    internal class Problem2871
    {
        public class Solution
        {
            public int MaxSubarrays(int[] nums)
            {
                int minSum = 0xFFFFF;
                bool zero = false;
                int ans = 0;
                foreach (int num in nums)
                {
                    minSum &= num;
                    if (minSum == 0)
                    {
                        zero = true;
                        ans++;
                        minSum = 0xFFFFF;
                    }
                }

                if (zero)
                {
                    return ans;
                }

                return 1;
            }
        }
    }
}
