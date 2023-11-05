namespace LeetCode.TODOs.RamdomPick
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Problem0721
    {
        public class Solution
        {
            public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
            {
                List<int> parent = new List<int>();
                for (int i = 0; i < accounts.Count; ++i)
                {
                    parent.Add(i);
                }

                Dictionary<string, int> dict = new Dictionary<string, int>();
                for (int i = 0; i < accounts.Count; ++i)
                {
                    IList<string> user = accounts[i];
                    for (int j = 1; j < user.Count; ++j)
                    {
                        string email = user[j];
                        if (dict.ContainsKey(email))
                        {
                            // i and dict[email] should be the same group
                            int root = FindRoot(parent, dict[email]);
                            parent[root] = i;
                        }
                        else
                        {
                            // Occur the first occurance of the email address
                            dict[email] = i;
                        }
                    }
                }

                Dictionary<int, KeyValuePair<string, HashSet<string>>> result = new Dictionary<int, KeyValuePair<string, HashSet<string>>>();
                for (int i = 0; i < accounts.Count; ++i)
                {
                    int root = FindRoot(parent, i);
                    if (!result.ContainsKey(root))
                    {
                        result[root] = new KeyValuePair<string, HashSet<string>>(accounts[root][0], new HashSet<string>());
                    }

                    for (int j = 1; j < accounts[i].Count; ++j)
                    {
                        result[root].Value.Add(accounts[i][j]);
                    }
                }

                return SortResult(result.Values);
            }

            private int FindRoot(List<int> parent, int index)
            {
                int root = index;
                while (parent[root] != root)
                {
                    root = parent[root];
                }

                while (parent[index] != root)
                {
                    int next = parent[index];
                    parent[index] = root;
                    index = next;
                }

                return root;
            }

            private List<IList<string>> SortResult(IEnumerable<KeyValuePair<string, HashSet<string>>> merged)
            {
                List<IList<string>> result = new List<IList<string>>();
                foreach (KeyValuePair<string, HashSet<string>> keyValuePair in merged)
                {
                    List<string> user = new List<string>();
                    user.Add(keyValuePair.Key);
                    List<string> emails = keyValuePair.Value.ToList();
                    emails.Sort(StringComparer.Ordinal);
                    user.AddRange(emails);
                    result.Add(user);
                }

                return result;
            }
        }
    }
}
