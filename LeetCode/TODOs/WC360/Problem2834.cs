namespace LeetCode.TODOs.WC360
{
    internal class Problem2834
    {
        public class Solution
        {
            public long MinimumPossibleSum(int n, int target)
            {
                HashSet<int> s = new HashSet<int>();
                int num = 1;
                long sum = 0;
                while (s.Count != n)
                {
                    if (num >= target || !s.Contains(target - num))
                    {
                        s.Add(num);
                        sum += num;
                    }

                    num++;
                }

                return sum;
            }
        }
    }
}
