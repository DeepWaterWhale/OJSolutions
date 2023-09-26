namespace LeetCode.ByWeeklyContest.BWC105
{
    internal class Problem2708
    {
        public long MaxStrength(int[] nums)
        {
            var posi = nums.Where(n => n > 0).ToList();
            bool hasZero = nums.Any(n => n == 0);
            var nega = nums.Where(n => n < 0).ToList();

            long ans = 1;
            var nc = 0;

            foreach(var n in posi)
            {
                ans *= n;
                nc++;
            }

            nega.Sort();
            int negaCount = nega.Count % 2 == 0 ? nega.Count : nega.Count - 1;
            for (int i = 0; i < negaCount; ++i)
            {
                ans *= nega[i];
                nc++;
            }

            if (nc == 0)
            {
                if (hasZero)
                {
                    // zeros with 0 or 1 nega
                    return 0;
                }
                else
                {
                    // 1 nega
                    return nega[nega.Count - 1];
                }
            }

            return ans;
        }
    }
}
