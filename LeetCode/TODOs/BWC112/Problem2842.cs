namespace LeetCode.TODOs.BWC112
{
    using Shared;
    using Shared.Utils;

    internal class Problem2842
    {
        public class Solution
        {
            public int CountKSubsequencesWithMaxBeauty(string s, int k)
            {
                if (k > 26)
                {
                    return 0;
                }

                var cc = ListUtils.MakeList(26, 0);
                foreach (char c in s)
                {
                    cc[c - 'a']++;
                }

                // Sort to select chars with maximum f(c)
                cc.Sort((n1, n2) => n2 - n1);

                // Consider k = 2, f(c) = 5, 4, 4, 4, 3..., then we have to choose 1 char from 3 chars with f(c) == 4
                //
                // The minimal f(c) is cc[k - 1]
                // We have ct chars whose f(c) == cc[k - 1] and we need to choose cr from it.
                int ct = 0, cr = 0;
                for (int i = 0; i < 26; ++i)
                {
                    if (cc[i] == cc[k - 1])
                    {
                        ct++;
                        if (i < k)
                        {
                            cr++;
                        }
                    }
                }

                long ans = MathUtils.Combination(ct, cr);
                ans %= Constants.MOD;

                // We have choosen the chars, count the way to get sub-array 
                for (int i = 0; i < k; i++)
                {
                    ans *= cc[i];
                    ans %= Constants.MOD;
                }

                return (int)ans;
            }
        }
    }
}
