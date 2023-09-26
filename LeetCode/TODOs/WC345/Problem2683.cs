namespace LeetCode.WeeklyContest.WC345
{
    internal class Problem2683
    {
        public class Solution
        {
            public bool DoesValidArrayExist(int[] derived)
            {
                int res = 0;
                foreach (int i in derived)
                {
                    res = res ^ i;
                }

                return res == 0;
            }
        }
    }
}
