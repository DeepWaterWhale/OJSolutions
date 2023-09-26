namespace LeetCode.WeeklyContest.WC346
{
    internal class Problem2696
    {
        public class Solution
        {
            public int MinLength(string s)
            {
                int preLength = s.Length + 1;
                while (preLength != s.Length)
                {
                    preLength = s.Length;
                    s = s.Replace("AB", "");
                    s = s.Replace("CD", "");
                }

                return s.Length;
            }
        }
    }
}
