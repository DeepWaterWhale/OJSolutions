namespace LeetCode.ByweeklyContest.BWC111
{
    internal class Problem2826
    {
        public class Solution
        {
            public int MinimumOperations(IList<int> nums)
            {
                int ans = nums.Count();

                for (int i = -1; i <= nums.Count; i++)
                {
                    for (int j = i; j <= nums.Count; j++)
                    {
                        // i is the first index of 2, j can be -1 means all elements are 3
                        // j is the first index of 3, j can be nums.Count means no elements is 3
                        ans = Math.Min(ans, this.Operations(nums, i, j));
                    }
                }

                return ans;
            }

            private int Operations(IList<int> nums, int i2, int i3)
            {
                int index = 0;
                int cnt = 0;
                while (index < nums.Count)
                {
                    if (index < i2 && nums[index] != 1)
                    {
                        cnt++;
                    }

                    if (i2 <= index && index < i3 && nums[index] != 2)
                    {
                        cnt++;
                    }

                    if (i3 <= index && nums[index] != 3)
                    {
                        cnt++;
                    }

                    index++;
                }

                return cnt;
            }
        }
    }
}
