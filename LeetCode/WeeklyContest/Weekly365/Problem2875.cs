namespace LeetCode.WeeklyContest.Weekly365
{
    internal class Problem2875
    {
        public class Solution
        {
            public int MinSizeSubarray(int[] nums, int target)
            {
                long[] leftSums = new long[nums.Length * 2];
                long tmp = 0;
                for (int i = 0; i < nums.Length; ++i)
                {
                    tmp += nums[i];
                    leftSums[i] = tmp;
                }

                for (int i = nums.Length; i < leftSums.Length; ++i)
                {
                    tmp += nums[i - nums.Length];
                    leftSums[i] = tmp;
                }

                int ans = 0;
                if (target >= leftSums[nums.Length - 1])
                {
                    int sum = (int)leftSums[nums.Length - 1];

                    ans = target / sum * nums.Length;
                    target = target % sum;
                }

                int rem = nums.Length;
                int left = 0, right = 0;
                while (left < leftSums.Length)
                {
                    while (right < leftSums.Length && leftSums[right] - leftSums[left] < target)
                    {
                        right++;
                    }

                    if (right == leftSums.Length)
                    {
                        break;
                    }

                    while (left < leftSums.Length && leftSums[right] - leftSums[left] > target)
                    {
                        left++;
                    }

                    if (leftSums[right] - leftSums[left] == target)
                    {
                        rem = Math.Min(rem, right - left);
                        left++;
                    }
                }

                if (rem == nums.Length)
                {
                    return -1;
                }

                return ans + rem;
            }
        }
    }
}
