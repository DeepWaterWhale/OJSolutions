namespace LeetCode.WeeklyContest.WC345
{
    using System.Collections.Generic;

    internal class Problem2685
    {
        public class Solution
        {
            public int CountCompleteComponents(int n, int[][] edges)
            {
                HashSet<int>[] unions = new HashSet<int>[n];
                HashSet<int>[] directConnected = new HashSet<int>[n];
                bool[] visited = new bool[n];

                for (int i = 0; i < n; i++)
                {
                    unions[i] = new HashSet<int>() { i };
                    directConnected[i] = new HashSet<int>();
                    visited[i] = false;
                }

                foreach (int[] edge in edges)
                {
                    unions[edge[0]].UnionWith(unions[edge[1]]);
                    foreach (int num in unions[edge[0]])
                    {
                        unions[num] = unions[edge[0]];
                    }

                    directConnected[edge[0]].Add(edge[1]);
                    directConnected[edge[1]].Add(edge[0]);
                }

                int ans = 0;
                for (int i = 0; i < n; ++i)
                {
                    bool flag = true;
                    foreach (int num in unions[i])
                    {
                        if (visited[num])
                        {
                            // This union is visited
                            flag = false;
                            break;
                        }

                        visited[num] = true;
                        if (directConnected[num].Count != unions[i].Count - 1)
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        ans++;
                    }
                }

                return ans;
            }
        }
    }
}
