namespace LeetCode.TODOs.RamdomPick
{
    internal class Problem2645
    {
        public class Solution
        {
            public int AddMinimum(string word)
            {
                int ans = 0, i = 0;
                while (i < word.Length)
                {
                    if (word[i] == 'a')
                    {
                        if (i + 1 < word.Length && word[i + 1] == 'b')
                        {
                            if (i + 2 < word.Length && word[i + 2] == 'c')
                            {
                                i += 3;
                            }
                            else
                            {
                                ans++;
                                i += 2;
                            }
                        }
                        else if (i + 1 < word.Length && word[i + 1] == 'c')
                        {
                            ans++;
                            i += 2;
                        }
                        else
                        {
                            ans += 2;
                            i++;
                        }
                    }
                    else if (word[i] == 'b')
                    {
                        if (i + 1 < word.Length && word[i + 1] == 'c')
                        {
                            ans++;
                            i += 2;
                        }
                        else
                        {
                            ans += 2;
                            i++;
                        }
                    }
                    else
                    {
                        ans += 2;
                        i++;
                    }
                }

                return ans;
            }
        }
    }
}
