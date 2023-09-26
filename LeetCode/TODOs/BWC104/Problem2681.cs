namespace LeetCode.TODOs.BWC104
{
    internal class Problem2681
    {
        public class Solution
        {
            public const long MOD = (long)10e8 + 7;

            // let minsum[k] = sum { min (group | group's maximum power is nl[k]) }
            // minsum[k] = minsum[k - 1] + minsum[k - 2] + ... + minsum[0] + nl[k].
            //
            // res[k] = sum of the power of all non-empty groups whose maimum power is nl[k].
            // 
            // final result = res[0] + res[1] + res[2] + .. + res[nums.Length - 1].
            // res[k] = nl[k] * nl[k] * sum (min{group | group's maximum power is nl[k]}).
            public int SumOfPower(int[] nums)
            {
                var nl = nums.Select(n => (long)n).ToList();
                nl.Sort();

                long[] minsum = new long[nl.Count];
                long tmp = 0;
                minsum[0] = nl[0];
                for (int i = 1; i < nl.Count; i++)
                {
                    tmp = (tmp + minsum[i - 1]) % MOD;
                    minsum[i] = (nl[i] + tmp) % MOD;
                }

                long[] res = new long[nl.Count];
                for (int i = 0; i < nl.Count; i++)
                {
                    res[i] = nl[i] * nl[i] % MOD * minsum[i] % MOD;
                }

                long ans = 0;
                for (int i = 0; i < res.Length; ++i)
                {
                    ans = (ans + res[i]) % MOD;
                }

                return (int)ans;
            }
        }
    }
}
