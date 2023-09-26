namespace LeetCode.TODOs.WC361
{
    internal class Problem2844
    {
        public class Solution
        {
            public int MinimumOperations(string num)
            {
                // it's special as long as it ends with 00 / 25 / 50 / 75
                bool findLastDigit = false;
                bool succeed = false;

                // if it is ends with zero
                int min0 = 0;
                for (int i = num.Length - 1; i >= 0; i--)
                {
                    if (!findLastDigit && num[i] == '0')
                    {
                        findLastDigit = true;
                        succeed = true; // Once we find 0, we can other digits to make it special
                    }
                    else if (findLastDigit && (num[i] == '0' || num[i] == '5'))
                    {
                        break;
                    }
                    else
                    {
                        min0++;
                    }
                }

                if (!succeed)
                {
                    min0 = num.Length;
                }

                int min5 = 0;
                findLastDigit = false;
                succeed = false;
                for (int i = num.Length - 1; i >= 0; i--)
                {
                    if (!findLastDigit && num[i] == '5')
                    {
                        findLastDigit = true;
                    }
                    else if (findLastDigit && (num[i] == '2' || num[i] == '7'))
                    {
                        succeed = true;
                        break;
                    }
                    else
                    {
                        min5++;
                    }
                }

                if (!succeed)
                {
                    min5 = num.Length;
                }

                return Math.Min(min0, min5);
            }
        }
    }
}
