namespace LeetCode.WeeklyContest.WC363
{
    internal class Problem2862
    {
        public class Solution
        {
            public long MaximumSum(IList<int> nums)
            {
                List<int> squares = new List<int>(100);
                for (int i = 1; i <= 100; i++)
                {
                    squares.Add(i * i);
                }

                long ans = 0;
                for (int i = squares.Count - 1; i > 0; i--)
                {
                    ans = Math.Max(ans, this.GetSum(nums, squares, i));
                }

                return Math.Max(ans, nums.Max());
            }

            private long GetSum(IList<int> nums, IList<int> squares, int maxSquareIndex)
            {
                long ans = 0;
                int maxTimes = nums.Count / squares[maxSquareIndex];
                for (int i = 1; i <= maxTimes; i++)
                {
                    long tmp = 0;
                    for (int j = 0; j <= maxSquareIndex; j++)
                    {
                        tmp += nums[(i * squares[j]) - 1];
                    }

                    ans = Math.Max(ans, tmp);
                }

                return ans;
            }
        }
    }
}
