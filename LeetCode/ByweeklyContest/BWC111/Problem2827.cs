namespace LeetCode.ByweeklyContest.BWC111
{
    internal class Problem2827
    {
        // The status contians (remainder, numLenth, evenCount)
        // And status transition depends on current position and prefix status
        // Use the general DigitDp class would make lambda expression too complex
        // Create a private class here, but the solution is similiar
        public class Solution
        {
            public int NumberOfBeautifulIntegers(int low, int high, int k)
            {
                return NumberOfBeautifulIntegers(high, k) - NumberOfBeautifulIntegers(low - 1, k);
            }

            private int NumberOfBeautifulIntegers(int right, int k)
            {
                var ddp = new DigitDp(right, k);
                var initialStatus = new Status();
                initialStatus.Remainder = 0;
                initialStatus.NumLength = right.ToString().Length;
                initialStatus.EvenCount = 0;
                return ddp.Solve(right.ToString().Length - 1, DigitDpPrefixStatus.LeadingZeros, initialStatus);
            }

            private enum DigitDpPrefixStatus
            {
                LeadingZeros = 0,
                LessThan = 1,
                EqualsRight = 2
            }

            private struct Status
            {
                public int NumLength;
                public int EvenCount;
                public int Remainder;
            }

            private class DigitDp
            {
                private readonly Dictionary<(int Pos, DigitDpPrefixStatus PrefixStatus, Status Status), int> dp
                    = new Dictionary<(int, DigitDpPrefixStatus, Status), int>();

                private readonly List<int> rightDigit;
                private readonly int Mod;
                public DigitDp(int right, int k)
                {
                    rightDigit = right.ToString().Reverse().Select(ch => ch - '0').ToList();
                    Mod = k;
                }

                public int Solve(int pos, DigitDpPrefixStatus prefixStatus, Status status)
                {
                    if (pos == -1)
                    {
                        if (status.Remainder == 0 && status.NumLength == status.EvenCount * 2)
                        {
                            return 1;
                        }

                        return 0;
                    }

                    if (dp.TryGetValue((pos, prefixStatus, status), out int res))
                    {
                        return res;
                    }

                    res = 0;
                    int max = 9;
                    if (pos == rightDigit.Count - 1 || // Now prefixStatus == LeadingZeros
                        prefixStatus == DigitDpPrefixStatus.EqualsRight)
                    {
                        max = rightDigit[pos];
                    }

                    for (int i = 0; i <= max; i++)
                    {
                        var nextStatus = new Status();
                        nextStatus.NumLength = status.NumLength;
                        nextStatus.EvenCount = status.EvenCount + (i + 1) % 2;
                        nextStatus.Remainder = (status.Remainder + i * ((int)Math.Pow(10, pos) % Mod)) % Mod;

                        if (i == 0 &&
                            prefixStatus == DigitDpPrefixStatus.LeadingZeros)
                        {
                            nextStatus.Remainder = 0;
                            nextStatus.NumLength = status.NumLength - 1;
                            nextStatus.EvenCount = 0;
                            res += Solve(pos - 1, DigitDpPrefixStatus.LeadingZeros, nextStatus);
                            continue;
                        }

                        if (i == rightDigit[pos] &&
                            (pos == rightDigit.Count - 1 || // Now prefixStatus == LeadingZeros, should change to EqualsRight
                            prefixStatus == DigitDpPrefixStatus.EqualsRight))
                        {
                            res += Solve(pos - 1, DigitDpPrefixStatus.EqualsRight, nextStatus);
                            continue;
                        }

                        res += Solve(pos - 1, DigitDpPrefixStatus.LessThan, nextStatus);
                    }

                    dp[(pos, prefixStatus, status)] = res;
                    return dp[(pos, prefixStatus, status)];
                }
            }
        }
    }
}
