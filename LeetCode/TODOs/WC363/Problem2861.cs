namespace LeetCode.TODOs.WC363
{
    using Shared.Algorithms;

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
                    ans = Math.Max(
                        ans,
                        this.MaxNumberOfAlloys(budget, composition[i].Select(num => (long)num).ToList(), longStock, longCost));
                }

                return (int)ans;
            }

            private long MaxNumberOfAlloys(long budget, IList<long> composition, IList<long> stock, IList<long> cost)
            {
                return BinarySearch.SearchLong(0, 200000000, cnt =>
                {
                    for (int i = 0; i < composition.Count; i++)
                    {
                        if (composition[i] * cnt > stock[i])
                        {
                            budget -= ((composition[i] * cnt) - stock[i]) * cost[i];
                        }

                        if (budget < 0)
                        {
                            return false;
                        }
                    }

                    return budget >= 0;
                });
            }
        }
    }
}
