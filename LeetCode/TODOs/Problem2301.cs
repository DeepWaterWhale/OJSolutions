namespace OjProblems.LeetCode
{
    internal class Problem2301
    {
        public class Solution
        {
            public bool MatchReplacement(string s, string sub, char[][] mappings)
            {
                Dictionary<char, HashSet<char>> dict = new Dictionary<char, HashSet<char>>();
                foreach (char[] mapping in mappings)
                {
                    if (!dict.ContainsKey(mapping[0]))
                    {
                        dict[mapping[0]] = new HashSet<char>();
                    }

                    dict[mapping[0]].Add(mapping[1]);
                }

                int length = sub.Length;
                for (int i = 0; i <= s.Length - length; ++i)
                {
                    if (this.IsMatch(s.Substring(i, length), sub, dict))
                    {
                        return true;
                    }
                }

                return false;
            }

            // If this get timeout error, can modify KMP to speed up
            public bool IsMatch(string a, string b, Dictionary<char, HashSet<char>> dict)
            {
                for (int i = 0; i < a.Length; ++i)
                {
                    if (a[i] == b[i] || (dict.ContainsKey(b[i]) && dict[b[i]].Contains(a[i])))
                    {
                        continue;
                    }

                    return false;
                }

                return true;
            }
        }
    }
}
