namespace LeetCode.WeeklyContest.Weekly367
{
    internal class Problem2905
    {
        public class Solution
        {
            public int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
            {
                var ans = this.FindIndices(nums, indexDifference, valueDifference, true);
                if (ans[0] == -1)
                {
                    ans = this.FindIndices(nums, indexDifference, valueDifference, false);
                }

                return ans;
            }

            public int[] FindIndices(int[] nums, int indexDifference, int valueDifference, bool inc)
            {
                int idx = 0;
                List<int> queue = new List<int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (queue.Count == 0 || (nums[i] > nums[queue.Last()]) == inc)
                    {
                        queue.Add(i);
                    }

                    while (idx < queue.Count && i - queue[idx] >= indexDifference)
                    {
                        idx++;
                    }

                    if (idx != 0 && Math.Abs(nums[i] - nums[queue[idx - 1]]) >= valueDifference)
                    {
                        return new int[] { queue[idx - 1], i };
                    }
                }

                return new int[] { -1, -1 };
            }
        }
    }
}
