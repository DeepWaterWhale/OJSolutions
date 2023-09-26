namespace OjProblems.LeetCode
{
    using System.Collections.Generic;

    internal class Problem0689
    {
        public class Solution
        {
            private readonly KeyValuePair<int, long> invalidResult = new KeyValuePair<int, long>(-1, -1);
            private int numsCount;
            private int subArrayLength;
            private readonly List<long> sums = new List<long>();
            // dp[subArrayCount, startIndex] = [x, y]
            // - subArrayCount: the sub-array count
            // - startIndex: the first index of the maximum subArrayCount sub-arrays must >= startIndex
            // - x: the first index of the maximum subArrayCount sub-arrays
            // - y: the maximum sum of of the subArrayCount sub-arrays
            // 
            // dp[subArrayCount, startIndex] = 0 if nums.Length - startIndex < subArrayCount * k
            // dp[subArrayCount, startIndex] = max{ sum[startIndex], dp[subArrayCount, startIndex + 1] }, when subArrayCount == 1
            // dp[subArrayCount, startIndex] = max{ dp[subArrayCount, startIndex + 1], sums[startIndex] + dp[subArrayCount - 1, startIndex + k] }, when subArrayCount > 1
            private readonly Dictionary<KeyValuePair<int, int>, KeyValuePair<int, long>> dp = new Dictionary<KeyValuePair<int, int>, KeyValuePair<int, long>>();
            public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
            {
                this.numsCount = nums.Length;
                this.subArrayLength = k;

                long sum = 0;
                for (int i = 0; i < k; ++i)
                {
                    sum += nums[i];
                }

                this.sums.Add(sum);
                for (int i = k; i < nums.Length; ++i)
                {
                    sum += nums[i] - nums[i - k];
                    this.sums.Add(sum);
                }

                KeyValuePair<int, long> first = this.Solve(3, 0);
                KeyValuePair<int, long> second = this.Solve(2, first.Key + k);
                KeyValuePair<int, long> third = this.Solve(1, second.Key + k);
                return new int[] { first.Key, second.Key, third.Key };
            }

            private KeyValuePair<int, long> Solve(int subArrayCount, int startIndex)
            {
                KeyValuePair<int, int> dictKey = new KeyValuePair<int, int>(subArrayCount, startIndex);
                if (this.dp.TryGetValue(dictKey, out KeyValuePair<int, long> dictValue))
                {
                    return dictValue;
                }

                // Last index is (startIndex + subArrayCount * this.subArrayLength - 1)
                if (startIndex + subArrayCount * this.subArrayLength - 1 < this.numsCount)
                {
                    if (subArrayCount == 1)
                    {
                        dictValue = this.Solve(subArrayCount, startIndex + 1);
                        if (dictValue.Key == -1 || this.sums[startIndex] >= dictValue.Value)
                        {
                            dictValue = new KeyValuePair<int, long>(startIndex, this.sums[startIndex]);
                        }
                    }
                    else
                    {
                        dictValue = this.Solve(subArrayCount, startIndex + 1);
                        KeyValuePair<int, long> t2 = this.Solve(subArrayCount - 1, startIndex + this.subArrayLength);
                        if (dictValue.Key == -1 || this.sums[startIndex] + t2.Value >= dictValue.Value)
                        {
                            dictValue = new KeyValuePair<int, long>(startIndex, this.sums[startIndex] + t2.Value);
                        }
                    }

                    this.dp[dictKey] = dictValue;
                    return dictValue;
                }

                return this.invalidResult;
            }
        }
    }
}
