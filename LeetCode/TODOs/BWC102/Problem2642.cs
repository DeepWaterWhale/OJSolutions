// --------------------------------------------------------------------------------------------------
//  author:       big_chicken
//  problem_link: https://leetcode.com/contest/biweekly-contest-102/problems/design-graph-with-shortest-path-calculator/
//  note_link:    
//  tags:         Floyd–Warshall algorithm
// --------------------------------------------------------------------------------------------------

namespace LeetCode.TODOs.BWC102
{
    using System;
    using System.Collections.Generic;

    internal class Problem2642
    {
        public class Graph
        {
            private readonly int nodeCount;
            private readonly Dictionary<(int, int), int> edges = new Dictionary<(int, int), int>();
            private int[,] shortest;

            public Graph(int n, int[][] edges)
            {
                this.nodeCount = n;
                foreach (int[] edge in edges)
                {
                    this.AddEdge(edge);
                }
            }

            public void AddEdge(int[] edge)
            {
                this.edges[(edge[0], edge[1])] = edge[2];
                if (this.shortest != null)
                {
                    for (int i = 0; i < this.nodeCount; ++i)
                    {
                        for (int j = 0; j < this.nodeCount; ++j)
                        {
                            if (this.shortest[i, edge[0]] != int.MaxValue && this.shortest[edge[1], j] != int.MaxValue)
                            {
                                this.shortest[i, j] = Math.Min(this.shortest[i, j],
                                    this.shortest[i, edge[0]] + edge[2] + this.shortest[edge[1], j]);
                            }
                        }
                    }
                }
            }

            public int ShortestPath(int node1, int node2)
            {
                if (this.shortest == null)
                {
                    this.Initialize();
                }

                if (this.shortest[node1, node2] == int.MaxValue)
                {
                    return -1;
                }

                return this.shortest[node1, node2];
            }

            private void Initialize()
            {
                this.shortest = new int[this.nodeCount, this.nodeCount];
                for (int i = 0; i < this.nodeCount; ++i)
                {
                    for (int j = 0; j < this.nodeCount; ++j)
                    {
                        this.shortest[i, j] = int.MaxValue;
                    }

                    this.shortest[i, i] = 0;
                }

                foreach (var edge in this.edges)
                {
                    this.shortest[edge.Key.Item1, edge.Key.Item2] = edge.Value;
                }

                // Floyd–Warshall algorithm
                for (int k = 0; k < this.nodeCount; ++k)
                {
                    for (int i = 0; i < this.nodeCount; ++i)
                    {
                        for (int j = 0; j < this.nodeCount; ++j)
                        {
                            if (this.shortest[i, k] != int.MaxValue && this.shortest[k, j] != int.MaxValue)
                            {
                                this.shortest[i, j] = Math.Min(this.shortest[i, j],
                                    this.shortest[i, k] + this.shortest[k, j]);
                            }
                        }
                    }
                }
            }
        }
    }
}
