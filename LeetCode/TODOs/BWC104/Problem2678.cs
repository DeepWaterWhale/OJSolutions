namespace LeetCode.TODOs.BWC104
{
    internal class Problem2678
    {
        public class Solution
        {
            public int CountSeniors(string[] details)
            {
                return details.Count(d =>
                {
                    return int.Parse(d.Substring(11, 2)) > 60;
                });
            }
        }
    }
}
