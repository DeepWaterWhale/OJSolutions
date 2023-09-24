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

        public DigitDp(int right, Func<TStatus, int, TStatus> statusUpdateFunc, Func<TStatus, int> endingFunc)
        {
            this.rightDigit = right.ToString().Reverse().Select(ch => (int)(ch - '0')).ToList();
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
            if (pos == this.rightDigit.Count - 1 || // Now prefixStatus == DigitDpPrefixStatus.LeadingZeros
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
                    (prefixStatus == DigitDpPrefixStatus.EqualsRight || pos == this.rightDigit.Count - 1))
                {
                    res += this.Solve(pos - 1, DigitDpPrefixStatus.EqualsRight, this.updateStatus(status, i));
                    continue;
                }

                res += this.Solve(pos - 1, DigitDpPrefixStatus.LessThan, this.updateStatus(status, i));
            }

            this.dp[(pos, prefixStatus, status)] = res;
            return res;
        }
    }
}
