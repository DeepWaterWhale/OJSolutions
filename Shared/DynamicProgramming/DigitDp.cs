namespace Shared.DynamicProgramming
{
    public enum DigitDpPrefixStatus
    {
        LeadingZeros = 0,
        LessThan = 1,
        EqualsRight = 2
    }

    public class DigitDp<TStatus>
    {
        private readonly Dictionary<(int Pos, DigitDpPrefixStatus PrefixStatus, TStatus Status), int> dp
            = new Dictionary<(int, DigitDpPrefixStatus, TStatus), int>();

        private readonly Func<TStatus, int, TStatus> updateStatus;
        private readonly Func<TStatus, int> endingFunc;
        private readonly List<int> rightDigit;

        public DigitDp(int right, Func<TStatus, int, TStatus> statusUpdateFunc, Func<TStatus, int> endingFunc) :
            this(right.ToString(), statusUpdateFunc, endingFunc)
        {
        }

        public DigitDp(string right, Func<TStatus, int, TStatus> statusUpdateFunc, Func<TStatus, int> endingFunc)
        {
            this.rightDigit = right.Reverse().Select(ch => (int)(ch - '0')).ToList();
            this.updateStatus = statusUpdateFunc;
            this.endingFunc = endingFunc;
        }

        public int Solve(int pos, DigitDpPrefixStatus prefixStatus, TStatus status)
        {
            if (pos == -1)
            {
                return this.endingFunc(status);
            }

            if (this.dp.TryGetValue((pos, prefixStatus, status), out int res))
            {
                return res;
            }

            res = 0;
            int max = 9;
            if (pos == this.rightDigit.Count - 1 || // Now prefixStatus == LeadingZeros
                prefixStatus == DigitDpPrefixStatus.EqualsRight)
            {
                max = this.rightDigit[pos];
            }

            for (int i = 0; i <= max; i++)
            {
                if (i == 0 &&
                    prefixStatus == DigitDpPrefixStatus.LeadingZeros)
                {
                    res += this.Solve(pos - 1, DigitDpPrefixStatus.LeadingZeros, this.updateStatus(status, i));
                    continue;
                }

                if (i == this.rightDigit[pos] &&
                    (pos == this.rightDigit.Count - 1 || // Now prefixStatus == LeadingZeros, should change to EqualsRight
                    prefixStatus == DigitDpPrefixStatus.EqualsRight))
                {
                    res += this.Solve(pos - 1, DigitDpPrefixStatus.EqualsRight, this.updateStatus(status, i));
                    continue;
                }

                res += this.Solve(pos - 1, DigitDpPrefixStatus.LessThan, this.updateStatus(status, i));
            }

            this.dp[(pos, prefixStatus, status)] = res;
            return this.dp[(pos, prefixStatus, status)];
        }

        public int SolveWithMod(int pos, DigitDpPrefixStatus prefixStatus, TStatus status, int MOD)
        {
            if (pos == -1)
            {
                return this.endingFunc(status);
            }

            if (this.dp.TryGetValue((pos, prefixStatus, status), out int res))
            {
                return res;
            }

            res = 0;
            int max = 9;
            if (pos == this.rightDigit.Count - 1 || // Now prefixStatus == LeadingZeros
                prefixStatus == DigitDpPrefixStatus.EqualsRight)
            {
                max = this.rightDigit[pos];
            }

            for (int i = 0; i <= max; i++)
            {
                if (i == 0 &&
                    prefixStatus == DigitDpPrefixStatus.LeadingZeros)
                {
                    res += this.SolveWithMod(pos - 1, DigitDpPrefixStatus.LeadingZeros, this.updateStatus(status, i), MOD);
                    res = res % MOD;
                    continue;
                }

                if (i == this.rightDigit[pos] &&
                    (pos == this.rightDigit.Count - 1 || // Now prefixStatus == LeadingZeros, should change to EqualsRight
                    prefixStatus == DigitDpPrefixStatus.EqualsRight))
                {
                    res += this.SolveWithMod(pos - 1, DigitDpPrefixStatus.EqualsRight, this.updateStatus(status, i), MOD);
                    res = res % MOD;
                    continue;
                }

                res += this.SolveWithMod(pos - 1, DigitDpPrefixStatus.LessThan, this.updateStatus(status, i), MOD);
                res = res % MOD;
            }

            this.dp[(pos, prefixStatus, status)] = res % MOD;
            return this.dp[(pos, prefixStatus, status)];
        }
    }
}
