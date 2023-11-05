namespace LeetCode.TODOs.RamdomPick
{
    using System;
    using System.Collections.Generic;

    internal class Problem0996
    {
        public class Solution
        {
            private readonly Dictionary<int, HashSet<int>> possibleNext = new Dictionary<int, HashSet<int>>();
            private readonly Dictionary<int, int> numCount = new Dictionary<int, int>();
            private int count;
            private int arrayLength;

            public int NumSquarefulPerms(int[] nums)
            {
                arrayLength = nums.Length;
                possibleNext[-1] = new HashSet<int>();
                foreach (int num in nums)
                {
                    possibleNext[-1].Add(num);
                    possibleNext[num] = new HashSet<int>();
                    if (!numCount.ContainsKey(num))
                    {
                        numCount[num] = 0;
                    }

                    numCount[num]++;
                }

                for (int i = 0; i < nums.Length; ++i)
                {
                    for (int j = i + 1; j < nums.Length; ++j)
                    {
                        int tmp = (int)Math.Sqrt(nums[i] + nums[j]);
                        if (tmp * tmp == nums[i] + nums[j])
                        {
                            possibleNext[nums[i]].Add(nums[j]);
                            possibleNext[nums[j]].Add(nums[i]);
                        }
                    }
                }

                count = 0;
                Solve(0, -1);
                return count;
            }

            private void Solve(int step, int previous)
            {
                if (step == arrayLength)
                {
                    count++;
                    return;
                }

                foreach (int num in possibleNext[previous])
                {
                    if (numCount[num] > 0)
                    {
                        numCount[num]--;
                        Solve(step + 1, num);
                        numCount[num]++;
                    }
                }
            }
        }
    }
}
