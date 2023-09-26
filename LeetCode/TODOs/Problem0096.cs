namespace LeetCode.TODOs
{
    using System.Collections.Generic;
    internal class Problem0096
    {
        public class Solution
        {
            private static readonly List<int> numTrees;

            static Solution()
            {
                numTrees = new List<int>() { 0, 1 };

                for (int i = 2; i <= 19; ++i)
                {
                    int ans = 0;

                    // i is the total node count of the tree
                    // j is the node count of left subtree of the root node
                    for (int j = 0; j < i; ++j)
                    {
                        if (j == 0 || j == i - 1)
                        {
                            ans += numTrees[i - 1];
                        }
                        else
                        {
                            ans += numTrees[j] * numTrees[i - j - 1];
                        }
                    }

                    numTrees.Add(ans);
                }
            }

            public int NumTrees(int n)
            {
                return numTrees[n];
            }
        }
    }
}
