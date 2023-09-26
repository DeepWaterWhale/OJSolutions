namespace LeetCode.TODOs.WC346
{
    internal class Problem2697
    {
        public class Solution
        {
            public string MakeSmallestPalindrome(string s)
            {
                char[] chars = s.ToCharArray();
                int begin = 0, end = s.Length - 1;
                while (begin < end)
                {
                    if (chars[begin] != chars[end])
                    {
                        if (chars[begin] < chars[end])
                        {
                            chars[end] = chars[begin];
                        }
                        else
                        {
                            chars[begin] = chars[end];
                        }
                    }

                    begin++;
                    end--;
                }

                return new string(chars);
            }
        }
    }
}
