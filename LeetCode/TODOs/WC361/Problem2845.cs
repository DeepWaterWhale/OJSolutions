namespace LeetCode.TODOs.WC361
{
    internal class Problem2845
    {
        public class Solution
        {
            public long CountInterestingSubarrays(IList<int> nums, int modulo, int k)
            {
                if (modulo == 1 && k == 0)
                {
                    long length = nums.Count;
                    return length * (length + 1) / 2;
                }

                List<int> indexes = new List<int>();
                for (int i = 0; i < nums.Count; i++)
                {
                    if (nums[i] % modulo == k)
                    {
                        indexes.Add(i);
                    }
                }

                long ans = 0;
                for (int i = 0; i < indexes.Count; i++)
                {
                    int maxStartIndex = indexes[i]; // Including
                    int minStartIndex = i == 0 ? -1 : indexes[i - 1]; // Not including
                    long possibleStartCount = maxStartIndex - minStartIndex;
                    int len = k == 0 ? modulo : k;
                    while (i + len <= indexes.Count)
                    {
                        // Count the sub-arr start contains [indexes[i] : indexes[i + len - 1]]
                        // But didn't contains indexes[i - 1] or indexes[i + len]
                        int minEndIndex = indexes[i + len - 1]; // Including
                        int maxEndIndex = i + len == indexes.Count ? nums.Count : indexes[i + len]; // Not including
                        long possibleEndCount = maxEndIndex - minEndIndex;

                        Console.WriteLine($"maxStartIndex = {maxStartIndex}:{nums[maxStartIndex]}, possibleStartCount = {possibleStartCount}");
                        Console.WriteLine($"minEndIndex = {minEndIndex}:{nums[minEndIndex]}, possibleEndCount = {possibleEndCount}");
                        ans += possibleStartCount * possibleEndCount;
                        len += modulo;
                    }
                }

                if (k == 0)
                {
                    long length = 0;
                    if (indexes.Count == 0)
                    {
                        length = nums.Count;
                        return length * (length + 1) / 2;
                    }

                    // In this case, all subarrays that doesn't contain any elements with index in indexes also is special
                    for (int i = 0; i < indexes.Count; ++i)
                    {
                        length = indexes[i] - (i == 0 ? -1 : indexes[i - 1]) - 1;
                        ans += length * (length + 1) / 2;
                    }

                    length = nums.Count - indexes.Last() - 1;
                    ans += length * (length + 1) / 2;
                }

                return ans;
            }
        }
    }
}
