namespace LeetCode.TODOs.RamdomPick
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Problem1520
    {
        public class Solution
        {
            private readonly int[][] firstLastIndex = new int[26][];
            private string input;

            public IList<string> MaxNumOfSubstrings(string s)
            {
                Initialize(s);

                List<int[]> intervals = new List<int[]>();
                for (int i = 0; i < 26; ++i)
                {
                    // A valid interval's start index must be the first occurrence of a char
                    // Get the all valid intervals first
                    if (firstLastIndex[i][0] != input.Length)
                    {
                        if (TryGetIntervalEnd(firstLastIndex[i][0], out int intervalEnd))
                        {
                            intervals.Add(new int[] { firstLastIndex[i][0], intervalEnd });
                        }
                    }
                }

                // Sort the interval by the interval start index
                intervals = intervals.OrderBy(interval => interval[0]).ToList();

                // Find all intervals that don't containning anyother interval
                List<string> result = new List<string>();
                int index = 0;
                while (index < intervals.Count)
                {
                    index++;
                    if (index < intervals.Count && intervals[index - 1][1] > intervals[index][0])
                    {
                        continue;
                    }

                    result.Add(s.Substring(intervals[index - 1][0], intervals[index - 1][1] - intervals[index - 1][0] + 1));
                }

                return result;
            }

            /// Get the first and last occurrence of a char
            private void Initialize(string s)
            {
                input = s;
                for (int i = 0; i < 26; ++i)
                {
                    firstLastIndex[i] = new int[2];
                    firstLastIndex[i][0] = s.Length;
                    firstLastIndex[i][1] = 0;
                }

                for (int i = 0; i < s.Length; ++i)
                {
                    int index = s[i] - 'a';
                    if (firstLastIndex[index][0] == s.Length)
                    {
                        firstLastIndex[index][0] = i;
                    }

                    firstLastIndex[index][1] = i;
                }
            }

            private bool TryGetIntervalEnd(int intervalStart, out int intervalEnd)
            {
                int i = intervalStart;
                intervalEnd = firstLastIndex[input[i] - 'a'][1];
                while (i <= intervalEnd)
                {
                    if (intervalStart > firstLastIndex[input[i] - 'a'][0])
                    {
                        // Means the interval containing a char that first occurrence is before the interval start
                        // It is not a valid interval
                        return false;
                    }

                    intervalEnd = Math.Max(intervalEnd, firstLastIndex[input[i] - 'a'][1]);
                    i++;
                }

                return true;
            }
        }
    }
}
