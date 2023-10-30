namespace LeetCode.WeeklyContest.Weekly369
{
    using Shared.DataStructures.Tree;

    internal class Problem2920
    {
        public class Solution
        {
            private int[] pows;

            // dp[(op2Cnt, node)]
            private Dictionary<(int, ITreeNode), int> dp;
            public int MaximumPoints(int[][] edges, int[] coins, int k)
            {
                pows = new int[17];
                int num = 1;
                for (int i = 0; i < 17; ++i)
                {
                    pows[i] = num;
                    num *= 2;
                }

                var root = TreeFactory.MakeSimpleTree(coins.Length, edges, 0);
                dp = new Dictionary<(int, ITreeNode), int>();
                return Solve(0, root, coins, k);
            }

            private int Solve(int op2Cnt, ITreeNode node, int[] coins, int k)
            {
                if (op2Cnt > 15)
                {
                    return 0;
                }

                if (dp.ContainsKey((op2Cnt, node)))
                {
                    return dp[(op2Cnt, node)];
                }

                // op1 ans
                var op1 = coins[node.Value] / pows[op2Cnt] - k;
                foreach (var child in node.GetChildren())
                {
                    op1 += Solve(op2Cnt, child, coins, k);
                }

                // op2 ans
                var op2 = coins[node.Value] / pows[op2Cnt + 1];
                foreach (var child in node.GetChildren())
                {
                    op2 += Solve(op2Cnt + 1, child, coins, k);
                }

                dp[(op2Cnt, node)] = Math.Max(op1, op2);
                return dp[(op2Cnt, node)];
            }
        }
    }
}
