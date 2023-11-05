namespace LeetCode.TODOs.RamdomPick
{
    internal class Problem2306
    {
        public class Solution
        {
            private const string alphabet = "abcdefghijklmnopqrstuvwxyz";
            public long DistinctNames(string[] ideas)
            {
                // count[i, j] means the number of ideas which:
                //     1. start with (char)('a' + i), assume the left part is 'left'
                //     2. (char)('a' + j) + 'left' doesn't exist in ideas
                int[,] count = new int[26, 26];

                HashSet<string> hs = new HashSet<string>(ideas);
                foreach (string idea in ideas)
                {
                    UpdateCount(count, idea, hs);
                }

                long res = 0;
                for (int i = 0; i < 26; ++i)
                {
                    for (int j = 0; j < 26; ++j)
                    {
                        res += count[i, j] * count[j, i];
                    }
                }

                return res;
            }

            private void UpdateCount(int[,] count, string name, HashSet<string> hs)
            {
                string sub = name.Substring(1);
                foreach (char c in alphabet)
                {
                    if (!hs.Contains(c + sub))
                    {
                        count[name[0] - 'a', c - 'a']++;
                    }
                }
            }
        }
    }
}
