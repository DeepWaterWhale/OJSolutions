namespace LeetCode.WeeklyContest.Weekly367
{
    using Shared.DataStructures.SegmentTree;

    internal class Problem2906
    {
        public class Solution
        {
            public int[][] ConstructProductMatrix(int[][] grid)
            {
                int height = grid.Length;
                int width = grid[0].Length;
                var flat = new List<int>(height * width);
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        flat.Add(grid[i][j] % 12345);
                    }
                }

                var st = new ReadOnlySegmentTree<int, int>(
                    elements: flat,
                    calFunc: num => num,
                    mergeFunc: (a, b) => a * b % 12345);

                int index = 0;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (index == 0)
                        {
                            grid[i][j] = st.Query(index + 1, flat.Count - 1);
                        }
                        else if (index == flat.Count - 1)
                        {
                            grid[i][j] = st.Query(0, index - 1);
                        }
                        else
                        {
                            grid[i][j] = st.Query(0, index - 1) * st.Query(index + 1, flat.Count - 1) % 12345;
                        }

                        index++;
                    }
                }

                return grid;
            }
        }
    }
}
