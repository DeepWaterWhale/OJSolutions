namespace LeetCode.WeeklyContest.Weekly323
{
    using Shared.Utils;

    internal class Problem2503
    {
        public class Solution
        {
            private readonly SortedDictionary<int, List<(int i, int j)>> sd = new SortedDictionary<int, List<(int i, int j)>>();
            private readonly List<(int Query, int Points)> res = new List<(int Query, int Points)>();
            private bool[,] visited;
            private int points = 0;
            private int height;
            private int width;

            public int[] MaxPoints(int[][] grid, int[] queries)
            {
                height = grid.Length;
                width = grid[0].Length;
                visited = ArrayUtils.Make2DArray(height, width, false);
                sd.Add(grid[0][0], new List<(int i, int j)>() { (0, 0) });

                // res[i] = (Query, Point) when query = Query + 1 the point you can get.
                res.Add((0, 0));
                Solve(grid);
                res.Add((1000005, height * width));

                int[] ans = new int[queries.Length];
                for (int i = 0; i < queries.Length; i++)
                {
                    int query = queries[i];
                    int left = 0, right = res.Count - 1;
                    while (left < right)
                    {
                        int middle = (left + right) / 2;
                        if (res[middle].Query >= query)
                        {
                            right = middle;
                        }
                        else
                        {
                            left = middle + 1;
                        }
                    }

                    ans[i] = res[left - 1].Points;
                }

                return ans;
            }

            private void Solve(int[][] grid)
            {
                while (sd.Count > 0)
                {
                    var kv = sd.First();
                    int query = kv.Key;
                    var nodes = kv.Value;

                    foreach (var node in nodes)
                    {
                        DfsVisit(grid, query, node.i, node.j);
                    }

                    res.Add((query, points));
                    sd.Remove(query);
                }
            }

            private void DfsVisit(int[][] grid, int query, int i, int j)
            {
                if (visited[i, j])
                {
                    return;
                }

                if (query < grid[i][j])
                {
                    if (!sd.ContainsKey(grid[i][j]))
                    {
                        sd[grid[i][j]] = new List<(int i, int j)>();
                    }

                    sd[grid[i][j]].Add((i, j));
                    return;
                }

                visited[i, j] = true;
                points++;
                if (i > 0)
                {
                    DfsVisit(grid, query, i - 1, j);
                }

                if (i < height - 1)
                {
                    DfsVisit(grid, query, i + 1, j);
                }

                if (j > 0)
                {
                    DfsVisit(grid, query, i, j - 1);
                }

                if (j < width - 1)
                {
                    DfsVisit(grid, query, i, j + 1);
                }
            }
        }
    }
}

