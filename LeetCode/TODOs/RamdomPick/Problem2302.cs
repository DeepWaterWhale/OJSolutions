namespace LeetCode.TODOs.RamdomPick
{
    internal class Problem2302
    {
        public class Solution
        {
            public long CountSubarrays(int[] nums, long k)
            {
                long[] leftSum = new long[nums.Length + 1];
                for (int i = 0; i < nums.Length; ++i)
                {
                    leftSum[i + 1] = leftSum[i] + nums[i];
                }

                long ans = 0;
                for (int i = 0; i < leftSum.Length; ++i)
                {
                    int last = FindLast(leftSum, i, leftSum.Length, k);
                    ans += last - i - 1;
                    // Console.WriteLine($"start = {i}, end = {last}");
                }

                return ans;
            }

            // sum[start : end) * (end - start) is strictly increasing when end increasing
            // Can use binary search to find the maximum end such that sum[start : end) * (end - start) < k
            // 
            // Note that start would be changed during the binary search, need to use another variable to store the leftMost index
            public int FindLast(long[] leftSum, int start, int end, long k)
            {
                int leftMost = start;
                while (start < end)
                {
                    int middle = (start + end) / 2;

                    if ((leftSum[middle] - leftSum[leftMost]) * (middle - leftMost) < k)
                    {
                        start = middle + 1;
                    }
                    else
                    {
                        end = middle;
                    }
                }

                return start;
            }
        }
    }
}
