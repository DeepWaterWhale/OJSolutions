namespace OjProblems.LeetCode
{
    using System;
    using System.Collections.Generic;

    internal class Problem1031
    {
        public class Solution
        {
            public int MaxSumTwoNoOverlap(int[] nums, int firstLen, int secondLen)
            {
                // sums[0: i) = leftSum[i]
                // sums[i: j) = leftSum[j] - leftSum[i]
                List<int> leftSum = new List<int>(nums.Length + 1);
                leftSum.Add(0);
                for (int i = 0; i < nums.Length; ++i)
                {
                    leftSum.Add(leftSum[i] + nums[i]);
                }

                // max1[i] is the max sum of a sub-array whose start index > i with length firstLen
                // max2[i] is the max sum of a sub-array whose start index > i with length secondLen
                int[] max1 = new int[nums.Length + 1];
                int[] max2 = new int[nums.Length + 1];
                max1[nums.Length] = -1;
                max2[nums.Length] = -1;
                for (int i = nums.Length - 1; i >= 0; --i)
                {
                    max1[i] = i + firstLen < leftSum.Count ? Math.Max(max1[i + 1], leftSum[i + firstLen] - leftSum[i]) : -1;
                    max2[i] = i + secondLen < leftSum.Count ? Math.Max(max2[i + 1], leftSum[i + secondLen] - leftSum[i]) : -1;
                }

                int result = 0;
                for (int i = 0; i + firstLen + secondLen < leftSum.Count; ++i)
                {
                    result = Math.Max(result, leftSum[i + firstLen] - leftSum[i] + max2[i + firstLen]);
                    result = Math.Max(result, leftSum[i + secondLen] - leftSum[i] + max1[i + secondLen]);
                }

                return result;
            }
        }
    }
}
