namespace OjProblems.LeetCode
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
                this.Initialize(n, edges);
                this.Visit(0, -1);
                this.Calculate(0, -1);

                return this.result;
            }

            private void Initialize(int n, int[][] edges)
            {
                this.totalNodeCount = n;
                this.tree = new List<int>[n];
                this.result = new int[n];
                this.subTreeNodeCount = new int[n];
                for (int i = 0; i < n; ++i)
                {
                    this.tree[i] = new List<int>();
                    this.subTreeNodeCount[i] = 1;
                    this.result[i] = 0;
                }

                foreach (int[] edge in edges)
                {
                    this.tree[edge[0]].Add(edge[1]);
                    this.tree[edge[1]].Add(edge[0]);
                }
            }

            private void Visit(int index, int parent)
            {
                this.result[index] = 0;
                this.subTreeNodeCount[index] = 1;

                // Visit children and update data
                foreach (var next in this.tree[index])
                {
                    if (next != parent)
                    {
                        // next is a child of index
                        this.Visit(next, index);

                        // Update current node data
                        this.subTreeNodeCount[index] += this.subTreeNodeCount[next];
                        this.result[index] += this.result[next] + this.subTreeNodeCount[next];
                    }
                }
            }

            private void Calculate(int index, int parent)
            {
                if (index != 0)
                {
                    this.result[index] = this.result[parent] + this.totalNodeCount - this.subTreeNodeCount[index] - this.subTreeNodeCount[index];
                }

                // Visit children and update data
                foreach (var next in this.tree[index])
                {
                    if (next != parent)
                    {
                        this.Calculate(next, index);
                    }
                }
            }
        }
    }
}
