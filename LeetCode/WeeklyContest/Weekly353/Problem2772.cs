namespace LeetCode.WeeklyContest.Weekly353
{
    using Shared.Utils;

    internal class Problem2772
    {
        public class Solution
        {
            public bool CheckArray(int[] nums, int k)
            {
                // op is the number we need to minus at current num
                int op = 0;
                // ops[i] = the count the operation starting from index i
                int[] ops = ArrayUtils.MakeArray(nums.Length, 0);
                for (int i = 0; i < nums.Length; ++i)
                {
                    if (i >= k)
                    {
                        op -= ops[i - k];
                    }

                    if (nums[i] < op)
                    {
                        return false;
                    }

                    ops[i] = nums[i] - op;
                    op = nums[i];
                    // Console.WriteLine($"num = {nums[i]}, ops[i] = {ops[i]}, op = {op}");
                }

                return op == ops[nums.Length - k];
            }
        }
    }
}
