namespace Shared.DataStructures.Tree
{
    public class TreeFactory
    {
        public static SimpleTreeNode MakeSimpleTree(int nodeCnt, int[][] weightedEdges, int root)
        {
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
            var rootNode = new SimpleTreeNode(root);

            foreach (var edge in weightedEdges)
            {
                if (!dict.ContainsKey(edge[0]))
                {
                    dict[edge[0]] = new List<int>();
                }

                if (!dict.ContainsKey(edge[1]))
                {
                    dict[edge[1]] = new List<int>();
                }

                dict[edge[0]].Add(edge[1]);
                dict[edge[1]].Add(edge[0]);
            }

            HashSet<int> visited = new HashSet<int>();
            Queue<SimpleTreeNode> queue = new Queue<SimpleTreeNode>();

            queue.Enqueue(rootNode);

            while (queue.Count > 0)
            {
                var now = queue.Dequeue();
                visited.Add(now.Value);

                if (dict.TryGetValue(now.Value, out List<int> children))
                {
                    foreach (int child in children)
                    {
                        if (!visited.Contains(child))
                        {
                            var childNode = new SimpleTreeNode(child);
                            now.AddChild(childNode);
                            queue.Enqueue(childNode);
                        }
                    }
                }
            }

            return rootNode;
        }

        public static WeightedTreeNode MakeWeightedTree(int nodeCnt, int[][] weightedEdges)
        {
            Dictionary<int, List<(int Child, int PathWeight)>> dict = new Dictionary<int, List<(int Child, int PathWeight)>>();
            foreach (var edge in weightedEdges)
            {
                if (!dict.ContainsKey(edge[0]))
                {
                    dict[edge[0]] = new List<(int Child, int PathWeight)>();
                }

                if (!dict.ContainsKey(edge[1]))
                {
                    dict[edge[1]] = new List<(int Child, int PathWeight)>();
                }

                dict[edge[0]].Add((edge[1], edge[2]));
                dict[edge[1]].Add((edge[0], edge[2]));
            }

            bool[] visited = new bool[nodeCnt];
            WeightedTreeNode[] nodes = new WeightedTreeNode[nodeCnt];
            for (int i = 0; i < nodeCnt; i++)
            {
                visited[i] = false;
                nodes[i] = new WeightedTreeNode(i);
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);

            while (queue.Count > 0)
            {
                var parent = nodes[queue.Dequeue()];
                visited[parent.Value] = true;

                foreach (var edge in dict[parent.Value])
                {
                    if (!visited[edge.Child])
                    {
                        parent.AddChild(nodes[edge.Child], edge.PathWeight);
                        queue.Enqueue(edge.Child);
                    }
                }
            }

            return nodes[0];
        }
    }
}
