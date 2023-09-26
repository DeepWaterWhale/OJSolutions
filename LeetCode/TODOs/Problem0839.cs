namespace LeetCode.TODOs
{
    using System.Collections.Generic;

    internal class Problem0839
    {
        public class Solution
        {
            public int NumSimilarGroups(string[] strs)
            {
                bool[] visited = new bool[strs.Length];
                bool[,] isSimiliar = new bool[strs.Length, strs.Length];

                for (int i = 0; i < strs.Length; ++i)
                {
                    visited[i] = false;
                    for (int j = i; j < strs.Length; ++j)
                    {
                        isSimiliar[i, j] = this.IsSimilar(strs[i], strs[j]);
                        isSimiliar[j, i] = isSimiliar[i, j];
                    }
                }

                int ans = 0;
                int index = 0;
                while (index < strs.Length)
                {
                    if (!visited[index])
                    {
                        ans++;
                        this.BFS(visited, isSimiliar, index);
                    }

                    index++;
                }

                return ans;
            }

            private bool IsSimilar(string a, string b)
            {
                int ans = 0;
                for (int i = 0; i < a.Length; ++i)
                {
                    if (a[i] != b[i])
                    {
                        ans++;
                    }

                    if (ans > 2)
                    {
                        return false;
                    }
                }

                return ans != 1;
            }

            private void BFS(bool[] visited, bool[,] isSimiliar, int index)
            {
                Queue<int> q = new Queue<int>();
                q.Enqueue(index);
                visited[index] = true;

                while (q.Count > 0)
                {
                    int now = q.Dequeue();
                    for (int i = 0; i < visited.Length; ++i)
                    {
                        if (!visited[i] && isSimiliar[now, i])
                        {
                            q.Enqueue(i);
                            visited[i] = true;
                        }
                    }
                }
            }
        }
    }
}
