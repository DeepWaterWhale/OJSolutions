namespace LeetCode.TODOs.RamdomPick
{
    using System;
    using System.Collections.Generic;

    internal class Problem2662
    {
        public class Solution
        {
            public int MinimumCost(int[] start, int[] target, int[][] specialRoads)
            {
                Dictionary<(int X, int Y), int> dist = new Dictionary<(int X, int Y), int>();

                List<(int X, int Y)> points = new List<(int X, int Y)>();
                points.Add((start[0], start[1]));
                points.Add((target[0], target[1]));
                foreach (var road in specialRoads)
                {
                    points.Add((road[0], road[1]));
                    points.Add((road[2], road[3]));
                    int i = points.Count;
                    dist[(i - 2, i - 1)] = road[4];
                }

                int[] minimal = new int[points.Count];
                bool[] visited = new bool[points.Count];
                for (int i = 0; i < points.Count; ++i)
                {
                    minimal[i] = Math.Abs(points[i].X - points[0].X) + Math.Abs(points[i].Y - points[0].Y);
                    visited[i] = false;
                }

                while (!visited[1])
                {
                    int min_index = -1;
                    for (int i = 0; i < points.Count; ++i)
                    {
                        if (visited[i])
                        {
                            continue;
                        }

                        if (min_index == -1 || minimal[i] < minimal[min_index])
                        {
                            min_index = i;
                        }
                    }

                    visited[min_index] = true;
                    for (int i = 0; i < points.Count; ++i)
                    {
                        if (visited[i])
                        {
                            continue;
                        }

                        if (dist.ContainsKey((min_index, i)))
                        {
                            minimal[i] = Math.Min(minimal[i], minimal[min_index] + dist[(min_index, i)]);
                        }
                        else
                        {
                            minimal[i] = Math.Min(minimal[i], minimal[min_index] + Math.Abs(points[i].X - points[min_index].X) + Math.Abs(points[i].Y - points[min_index].Y));
                        }
                    }
                }

                return minimal[1];
            }
        }
    }
}
