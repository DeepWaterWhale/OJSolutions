namespace LeetCode.TODOs.RamdomPick
{
    using System;
    internal class Problem1373
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
            private int maxSumBst = 0;

            public int MaxSumBST(TreeNode root)
            {
                CalculateTreeNodeInfo(root);
                return maxSumBst;
            }

            public TreeNodeInfo CalculateTreeNodeInfo(TreeNode node)
            {
                if (node == null)
                {
                    return null;
                }

                TreeNodeInfo left = CalculateTreeNodeInfo(node.left);
                TreeNodeInfo right = CalculateTreeNodeInfo(node.right);

                TreeNodeInfo result = new TreeNodeInfo()
                {
                    IsBinarySearchTree = (left == null || left.IsBinarySearchTree && left.Max < node.val) &&
                                         (right == null || right.IsBinarySearchTree && node.val < right.Min),
                    Min = left?.Min ?? node.val,
                    Max = right?.Max ?? node.val,
                    Sum = (left?.Sum ?? 0) + (right?.Sum ?? 0) + node.val
                };

                if (result.IsBinarySearchTree)
                {
                    maxSumBst = Math.Max(maxSumBst, result.Sum);
                }

                return result;
            }
        }

        public class TreeNodeInfo
        {
            public bool IsBinarySearchTree;
            public int Min;
            public int Max;
            public int Sum;
        }
    }
}
