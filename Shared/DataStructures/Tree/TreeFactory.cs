namespace Shared.DataStructures.Tree
{
    public class TreeFactory
    {
        public static WeightedTreeNode MakeWeightedTree(int nodeCnt, int[][] weightedEdges)
        {
            bool[] visited = new bool[nodeCnt];
            WeightedTreeNode[] nodes = new WeightedTreeNode[nodeCnt];
            for (int i = 0; i < nodeCnt; i++)
            {
                visited[i] = false;
                nodes[i] = new WeightedTreeNode(i);
            }

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
