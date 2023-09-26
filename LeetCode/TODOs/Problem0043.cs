namespace LeetCode.TODOs
{
    using System.Collections.Generic;
    using System.Linq;

    internal class Solution
    {
        public string Multiply(string num1, string num2)
        {
            if (num1 == "0" || num2 == "0")
            {
                return "0";
            }

            List<char> a = num1.Reverse().ToList();
            List<char> b = num2.Reverse().ToList();
            int[] res = new int[num1.Length + num2.Length];
            for (int i = 0; i < res.Length; ++i)
            {
                res[i] = 0;
            }

            for (int i = 0; i < a.Count(); ++i)
            {
                for (int j = 0; j < b.Count(); ++j)
                {
                    int k = i + j;
                    res[k] += this.ConvertChar(a[i]) * this.ConvertChar(b[j]);
                    res[k + 1] += res[k] / 10;
                    res[k] %= 10;
                }
            }

            string str = string.Join("", res.Reverse());
            return str.TrimStart('0');
        }

        private int ConvertChar(char c)
        {
            return c - '0';
        }
    }
}