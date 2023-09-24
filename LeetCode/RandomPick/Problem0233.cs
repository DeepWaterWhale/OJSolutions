namespace LeetCode.TODOs
{
    using Shared.DynamicProgramming;

    internal class Problem0233
    {
        public class Solution
        {
            public int CountDigitOne(int n)
            {
                var ddp = new DigitDp<int>(
                    right: n,
                    statusUpdateFunc: (count1, digit) =>
                    {
                        if (digit == 1)
                        {
                            return count1 + 1;
                        }

                        return count1;
                    },
                    endingFunc: count1 =>
                    {
                        return count1;
                    });

                return ddp.Solve(n.ToString().Length - 1, DigitDpPrefixStatus.LeadingZeros, 0);
            }
        }
    }
}
