namespace LeetCode.ByweeklyContest.Biweekly114
{
    using Shared.DataStructures.Tree;
    using Shared.DataStructures.Tree.Extensions;

    internal class Problem2872
    {
        public class Solution
        {
            public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k)
            {
                var root = TreeFactory.MakeSimpleTree(n, edges, 0, out Dictionary<int, SimpleTreeNode> nodes);
                for (int i = 0; i < n; ++i)
                {
                    nodes[i].Value = values[i];
                }

                int ans = 1;
                root.DfsTraverse(
                    whenVisitFromParent: (parent, now) =>
                    {
                    },
                    whenVisitFromChild: (now, child) =>
                    {
                        if (child.Value % k == 0)
                        {
                            // Cut now->child to make component cnt++
                            // Console.WriteLine($"Cut {now.Value}->{child.Value}");
                            ans++;
                        }
                        else
                        {
                            now.Value += child.Value;
                        }
                    });

                return ans;
            }
        }
    }
}
