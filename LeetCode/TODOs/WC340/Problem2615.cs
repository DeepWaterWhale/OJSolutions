// --------------------------------------------------------------------------------------------------
//  author:       big_chicken
//  problem_link: 
//  note_link:    
//  tags:         
// --------------------------------------------------------------------------------------------------

namespace LeetCode.TODOs.WC340
{
    using System.Collections.Generic;

    internal class Problem2615
    {
        public class Solution
        {
            public long[] Distance(int[] nums)
            {
                Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
                Dictionary<int, long> sum = new Dictionary<int, long>();
                long[] ans = new long[nums.Length];

                for (int i = 0; i < nums.Length; ++i)
                {
                    if (!dict.ContainsKey(nums[i]))
                    {
                        dict[nums[i]] = new List<int>();
                        sum[nums[i]] = 0;
                    }

                    dict[nums[i]].Add(i);
                    sum[nums[i]] += i;

                    ans[i] = 0;
                }

                foreach (KeyValuePair<int, List<int>> kv in dict)
                {
                    long left = 0, right = sum[kv.Key];
                    for (int i = 0; i < kv.Value.Count; ++i)
                    {
                        // long * int would return int causing overflow
                        long index = i;
                        ans[kv.Value[i]] = (kv.Value[i] * index) - left + (right - (kv.Value[i] * (kv.Value.Count - index)));
                        left += kv.Value[i];
                        right -= kv.Value[i];
                    }
                }

                return ans;
            }
        }
    }
}
