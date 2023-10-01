namespace Shared.DataStructures.Tree
{
    using Shared.DataStructures.Graph;
    using Shared.DataStructures.Graph.Extensions;

    public class TreeFactory
    {
        public static SimpleTreeNode MakeSimpleTree(int nodeCnt, int[][] edges, int root)
        {
            return MakeSimpleTree(nodeCnt, edges, root, out _);
        }

        public static SimpleTreeNode MakeSimpleTree(int nodeCnt, int[][] edges, int root, out Dictionary<int, SimpleTreeNode> nodes)
        {
            var adjLists = new AdjacentLists(edges);
            Dictionary<int, SimpleTreeNode> tmp = new Dictionary<int, SimpleTreeNode>();
            adjLists.DfsTraverse(
                start: root,
                whenFirstVisit: (previous, now) =>
                {
                    tmp[now] = new SimpleTreeNode(now);
                },
                whenBackFromNext: (now, next) =>
                {
                    tmp[now].AddChild(tmp[next]);
                });

            nodes = tmp;
            return tmp[root];
        }

        public static WeightedTreeNode MakeWeightedTree(int nodeCnt, int[][] weightedEdges, int root)
        {
            var wadj = new WeightedAdjacentLists(weightedEdges);
            Dictionary<int, WeightedTreeNode> nodes = new Dictionary<int, WeightedTreeNode>();
            wadj.DfsTraverse(
                start: root,
                whenFirstVisit: (previous, now) =>
                {
                    nodes[now] = new WeightedTreeNode(now);
                },
                whenBackFromNext: (now, next) =>
                {
                    var weight = wadj.GetWeight(now, next);
                    nodes[now].AddChild(nodes[next], weight);
                });

            return nodes[root];
        }
    }
}
