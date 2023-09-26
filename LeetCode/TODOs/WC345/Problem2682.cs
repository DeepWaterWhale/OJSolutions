namespace LeetCode.TODOs.WC345
{
    using System.Collections.Generic;

    internal class Problem2682
    {
        public class Solution
        {
            public int[] CircularGameLosers(int n, int k)
            {
                HashSet<int> res = new HashSet<int>();
                int next = 0;
                int round = 1;
                while (res.Add(next))
                {
                    next = (next + (round * k)) % n;
                    round++;
                }

                List<int> list = new List<int>();
                for (int i = 0; i < n; ++i)
                {
                    if (!res.Contains(i))
                    {
                        list.Add(i + 1);
                    }
                }

                return list.ToArray();
            }
        }
    }
}
