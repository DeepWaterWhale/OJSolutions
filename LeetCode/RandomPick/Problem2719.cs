namespace LeetCode.TODOs
{
    using Shared;
    using Shared.DynamicProgramming;

    internal class Problem2719
    {
        public class Solution
        {
            public int Count(string num1, string num2, int min_sum, int max_sum)
            {
                var ans = this.Count(num2, min_sum, max_sum) - this.Count(num1, min_sum, max_sum);

                // Check num1 is good or not
                var dsNum1 = num1.Select(ch => (int)(ch - '0')).Sum();
                if (min_sum <= dsNum1 && dsNum1 <= max_sum) ans++;
                if (ans < 0) ans += Constants.MOD;

                return ans;
            }

            private int Count(string num1, int min_sum, int max_sum)
            {
                var ddp = new DigitDp<int>(
                    right: num1,
                    statusUpdateFunc: (digitSum, digit) =>
                    {
                        return digitSum + digit;
                    },
                    endingFunc: digitSum =>
                    {
                        if (min_sum <= digitSum && digitSum <= max_sum)
                        {
                            return 1;
                        }

                        return 0;
                    });

                return ddp.SolveWithMod(num1.Length - 1, DigitDpPrefixStatus.LeadingZeros, 0, Constants.MOD);
            }
        }
    }
}
