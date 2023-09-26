namespace OjProblems.LeetCode
{
    using System;

    internal class Problem0565
    {
        public class Solution
        {
            public int ArrayNesting(int[] nums)
            {
                int result = 0;
                for (int i = 0; i < nums.Length; ++i)
                {
                    if (nums[i] != -1)
                    {
                        int count = 0;
                        int index = i;
                        while (nums[index] != -1)
                        {
                            count++;
                            int next = nums[index];
                            nums[index] = -1;
                            index = next;
                        }

                        result = Math.Max(result, count);
                    }
                }

                return result;
            }
        }
    }
}
