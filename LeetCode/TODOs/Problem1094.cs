namespace LeetCode.TODOs
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Problem1094
    {
        public class Solution
        {
            public bool CarPooling(int[][] trips, int capacity)
            {
                Dictionary<int, int> change = new Dictionary<int, int>();
                foreach (var trip in trips)
                {
                    if (!change.ContainsKey(trip[1]))
                    {
                        change[trip[1]] = trip[0];
                    }
                    else
                    {
                        change[trip[1]] += trip[0];
                    }

                    if (!change.ContainsKey(trip[2]))
                    {
                        change[trip[2]] = -trip[0];
                    }
                    else
                    {
                        change[trip[2]] -= trip[0];
                    }
                }

                foreach (var kv in change.ToList().OrderBy(kv => kv.Key))
                {
                    capacity -= kv.Value;

                    if (capacity < 0)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
