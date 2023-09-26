namespace LeetCode.WeeklyContest.WC346
{
    internal class Problem2699
    {
        public class Solution
        {
            private const long Unreachable = int.MaxValue;
            public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target)
            {
                var dist = this.ConvertToAdjacentMatrix(edges, n);
                (int Prev, long MinPossible)[] values = new (int Prev, long MinPossible)[n];

                for (int i = 0; i < n; ++i)
                {
                    if (dist[source, i] == -1)
                    {
                        values[i] = (source, 1);
                    }
                    else
                    {
                        values[i] = (source, dist[source, i]);
                    }
                }

                return null;
            }

            private long[, ] ConvertToAdjacentMatrix(int[][] edges, int n)
            {
                long[,] dist = new long[n, n];
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        dist[i, j] = Unreachable;
                    }

                    dist[i, i] = 0;
                }

                foreach (var edge in edges)
                {
                    dist[edge[0], edge[1]] = edge[2];
                    dist[edge[1], edge[0]] = edge[2];
                }

                return dist;
            }
        }
    }
}
