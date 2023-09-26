namespace LeetCode.ByWeeklyContest.BWC105
{
    internal class Problem2706
    {
        public class Solution
        {
            public int BuyChoco(int[] prices, int money)
            {
                var l = prices.ToList();
                l.Sort();
                var left = money - l[0] - l[1];
                if (left >= 0)
                {
                    return left;
                }

                return money;
            }
        }
    }
}
