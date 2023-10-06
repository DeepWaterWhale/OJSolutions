namespace LeetCode.WeeklyContest.Weekly365
{
    using Shared.Utils;

    internal class Problem2876
    {
        public class Solution
        {
            public int[] CountVisitedNodes(IList<int> edges)
            {
                int[] ans = ArrayUtils.MakeArray(edges.Count, -1);
                for (int i = 0; i < edges.Count; i++)
                {
                    if (ans[i] == -1)
                    {
                        List<int> visited = new List<int>();
                        int now = i;
                        while (!visited.Contains(now) && ans[now] == -1)
                        {
                            ans[now] = 0;
                            visited.Add(now);
                            now = edges[now];
                        }

                        bool newCircle = false;
                        if (ans[now] == 0)
                        {
                            newCircle = true;

                            // Find a circle starting from now
                            // record the circle length on all nodes in the circle
                            int nowIndex = visited.IndexOf(now);
                            int circleCnt = visited.Count - nowIndex;
                            for (int j = nowIndex; j < visited.Count; ++j)
                            {
                                // all nodes in the circle, set the result
                                ans[visited[j]] = circleCnt;
                            }
                        }

                        if (ans[now] != -1)
                        {
                            // find a path to a node which already visited
                            int endIndex = newCircle ? visited.IndexOf(now) : visited.Count;
                            for (int j = 0; j < endIndex; j++)
                            {
                                ans[visited[j]] = endIndex - j + ans[now];
                            }
                        }
                    }
                }

                return ans;
            }
        }
    }
}
