namespace LeetCode.TODOs.BWC104
{
    internal class Problem2679
    {
        public class Solution
        {
            public int MatrixSum(int[][] nums)
            {
                List<int>[] lists = nums.Select(x => x.ToList()).ToArray();
                foreach (List<int> list in lists)
                {
                    list.Sort();
                }

                int ans = 0;

                for (int i = 0; i < lists[0].Count; ++i)
                {
                    int tmp = lists[0][i];
                    for (int j = 0; j < lists.Length; ++j)
                    {
                        tmp = Math.Max(tmp, lists[j][i]);
                    }

                    ans += tmp;
                }

                return ans;
            }
        }
    }
}
