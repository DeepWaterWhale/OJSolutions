namespace LeetCode.TODOs.WC361
{
    using Shared.Algorithms;
    using Shared.DataStructures.Tree;
    using Shared.DataStructures.Tree.Extensions;

    internal class Problem2846
    {
        public class Solution
        {
            public int[] MinOperationsQueries(int n, int[][] edges, int[][] queries)
            {
                var root = TreeFactory.MakeWeightedTree(n, edges, 0);
                var lca = new LcaAlgorithm(root);

                Dictionary<int, int[]> subtreeEdgeCnt = new Dictionary<int, int[]>();
                root.DfsTraverse(
                    whenVisitFromParent: (parent, node) =>
                    {
                        subtreeEdgeCnt[node.Value] = new int[27];
                        for (int i = 0; i < 27; ++i)
                        {
                            subtreeEdgeCnt[node.Value][i] = 0;
                        }
                    },
                    whenVisitFromChild: (node, child) =>
                    {
                        for (int i = 0; i < 27; ++i)
                        {
                            subtreeEdgeCnt[node.Value][i] += subtreeEdgeCnt[child.Value][i];
                        }

                        var wnode = child as WeightedTreeNode;
                        subtreeEdgeCnt[node.Value][wnode.Weight]++;
                    });

                List<int> ans = new List<int>();
                foreach (var query in queries)
                {
                    int ancester = lca.GetLca(query[0], query[1]);
                    int[] pathes = new int[27];
                    for (int i = 0; i < 27; ++i)
                    {
                        pathes[i] = subtreeEdgeCnt[ancester][i] - subtreeEdgeCnt[query[0]][i] - subtreeEdgeCnt[query[1]][i];
                    }

                    int total = pathes.Sum();
                    int max = pathes.Max();
                    ans.Add(total - max);
                }

                return ans.ToArray();
            }
        }
    }
}
