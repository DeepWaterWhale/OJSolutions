using System.Runtime.CompilerServices;

namespace LeetCode.WeeklyContest.WC363
{
    internal class Problem2861
    {
        public class Solution
        {
            public int MaxNumberOfAlloys(int n, int k, int budget, IList<IList<int>> composition, IList<int> stock, IList<int> cost)
            {
                long ans = 0;
                List<long> longStock = stock.Select(num => (long)num).ToList();
                List<long> longCost = cost.Select(num => (long)num).ToList();
                for (int i = 0; i < composition.Count; ++i)
                {
                    ans = Math.Max(ans, this.MaxNumberOfAlloys(budget, composition[i].Select(num => (long)num).ToList(), longStock, longCost));
                }

                return (int)ans;
            }

            private long MaxNumberOfAlloys(long budget, IList<long> composition, IList<long> stock, IList<long> cost)
            {
                long max = 200000000; // 2 * 10^8
                long min = 0;
                while (min < max)
                {
                    long middle = (max + min) / 2;
                    if (this.CanMake(middle, budget, composition, stock, cost))
                    {
                        min = middle + 1;
                    }
                    else
                    {
                        max = middle - 1;
                    }
                }

                if (this.CanMake(min, budget, composition, stock, cost))
                {
                    return min;
                }
                return min - 1;
            }

            private bool CanMake(long count, long budget, IList<long> composition, IList<long> stock, IList<long> cost)
            {
                for (int i = 0; i < composition.Count; i++)
                {
                    if (composition[i] * count > stock[i])
                    {
                        budget -= ((composition[i] * count - stock[i]) * cost[i]);
                    }

                    if (budget < 0)
                    {
                        return false;
                    }
                }

                return budget >= 0;
            }
        }
    }
}
