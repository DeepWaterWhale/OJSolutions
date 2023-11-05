namespace LeetCode.WeeklyContest.Weekly366
{
    using Shared;
    using Shared.Utils;

    internal class Problem2897
    {
        public class Solution
        {
            public int MaxSum(IList<int> nums, int k)
            {
                int[] cnts = ArrayUtils.MakeArray(32, 0);
                foreach (int num in nums)
                {
                    for (int i = 0; i < 32; ++i)
                    {
                        if ((num & 1 << i) != 0)
                        {
                            cnts[i]++;
                        }
                    }
                }

                long ans = 0;
                while (k-- > 0)
                {
                    long num = 0;
                    for (int i = 0; i < 32; ++i)
                    {
                        if (cnts[i] > 0)
                        {
                            num += 1 << i;
                            cnts[i]--;
                        }
                    }

                    if (num == 0)
                    {
                        break;
                    }

                    ans = (ans + num * num % Constants.MOD) % Constants.MOD;
                }

                return (int)ans;
            }
        }
    }
}
