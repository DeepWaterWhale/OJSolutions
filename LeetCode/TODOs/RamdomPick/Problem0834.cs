namespace LeetCode.TODOs.RamdomPick
{
    internal class Problem0834
    {
        public class Solution
        {
            private int totalNodeCount;
            private List<int>[] tree;
            private int[] subTreeNodeCount;
            private int[] result;

            public int[] SumOfDistancesInTree(int n, int[][] edges)
            {
                Initialize(n, edges);
                Visit(0, -1);
                Calculate(0, -1);

                return result;
            }

            private void Initialize(int n, int[][] edges)
            {
                totalNodeCount = n;
                tree = new List<int>[n];
                result = new int[n];
                subTreeNodeCount = new int[n];
                for (int i = 0; i < n; ++i)
                {
                    tree[i] = new List<int>();
                    subTreeNodeCount[i] = 1;
                    result[i] = 0;
                }

                foreach (int[] edge in edges)
                {
                    tree[edge[0]].Add(edge[1]);
                    tree[edge[1]].Add(edge[0]);
                }
            }

            private void Visit(int index, int parent)
            {
                result[index] = 0;
                subTreeNodeCount[index] = 1;

                // Visit children and update data
                foreach (var next in tree[index])
                {
                    if (next != parent)
                    {
                        // next is a child of index
                        Visit(next, index);

                        // Update current node data
                        subTreeNodeCount[index] += subTreeNodeCount[next];
                        result[index] += result[next] + subTreeNodeCount[next];
                    }
                }
            }

            private void Calculate(int index, int parent)
            {
                if (index != 0)
                {
                    result[index] = result[parent] + totalNodeCount - subTreeNodeCount[index] - subTreeNodeCount[index];
                }

                // Visit children and update data
                foreach (var next in tree[index])
                {
                    if (next != parent)
                    {
                        Calculate(next, index);
                    }
                }
            }
        }
    }
}
