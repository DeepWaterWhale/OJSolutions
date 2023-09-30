namespace Shared.Algorithms
{
    using Shared.DataStructures.SegmentTree;
    using Shared.DataStructures.Tree;
    using Shared.DataStructures.Tree.Extensions;

    /// <summary>
    /// Lowest Common Ancestor algorithm
    /// </summary>
    public class LcaAlgorithm
    {
        /// <summary>
        /// Traverse order of all nodes by DFS
        /// </summary>
        private readonly List<int> euler = new List<int>();

        /// <summary>
        /// The index of first visit of each node in dfs traverse 
        /// </summary>
        private readonly Dictionary<int, int> first = new Dictionary<int, int>();

        /// <summary>
        /// The depth of each node
        /// </summary>
        private readonly Dictionary<int, int> depth = new Dictionary<int, int>();

        /// <summary>
        /// The segment tree of the lca algorithm
        /// </summary>
        private readonly ReadOnlySegmentTree<(int Node, int Depth), int> segmentTree;

        public LcaAlgorithm(ITreeNode root)
        {
            this.depth[root.Value] = 0;

            TreeDfsExtension.DfsTraverse(
                root: root,
                whenVisitFromParent: (parent, node) =>
                {
                    this.first[node.Value] = this.euler.Count;
                    this.euler.Add(node.Value);
                    if (parent != null)
                    {
                        this.depth[node.Value] = this.depth[parent.Value] + 1;
                    }
                },
                whenVisitFromChild: (parent, child) =>
                {
                    this.euler.Add(parent.Value);
                });

            // Use segment tree to find the node with minimal depth
            this.segmentTree = new ReadOnlySegmentTree<(int Node, int Depth), int>(
                elements: this.euler.Select(node => (Node: node, Depth: this.depth[node])).ToList(),
                calFunc: ele => ele.Node,
                mergeFunc: (node1, node2) =>
                {
                    if (this.depth[node1] < this.depth[node2])
                    {
                        return node1;
                    }

                    return node2;
                });
        }

        public int GetLca(int node1, int node2)
        {
            return this.segmentTree.Query(
                Math.Min(this.first[node1], this.first[node2]),
                Math.Max(this.first[node1], this.first[node2]));
        }
    }
}
