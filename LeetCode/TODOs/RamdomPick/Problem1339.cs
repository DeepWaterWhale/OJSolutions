namespace LeetCode.TODOs.RamdomPick
{
    using System;

    internal class Problem1339
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        public class Solution
        {
            public int MaxProduct(TreeNode root)
            {
                long sum = CalculateSum(root);
                long ans = MaxProduct(root, sum);
                return (int)(ans % 1000000007);
            }

            private int CalculateSum(TreeNode root)
            {
                if (root == null)
                {
                    return 0;
                }

                int left = CalculateSum(root.left);
                int right = CalculateSum(root.right);
                root.val += left + right;
                return root.val;
            }

            private long MaxProduct(TreeNode root, long sum)
            {
                if (root == null)
                {
                    return 0;
                }

                long ans = 0;
                ans = Math.Max(root.val * (sum - root.val), ans);
                ans = Math.Max(MaxProduct(root.left, sum), ans);
                ans = Math.Max(MaxProduct(root.right, sum), ans);
                return ans;
            }
        }
    }
}
