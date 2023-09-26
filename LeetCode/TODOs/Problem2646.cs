namespace LeetCode.TODOs
{
    internal class Problem2646
    {
        public class Solution
        {
            private readonly Dictionary<int, (int Selected, int NotSelected)> dp = new Dictionary<int, (int, int)>();

            public int MinimumTotalPrice(int n, int[][] edges, int[] price, int[][] trips)
            {
                int[] nc = new int[n]; // count of each node being visited in all trips
                List<int>[] connected = new List<int>[n];
                for (int i = 0; i < n; i++)
                {
                    connected[i] = new List<int>();
                    nc[i] = 0;
                }

                foreach (var edge in edges)
                {
                    connected[edge[0]].Add(edge[1]);
                    connected[edge[1]].Add(edge[0]);
                }

                foreach (var trip in trips)
                {
                    this.CountNodeInPath(n, connected, trip[0], trip[1], nc);
                }

                bool[] visited = new bool[n];
                for (int i = 0; i < n; i++) { visited[i] = false; }
                this.Solve(n, connected, price, 0, nc, visited);

                int ans = 0;
                for (int i = 0; i < n; ++i)
                {
                    ans += nc[i] * price[i];
                    Console.WriteLine(nc[i]);
                }

                return ans - Math.Max(this.dp[0].Selected, this.dp[0].NotSelected);
            }

            private void Solve(int n, List<int>[] connnected, int[] price, int node, int[] nc, bool[] visited)
            {
                visited[node] = true;
                int selected = nc[node] * price[node] / 2, notSelected = 0;
                foreach (var next in connnected[node])
                {
                    if (visited[next])
                    {
                        continue;
                    }

                    this.Solve(n, connnected, price, next, nc, visited);

                    selected += this.dp[next].NotSelected;
                    notSelected += Math.Max(this.dp[next].Selected, this.dp[next].NotSelected);
                }

                this.dp[node] = (selected, notSelected);
            }

            private void CountNodeInPath(int n, List<int>[] connnected, int start, int end, int[] nc)
            {
                bool[] visited = new bool[n];
                for (int i = 0; i < n; i++) { visited[i] = false; }
                this.CountPath(connnected, start, end, nc, visited);
                nc[start]++;
            }

            private bool CountPath(List<int>[] connnected, int start, int end, int[] nc, bool[] visited)
            {
                visited[start] = true;
                if (start == end)
                {
                    return true;
                }

                foreach (var next in connnected[start])
                {
                    if (visited[next])
                    {
                        continue;
                    }

                    if (this.CountPath(connnected, next, end, nc, visited))
                    {
                        nc[next]++;
                        return true;
                    }
                }

                return false;
            }
        }
    }
}