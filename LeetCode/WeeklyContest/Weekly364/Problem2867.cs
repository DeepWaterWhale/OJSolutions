namespace LeetCode.WeeklyContest.Weekly364
{
    using Shared.DataStructures.Tree;
    using Shared.DataStructures.Tree.Extensions;
    using Shared.Utils;

    internal class Problem2867
    {
        public class Solution
        {
            public long CountPaths(int n, int[][] edges)
            {
                var primes = MathUtils.GetAllPrimes(n + 1);
                var root = TreeFactory.MakeSimpleTree(n, edges, n);
                Dictionary<int, long> subtreeNonPrimePath = new Dictionary<int, long>();
                TreeDfsExtension.DfsTraverse(
                    root,
                    whenVisitFromParent: (parent, now) =>
                    {
                        if (primes.Contains(now.Value))
                        {
                            subtreeNonPrimePath[now.Value] = 0;
                        }
                        else
                        {
                            subtreeNonPrimePath[now.Value] = 1;
                        }
                    },
                    whenVisitFromChild: (now, child) =>
                    {
                        if (!primes.Contains(now.Value))
                        {
                            subtreeNonPrimePath[now.Value] += subtreeNonPrimePath[child.Value];
                        }
                    });

                Dictionary<int, long> parentNonPrimePath = new Dictionary<int, long>();
                long ans = 0;
                TreeDfsExtension.DfsTraverse(
                    root,
                    whenVisitFromParent: (parent, now) =>
                    {
                        if (parent != null)
                        {
                            if (primes.Contains(parent.Value))
                            {
                                parentNonPrimePath[now.Value] = 0;
                            }
                            else
                            {
                                parentNonPrimePath[now.Value] = parentNonPrimePath[parent.Value] // through parent to its parent
                                + subtreeNonPrimePath[parent.Value] // through parent to now's siblings
                                - subtreeNonPrimePath[now.Value];  // Minus the path now->parent->now
                            }
                        }
                        else
                        {
                            parentNonPrimePath[now.Value] = 0;
                        }

                        if (primes.Contains(now.Value))
                        {
                            // Count all pathes contains now as the only prime
                            long total = parentNonPrimePath[now.Value];
                            foreach (var child in now.GetChildren())
                            {
                                total += subtreeNonPrimePath[child.Value];
                            }

                            long tmp = total * total - parentNonPrimePath[now.Value] * parentNonPrimePath[now.Value];
                            foreach (var child in now.GetChildren())
                            {
                                tmp -= subtreeNonPrimePath[child.Value] * subtreeNonPrimePath[child.Value];
                            }

                            tmp /= 2; // all pathes start contains now and now it is not the ends.
                            ans += tmp + total;
                        }

                    },
                    whenVisitFromChild: null);

                return ans;
            }
        }
    }
}
